using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillBoard.Domain.Questions;
using SkillBoard.Domain.Quizzes;
using SkillBoard.Domain.Quizzes.ValueObjects;

namespace SkillBoard.Infrastructure.Postgres.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("quizzes");

        builder.HasKey(q => q.Id).HasName("pk_quizzes");

        builder.Property(q => q.Id)
            .HasConversion(id => id.Value, value => QuizId.FromValue(value))
            .HasColumnName("id");

        builder.Property(q => q.Title)
            .HasConversion(title => title.Value, value => QuizTitle.Create(value).Value)
            .HasColumnName("title")
            .HasMaxLength(60);

        builder.Property(q => q.Deadline)
            .HasColumnName("deadline");

        builder.Property(q => q.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(q => q.CreatedBy)
            .HasConversion(createdBy => createdBy.Value, value => QuizCreatedBy.FromValue(value))
            .HasColumnName("created_by");

        builder.Property(q => q.CreatorUserId)
            .HasConversion(cuid => cuid.Value, value => CreatorUserId.FromValue(value))
            .HasColumnName("creator_user_id");

        builder.Property(q => q.IsPublished)
            .HasConversion(ip => ip.Value, value => QuizIsPublished.Create(value).Value)
            .HasColumnName("is_published");

        builder.HasMany(q => q.Questions)
            .WithOne()
            .HasForeignKey("QuizId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata
            .FindNavigation(nameof(Quiz.Questions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}