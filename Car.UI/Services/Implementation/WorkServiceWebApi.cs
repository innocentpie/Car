using Car.Shared;
using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Text;
using System.Web;

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

		public async Task<IList<WorkGetDTO>> GetAllWorksAsync(bool includeCustomer = false)
		{
			StringBuilder uriSb = new StringBuilder("/api/Works?");
			if (includeCustomer)
				uriSb.Append($"includeCustomer={includeCustomer}");

            return await _httpClient.GetFromJsonAsync<IList<WorkGetDTO>>(uriSb.ToString());
		}

        public async Task<WorkGetDTO> GetWorkAsync(Guid id, bool includeCustomer = false)
		{
            StringBuilder uriSb = new StringBuilder($"/api/Works/{id}?");
            if (includeCustomer)
                uriSb.Append($"includeCustomer={includeCustomer}");

            return await _httpClient.GetFromJsonAsync<WorkGetDTO>(uriSb.ToString());
		}

        public async Task UpdateWorkAsync(WorkDTO work)
		{
			await _httpClient.PutAsJsonAsync($"/api/Works/{work.Id}", work);
		}
	}
}
