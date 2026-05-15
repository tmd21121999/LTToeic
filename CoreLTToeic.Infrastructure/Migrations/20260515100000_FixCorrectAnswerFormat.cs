using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreLTToeic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCorrectAnswerFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Fix seeded data: "(A)" → "A", "(B)" → "B", etc.
            migrationBuilder.Sql(@"
                UPDATE Questions
                SET CorrectAnswer = SUBSTRING(CorrectAnswer, 2, 1)
                WHERE CorrectAnswer LIKE '(_)'
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Questions
                SET CorrectAnswer = '(' + CorrectAnswer + ')'
                WHERE CorrectAnswer IN ('A','B','C','D')
            ");
        }
    }
}
