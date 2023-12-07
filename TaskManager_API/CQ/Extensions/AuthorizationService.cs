using Domain.Infrastructure.DBConnection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using TaskManager_API.Exceptions.CustomExceptions;

namespace TaskManager_API.CQ.Extensions
{
    public class AuthorizationService
    {
        private readonly ApplicationContext _context;
        private readonly User _user;

        public AuthorizationService(ApplicationContext context, User user)
        {
            _context = context;
            _user = user;
        }

        public async Task<bool> IsUser()
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == _user.Id);
            if (role != null) return true;
            return false;
        }

        public async Task<bool> IsAdmin()
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == _user.Id)
                ?? throw new NotFoundException(nameof(_context.Roles), _user.Id);
            if (role.Name == "admin") return true;
            return false;
        }
    }
}
