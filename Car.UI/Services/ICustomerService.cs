using Car.Shared;
using System;

namespace Car.UI.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync();

		Task<Customer> GetCustomerAsync(Guid id);

		Task DeleteCustomerAsync(Guid id);

		Task AddCustomerAsync(Customer customer);

		Task UpdateCustomerAsync(Customer customer);
	}
}
