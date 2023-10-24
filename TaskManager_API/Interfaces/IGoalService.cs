using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IGoalService
    {
        //public Task<Guid> CreateAsync(string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId);
        public Task<Guid> CreateAsync(Goal goal);
        public Task DeleteAsync(Guid goalId);
        //public Task UpdateAsync(Guid goalId, string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId);
        public Task UpdateAsync(Guid updatingGoalId, Goal inputGoal);
        public Task<Goal> GetAsync(Guid goalId);
        public Task<List<Goal>> GetAllAsync();
    }
}
