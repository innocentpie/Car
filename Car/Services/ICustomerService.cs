using Car.Shared;

namespace Car.Services
{
    public interface ICustomerService
    {
        Task Add(CustomerPropertiesDTO newCustomer);

        Task Delete(Guid id);

        Task<CustomerGetUpdateDTO?> Get(Guid id);

        Task<CustomerGetIncludeWorksDTO?> GetIncludeWorks(Guid id);

        Task<List<CustomerGetUpdateDTO>> GetAll();

        Task<List<CustomerGetIncludeWorksDTO>> GetAllIncludeWorks();

        Task Update(CustomerGetUpdateDTO newCustomer);
    }
}
