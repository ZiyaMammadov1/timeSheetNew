using Microsoft.EntityFrameworkCore;
using TimeSheet.Entities;

namespace TimeSheet.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkType> WorkType { get; set; }
        public DbSet<mainTimeSheet> MainTimeSheets { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(a => a.fin)
                .IsUnique();

        }
    }
}
