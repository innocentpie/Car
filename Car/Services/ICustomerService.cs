using Car.Shared;
using System;

namespace Car.Services
{
    public interface ICustomerService
    {
        Task Add(CustomerPropertiesDTO newCustomer);

        Task Delete(Guid id);

        Task<CustomerGetUpdateDTO?> Get(Guid id);

        Task<List<CustomerGetUpdateDTO>> GetAll();

        Task Update(CustomerGetUpdateDTO newCustomer);
    }
}
