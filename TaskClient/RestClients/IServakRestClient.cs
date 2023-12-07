using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskClient.Models;
using TaskManager_API.CQ.Requests;

namespace TaskClient.RestClients
{
    public interface IServakRestClient
    {
        Task<Guid> CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(Guid updatingUserId, User inputUser);
        Task<User> GetUserAsync(Guid userId);
        Task<List<User>> GetAllUsersAsync();

        Task<Guid> CreateRoleAsync(string roleName);
        Task DeleteRoleAsync(Guid roleId);
        Task UpdateRoleAsync(Guid roleId, string roleName);
        Task<Role> GetRoleAsync(Guid roleId);

        [Get("/User/check/{login}/")]
        Task<IActionResult> CheckLogin(string login);
        Task<List<Role>> GetAllRolesAsync();

        Task<Guid> CreateGoalAsync(Goal goal);
        Task DeleteGoalAsync(Guid goalId);
        Task UpdateGoalAsync(Guid updatingGoalId, Goal inputGoal);
        Task<Goal> GetGoalAsync(Guid goalId);//[eq
        Task<List<Goal>> GetAllGoalsAsync();

        [Get("/auth/login/")]
        Task Login(/*[FromBody]*/ LoginRequest request);
        [Post("/auth/registration/")]
        Task<IActionResult> Register(/*[FromBody]*/ RegisterRequest request);
    }
}
