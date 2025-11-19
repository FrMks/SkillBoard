namespace SkillBoard.Domain.QuizResults.ValueObjects;

public sealed record QuizResultId
{
    public Guid Value { get; }
    
    public static QuizResultId NewQuizId() => new(Guid.NewGuid());

    public static QuizResultId FromValue(Guid value) => new(value); 
    
    private QuizResultId(Guid value)
    {
        Value = value;
    }
}