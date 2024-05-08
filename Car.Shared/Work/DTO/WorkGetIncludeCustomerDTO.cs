using System.ComponentModel.DataAnnotations;

namespace Car.Shared
{
    public class WorkGetIncludeCustomerDTO
    {
        public WorkGetUpdateDTO Work { get; set; }

        public CustomerGetUpdateDTO Customer { get; set; }
    }
}
