using Car.Controllers;
using Car.Services;
using Car.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Car.Tests
{
    public class WorksControllerTests
    {
        [Fact]
        public async Task Get_ExistingWork_ReturnsOkWork()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new WorkGetDTO());
            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Get(Guid.Empty);
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<WorkGetDTO?>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Get_NonExistingWork_ReturnsNotFound()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);
            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Get(Guid.Empty);
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_Works_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(value: new List<WorkGetDTO>());
            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.GetAll();
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<WorkGetDTO>>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Add_WorkProperties_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Add(It.IsAny<WorkPropertiesDTO>()))
                .Verifiable();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Add(new WorkPropertiesDTO());

            workServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Delete_NonExistingWork_ReturnsNotFound()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Delete(Guid.Empty);

            workServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Delete_ExistingWork_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new WorkGetDTO());
            workServiceMock
                .Setup(x => x.Delete(It.IsAny<Guid>()))
                .Verifiable();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Delete(Guid.Empty);

            workServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_ExistingWork_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new WorkGetDTO() { Work = new WorkDTO() { Properties = new WorkPropertiesDTO() { } } });
            workServiceMock
                .Setup(x => x.Update(It.IsAny<WorkDTO>()))
                .Verifiable();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Update(Guid.Empty, new WorkDTO() { Properties = new WorkPropertiesDTO() { } });

            workServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_NonExistingWork_ReturnsNotFound()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Update(Guid.Empty, new WorkDTO()
            {
                Id = Guid.Empty,
            });

            workServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

		[Fact]
		public async Task Update_IdMismatch_ReturnsBadRequest()
		{
			Mock<IWorkService> workServiceMock = new Mock<IWorkService>();

			WorksController WorksController = new WorksController(workServiceMock.Object);

			var response = await WorksController.Update(Guid.Empty, new WorkDTO()
			{
				Id = Guid.NewGuid(),
			});

			Assert.IsType<BadRequestResult>(response);
		}
	}
}
