using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class EditedReviewDescriptionLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BookReviews",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: true,
                comment: "The current Book Review's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BookReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
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
                values: new object[] { "47e76325-6e99-448e-8b9b-e9d419c36ff4", "AQAAAAEAACcQAAAAEPpmcOiXHjUm1zUvOStwxXCdOgOLRI2n7hmrbQm19KYYBt7p2qD1ihsdHh96P21FPA==", "a3b3d52c-85aa-485f-a5c9-6b87e8dd7dcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2ea31e1-057a-4bc2-9423-e1d60f4bedec", "AQAAAAEAACcQAAAAEDppcqFRlfP+caSHmcmTtjxRmywLLHbSToP8mYxdKpAme2Ex+cU5yODS3tYIOc5RLg==", "f04aa454-e819-4307-8f10-e84b3746d291" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 2, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 2, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 2, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
