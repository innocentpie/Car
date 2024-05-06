using Car.Data;
using Car.Services;
using Car.Shared;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Add([FromBody] Work work)
        {
            Work existingWork = await _workService.Get(work.Id);
            if (existingWork != null)
                return Conflict();

            await _workService.Add(work);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Work work = await _workService.Get(id);

            if (work is null)
            {
                return NotFound();
            }

            await _workService.Delete(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Work>> Get(Guid id)
        {
            Work work = await _workService.Get(id);

            if (work is null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            return Ok(await _workService.GetAll());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Work newWork)
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

            await _workService.Update(newWork);

            return Ok();
        }
    }
}
