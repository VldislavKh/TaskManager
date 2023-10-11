namespace TaskManager_API.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> CreateAsync(string login, string email, string password, Guid roleId);
        public Task DeleteAsync(Guid id);
        public Task UpdateAsync(Guid userId, string login, string email, string password, Guid roleId);
    }
}
