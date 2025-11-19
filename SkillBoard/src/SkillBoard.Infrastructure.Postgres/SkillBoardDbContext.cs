using Microsoft.EntityFrameworkCore;

namespace SkillBoard.Infrastructure.Postgres;

public class SkillBoardDbContext : DbContext
{
    private readonly string _connectionString;

    public SkillBoardDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString); // Используй Npgsql в качестве бд
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillBoardDbContext).Assembly);
    }

    // public DbSet<Location> Locations => Set<Location>();
    // public DbSet<DepartmentLocation> DepartmentLocations => Set<DepartmentLocation>();
    // public DbSet<Department> Departments => Set<Department>();
    // public DbSet<Position> Positions => Set<Position>();
    // public DbSet<DepartmentPosition> DepartmentPositions => Set<DepartmentPosition>();
}