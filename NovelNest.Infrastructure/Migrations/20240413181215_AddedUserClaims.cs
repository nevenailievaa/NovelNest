using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedUserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin Adminov", "c2f14bf7-ffdd-47a4-90b3-f2309486fae9" },
                    { 2, "user:fullname", "Publisher Publishov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 3, "user:fullname", "Guest Guestov", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a724c20-fa08-448e-870d-bb7100d8f2c3", "AQAAAAEAACcQAAAAEOKJOgPYRYCGyAx71xbURXRhgYhufnUnt/FiZpFshiEFYLZHPBcaJXyMd70em3oK+Q==", "f7adb999-1ab8-423d-b91f-658a907647c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5df97f94-d628-44ab-8d9b-1d0a72ff59ce", "AQAAAAEAACcQAAAAEMrAUnsH896/9c4tDPW+/zMn/yBYMnlQUyP+SjzHCgWOl4tlBJWM/LOT/5Av5SYKLg==", "7a874a54-40aa-4ed3-9a63-46d8f190247b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b61a75-f376-4081-9751-a52156672960", "AQAAAAEAACcQAAAAEGLehkkvrJDNMOp/omR0ifDDkiVimNGEjfOKzLOJH4jNighsLkyNqUBtXjB+I0o6sw==", "0d15ff89-ae1e-4af4-8c72-57fe1e5397e3" });

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
    }
}
