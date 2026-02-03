using ApiGameVr.Application.Features.Users.Commands.Create;
using ApiGameVr.Application.Features.Users.Commands.Delete;
using ApiGameVr.Application.Features.Users.Query;
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
        [Route("create")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult>Delete(DeleteUserCommand command)
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
