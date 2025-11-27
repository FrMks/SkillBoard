using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillBoard.Domain.Answers;
using SkillBoard.Domain.Questions;
using SkillBoard.Domain.Questions.ValueObjects;
using SkillBoard.Domain.Quizzes.ValueObjects;

namespace SkillBoard.Infrastructure.Postgres.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.HasKey(q => q.Id).HasName("pk_questions");

        builder.Property(q => q.Id)
            .HasConversion(id => id.Value, value => QuestionId.FromValue(value))
            .HasColumnName("id");

        builder.Property(q => q.QuizId)
            .HasConversion(qzid => qzid.Value, value => QuizId.FromValue(value))
            .HasColumnName("quiz_id");

        builder.Property(q => q.Type)
            .HasColumnName("type")
            .HasConversion<int>();

        builder.Property(q => q.MultipleAnswers)
            .HasColumnType("text[]")
            .HasColumnName("multiple_answers");

        builder.Property(q => q.SingleAnswer)
            .HasColumnName("single_answer");

        builder.Property(q => q.Points)
            .HasConversion(p => p.Value, value => QuestionPoints.Create(value).Value)
            .HasMaxLength(10)
            .HasColumnName("points");

        builder.Property(q => q.OrderIndex)
            .HasConversion(o => o.Value, value => QuestionOrderIndex.Create(value).Value)
            .HasColumnName("order_index");

        builder.Property(q => q.QuestionText)
            .HasConversion(qt => qt.Value, value => QuestionText.Create(value).Value)
            .HasColumnName("question_text");

        builder.HasMany(q => q.Answers)
            .WithOne()
            .HasForeignKey("QuestionId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata
            .FindNavigation(nameof(Question.Answers))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
