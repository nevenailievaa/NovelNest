using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeedDbChangedUserNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6a724c20-fa08-448e-870d-bb7100d8f2c3", "GUEST@GMAIL.COM", "AQAAAAEAACcQAAAAEOKJOgPYRYCGyAx71xbURXRhgYhufnUnt/FiZpFshiEFYLZHPBcaJXyMd70em3oK+Q==", "f7adb999-1ab8-423d-b91f-658a907647c6", "guest@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5df97f94-d628-44ab-8d9b-1d0a72ff59ce", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMrAUnsH896/9c4tDPW+/zMn/yBYMnlQUyP+SjzHCgWOl4tlBJWM/LOT/5Av5SYKLg==", "7a874a54-40aa-4ed3-9a63-46d8f190247b", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "81b61a75-f376-4081-9751-a52156672960", "PUBLISHER@GMAIL.COM", "AQAAAAEAACcQAAAAEGLehkkvrJDNMOp/omR0ifDDkiVimNGEjfOKzLOJH4jNighsLkyNqUBtXjB+I0o6sw==", "0d15ff89-ae1e-4af4-8c72-57fe1e5397e3", "publisher@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "fa338669-b58c-4e42-8d31-4062875ec6d1", "GUEST", "AQAAAAEAACcQAAAAEK+MAsHQe5LDFBwxQL8DlZpFjAHmNLMtRubbFfvLfULxTgDkmMgd+E6tsqM4K5voWg==", "e9e3b6ea-4a14-4cb8-8db8-a54a6c231afc", "Guest" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5dabc723-5f09-4783-98b8-fb69675439ba", "ADMIN", "AQAAAAEAACcQAAAAEME7pPxbbUSqMjw4ZQxSOt6RZ4YFGWNYLBmNepZ2P40YRur8mrqnnD0QZ0n/PKpapA==", "5ec90344-afe5-4a87-aa3c-5adc14266fdb", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3fba7de3-d47f-4fbf-ba7d-a7bc9e12b1b8", "PUBLISHER", "AQAAAAEAACcQAAAAEFJHuXrSK9htUucSuwixIWrNbNpKHX0mXI6hq4oZ3GXl4kamOqArTlcnfgBx1rk1LQ==", "26122028-1d0d-4135-8e56-e0af63d9c4df", "Publisher" });
        }
    }
}
