using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Questions;
using SkillBoard.Domain.Quizzes.ValueObjects;

namespace SkillBoard.Domain.Quizzes;

public sealed class Quiz
{
    private readonly List<Question> _qustions = new();
    
    public QuizId Id { get; }
    
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
    
    public IReadOnlyCollection<Question> Questions => _qustions.AsReadOnly();

    public static Result<Quiz, Error> Create(QuizId quizId, QuizTitle title, DateTime deadline, QuizCreatedBy createdBy,
        QuizIsPublished isPublished)
    {
        Quiz quiz = new(quizId, title, deadline, createdBy, isPublished);

        return Result.Success<Quiz, Error>(quiz);
    }

    // EF Core
    private Quiz()
    {
    }

    private Quiz(QuizId id, QuizTitle title, DateTime deadline, QuizCreatedBy createdBy, QuizIsPublished isPublished)
    {
        Id = id;
        Title = title;
        Deadline = deadline;
        CreatedBy = createdBy;
        IsPublished = isPublished;
        CreatedAt = DateTime.UtcNow;
    }
}