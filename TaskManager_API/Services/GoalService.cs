using Domain.Infrastructure.DBConnection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TaskManager_API.Exceptions.CustomExceptions;
using TaskManager_API.Interfaces;

namespace TaskManager_API.Services
{
    public class GoalService : IGoalService
    {
        private readonly ApplicationContext _context;

        public GoalService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException(nameof(_context), userId);

            var goal = new Goal();
            goal.Name = goalName;
            goal.Description = description;
            goal.CreationDay = creationDay;
            goal.Deadline = deadline;
            goal.Priority = priority;
            goal.UserId = userId;
            goal.User = user;

            await _context.AddAsync(goal);
            await _context.SaveChangesAsync();

            return goal.Id;
        }

        public async Task DeleteAsync(Guid goalId)
        {
            var goal = await _context.Goals.SingleOrDefaultAsync(g => g.Id == goalId)
                ?? throw new NotFoundException(nameof(_context), goalId); 

            _context.Remove(goal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid goalId, string goalName, string description, DateTime creationDay, DateTime deadline, Priority priority, Guid userId)
        {
            var goal = await _context.Goals.SingleOrDefaultAsync(g => g.Id == goalId)
                ?? throw new NotFoundException(nameof(_context), goalId);

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException(nameof(_context), userId);

            goal.Name = goalName;
            goal.Description = description;
            goal.CreationDay = creationDay;
            goal.Deadline = deadline;
            goal.Priority = priority;
            goal.UserId = userId;
            goal.User = user;

            _context.Update(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<Goal> GetAsync(Guid goalId)
        {
            var goal = await _context.Goals.SingleOrDefaultAsync(g => g.Id == goalId)
                ?? throw new NotFoundException(nameof(_context), goalId); 

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == goal.UserId)
                ?? throw new NotFoundException(nameof(_context), goal.UserId); 

            user.Role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == user.RoleId)
                ?? throw new NotFoundException(nameof(_context), user.RoleId); 

            goal.User = user;

            return goal;
        }

        public async Task<List<Goal>> GetAllAsync()
        {
            var goals = await _context.Goals.ToListAsync();
            
            foreach (var goal in goals)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == goal.UserId)
                     ?? throw new NotFoundException(nameof(_context), goal.UserId); 

                user.Role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == user.RoleId)
                    ?? throw new NotFoundException(nameof(_context), user.RoleId);

                goal.User = user;
            }

            return goals;
        }
    }
}
