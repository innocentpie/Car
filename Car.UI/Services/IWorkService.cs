using Car.Shared;

namespace Car.UI.Services
{
	public interface IWorkService
	{
		Task<IList<WorkGetDTO>> GetAllWorksAsync(bool includeCustomer = false);

		Task<WorkGetDTO> GetWorkAsync(Guid id, bool includeCustomer = false);

		Task DeleteWorkAsync(Guid id);

		Task AddWorkAsync(WorkPropertiesDTO work);

		Task UpdateWorkAsync(WorkDTO work);
	}
}
