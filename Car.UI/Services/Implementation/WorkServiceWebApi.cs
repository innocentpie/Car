using Car.Shared;
using System.Net.Http.Json;

namespace Car.UI.Services.Implementation
{
	public class WorkServiceWebApi : IWorkService
	{
		private readonly HttpClient _httpClient;

		public WorkServiceWebApi(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task AddWorkAsync(WorkPropertiesDTO work)
		{
			await _httpClient.PostAsJsonAsync("/api/Works", work);
		}

		public async Task DeleteWorkAsync(Guid id)
		{
			await _httpClient.DeleteAsync($"/api/Works/{id}");
		}

		public async Task<IEnumerable<WorkGetUpdateDTO>> GetAllWorksAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<WorkGetUpdateDTO>>("/api/Works");
		}

        public async Task<IEnumerable<WorkGetIncludeCustomerDTO>> GetAllWorksIncludeCustomerAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WorkGetIncludeCustomerDTO>>("/api/Works/inclcustomer");
        }

        public async Task<WorkGetUpdateDTO> GetWorkAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<WorkGetUpdateDTO>($"/api/Works/{id}");
		}

		public async Task UpdateWorkAsync(WorkGetUpdateDTO work)
		{
			await _httpClient.PutAsJsonAsync($"/api/Works/{work.Id}", work);
		}
	}
}
