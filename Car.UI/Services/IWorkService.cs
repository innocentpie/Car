using Car.Shared;

namespace Car.UI.Services
{
	public interface IWorkService
	{
		Task<IList<WorkGetUpdateDTO>> GetAllWorksAsync();
		Task<IList<WorkGetIncludeCustomerDTO>> GetAllWorksIncludeCustomerAsync();

		Task<WorkGetUpdateDTO> GetWorkAsync(Guid id);
		Task<WorkGetIncludeCustomerDTO> GetWorkIncludeCustomerAsync(Guid id);

		Task DeleteWorkAsync(Guid id);

		Task AddWorkAsync(WorkPropertiesDTO work);

		Task UpdateWorkAsync(WorkGetUpdateDTO work);
	}
}
