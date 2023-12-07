using Domain.Infrastructure.DBConnection;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaskManager_API.Exceptions.CustomExceptions;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Requests
{
    public class LoginRequest : IRequest<User>
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public class LoginRequestHandler : IRequestHandler<LoginRequest, User>
        {
            private readonly ApplicationContext _context;

            public LoginRequestHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(LoginRequest request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Login == request.Login && u.Password == CreateSHA256(request.Password))
                ?? throw new NotFoundException(nameof(_context.Users), request.Login);
                var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == user.RoleId)
                    ?? throw new NotFoundException(nameof(_context.Roles), user.RoleId);

                user.Role = role;

                return user;
            }
        }

        private static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
    }
}
