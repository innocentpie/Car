using Car.Data;
using Car.Shared;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Car.Mappers;

namespace Car.Services.Implementation.DB
{
    public class CustomerServiceDB : ICustomerService
    {
        private readonly ILogger<CustomerServiceDB> _logger;
        private readonly WebApiDbContext _context;

		public CustomerServiceDB(ILogger<CustomerServiceDB> logger, WebApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(CustomerPropertiesDTO newCustomer)
        {
            Customer customer = newCustomer.MapToNewCustomer();
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

			_logger.LogInformation("Customer added {@id}: {@customer}", customer.Id, newCustomer);
		}

		public async Task Delete(Guid id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

			_logger.LogInformation("Customer deleted with id: {@id}", id);
		}

		public async Task<CustomerGetDTO?> Get(Guid id, bool includeWorks = false)
        {
			IQueryable<Customer> query = _context.Customers;
			if (includeWorks)
				query = query.Include(x => x.Works);

			Customer? customer = await query.FirstOrDefaultAsync(x => x.Id == id);
            CustomerGetDTO? dto = customer?.MapToCustomerGetDTO(includeWorks);
			_logger.LogInformation("Customer retrieved: {@customer}", dto);
            return dto;
        }

        public async Task<List<CustomerGetDTO>> GetAll(bool includeWorks = false)
        {
			IQueryable<Customer> query = _context.Customers;
			if (includeWorks)
				query = query.Include(x => x.Works);

			var result = await query
                .Select(x => x.MapToCustomerGetDTO(includeWorks))
                .ToListAsync();

			_logger.LogInformation($"All {result.Count} customers retrieved");
            return result;
		}

        public async Task Update(CustomerDTO newCustomer)
        {
            Customer? customer = await _context.Customers.FindAsync(newCustomer.Id);
            if(customer == null)
                throw new InvalidOperationException();
            
            newCustomer.MapIntoCustomer(customer);
			await _context.SaveChangesAsync();

			_logger.LogInformation("Work updated: {@customer}", customer);
        }
    }
}
