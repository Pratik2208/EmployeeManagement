using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<Department>()
                 .HasMany(d => d.Employees)
                 .WithOne(e => e.Department)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
