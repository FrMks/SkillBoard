using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Domain.Users;

public class User
{
    public UserId Id { get; }
    
    public UserName UserName { get; }
    
    public PasswordHash PasswordHash { get; }
    
    public UserRole UserRole { get; }
    
    public DateTime CreatedAt { get; }
    
    public static Result<User, Error> Create(UserId id,
        UserName userName,
        PasswordHash passwordHash,
        UserRole userRole)
    {
        User user = new(id, userName, passwordHash, userRole);

        return Result.Success<User, Error>(user);
    }
    
    // EF Core
    private User()
    {
    }
    
    private User(UserId id,
        UserName userName,
        PasswordHash passwordHash,
        UserRole userRole)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        UserRole = userRole;
        CreatedAt = DateTime.UtcNow;
    }
}