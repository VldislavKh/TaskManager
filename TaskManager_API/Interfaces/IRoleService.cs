﻿namespace TaskManager_API.Interfaces
{
    public interface IRoleService
    {
        public Task<Guid> CreateAsync(string roleName);
        public Task DeleteAsync(Guid roleId);
    }
}
