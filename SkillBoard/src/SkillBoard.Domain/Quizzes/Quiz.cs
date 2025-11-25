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
    /// Идентификатор пользователя, который создал тест. Предполагается, что это тимлид.
    /// </summary>
    public CreatorUserId CreatorUserId { get; }
    
    /// <summary>
    /// Опубликован ли текст (черновик или активен)
    /// </summary>
    public QuizIsPublished IsPublished { get; }
    
    public IReadOnlyCollection<Question> Questions => _qustions.AsReadOnly();

    public static Result<Quiz, Error> Create(
        QuizId id,
        QuizTitle title,
        DateTime deadline,
        QuizCreatedBy createdBy,
        QuizIsPublished isPublished,
        CreatorUserId creatorUserId)
    {
        Quiz quiz = new(id, title, deadline, createdBy, isPublished, creatorUserId);

        return Result.Success<Quiz, Error>(quiz);
    }

    // EF Core
    private Quiz(CreatorUserId creatorUserId)
    {
        CreatorUserId = creatorUserId;
    }

    private Quiz(
        QuizId id,
        QuizTitle title,
        DateTime deadline,
        QuizCreatedBy createdBy,
        QuizIsPublished isPublished,
        CreatorUserId creatorUserId)
    {
        Id = id;
        Title = title;
        Deadline = deadline;
        CreatedBy = createdBy;
        IsPublished = isPublished;
        CreatorUserId = creatorUserId;
        CreatedAt = DateTime.UtcNow;
    }
}