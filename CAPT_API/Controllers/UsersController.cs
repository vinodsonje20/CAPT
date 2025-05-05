using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CAPT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous] // <---- THIS
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            _logger.LogInformation("Creating Users...");
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllUsers), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest();
            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
