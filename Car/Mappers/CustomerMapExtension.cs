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

        public static CustomerGetUpdateDTO MapToCustomerGetUpdateDTO(this Customer customer)
        {
            return new CustomerGetUpdateDTO()
            {
                Id = customer.Id,
                Properties = customer.MapToCustomerPropertiesDTO(),
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

        public static void MapIntoCustomer(this CustomerGetUpdateDTO updateDTO, Customer customer)
        {
            customer.Name = updateDTO.Properties.Name;
            customer.Address = updateDTO.Properties.Address;
            customer.Email = updateDTO.Properties.Email;
        }
    }
}
