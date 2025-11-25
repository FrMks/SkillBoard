using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Questions.ValueObjects;

public sealed record QuestionText
{
    public string Value { get; }

    public static Result<QuestionText, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Error.Validation(null, "Question text cannot be empty");
        
        var trimmed = input.Trim();
        
        QuestionText questionText = new(trimmed);

        return Result.Success<QuestionText, Error>(questionText);
    }

    private QuestionText(string value)
    {
        Value = value;
    }
}