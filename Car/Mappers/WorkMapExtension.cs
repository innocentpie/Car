using Car.Shared;

namespace Car.Mappers
{
    public static class WorkMapExtension
    {
        public static WorkGetIncludeCustomerDTO MapToWorkGetIncludeCustomerDTO(this Work work)
        {
            return new WorkGetIncludeCustomerDTO()
            {
                Work = work.MapToWorkGetUpdateDTO(),
                Customer = work.Customer.MapToCustomerGetUpdateDTO(),
            };
        }

        public static WorkPropertiesDTO MapToWorkPropertiesDTO(this Work work)
        {
            return new WorkPropertiesDTO()
            {
                CustomerId = work.CustomerId,
                LicensePlate = work.LicensePlate,
                ManufacturingYear = work.ManufacturingYear,
                Category = work.Category,
                Description = work.Description,
                Severity = work.Severity,
                Status = work.Status,
            };
        }

        public static WorkGetUpdateDTO MapToWorkGetUpdateDTO(this Work work)
        {
            return new WorkGetUpdateDTO()
            {
                Id = work.Id,
                Properties = work.MapToWorkPropertiesDTO(),
            };
        }

        public static Work MapToNewWork(this WorkPropertiesDTO work)
        {
            return new Work()
            {
                CustomerId = work.CustomerId,
                LicensePlate = work.LicensePlate,
                ManufacturingYear = work.ManufacturingYear,
                Category = work.Category,
                Description = work.Description,
                Severity = work.Severity,
                Status = work.Status,
            };
        }

        public static void MapIntoWork(this WorkGetUpdateDTO updateDTO, Work work)
        {
            work.CustomerId = updateDTO.Properties.CustomerId;
            work.LicensePlate = updateDTO.Properties.LicensePlate;
            work.ManufacturingYear = updateDTO.Properties.ManufacturingYear;
            work.Category = updateDTO.Properties.Category;
            work.Description = updateDTO.Properties.Description;
            work.Severity = updateDTO.Properties.Severity;
            work.Status = updateDTO.Properties.Status;
        }
    }
}
