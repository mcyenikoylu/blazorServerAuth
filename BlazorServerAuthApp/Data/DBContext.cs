using Microsoft.EntityFrameworkCore;

namespace BlazorServerAuthApp;

public class DBContext : DbContext
{

    public DbSet<UserAccount>? EmployeesDbSet { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseCosmos(
            "https://myapp-license-db.documents.azure.com:443/",
            "pvLGdvW1PYgSQmGijbn3OeX6KWy9Un0tkWHQzjfYfAtqcamJ6KJkGVAb5AEPXDsPEYS1UPpfXMZJACDbgXHHwg==",
            "myapp-license-db"
        ));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>()
        .ToContainer("Employees")
        .HasPartitionKey(a => a.categoryId);
    }
}