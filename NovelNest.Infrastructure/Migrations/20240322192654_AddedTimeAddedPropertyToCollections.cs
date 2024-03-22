using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedTimeAddedPropertyToCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAdded",
                table: "BooksUsersWantToRead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The time when the entity was added");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAdded",
                table: "BooksUsersRead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The time when the entity was added");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentPage",
                table: "BooksUsersCurrentlyReading",
                type: "int",
                nullable: false,
                comment: "The Page the User is on to",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAdded",
                table: "BooksUsersCurrentlyReading",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The time when the entity was added");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "740b2e32-ce11-4546-b3a3-bfb1d365705f", "AQAAAAEAACcQAAAAELh8RewMHelwEoethqf9VUjv87cfBE1zCBGB1gkGKazYhge07QE1R+DGPHLBXvfFNA==", "f11054ff-863f-4e74-9b4c-0e859b055e48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65244e87-ba44-41a3-ba7c-a51802db725e", "AQAAAAEAACcQAAAAEDm37ljiwYEb+Ic50ehIUMSDAJOZXx8a0tcyWPtRR0g/1qJaGAtuYL+kdlwM9OMROg==", "8af549a9-5f08-4e9c-985b-e83a59f9e98e" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeAdded",
                table: "BooksUsersWantToRead");

            migrationBuilder.DropColumn(
                name: "TimeAdded",
                table: "BooksUsersRead");

            migrationBuilder.DropColumn(
                name: "TimeAdded",
                table: "BooksUsersCurrentlyReading");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentPage",
                table: "BooksUsersCurrentlyReading",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The Page the User is on to");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d001a6e8-6eb4-444d-a9bb-fbaba38acc2f", "AQAAAAEAACcQAAAAEJz+O01eP6F+jM8gCEYA966VB1soDEoChLMXD6uJtHDQJoxGLA9SxdHr0YriuPs09g==", "1bdfd1e1-6b91-4821-9c1e-1f26d70b84f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20949a3c-9333-42c2-badc-6fae1b101162", "AQAAAAEAACcQAAAAEB3l0FT/LKW4F8pFyHXE+6bYc95zvf4eTmdOG+JU6el2eqPmVdaxZLFA6hBCMKhU1w==", "c597ac2b-d95a-48af-b85a-0f1bbbcbaa1f" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}