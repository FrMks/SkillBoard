namespace SkillBoard.Domain.Questions;

public enum QuestionType
{
    /// <summary>
    /// Один ответ у вопроса.
    /// </summary>
    SingleChoice,
    
    /// <summary>
    /// Много ответов у вопроса.
    /// </summary>
    MultipleChoice,
}