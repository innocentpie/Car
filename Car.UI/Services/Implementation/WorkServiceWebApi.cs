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

		public async Task AddWorkAsync(Work work)
		{
			await _httpClient.PostAsJsonAsync("/api/Works", work);
		}

		public async Task DeleteWorkAsync(Guid id)
		{
			await _httpClient.DeleteAsync($"/api/Works/{id}");
		}

		public async Task<IEnumerable<Work>> GetAllWorksAsync()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Work>>("/api/Works");
		}

		public async Task<Work> GetWorkAsync(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Work>($"/api/Works/{id}");
		}

		public async Task UpdateWorkAsync(Work work)
		{
			await _httpClient.PutAsJsonAsync($"/api/Works/{work.Id}", work);
		}
	}
}
