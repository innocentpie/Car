using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class CustomerGetDTO
    {
        public CustomerDTO Customer { get; set; }

        public List<WorkGetDTO>? Works { get; set; }
    }
}
