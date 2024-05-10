using Car.Shared;
using System.Net.Http.Json;

namespace Car.UI.Services.Implementation
{
	public class CustomerServiceWebApi : ICustomerService
	{
		private readonly HttpClient _httpClient;

        public CustomerServiceWebApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddCustomerAsync(CustomerPropertiesDTO customer)
		{
			await _httpClient.PostAsJsonAsync("/api/Customers", customer);
		}

		public async Task DeleteCustomerAsync(Guid id)
		{
			await _httpClient.DeleteAsync($"/api/Customers/{id}");
		}

		public async Task<IEnumerable<CustomerGetUpdateDTO>> GetAllCustomersAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerGetUpdateDTO>>("/api/Customers");
		}

        public async Task<IEnumerable<CustomerGetIncludeWorksDTO>> GetAllCustomersIncludeWorksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerGetIncludeWorksDTO>>("/api/Customers/inclworks");
        }

        public async Task<CustomerGetUpdateDTO> GetCustomerAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<CustomerGetUpdateDTO>($"/api/Customers/{id}");
		}

        public async Task<CustomerGetIncludeWorksDTO> GetCustomerIncludeWorksAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerGetIncludeWorksDTO>($"/api/Customers/{id}/inclworks");
        }

        public async Task UpdateCustomerAsync(CustomerGetUpdateDTO customer)
		{
			await _httpClient.PutAsJsonAsync($"/api/Customers/{customer.Id}", customer);
		}
	}
}
