using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.QuizResults.ValueObjects;

public sealed record PercentageScore
{
    public decimal Value { get; }

    public static Result<PercentageScore, Error> Calculate(int totalPoints, int maxPoints)
    {
        if (maxPoints == 0)
        {
            return Error.Validation(null, "Total points cannot be zero.");
        }

        var percentage = (decimal)totalPoints / maxPoints * 100;
        return new PercentageScore(Math.Round(percentage, 2));
    }
    
    private PercentageScore(decimal value)
    {
        Value = value;
    }
}
