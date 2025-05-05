using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CAPT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CheckTypeController> _logger;

        public CheckTypeController(IMediator mediator, ILogger<CheckTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCheckTypeCommand command)
        {
            _logger.LogInformation("Creating CheckTypes...");
            var CheckTypeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllCheckTypes), new { CheckTypeId }, null);
        }

        [HttpPut("{CheckTypeId}")]
        public async Task<IActionResult> UpdateCheckType(int CheckTypeId, UpdateCheckTypeCommand command)
        {
            if (CheckTypeId != command.CheckTypeId) return BadRequest();
            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{CheckTypeId}")]
        public async Task<IActionResult> DeleteCheckType(int CheckTypeId)
        {
            var result = await _mediator.Send(new DeleteCheckTypeCommand { CheckTypeId = CheckTypeId });
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCheckTypes()
        {
            var result = await _mediator.Send(new GetAllCheckTypeQuery());
            return Ok(result);
        }

        [HttpGet("{CheckTypeId}")]
        public async Task<IActionResult> GetCheckTypeById(int CheckTypeId)
        {
            var CheckType = await _mediator.Send(new GetCheckTypeByIdQuery { CheckTypeId = CheckTypeId });
            if (CheckType == null) return NotFound();
            return Ok(CheckType);
        }
    }
}
