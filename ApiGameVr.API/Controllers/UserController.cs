using ApiGameVr.Application.Features.Users.Commands.Create;
using ApiGameVr.Application.Features.Users.Commands.Delete;
using ApiGameVr.Application.Features.Users.Query;
using ApiGameVr.Application.Interfaces.Logging;
using ApiGameVr.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameVr.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggerService _logger;
        public UserController(IMediator mediator, ILoggerService logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            try
            {
                Unit response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"mail creation failed {e.Message}");
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult>Delete(DeleteUserCommand command)
        {
            Unit response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IReadOnlyList<ApplicationUser>> Get()
        {
            IReadOnlyList<ApplicationUser> users = await _mediator.Send(new GetUsersQuery());
            return users;
        }
    }
}
