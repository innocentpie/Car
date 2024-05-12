using Car.Shared;

namespace Car.Services
{
    public interface IWorkService
    {
        Task Add(WorkPropertiesDTO newWork);

        Task Delete(Guid id);

        Task<WorkGetDTO?> Get(Guid id, bool includeCustomer = false);

        Task<List<WorkGetDTO>> GetAll(bool includeCustomer = false);

        Task Update(WorkDTO newWork);
    }
}
