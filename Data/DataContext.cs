using GESTIONES.Models;
using GESTIONES.Models;
using Microsoft.EntityFrameworkCore;

namespace GESTIONES.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<deporte> Deportes { get; set; }
    public DbSet<User> Users { get; set; }
     public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<deporte>().ToTable("Deportes");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Loan>().ToTable("Loans");
    }
}