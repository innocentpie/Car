using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class WorkGetDTO
    {
        public WorkDTO Work { get; set; }

        public CustomerDTO? Customer { get; set; }
    }
}
