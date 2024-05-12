using Car.Controllers;
using Car.Services;
using Car.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Car.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public async Task Get_ExistingCustomer_ReturnsOkCustomer()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new CustomerGetDTO());
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Get(Guid.Empty);
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CustomerGetDTO?>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Get_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Get(Guid.Empty);
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_Customers_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(value: new List<CustomerGetDTO>());
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.GetAll();
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CustomerGetDTO>>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Add_CustomerProperties_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Add(It.IsAny<CustomerPropertiesDTO>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Add(new CustomerPropertiesDTO());

            customerServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Delete_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Delete(Guid.Empty);

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Delete_ExistingCustomer_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new CustomerGetDTO());
            customerServiceMock
                .Setup(x => x.Delete(It.IsAny<Guid>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Delete(Guid.Empty);

            customerServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_ExistingCustomer_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(new CustomerGetDTO());
            customerServiceMock
                .Setup(x => x.Update(It.IsAny<CustomerDTO>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Update(Guid.Empty, new CustomerDTO()
            {
                Id = Guid.Empty,
            });

            customerServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Update(Guid.Empty, new CustomerDTO()
            {
                Id = Guid.Empty,
            });

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Update(Guid.Empty, new CustomerDTO()
            {
                Id = Guid.NewGuid(),
            });

            Assert.IsType<BadRequestResult>(response);
        }
    }
}
