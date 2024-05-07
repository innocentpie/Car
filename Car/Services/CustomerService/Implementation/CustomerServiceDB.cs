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
            _context.Entry(customer).State = EntityState.Detached;
        }

        public async Task Delete(Guid id)
        {
            await _context.Customers
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Update(Customer customer)
        {
            await _context.Customers
                .Where(x => x.Id == customer.Id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(x => x.Name, customer.Name)
                    .SetProperty(x => x.Address, customer.Address)
                    .SetProperty(x => x.Address, customer.Address)
                    .SetProperty(x => x.Email, customer.Email)
            );
        }
    }
}
