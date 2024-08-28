using AcademyApplication.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademyApplication.DataAccess.Data
{
    public class AcademyAppDbContext : DbContext
    {
        public AcademyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
