using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class EditedYearPublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearPublished",
                table: "Books",
                type: "int",
                nullable: false,
                comment: "The date on which the current Book was published",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldComment: "The date on which the current Book was published");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YearPublished",
                table: "Books",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                comment: "The date on which the cuurent Book was published",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The date on which the cuurent Book was published");
        }
    }
}
