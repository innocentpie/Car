using Car.Shared;
using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Text;
using System.Web;

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

		public async Task<IList<CustomerGetDTO>> GetAllCustomersAsync(bool includeWorks = false)
		{
            StringBuilder uriSb = new StringBuilder("/api/Customers/?");
            if (includeWorks)
                uriSb.Append($"includeWorks={includeWorks}");

            return await _httpClient.GetFromJsonAsync<IList<CustomerGetDTO>>(uriSb.ToString());
		}

        public async Task<CustomerGetDTO> GetCustomerAsync(Guid id, bool includeWorks = false)
		{
            StringBuilder uriSb = new StringBuilder($"/api/Customers/{id}/?");
            if (includeWorks)
                uriSb.Append($"includeWorks={includeWorks}");

            return await _httpClient.GetFromJsonAsync<CustomerGetDTO>(uriSb.ToString());
		}

        public async Task UpdateCustomerAsync(CustomerDTO customer)
		{
			await _httpClient.PutAsJsonAsync($"/api/Customers/{customer.Id}", customer);
		}
	}
}
