using Car.Shared;
using System;

namespace Car.UI.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerGetUpdateDTO>> GetAllCustomersAsync();

		Task<CustomerGetUpdateDTO> GetCustomerAsync(Guid id);

		Task DeleteCustomerAsync(Guid id);

		Task AddCustomerAsync(CustomerPropertiesDTO customer);

		Task UpdateCustomerAsync(CustomerGetUpdateDTO customer);
	}
}
