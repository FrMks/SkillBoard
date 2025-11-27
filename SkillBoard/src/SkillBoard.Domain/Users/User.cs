using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Quizzes;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Domain.Users;

public class User
{
    private readonly List<Quiz> _quizzes = new();
    
    public UserId Id { get; }
    
    public UserName UserName { get; }
    
    public PasswordHash PasswordHash { get; }
    
    public UserRole UserRole { get; }
    
    public DateTime CreatedAt { get; }
    
    public IReadOnlyCollection<Quiz>? Quizzes => _quizzes.AsReadOnly();
    
    public static Result<User, Error> Create(UserId id,
        UserName userName,
        PasswordHash passwordHash,
        UserRole userRole,
        IEnumerable<Quiz>? quizzes = null)
    {
        User user = new(id, userName, passwordHash, userRole, quizzes);

        return Result.Success<User, Error>(user);
    }
    
    // EF Core
    private User()
    {
    }
    
    private User(UserId id,
        UserName userName,
        PasswordHash passwordHash,
        UserRole userRole,
        IEnumerable<Quiz>? quizzes = null)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        UserRole = userRole;
        CreatedAt = DateTime.UtcNow;
        if (quizzes != null)
            _quizzes.AddRange(quizzes);
    }
}