using APi2.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API2.Infra.Repository.Context;

public class EmployeeContext(DbContextOptions<EmployeeContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Anish Aravind", Position = "Software Engineer" },
            new Employee { Id = 2, Name = "Jiya Anish", Position = "Product Manager" }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}