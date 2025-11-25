using Microsoft.EntityFrameworkCore;
using SkillBoard.Domain.Answers;
using SkillBoard.Domain.Questions;
using SkillBoard.Domain.QuizResults;
using SkillBoard.Domain.Quizzes;
using SkillBoard.Domain.Users;

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

    public DbSet<Quiz> Quizes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<User> Users => Set<User>();
    public DbSet<QuizResult> QuizResults => Set<QuizResult>();
}