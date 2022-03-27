using Microsoft.EntityFrameworkCore;

namespace EdtechSolution.Domain;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
}