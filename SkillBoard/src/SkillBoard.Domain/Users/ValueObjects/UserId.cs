namespace SkillBoard.Domain.Users.ValueObjects;

public sealed class UserId
{
    public Guid Value { get; }
    
    public static UserId NewQuizId() => new(Guid.NewGuid());

    public static UserId FromValue(Guid value) => new(value); 
    
    private UserId(Guid value)
    {
        Value = value;
    }
}