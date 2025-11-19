using CSharpFunctionalExtensions;
using Shared;
using SkillBoard.Domain.Quizzes.ValueObjects;

namespace SkillBoard.Domain.Users.ValueObjects;

public sealed record UserName
{
    public string Value { get; }

    public Result<UserName, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Error.Validation(null, "Quiz title cannot be empty.");
        
        string trimmed = input.Trim();
        
        if (trimmed.Length is > LengthConstants.LENGTH60)
            return Error.Validation("lenght.is.invalid", "Location name cannot be less than 3 symbols and more than 120 characters");

        UserName userName = new(trimmed);

        return Result.Success<UserName, Error>(userName);
    }

    private UserName(string value)
    {
        Value = value;
    }
}