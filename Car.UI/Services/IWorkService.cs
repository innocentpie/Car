using Car.Shared;

namespace Car.UI.Services
{
	public interface IWorkService
	{
		Task<IEnumerable<WorkGetUpdateDTO>> GetAllWorksAsync();
		Task<IEnumerable<WorkGetIncludeCustomerDTO>> GetAllWorksIncludeCustomerAsync();

		Task<WorkGetUpdateDTO> GetWorkAsync(Guid id);

		Task DeleteWorkAsync(Guid id);

		Task AddWorkAsync(WorkPropertiesDTO work);

		Task UpdateWorkAsync(WorkGetUpdateDTO work);
	}
}
