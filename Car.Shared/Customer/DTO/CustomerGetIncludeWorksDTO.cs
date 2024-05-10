using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class CustomerGetIncludeWorksDTO
    {
        public CustomerGetUpdateDTO Customer { get; set; }

        public List<WorkGetUpdateDTO> Works { get; set; }
    }
}
