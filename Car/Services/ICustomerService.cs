using Car.Shared;

namespace Car.Services
{
    public interface ICustomerService
    {
        Task Add(CustomerPropertiesDTO newCustomer);

        Task Delete(Guid id);

        Task<CustomerGetDTO?> Get(Guid id, bool includeWorks = false);

        Task<List<CustomerGetDTO>> GetAll(bool includeWorks = false);

        Task Update(CustomerDTO newCustomer);
    }
}
