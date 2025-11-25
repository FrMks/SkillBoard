using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Users.ValueObjects;

public record PasswordHash
{
    public string Value { get; }

    public static Result<PasswordHash, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Error.Validation(null, "Password hash cannot be null or empty.");

        return new PasswordHash(input);
    }

    private PasswordHash(string value)
    {
        Value = value;   
    }
}