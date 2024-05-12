using Car.Shared;

namespace Car.UI.Services
{
	public interface ICustomerService
	{
		Task<IList<CustomerGetDTO>> GetAllCustomersAsync(bool includeWorks = false);

		Task<CustomerGetDTO> GetCustomerAsync(Guid id, bool includeWorks = false);

		Task DeleteCustomerAsync(Guid id);

		Task AddCustomerAsync(CustomerPropertiesDTO customer);

		Task UpdateCustomerAsync(CustomerDTO customer);
	}
}
