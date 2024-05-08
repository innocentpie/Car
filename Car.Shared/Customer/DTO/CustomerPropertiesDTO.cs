using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class CustomerPropertiesDTO
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
