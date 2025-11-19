using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Answers.ValueObjects;
using SkillBoard.Domain.Questions.ValueObjects;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Domain.Answers;

public sealed class Answer
{
    public AnswerId Id { get; }
    
    public UserId UserId { get; }
    
    public QuestionId QuestionId { get; }
    
    public string[]? MultipleAnswers { get; }
    
    public string? SingleAnswer { get; }
    
    public AnswerIsCorrect IsCorrect { get; } 
    
    /// <summary>
    /// Сколько заработал пользователь. 0 если ответ неверный, Question.Points если верно.
    /// </summary>
    public AnswerPointsEarned PointsEarned { get; }
    
    public DateTime SubmittedAt { get; }

    public static Result<Answer, Error> Create(AnswerId id,
        UserId userId,
        QuestionId questionId,
        string[]? multipleAnswers,
        string? singleAnswer,
        AnswerIsCorrect isCorrect,
        AnswerPointsEarned pointsEarned)
    {
        if (multipleAnswers?.Length == 0 && string.IsNullOrWhiteSpace(singleAnswer))
            return Error.Validation(null, "Multiple answers should not be empty or single answer should not be empty.");

        Answer answer = new(id, userId, questionId, multipleAnswers, singleAnswer, isCorrect, pointsEarned);
        return Result.Success<Answer, Error>(answer);
    }
    
    // EF Core
    private Answer()
    {
    }

    private Answer(AnswerId id,
        UserId userId,
        QuestionId questionId,
        string[]? multipleAnswers,
        string? singleAnswer,
        AnswerIsCorrect isCorrect,
        AnswerPointsEarned pointsEarned)
    {
        Id = id;
        UserId = userId;
        QuestionId = questionId;
        MultipleAnswers = multipleAnswers;
        SingleAnswer = singleAnswer;
        IsCorrect = isCorrect;
        PointsEarned = pointsEarned;
        SubmittedAt = DateTime.UtcNow;
    }
}