using Car.Shared;

namespace Car.UI.Services
{
	public interface IWorkService
	{
		Task<IEnumerable<Work>> GetAllWorksAsync();

		Task<Work> GetWorkAsync(Guid id);

		Task DeleteWorkAsync(Guid id);

		Task AddWorkAsync(Work work);

		Task UpdateWorkAsync(Work work);
	}
}
