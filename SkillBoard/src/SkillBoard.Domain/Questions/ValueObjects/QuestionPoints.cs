using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Questions.ValueObjects;

public sealed record QuestionPoints
{
    public int Value { get; }

    public static Result<QuestionPoints, Error> Create(int input)
    {
        if (input <= 0 || input > 10)
            return Error.Validation(null, "Question points cannot be zero or negative and more than 10.");

        QuestionPoints questionPoints = new(input);

        return Result.Success<QuestionPoints, Error>(questionPoints);
    }

    private QuestionPoints(int value)
    {
        Value = value;
    }
}