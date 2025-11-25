using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Questions.ValueObjects;

public sealed record QuestionOrderIndex
{
    public int Value { get; }

    public static Result<QuestionOrderIndex, Error> Create(int input)
    {
        if (input <= 1)
            return Error.Validation(null, "Question order index must be greater than 1");

        QuestionOrderIndex questionOrderIndex = new(input);

        return Result.Success<QuestionOrderIndex, Error>(questionOrderIndex);
    }

    private QuestionOrderIndex(int value)
    {
        Value = value;
    }
}