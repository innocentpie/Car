using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car.Shared
{
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}-[1-9]{3}$")]
        public string LicensePlate { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "9999-12-31")]
        public DateTime ManufacturingDate { get; set; }

        [Required]
        public WorkCategory Category { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public int Severity { get; set; }

        [Required]
        public WorkStatus Status { get; set; }
    }
}
