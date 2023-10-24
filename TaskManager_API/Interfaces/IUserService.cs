﻿using Domain.Models;

namespace TaskManager_API.Interfaces
{
    public interface IUserService
    {
        //public Task<Guid> CreateAsync(string login, string email, string password, Guid roleId);
        public Task<Guid> CreateAsync(User user);
        public Task DeleteAsync(Guid id);
        //public Task UpdateAsync(Guid userId, string login, string email, string password, Guid roleId);
        public Task UpdateAsync(Guid updatingUserId, User inputUser);
        public Task<User> GetAsync(Guid userId);
        public Task<List<User>> GetAllAsync();
    }
}
