using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Answers.ValueObjects;

public record AnswerIsCorrect
{
    public bool Value { get; }

    public static Result<AnswerIsCorrect, Error> Create(bool input)
    {
        AnswerIsCorrect answerIsCorrect = new(input);
        return Result.Success<AnswerIsCorrect, Error>(answerIsCorrect);
    }

    private AnswerIsCorrect(bool value)
    {
        Value = value;
    }
}