using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infrastructure.DBConnection
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Goal> Goals => Set<Goal>();
        public DbSet<Role> Roles => Set<Role>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
