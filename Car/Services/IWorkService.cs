using Car.Shared;

namespace Car.Services
{
    public interface IWorkService
    {
        Task Add(WorkPropertiesDTO newWork);

        Task Delete(Guid id);

        Task<WorkGetUpdateDTO?> Get(Guid id);

        Task<List<WorkGetUpdateDTO>> GetAll();

        Task<List<WorkGetIncludeCustomerDTO>> GetAllIncludeCustomer();

        Task Update(WorkGetUpdateDTO newWork);
    }
}
