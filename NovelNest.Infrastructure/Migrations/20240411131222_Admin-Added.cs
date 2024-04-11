using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75d905cd-911b-48b8-9f85-be643b8cfbe3", "Guest", "Guestov", "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEALa2j1jo71VeXGw9CQ6Ps2p4aoD/Jq7oDvvfq8czCmzTOePkxs1H8ckIDMEYBZt/w==", "a258d0dd-06f2-4061-b84c-af29aa54688a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "386a0cac-42a7-426c-a4a4-bda89fd32002", "Publisher", "Publishov", "PUBLISHER@GMAIL.COM", "PUBLISHER", "AQAAAAEAACcQAAAAEMMGJVk1CpnRXsCl/N0fISicha5k6B7R9Bc6CMZNKUyswUzSEW8qiwKroNrUvUqS/A==", "896d00b4-2b9b-4c08-be13-0aada9e3e71a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2f14bf7-ffdd-47a4-90b3-f2309486fae9", 0, "3209f9af-b7f1-4355-a007-6d266a0e850c", "admin@gmail.com", false, "Admin", "Adminov", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENxr7apVTG+9fAEo87+Aw361hcCSZqL9Kdut9bE/PwwHbaxd36xdE1zEleTMKqpiYw==", null, false, "1ecd3d2f-ced2-4b43-8548-dda9ec358768", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 2, "c2f14bf7-ffdd-47a4-90b3-f2309486fae9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de249fab-4e52-4a6a-9100-b84ffb131128", "", "", "guest@gmail.com", "guest", "AQAAAAEAACcQAAAAELWG+MnzSRaZWHdDi3a7aY6EQLK2G+70tDSU1QuTkaevAJLlEUm6J8NPpf5T+7C/pw==", "46b296ec-09d8-4fb8-8507-ae11331e312f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f3a070-e27e-40e1-b7b5-c85aaa73b199", "", "", "publisher@gmail.com", "publisher", "AQAAAAEAACcQAAAAEHIbopizn89Eiz7+7pMJHHiLoalJrA7OWlhWH8z2XPbU3TbRhNtfEMFIZmxQsa5OhQ==", "bdd9a056-8293-476d-85c3-68d7ab864a37" });
        }
    }
}