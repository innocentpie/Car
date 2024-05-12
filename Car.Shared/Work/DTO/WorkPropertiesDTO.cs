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
        [Range(1900, int.MaxValue, ErrorMessage = "The Manufacturing Year field's minimum value is 1900.")]
        public int ManufacturingYear { get; set; }

        [Required]
		[EnumDataType(typeof(WorkCategory))]
		public WorkCategory Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10000, ErrorMessage = "The Description field's maximum allowed length is 10000 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "The Severity field must be between 1 and 10.")]
        public int Severity { get; set; }

        [Required]
		[EnumDataType(typeof(WorkStatus))]
		public WorkStatus Status { get; set; }
    }
}
