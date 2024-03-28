using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class ArticleCommentDescriptionLengthMinimized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ArticleComments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "The current Article Comment's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldComment: "The current Article Comment's Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fc11dd2-61f2-4598-a56e-17e888b37a71", "AQAAAAEAACcQAAAAEBSLeOTPCYcojy0w9dxQ4a1EYXBxa3J+SzKmN4tigD3w1GzoOzMVOlFgC34eQvSdWg==", "7992ca43-ca96-4342-a114-2d8a5b77ffa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e8ac6a3-902d-47d3-b895-b466de10c5e1", "AQAAAAEAACcQAAAAEASUee2fyL7minld4FNTceZku4W08J1ZFtT1bFfkrPD0rFkW+S3sfddTkw6G8zSM+A==", "38b34f59-7bde-4717-91f8-af96ebe74117" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ArticleComments",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                comment: "The current Article Comment's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "The current Article Comment's Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc086dc-2c2b-470c-817b-d7b34b6c1662", "AQAAAAEAACcQAAAAEDOISqFr5k7Pa7Q0PH4WtIaEUADpihNO4EcpkvgJ8X8r1m6l0zzb9s5Di36JgnHERA==", "7dbae72b-7b65-4305-9201-7dd101cec7d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00931b13-c44d-4d92-9843-50d0396c898d", "AQAAAAEAACcQAAAAEFB0pYh5owJVnoaBgBRev0rbxumSHexxtumaujUjzqChB4W0cGUrRbcctP619q0Ykw==", "1524e83b-7a2a-4c7f-8c62-84266784b153" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
