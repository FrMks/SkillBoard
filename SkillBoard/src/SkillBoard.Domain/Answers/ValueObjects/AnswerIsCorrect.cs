using CSharpFunctionalExtensions;
using Shared;

namespace SkillBoard.Domain.Answers.ValueObjects;

public class AnswerIsCorrect
{
    public bool Value { get; }

    public Result<AnswerIsCorrect, Error> Create(bool input)
    {
        AnswerIsCorrect answerIsCorrect = new(input);
        return Result.Success<AnswerIsCorrect, Error>(answerIsCorrect);
    }

    private AnswerIsCorrect(bool value)
    {
        Value = value;
    }
}