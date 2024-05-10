using Car.Services;
using Car.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerPropertiesDTO customer)
        {
            await _customerService.Add(customer);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            CustomerGetUpdateDTO? customer = await _customerService.Get(id);

            if (customer is null)
            {
                return NotFound();
            }

            await _customerService.Delete(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerGetUpdateDTO>> Get(Guid id)
        {
            CustomerGetUpdateDTO? customer = await _customerService.Get(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("{id:guid}/inclworks")]
        public async Task<ActionResult<CustomerGetIncludeWorksDTO>> GetIncludeWorks(Guid id)
        {
            CustomerGetIncludeWorksDTO? customer = await _customerService.GetIncludeWorks(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerGetUpdateDTO>>> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("inclworks")]
        public async Task<ActionResult<List<CustomerGetIncludeWorksDTO>>> GetAllIncludeWorks()
        {
            return Ok(await _customerService.GetAllIncludeWorks());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CustomerGetUpdateDTO newCustomer)
        {
            if (id != newCustomer.Id)
            {
                return BadRequest();
            }

            var existingCustomer = await _customerService.Get(id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            await _customerService.Update(newCustomer);

            return Ok();
        }

    }
}
