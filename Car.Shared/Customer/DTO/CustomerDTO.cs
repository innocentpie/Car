using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class CustomerDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public CustomerPropertiesDTO Properties { get; set; }
    }
}
