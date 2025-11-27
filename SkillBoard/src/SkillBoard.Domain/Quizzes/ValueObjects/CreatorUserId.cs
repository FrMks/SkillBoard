namespace SkillBoard.Domain.Quizzes.ValueObjects;

public record CreatorUserId
{
    public Guid Value { get; }
    
    public static CreatorUserId NewQuizId() => new(Guid.NewGuid());

    public static CreatorUserId FromValue(Guid value) => new(value); 
    
    private CreatorUserId(Guid value)
    {
        Value = value;
    }
}