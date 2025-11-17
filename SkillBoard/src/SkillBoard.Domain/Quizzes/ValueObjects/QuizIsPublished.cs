using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Quizzes.ValueObjects;

public sealed class QuizIsPublished
{
    public bool Value { get; }

    public Result<QuizIsPublished, Error> Create(bool input)
    {
        QuizIsPublished quizIsPublished = new(input);
        return Result.Success<QuizIsPublished, Error>(quizIsPublished);
    }

    private QuizIsPublished(bool value)
    {
        Value = value;
    }
}