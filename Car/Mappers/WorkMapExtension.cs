using Car.Shared;

namespace Car.Mappers
{
    public static class WorkMapExtension
    {
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

        public static WorkDTO MapToWorkDTO(this Work work)
        {
            return new WorkDTO()
            {
                Id = work.Id,
                Properties = work.MapToWorkPropertiesDTO(),
            };
        }

        public static WorkGetDTO MapToWorkGetDTO(this Work work, bool includeCustomer = false)
        {
            return new WorkGetDTO()
            {
                Work = work.MapToWorkDTO(),
                Customer = includeCustomer ? work.Customer.MapToCustomerGetDTO() : null,
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

        public static void MapIntoWork(this WorkDTO updateDTO, Work work)
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
