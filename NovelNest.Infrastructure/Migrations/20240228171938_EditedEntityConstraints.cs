using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class EditedEntityConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The current Event's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "The current Event's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "The current Event's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "The current Event's Description");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "BookStores",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The current BookStore's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "The current BookStore's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The current Article's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "The current Article's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                comment: "The current Article's Content",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "The current Article's Content");

            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Article's Views Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "The current Event's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "The current Event's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The current Event's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "The current Event's Description");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "BookStores",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "The current BookStore's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "The current BookStore's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Articles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "The current Article's Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "The current Article's Image Url");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "The current Article's Content",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000,
                oldComment: "The current Article's Content");
        }
    }
}
