namespace SkillBoard.Domain.Questions.ValueObjects;

public sealed record QuestionId
{
    public Guid Value { get; }
    
    public static QuestionId NewQuizId() => new(Guid.NewGuid());

    public static QuestionId FromValue(Guid value) => new(value); 
    
    private QuestionId(Guid value)
    {
        Value = value;
    }
}