using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedWorkingTimeToTheBookStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingTime",
                table: "BookStores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The current BookStore's Closing Time");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningTime",
                table: "BookStores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The current BookStore's Opening Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "BookStores");
        }
    }
}
