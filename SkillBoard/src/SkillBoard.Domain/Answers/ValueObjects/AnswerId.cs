namespace SkillBoard.Domain.Answers.ValueObjects;

public sealed class AnswerId
{
    public Guid Value { get; }
    
    public static AnswerId NewQuizId() => new(Guid.NewGuid());

    public static AnswerId FromValue(Guid value) => new(value); 
    
    private AnswerId(Guid value)
    {
        Value = value;
    }
}