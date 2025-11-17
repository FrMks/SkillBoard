using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Answers;
using SkillBoard.Domain.Questions.ValueObjects;
using SkillBoard.Domain.Quizzes.ValueObjects;

namespace SkillBoard.Domain.Questions;

public sealed class Question
{
    private readonly List<Answer> _answers = new();
    
    public QuestionId Id { get; }
    
    public QuizId QuizId { get; }
    
    public QuestionType Type { get; }
    
    public string[]? MultipleAnswers { get; }
    
    public string? SingleAnswer { get; }
    
    /// <summary>
    /// Сколько баллов за правильный ответ.
    /// </summary>
    public QuestionPoints Points { get; }
    
    /// <summary>
    /// Порядковый номер вопроса в тесте.
    /// </summary>
    public QuestionOrderIndex OrderIndex { get; }
    
    public QuestionText QuestionText { get; }
    
    public IReadOnlyCollection<Answer> Answers => _answers.AsReadOnly();
    
    public static Result<Question, Error> Create(QuestionId id, QuizId quizId, QuestionType type, string[]? multipleAnswers, string? singleAnswer, QuestionPoints points, QuestionOrderIndex orderIndex, QuestionText questionText)
    {
        if (multipleAnswers?.Length == 0 && string.IsNullOrWhiteSpace(singleAnswer))
            return Error.Validation(null, "Multiple answers should not be empty or single answer should not be empty.");

        Question question = new(id, quizId, type, multipleAnswers, singleAnswer, points, orderIndex, questionText);
        
        return Result.Success<Question, Error>(question);
    }

    // EF Core
    private Question()
    {
    }
    
    private Question(QuestionId id, QuizId quizId, QuestionType type, string[]? multipleAnswers, string? singleAnswer, QuestionPoints points, QuestionOrderIndex orderIndex, QuestionText questionText)
    {
        Id = id;
        QuizId = quizId;
        Type = type;
        MultipleAnswers = multipleAnswers;
        SingleAnswer = singleAnswer;
        Points = points;
        OrderIndex = orderIndex;
        QuestionText = questionText;
    }
}