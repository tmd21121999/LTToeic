using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreLTToeic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addexplanationandtotalquestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalListeningQuestions",
                table: "UserResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalReadingQuestions",
                table: "UserResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalListeningQuestions",
                table: "UserResults");

            migrationBuilder.DropColumn(
                name: "TotalReadingQuestions",
                table: "UserResults");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Questions");
        }
    }
}
