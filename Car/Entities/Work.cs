using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Car.Shared;

namespace Car
{
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}-[0-9]{3}$")]
        public string LicensePlate { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public int ManufacturingYear { get; set; }

        [Required]
        [EnumDataType(typeof(WorkCategory))]
		public WorkCategory Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 10)]
        public int Severity { get; set; }

        [Required]
        [EnumDataType(typeof(WorkStatus))]
        public WorkStatus Status { get; set; }
    }
}
