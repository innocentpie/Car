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

        public async Task AddCustomerAsync(Customer customer)
		{
			await _httpClient.PostAsJsonAsync("/api/Customers", customer);
		}

		public async Task DeleteCustomerAsync(Guid id)
		{
			await _httpClient.DeleteAsync($"/api/Customers/{id}");
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("/api/Customers");
		}

		public async Task<Customer> GetCustomerAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Customer>($"/api/Customers/{id}");
		}

		public async Task UpdateCustomerAsync(Customer customer)
		{
			await _httpClient.PutAsJsonAsync($"/api/Customers/{customer.Id}", customer);
		}
	}
}
