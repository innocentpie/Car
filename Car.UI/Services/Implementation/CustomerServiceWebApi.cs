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

		public async Task<IList<CustomerGetUpdateDTO>> GetAllCustomersAsync()
		{
			return await _httpClient.GetFromJsonAsync<IList<CustomerGetUpdateDTO>>("/api/Customers");
		}

        public async Task<IList<CustomerGetIncludeWorksDTO>> GetAllCustomersIncludeWorksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IList<CustomerGetIncludeWorksDTO>>("/api/Customers/inclworks");
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
