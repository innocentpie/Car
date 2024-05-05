using Car.Shared;

namespace Car.Services
{
    public interface IWorkService
    {
        Task Add(Work work);

        Task Delete(Guid id);

        Task<Work> Get(Guid id);

        Task<List<Work>> GetAll();

        Task Update(Work work);
    }
}
