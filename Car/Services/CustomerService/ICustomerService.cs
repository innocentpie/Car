using Car.Shared;
using System;

namespace Car.Services
{
    public interface ICustomerService
    {
        Task Add(Customer customer);

        Task Delete(Guid id);

        Task<Customer> Get(Guid id);

        Task<List<Customer>> GetAll();

        Task Update(Customer person);
    }
}
