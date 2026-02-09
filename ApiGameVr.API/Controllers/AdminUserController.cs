using ApiGameVr.Application.Features.AdminUsers.Commands.Create;
using ApiGameVr.Application.Interfaces.Logging;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameVr.API.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILoggerService _loggerService;
        public AdminUserController(IMediator mediator, UserManager<IdentityAdminUser> userManager, ILoggerService loggerService, IUserStore<IdentityAdminUser> userStore)
        {
            _mediator = mediator;
            _loggerService = loggerService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CreateAdminUserCommand command)
        {
            try
            {
                Unit response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                _loggerService.LogError($"mail creation failed {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
    
}
