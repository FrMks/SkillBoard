using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillBoard.Domain.QuizResults;
using SkillBoard.Domain.QuizResults.ValueObjects;
using SkillBoard.Domain.Quizzes.ValueObjects;
using SkillBoard.Domain.Users.ValueObjects;

namespace SkillBoard.Infrastructure.Postgres.Configurations;

public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder.ToTable("quiz_results");

        builder.HasKey(qr => qr.Id).HasName("pk_quiz_results");

        builder.Property(qr => qr.Id)
            .HasConversion(
                id => id.Value, 
                value => QuizResultId.FromValue(value))
            .HasColumnName("id");

        builder.Property(qr => qr.QuizId)
            .HasConversion(
                qid => qid.Value, 
                value => QuizId.FromValue(value))
            .HasColumnName("quiz_id");

        builder.Property(qr => qr.UserId)
            .HasConversion(
                uid => uid.Value, 
                value => UserId.FromValue(value))
            .HasColumnName("user_id");

        builder.Property(qr => qr.TimeTaken)
            .HasColumnName("time_taken");

        builder.Property(qr => qr.CompletedAt)
            .HasColumnName("completed_at");

        builder.Property(qr => qr.TotalPoints)
            .HasColumnName("total_points");

        builder.Property(qr => qr.MaxPoints)
            .HasColumnName("max_points");

        builder.Property(qr => qr.PercentageScore)
            .HasConversion(
                ps => ps.Value, 
                value => PercentageScore.FromValue(value))
            .HasColumnName("percentage_score");
    }
}