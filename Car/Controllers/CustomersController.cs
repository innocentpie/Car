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
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            Customer existingCustomer = await _customerService.Get(customer.Id);
            if(existingCustomer != null) 
                return Conflict();

            await _customerService.Add(customer);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Customer customer = await _customerService.Get(id);

            if (customer is null)
            {
                return NotFound();
            }

            await _customerService.Delete(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            Customer customer = await _customerService.Get(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Customer newCustomer)
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
