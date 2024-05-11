using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class WorkPropertiesDTO
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}-[0-9]{3}$", ErrorMessage = "Must be a valid license plate number! (XXX-YYY where Xs are upper case letters and Ys are numbers 0-9)")]
        public string LicensePlate { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public int ManufacturingYear { get; set; }

        [Required]
        public WorkCategory Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 10)]
        public int Severity { get; set; }

        [Required]
        public WorkStatus Status { get; set; }
    }
}
