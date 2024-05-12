using Car.UI.Services.Implementation;
using Car.Shared;

namespace Car.UI.Tests
{
    public class WorkHourEstimationServiceTests
    {
        public static IEnumerable<object[]> Generate_AllCategoriesOthersConstantTestData()
        {
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 3,
                    Severity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Engine,
                    ManufacturingYear = DateTime.Now.Year - 3,
                    Severity = 1,
                },
                8d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.RunningGear,
                    ManufacturingYear = DateTime.Now.Year - 3,
                    Severity = 1,
                },
                6d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Brakes,
                    ManufacturingYear = DateTime.Now.Year - 3,
                    Severity = 1,
                },
                4d * 0.5d * 0.2d
            ];
        }

        public static IEnumerable<object[]> Generate_AllManufacturingYearsOthersConstantTestData()
        {
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 0,
                    Severity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 4,
                    Severity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 5,
                    Severity = 1,
                },
                3d * 1.0d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 9,
                    Severity = 1,
                },
                3d * 1.0d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 10,
                    Severity = 1,
                },
                3d * 1.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 19,
                    Severity = 1,
                },
                3d * 1.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 20,
                    Severity = 1,
                },
                3d * 2.0d * 0.2d
            ];
        }

        public static IEnumerable<object[]> Generate_AllSeveritiesOthersConstantTestData()
        {
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 2,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 3,
                },
                3d * 0.5d * 0.4d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 4,
                },
                3d * 0.5d * 0.4d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 5,
                },
                3d * 0.5d * 0.6d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 7,
                },
                3d * 0.5d * 0.6d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 8,
                },
                3d * 0.5d * 0.8d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 9,
                },
                3d * 0.5d * 0.8d
            ];
            yield return [
                new WorkPropertiesDTO()
                {
                    Category = WorkCategory.Body,
                    ManufacturingYear = DateTime.Now.Year - 1,
                    Severity = 10,
                },
                3d * 0.5d * 1.0d
            ];
        }

        [Theory]
        [MemberData(nameof(Generate_AllCategoriesOthersConstantTestData))]
        public void GetEstimation_AllCategoriesOthersConstant_ReturnsCorrectEstimation(WorkPropertiesDTO work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }

        [Theory]
        [MemberData(nameof(Generate_AllManufacturingYearsOthersConstantTestData))]
        public void GetEstimation_AllManufacturingYearsOthersConstant_ReturnsCorrectEstimation(WorkPropertiesDTO work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }

        [Theory]
        [MemberData(nameof(Generate_AllSeveritiesOthersConstantTestData))]
        public void GetEstimation_AllSeveritiesOthersConstant_ReturnsCorrectEstimation(WorkPropertiesDTO work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }
    }
}