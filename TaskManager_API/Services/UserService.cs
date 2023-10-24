using Microsoft.EntityFrameworkCore;
using Domain.Infrastructure.DBConnection;
using Domain.Models;
using TaskManager_API.Interfaces;
using System.Text;
using System.Security.Cryptography;
using TaskManager_API.Exceptions.CustomExceptions;

namespace TaskManager_API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        //public async Task<Guid> CreateAsync(string login, string email, string password, Guid roleId)
        //{
        //    var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId)
        //        ?? throw new NotFoundException(nameof(_context), roleId);

        //    var user = new User();
        //    user.Login = login;
        //    user.Email = email;
        //    user.Password = CreateSHA256(password);
        //    user.RoleId = roleId;
        //    user.Role = role;

        //    await _context.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //    return user.Id;
        //}

        public async Task<Guid> CreateAsync(User user)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(role => role.Id == user.RoleId)
                ?? throw new NotFoundException(nameof(_context), user.RoleId);

            var creatingUser = new User();
            creatingUser.Login = user.Login;
            creatingUser.Email = user.Email;
            creatingUser.Password = CreateSHA256(user.Password);
            creatingUser.RoleId = role.Id;
            creatingUser.Role = role;

            await _context.AddAsync(creatingUser);
            await _context.SaveChangesAsync();
            return creatingUser.Id;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException(nameof(_context), userId);

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateAsync(Guid userId, string login, string email, string password, Guid roleId)
        //{
        //    var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId)
        //        ?? throw new NotFoundException(nameof(_context), userId);

        //    var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId)
        //        ?? throw new NotFoundException(nameof(_context), roleId);

        //    user.Login = login;
        //    user.Email = email;
        //    user.Password = CreateSHA256(password);
        //    user.RoleId = roleId;
        //    user.Role = role;

        //    _context.Update(user);
        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateAsync(Guid updatingUserId, User inputUser)
        {
            var updatingUser = await _context.Users.SingleOrDefaultAsync(user => user.Id == updatingUserId)
                ?? throw new NotFoundException(nameof(_context), updatingUserId);

            var role = await _context.Roles.SingleOrDefaultAsync(role => role.Id == inputUser.RoleId)
                ?? throw new NotFoundException(nameof(_context), inputUser.RoleId);

            updatingUser.Login = inputUser.Login;
            updatingUser.Email = inputUser.Email;
            updatingUser.Password = CreateSHA256(inputUser.Password);
            updatingUser.RoleId = role.Id;
            updatingUser.Role = role;

            _context.Update(updatingUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException(nameof(_context), userId);
            
            user.Role = _context.Roles.SingleOrDefault(r => r.Id == user.RoleId)
                ?? throw new NotFoundException(nameof(_context), user.RoleId);

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            foreach(var user in users)
            {
                user.Role = _context.Roles.SingleOrDefault(r => r.Id == user.RoleId)
                    ?? throw new NotFoundException(nameof(_context), user.RoleId);
            }
            return users;
        }


        private string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
    }
}
