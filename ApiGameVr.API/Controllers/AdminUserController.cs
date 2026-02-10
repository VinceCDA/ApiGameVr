using ApiGameVr.Application.Features.AdminUsers.Commands.Create;
using ApiGameVr.Application.Features.AdminUsers.Commands.Login;
using ApiGameVr.Application.Interfaces.Logging;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiGameVr.API.Controllers
{
    [ApiController]
    [Route("test")]
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
                return Ok("user created");
            }
            catch (Exception e)
            {
                _loggerService.LogError($"mail creation failed {e.Message}");
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>> Login(LoginAdminUserCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return TypedResults.Empty;
            }
            catch (Exception e)
            {
                _loggerService.LogError($"login failed {e.Message}");
                return TypedResults.Problem("error", statusCode: StatusCodes.Status401Unauthorized);
            }
        }
    }
    
}
