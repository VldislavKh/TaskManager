using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IGoalService
    {
        public Task<Guid> CreateGoalAsync(Goal goal);
        public Task DeleteGoalAsync(Guid goalId);
        public Task UpdateGoalAsync(Guid updatingGoalId, Goal inputGoal);
        public Task<Goal> GetGoalAsync(Guid goalId);
        public Task<List<Goal>> GetAllGoalsAsync();
    }
}
