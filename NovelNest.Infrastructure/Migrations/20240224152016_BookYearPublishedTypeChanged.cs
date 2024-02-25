using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class BookYearPublishedTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "YearPublished",
                table: "Books",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                comment: "The date on which the cuurent Book was published");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearPublished",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The date on which the cuurent Book was published");
        }
    }
}
