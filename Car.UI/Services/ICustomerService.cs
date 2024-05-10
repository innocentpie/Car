using Car.Shared;

namespace Car.UI.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerGetUpdateDTO>> GetAllCustomersAsync();
		Task<IEnumerable<CustomerGetIncludeWorksDTO>> GetAllCustomersIncludeWorksAsync();

		Task<CustomerGetUpdateDTO> GetCustomerAsync(Guid id);
		Task<CustomerGetIncludeWorksDTO> GetCustomerIncludeWorksAsync(Guid id);

		Task DeleteCustomerAsync(Guid id);

		Task AddCustomerAsync(CustomerPropertiesDTO customer);

		Task UpdateCustomerAsync(CustomerGetUpdateDTO customer);
	}
}
