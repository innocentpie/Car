using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class WorkDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public WorkPropertiesDTO Properties { get; set; }
    }
}
