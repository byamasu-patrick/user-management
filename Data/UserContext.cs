using MassTransit.Internals.GraphValidation;
using Microsoft.EntityFrameworkCore;
using UserManagement.Entities;

namespace UserManagement.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>();
        }
    }
}
