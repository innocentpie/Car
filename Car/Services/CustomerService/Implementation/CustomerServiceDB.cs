using Car.Data;
using Car.Shared;
using Microsoft.EntityFrameworkCore;

namespace Car.Services.Implementation.DB
{
    public class CustomerServiceDB : ICustomerService
    {
        private readonly WebApiDbContext _context;

        public CustomerServiceDB(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var customer = await Get(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Update(Customer newCustomer)
        {
            var customer = await Get(newCustomer.Id);

            customer.Name = newCustomer.Name;
            customer.Email = newCustomer.Email;
            customer.Address = newCustomer.Address;

            await _context.SaveChangesAsync();
        }
    }
}
