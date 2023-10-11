using Domain.Infrastructure.DBConnection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using TaskManager_API.Interfaces;

namespace TaskManager_API.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationContext _context;

        public RoleService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(string roleName)
        {
            var role = new Role();
            role.Name = roleName;

            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public async Task DeleteAsync(Guid roleId)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId); //TODO NFexception

            _context.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid roleId, string roleName)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId); //TODO NFException

            role.Name = roleName;

            _context.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
