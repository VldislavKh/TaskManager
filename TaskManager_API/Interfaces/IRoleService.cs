using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IRoleService
    {
        public Task<Guid> CreateRoleAsync(string roleName);
        public Task DeleteRoleAsync(Guid roleId);
        public Task UpdateRoleAsync(Guid roleId, string roleName);
        public Task<Role> GetRoleAsync(Guid roleId);
        public Task<List<Role>> GetAllRolesAsync();
    }
}
