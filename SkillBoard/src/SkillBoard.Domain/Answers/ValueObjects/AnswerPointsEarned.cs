using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Answers.ValueObjects;

public record class AnswerPointsEarned
{
    public int Value { get; }

    public Result<AnswerPointsEarned, Error> Create(int input)
    {
        if (input <= 0 || input > 10)
            return Error.Validation(null, "Answer points earned cannot be zero or negative and more than 10.");

        AnswerPointsEarned answerPointsEarned = new(input);

        return Result.Success<AnswerPointsEarned, Error>(answerPointsEarned);
    }

    private AnswerPointsEarned(int value)
    {
        Value = value;
    }
}