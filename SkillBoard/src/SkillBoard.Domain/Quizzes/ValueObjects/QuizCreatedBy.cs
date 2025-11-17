namespace SkillBoard.Domain.Quizzes.ValueObjects;

public sealed class QuizCreatedBy
{
    public Guid Value { get; }
    
    public static QuizCreatedBy NewQuizId() => new(Guid.NewGuid());

    public static QuizCreatedBy FromValue(Guid value) => new(value); 
    
    private QuizCreatedBy(Guid value)
    {
        Value = value;
    }
}