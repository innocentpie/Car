using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class CustomerPropertiesDTO
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "The Name field's maximum allowed length is 100 characters.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "The Address field's maximum allowed length is 100 characters.")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "The Email field's maximum allowed length is 100 characters.")]
        public string Email { get; set; }
    }
}
