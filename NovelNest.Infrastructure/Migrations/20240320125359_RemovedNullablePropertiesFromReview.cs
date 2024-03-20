using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class RemovedNullablePropertiesFromReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The current Book Review's Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The current Book Review's Title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BookReviews",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                defaultValue: "",
                comment: "The current Book Review's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldNullable: true,
                oldComment: "The current Book Review's Description");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BookReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The current Book Review's Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The current Book Review's Title");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BookReviews",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: true,
                comment: "The current Book Review's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000,
                oldComment: "The current Book Review's Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39dcc597-d053-432f-ba02-a9ee0ca240c8", "AQAAAAEAACcQAAAAECStrDchWt9S9Xz9O8D7FtPrO9+csBMkm+dYoJwaJq0Cq3DvUsmi51MO58N7zmCKiA==", "44c49be2-fe4b-4fef-8f8d-f42f8b6f434b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3376c37d-4757-4b5a-897d-06c3d00d7ba3", "AQAAAAEAACcQAAAAENMFj8rClCDtdA+9L/tTWgDm0eWHl4TLuaddxAI010nd8haqCxlRRbE6Kauo22RFnw==", "e17d8341-5f89-4ce3-aac3-7c48b1b247d8" });
        }
    }
}