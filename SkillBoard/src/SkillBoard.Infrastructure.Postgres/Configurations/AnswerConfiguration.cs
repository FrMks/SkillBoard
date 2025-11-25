using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillBoard.Domain.Answers;
using SkillBoard.Domain.Answers.ValueObjects;
using SkillBoard.Domain.Questions.ValueObjects;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Infrastructure.Postgres.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("answers");

        builder.HasKey(a => a.Id).HasName("pk_answers");

        builder.Property(a => a.Id)
            .HasConversion(id => id.Value, value => AnswerId.FromValue(value))
            .HasColumnName("id");

        builder.Property(a => a.UserId)
            .HasConversion(uid => uid.Value, value => UserId.FromValue(value))
            .HasColumnName("user_id");

        builder.Property(a => a.QuestionId)
            .HasConversion(qid => qid.Value, value => QuestionId.FromValue(value))
            .HasColumnName("question_id");

        builder.Property(a => a.MultipleAnswers)
            .HasColumnType("text[]")
            .HasColumnName("multiple_answers");

        builder.Property(a => a.SingleAnswer)
            .HasColumnName("single_answer");

        builder.Property(a => a.IsCorrect)
            .HasConversion(c => c.Value, value => AnswerIsCorrect.Create(value).Value)
            .HasColumnName("is_correct");

        builder.Property(a => a.PointsEarned)
            .HasConversion(p => p.Value, value => AnswerPointsEarned.Create(value).Value)
            .HasMaxLength(10)
            .HasColumnName("points_earned");

        builder.Property(a => a.SubmittedAt)
            .HasColumnName("submitted_at");
    }
}