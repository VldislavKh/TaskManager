using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Requests;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("/api/Auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _mediator.Send(new LoginRequest
            { Login = request.Login, Password = request.Password });

            if (user != null)
            {
                //Generate JWT
                return Ok(await _mediator
                    .Send(new GenerateJWTRequest
                    {
                        User = user
                    }));
            }

            return Unauthorized();
        }
    }
}
