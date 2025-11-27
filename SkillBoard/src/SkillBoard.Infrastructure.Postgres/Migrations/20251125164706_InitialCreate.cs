using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillBoard.Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quiz_results",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quiz_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    time_taken = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_points = table.Column<int>(type: "integer", nullable: false),
                    max_points = table.Column<int>(type: "integer", nullable: false),
                    percentage_score = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quiz_results", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    user_role = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creator_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_quizzes_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quiz_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    multiple_answers = table.Column<string[]>(type: "text[]", nullable: true),
                    single_answer = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    order_index = table.Column<int>(type: "integer", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_quizzes_quiz_id",
                        column: x => x.quiz_id,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    multiple_answers = table.Column<string[]>(type: "text[]", nullable: true),
                    single_answer = table.Column<string>(type: "text", nullable: true),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    points_earned = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    submitted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_quiz_id",
                table: "questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_UserId",
                table: "quizzes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "quiz_results");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
