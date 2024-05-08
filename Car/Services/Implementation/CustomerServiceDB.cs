using Car.Data;
using Car.Shared;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Car.Mappers;

namespace Car.Services.Implementation.DB
{
    public class CustomerServiceDB : ICustomerService
    {
        private readonly WebApiDbContext _context;

        public CustomerServiceDB(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task Add(CustomerPropertiesDTO newCustomer)
        {
            Customer customer = newCustomer.MapToNewCustomer();
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Customer customer = await GetCustomerAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerGetUpdateDTO?> Get(Guid id)
        {
            Customer? customer = await GetCustomerAsync(id);
            CustomerGetUpdateDTO? dto = customer?.MapToCustomerGetUpdateDTO();
            return dto;
        }

        public async Task<List<CustomerGetUpdateDTO>> GetAll()
        {
            var result = await _context.Customers
                .Select(x => x.MapToCustomerGetUpdateDTO())
                .ToListAsync();
            return result;
        }

        public async Task Update(CustomerGetUpdateDTO newCustomer)
        {
            Customer? customer = await GetCustomerAsync(newCustomer.Id);
            newCustomer.MapIntoCustomer(customer);
            await _context.SaveChangesAsync();
        }


        private async Task<Customer?> GetCustomerAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}
