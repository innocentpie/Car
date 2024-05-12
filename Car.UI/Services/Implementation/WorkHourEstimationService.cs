using Car.Shared;

namespace Car.UI.Services.Implementation
{
    public class WorkHourEstimationService : IWorkHourEstimationService
    {
        public double GetWorkHourEstimation(WorkPropertiesDTO workProperties)
        {
            double categoryMul = workProperties.Category switch
            {
                WorkCategory.Body => 3d,
                WorkCategory.Engine => 8d,
                WorkCategory.RunningGear => 6d,
                WorkCategory.Brakes => 4d,
                _ => 0d,
            };

            int age = DateTime.Now.Year - workProperties.ManufacturingYear;
            double ageMul = age switch
            {
                int i when i < 5 => 0.5d,
                int i when i < 10 => 1d,
                int i when i < 20 => 1.5d,
                int i when i >= 20 => 2d,
            };

            double severtityMul = workProperties.Severity switch
            {
                int i when i <= 2 => 0.2d,
                int i when i >= 3 && i <= 4 => 0.4d,
                int i when i >= 5 && i <= 7 => 0.6d,
                int i when i >= 8 && i <= 9 => 0.8d,
                int i when i >= 10 => 1d,
            };

            return categoryMul * ageMul * severtityMul;
        }
    }
}
