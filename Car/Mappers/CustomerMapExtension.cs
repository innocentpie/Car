using Car.Shared;

namespace Car.Mappers
{
    public static class CustomerMapExtension
    {
        public static CustomerPropertiesDTO MapToCustomerPropertiesDTO(this Customer customer)
        {
            return new CustomerPropertiesDTO()
            {
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email,
            };
        }

        public static CustomerDTO MapToCustomerDTO(this Customer customer)
        {
            return new CustomerDTO()
            {
                Id = customer.Id,
                Properties = customer.MapToCustomerPropertiesDTO(),
            };
        }

        public static CustomerGetDTO MapToCustomerGetDTO(this Customer customer, bool includeWorks = false)
        {
            return new CustomerGetDTO()
            {
                Customer = customer.MapToCustomerDTO(),
                Works = includeWorks ? customer.Works?.Select(x => x.MapToWorkDTO()).ToList() : null,
            };
        }

        public static Customer MapToNewCustomer(this CustomerPropertiesDTO customer)
        {
            return new Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email,
            };
        }

        public static void MapIntoCustomer(this CustomerDTO updateDTO, Customer customer)
        {
            customer.Name = updateDTO.Properties.Name;
            customer.Address = updateDTO.Properties.Address;
            customer.Email = updateDTO.Properties.Email;
        }
    }
}
