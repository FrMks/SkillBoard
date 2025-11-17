using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Quiz.ValueObjects;
using SkillBoard.Domain.QuizAgregator.ValueObjects;

namespace SkillBoard.Domain.QuizAgregator;

public sealed class Quiz
{
    public QuizId QuizId { get; }
    
    public QuizTitle Title { get; }
    
    public DateTime Deadline { get; }
    
    /// <summary>
    /// Id пользователя, кто создал Quiz (тимлид).
    /// </summary>
    public QuizCreatedBy CreatedBy { get; }
    
    public DateTime CreatedAt { get; }
    
    /// <summary>
    /// Опубликован ли текст (черновик или активен)
    /// </summary>
    public QuizIsPublished IsPublished { get; }

    public static Result<Quiz> Create(QuizId quizId, QuizTitle title, DateTime deadline, QuizCreatedBy createdBy,
        QuizIsPublished isPublished)
    {
        Quiz quiz = new(quizId, title, deadline, createdBy, isPublished);

        return Result.Success(quiz);
    }

    // EF Core
    private Quiz(QuizId quizId, QuizTitle title, DateTime deadline, QuizCreatedBy createdBy, QuizIsPublished isPublished)
    {
        QuizId = quizId;
        Title = title;
        Deadline = deadline;
        CreatedBy = createdBy;
        IsPublished = isPublished;
        CreatedAt = DateTime.UtcNow;
    }
}