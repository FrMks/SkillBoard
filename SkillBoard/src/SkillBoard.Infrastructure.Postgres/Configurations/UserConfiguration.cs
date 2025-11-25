using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillBoard.Domain.Users;
using SkillBoard.Domain.Users.ValueObjects;
using SkillBoard.Domain.Quizzes;

namespace SkillBoard.Infrastructure.Postgres.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id).HasName("pk_users");

        builder.Property(u => u.Id)
            .HasConversion(id => id.Value, value => UserId.FromValue(value))
            .HasColumnName("id");

        builder.Property(u => u.UserName)
            .HasConversion(n => n.Value, value => UserName.Create(value).Value)
            .HasColumnName("username")
            .HasMaxLength(60);

        builder.Property(u => u.PasswordHash)
            .HasConversion(ph => ph.Value, value => PasswordHash.Create(value).Value)
            .HasColumnName("password_hash")
            .IsRequired();

        builder.Property(u => u.UserRole)
            .HasColumnName("user_role")
            .HasConversion<int>();

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at");

        builder
            .HasMany<Quiz>("_quizzes")
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(u => u.Quizzes)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}