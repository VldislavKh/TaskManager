using Domain.Infrastructure.DBConnection;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using TaskManager_API.CQ.Requests.Validation;
using TaskManager_API.Exceptions.CustomExceptions;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Requests
{
    public class RegisterRequest : IRequest<User>
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }


        public class RegisterRequestHandler : IRequestHandler<RegisterRequest, User>
        {
            private readonly ApplicationContext _context;
            private readonly IUserService _userService;
            private readonly IRoleService _roleService;
            private readonly RegisterRequestValidator _validator;

            public RegisterRequestHandler(ApplicationContext context, IUserService userService, IRoleService roleService)
            {
                _context = context;
                _userService = userService;
                _roleService = roleService;
                _validator = new RegisterRequestValidator();
            }

            public async Task<User> Handle(RegisterRequest request, CancellationToken cancellationToken)
            {
                await _validator.ValidateAndThrowAsync(request);

                var login = await _context.Users.SingleOrDefaultAsync(u => u.Login == request.Login)               
                    ?? throw new NotUniqueLoginException(nameof(_context.Users), request.Login);

                Guid roleId;
                var role = await _context.Roles.SingleOrDefaultAsync(r => r.Name == "user");
        
                if (role == null)
                {
                   roleId = await _roleService.CreateRoleAsync("user");
                   role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId)
                        ?? throw new NotFoundException(nameof(_context.Roles), roleId);
                } 
                else
                {
                    roleId = role.Id;
                }

                var user = new User
                {
                    Login = request.Login,
                    Email = request.Email,
                    Password = request.Password,
                    Role = role,
                    RoleId = roleId
                };

                await _userService.CreateUserAsync(user);
                return user;
            }
        }

    }
}
