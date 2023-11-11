using Domain.Infrastructure.Authentication;
using Domain.Infrastructure.DBConnection;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TaskManager_API.CQ.Requests
{
    public class GenerateJWTRequest : IRequest<string>
    {
        public User User { get; set; }

        public class GenerateJWTRequestHandler : IRequestHandler<GenerateJWTRequest, string>
        {
            private readonly ApplicationContext _context;
            private readonly IOptions<AuthOptions> _authOptions;

            public GenerateJWTRequestHandler(ApplicationContext context, IOptions<AuthOptions> authOptions)
            {
                _context = context;
                _authOptions = authOptions;
            }

            public async Task<string> Handle(GenerateJWTRequest request, CancellationToken cancellationToken)
            {
                var authParams = _authOptions.Value;

                var securityKey = authParams.GetSymmetricSecurityKey();
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Name, request.User.Login),
                    new Claim(JwtRegisteredClaimNames.Sub, request.User.Id.ToString())
                };

                var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == request.User.RoleId);
                claims.Add(new Claim("role", role.Name.ToString()));

                var token = new JwtSecurityToken(authParams.Issuer,
                    authParams.Audience,
                    claims,
                    expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}
