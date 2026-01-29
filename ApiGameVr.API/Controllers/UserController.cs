using ApiGameVr.Application.Users.Commands;
using ApiGameVr.Application.Users.Query;
using ApiGameVr.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameVr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IReadOnlyList<User>> Get()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return users;
        }
    }
}
