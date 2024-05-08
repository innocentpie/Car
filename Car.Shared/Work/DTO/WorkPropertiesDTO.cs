using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class WorkPropertiesDTO
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}-[1-9]{3}$")]
        public string LicensePlate { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31")]
        public DateTime ManufacturingDate { get; set; }

        [Required]
        public WorkCategory Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public int Severity { get; set; }

        [Required]
        public WorkStatus Status { get; set; }
    }
}
