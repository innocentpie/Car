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
            CustomerGetDTO? customer = await _customerService.Get(id);

            if (customer is null)
            {
                return NotFound();
            }

            await _customerService.Delete(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerGetDTO>> Get(Guid id, [FromQuery] bool includeWorks = false)
        {
            CustomerGetDTO? customer = await _customerService.Get(id, includeWorks);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerGetDTO>>> GetAll([FromQuery] bool includeWorks = false)
        {
            return Ok(await _customerService.GetAll(includeWorks));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CustomerDTO newCustomer)
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
