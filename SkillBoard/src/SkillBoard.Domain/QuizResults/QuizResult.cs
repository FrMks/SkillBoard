using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.QuizResults.ValueObjects;
using SkillBoard.Domain.Quizzes.ValueObjects;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Domain.QuizResults;

public sealed class QuizResult
{
    public QuizResultId Id { get; }
    
    public QuizId QuizId { get; }
    
    public UserId UserId { get; }
    
    public DateTime TimeTaken { get; }
    
    public DateTime CompletedAt { get; }
    
    public int TotalPoints { get; }
    
    public int MaxPoints { get; }
    
    public PercentageScore PercentageScore { get; }
    
    /// <summary>
    /// Процент правильный ответов (TotalPoints / MaxPoints * 100)
    /// </summary>
    public double PercentageScope { get; }
    
    public static Result<QuizResult, Error> Create(QuizResultId id,
        QuizId quizId,
        UserId userId,
        DateTime timeTaken,
        int totalPoints,
        int maxPoints)
    {
        PercentageScore.Calculate(totalPoints, maxPoints);

        QuizResult quizResult = new(id, quizId, userId, timeTaken, totalPoints, maxPoints);

        return Result.Success<QuizResult, Error>(quizResult);
    }
    
    // EF Core
    // private QuizResult()
    // {
    // }
    
    private QuizResult(QuizResultId id,
        QuizId quizId,
        UserId userId,
        DateTime timeTaken,
        int totalPoints,
        int maxPoints)
    {
        Id = id;
        QuizId = quizId;
        UserId = userId;
        TimeTaken = timeTaken;
        TotalPoints = totalPoints;
        MaxPoints = maxPoints;
        CompletedAt = DateTime.UtcNow;
    }
}