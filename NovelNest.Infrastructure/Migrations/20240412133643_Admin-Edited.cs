using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AdminEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa338669-b58c-4e42-8d31-4062875ec6d1", "AQAAAAEAACcQAAAAEK+MAsHQe5LDFBwxQL8DlZpFjAHmNLMtRubbFfvLfULxTgDkmMgd+E6tsqM4K5voWg==", "e9e3b6ea-4a14-4cb8-8db8-a54a6c231afc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dabc723-5f09-4783-98b8-fb69675439ba", "AQAAAAEAACcQAAAAEME7pPxbbUSqMjw4ZQxSOt6RZ4YFGWNYLBmNepZ2P40YRur8mrqnnD0QZ0n/PKpapA==", "5ec90344-afe5-4a87-aa3c-5adc14266fdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fba7de3-d47f-4fbf-ba7d-a7bc9e12b1b8", "AQAAAAEAACcQAAAAEFJHuXrSK9htUucSuwixIWrNbNpKHX0mXI6hq4oZ3GXl4kamOqArTlcnfgBx1rk1LQ==", "26122028-1d0d-4135-8e56-e0af63d9c4df" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 12, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75d905cd-911b-48b8-9f85-be643b8cfbe3", "AQAAAAEAACcQAAAAEALa2j1jo71VeXGw9CQ6Ps2p4aoD/Jq7oDvvfq8czCmzTOePkxs1H8ckIDMEYBZt/w==", "a258d0dd-06f2-4061-b84c-af29aa54688a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3209f9af-b7f1-4355-a007-6d266a0e850c", "AQAAAAEAACcQAAAAENxr7apVTG+9fAEo87+Aw361hcCSZqL9Kdut9bE/PwwHbaxd36xdE1zEleTMKqpiYw==", "1ecd3d2f-ced2-4b43-8548-dda9ec358768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "386a0cac-42a7-426c-a4a4-bda89fd32002", "AQAAAAEAACcQAAAAEMMGJVk1CpnRXsCl/N0fISicha5k6B7R9Bc6CMZNKUyswUzSEW8qiwKroNrUvUqS/A==", "896d00b4-2b9b-4c08-be13-0aada9e3e71a" });

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
    }
}
