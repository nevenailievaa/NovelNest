using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class MoreGenresSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "822aafa1-a934-46cc-acfd-736b5343040b", "AQAAAAEAACcQAAAAEGnvIl4V0xakz9cyfldfiegRY2U4ueTNAopBrXelsn14pHR4VupYsRbAkID6fM0Oew==", "ccc37d36-957b-48ce-b11a-0419bedd80fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fba58968-7c4c-4f63-98cf-c59ec62684cd", "AQAAAAEAACcQAAAAENFC1MyiS4ANh8wcZ6CaQBaBCIbTr2FxRbaksBJV4LTnha3VxBzv2mtMae8oQnNRMQ==", "3929b346-76ea-4ed4-8dbc-8393cc6ec121" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09d5b7ad-3e06-4da6-b632-25f67572c50a", "AQAAAAEAACcQAAAAEB+plFpgI3r0XCjnKv4uihVURWohAZLM6PzCSYeIgGSVAS/tBazL1RjVR66HgrXATQ==", "8502b394-96de-40ce-b104-f3173ed55d08" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 14, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Художествена Измислица" },
                    { 14, "Драма" },
                    { 15, "Военни" },
                    { 16, "История" },
                    { 17, "Философия" },
                    { 18, "Бизнес" },
                    { 19, "Наука" },
                    { 20, "Здраве" },
                    { 21, "Кулинарни" },
                    { 22, "Пътувания" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9992bc9c-75ea-43f3-9ed5-8266999dd8f8", "AQAAAAEAACcQAAAAEP7cmUnx2Vz1OzyygezASMWes/3OE9hA3WT/L98f3LNosY0NU+CgzMuNKxBYhnmqaw==", "68db502f-c277-4b6a-b8a4-c4a9946b83e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "948f68e3-9464-4bd8-a434-7ec745ba2839", "AQAAAAEAACcQAAAAEMH0ESmGzXxEBIgKbwtOedEvZmoFA/nZ6XiAzhvS361/V7pIMinCKr7xQb+lNTm/Iw==", "0a33b56b-6062-4ad0-944f-cdbb61bbc4d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dc5f91b-1e17-4540-8a48-e43ea3a84c1a", "AQAAAAEAACcQAAAAEHdd1bQJMO18qMuU1OLkYrrcwguQSL11tLOZ9igY1AuQGgRp2iTFRWE9zZEc1J6yQw==", "d477d84c-22d9-4342-9aed-f5af7bf0dc68" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 13, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
