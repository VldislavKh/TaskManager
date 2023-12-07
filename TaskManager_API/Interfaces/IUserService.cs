using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(Guid updatingUserId, User inputUser);
        Task<User> GetUserAsync(Guid userId);
        Task<bool> IsLoginUniqueAsync(string Login);
        Task<List<User>> GetAllUsersAsync();
    }
}
