using Microsoft.EntityFrameworkCore;
using Domain.Infrastructure.DBConnection;
using Domain.Models;
using TaskManager_API.Interfaces;
using System.Text;
using System.Security.Cryptography;

namespace TaskManager_API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(string login, string email, string password, Guid roleId)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId); //TODO NFexception

            var user = new User();
            user.Login = login;
            user.Email = email;
            user.Password = CreateSHA256(password);
            user.RoleId = roleId;
            user.Role = role;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId); //TODO NFexception

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid userId, string login, string email, string password, Guid roleId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId); //TODO NFexception

            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId); //TODO NFexception

            user.Login = login;
            user.Email = email;
            user.Password = CreateSHA256(password);
            user.RoleId = roleId;
            user.Role = role;

            _context.Update(user);
            await _context.SaveChangesAsync();
        }



        private string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
    }
}
