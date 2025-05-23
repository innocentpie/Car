﻿using Car.Data;
using Car.Services;
using Car.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorksController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WorkPropertiesDTO work)
        {
            await _workService.Add(work);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            WorkGetDTO? work = await _workService.Get(id);

            if (work is null)
            {
                return NotFound();
            }

            await _workService.Delete(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WorkGetDTO>> Get(Guid id, [FromQuery] bool includeCustomer = false)
        {
            WorkGetDTO? work = await _workService.Get(id, includeCustomer);

            if (work is null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkGetDTO>>> GetAll(bool includeCustomer = false)
        {
            return Ok(await _workService.GetAll(includeCustomer));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WorkDTO newWork)
        {
            if (id != newWork.Id)
            {
                return BadRequest();
            }

            var existingWork = await _workService.Get(id);

            if (existingWork == null)
            {
                return NotFound();
            }

            if (newWork.Properties.Status < existingWork.Work.Properties.Status)
            {
                ModelState.AddModelError<WorkDTO>((x) => x.Properties.Status, "New status cannot be lower than current.");
                return ValidationProblem(ModelState);
			}

            await _workService.Update(newWork);

            return Ok();
        }
    }
}
