using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Quizzes.ValueObjects;

public sealed record QuizTitle
{
    public string Value { get; }

    public static Result<QuizTitle, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Error.Validation(null, "Quiz title cannot be empty.");
        
        string trimmed = input.Trim();
        
        if (trimmed.Length is > LengthConstants.LENGTH60)
            return Error.Validation("lenght.is.invalid", "Location name cannot be less than 3 symbols and more than 120 characters");

        QuizTitle quizTitle = new(trimmed);

        return Result.Success<QuizTitle, Error>(quizTitle);
    }

    private QuizTitle(string value)
    {
        Value = value;
    }
}