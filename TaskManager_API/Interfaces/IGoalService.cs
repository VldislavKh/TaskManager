using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IGoalService
    {
        public Task<Guid> CreateAsync(string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId);
        public Task DeleteAsync(Guid goalId);
        public Task UpdateAsync(Guid goalId, string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId);
        public Task<Goal> GetAsync(Guid goalId);
        public Task<List<Goal>> GetAllAsync();
    }
}
