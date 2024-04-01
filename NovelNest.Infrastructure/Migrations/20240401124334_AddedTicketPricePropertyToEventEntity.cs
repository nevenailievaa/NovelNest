using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedTicketPricePropertyToEventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Events",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "The current Event's Ticket Price");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c9e2314-aa85-4cd3-8cb4-051c4a5fc001", "AQAAAAEAACcQAAAAECN0cVUwgOwEQZM9pBQwLJIXUGKpHk6QEhhS4NOTWwJfLZS4vAvZ7gpM5Jd7JA1mLg==", "daf513bc-16d9-470e-9010-8ccf17cea50e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1de4fc4d-8a90-434d-a2ad-f50dca6584c4", "AQAAAAEAACcQAAAAEJos1hEXVDNvqOUaIHFMGPpLyqBvNUMELUuuTCfhak/ZpQE79iMh7Yu4Ajm4OMqpPQ==", "07825e95-eb31-4f3d-af44-a4d22eab48cd" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketPrice",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "TicketPrice",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "TicketPrice",
                value: 10m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "157a2d22-95a6-449b-b5c4-4b15b2df05e1", "AQAAAAEAACcQAAAAEBPw6eHLEzZTfOkcy+nlfeFvGBCgicDQ7pIiesc/SV+i2Ucj6Kr5GQ3CzSvB4tfu0w==", "bcb0a7b7-356e-4e43-a344-e22e8537f23a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e22a8847-65eb-4f1b-a65f-1636a0c3d1ab", "AQAAAAEAACcQAAAAEItDU4Y/g7odhaArgyqenbL9qpeFtlAD5yoB0yTQ+7BNDFNOAbHJQ7VbnaWLsU3f1w==", "2d3124e4-dc60-4faf-a5a9-c82c5517ea90" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
