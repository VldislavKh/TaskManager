using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Requests;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/login")]
        public async Task<IActionResult> Login(/*[FromBody]*/ LoginRequest request)
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

        [HttpPost("/registration")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var rUser = await _mediator.Send(request);
            if (rUser != null)
            {
                var lUser = await _mediator.Send(new LoginRequest
                { Login = request.Login, Password = request.Password });

                if (lUser != null)
                {
                    //Generate JWT
                    return Ok(await _mediator
                        .Send(new GenerateJWTRequest
                        {
                            User = lUser
                        })); ;
                }
            }
            return Unauthorized();
        }
    }
}
