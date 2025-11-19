namespace SkillBoard.Domain.Quizzes.ValueObjects;

public sealed record QuizId
{
    public Guid Value { get; }
    
    public static QuizId NewQuizId() => new(Guid.NewGuid());

    public static QuizId FromValue(Guid value) => new(value); 
    
    private QuizId(Guid value)
    {
        Value = value;
    }
}