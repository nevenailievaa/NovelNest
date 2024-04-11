using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de249fab-4e52-4a6a-9100-b84ffb131128", "", "", "AQAAAAEAACcQAAAAELWG+MnzSRaZWHdDi3a7aY6EQLK2G+70tDSU1QuTkaevAJLlEUm6J8NPpf5T+7C/pw==", "46b296ec-09d8-4fb8-8507-ae11331e312f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f3a070-e27e-40e1-b7b5-c85aaa73b199", "", "", "AQAAAAEAACcQAAAAEHIbopizn89Eiz7+7pMJHHiLoalJrA7OWlhWH8z2XPbU3TbRhNtfEMFIZmxQsa5OhQ==", "bdd9a056-8293-476d-85c3-68d7ab864a37" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 11, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 11, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
        }
    }
}
