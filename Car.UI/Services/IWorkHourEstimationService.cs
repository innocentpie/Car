using Car.Shared;

namespace Car.UI.Services
{
    public interface IWorkHourEstimationService
    {
        double GetWorkHourEstimation(WorkPropertiesDTO workProperties);

    }
}
