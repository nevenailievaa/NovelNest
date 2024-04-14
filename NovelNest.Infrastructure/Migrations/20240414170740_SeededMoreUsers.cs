using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededMoreUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8f1f503-3659-4e5f-81dd-e599a0e3c19f", "AQAAAAEAACcQAAAAEIeEE/EvY1rM3iqZ9Y3KVX0nmOO0SKPrfrUYS+jJpeeWcFFDu1mKlGJM6w+Ij2KSIQ==", "8786dca5-597a-403a-9cbd-91006422ffe9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf2c59a5-bf03-4731-bc81-e2c7f90651a7", "AQAAAAEAACcQAAAAEEn7ICuK4CDQ5NkjJgS+Ft0ysp/GbY0h8nyLTV4zpQ/hdn3m9PFRut8SQzP1TcGyDQ==", "beb47709-fad2-494b-af19-0dd026ca597b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e9aaa12-110c-4fae-9542-e4e31a8598ce", "AQAAAAEAACcQAAAAEHwxhsTl0U/GoIHoHZhPQgQ1MfPoc75e48Gy0wF/+vL06RMnZuvzkoMtnlgtVytN2w==", "6756383e-4179-43d9-be4c-b01abe5073e9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "64ce3106-ec7d-44cb-b167-bf946b88bb1b", 0, "86aad5c5-5556-4017-bfea-b6729342c5c6", "nevena@gmail.com", false, "Nevena", "Ilieva", false, null, "NEVENA@GMAIL.COM", "NEVENA@GMAIL.COM", "AQAAAAEAACcQAAAAEN57sLoYK8xwkTmBOvGPx74MO7iL+mpaC7ot2BZ+SeqhWAQshdjvFBKDZ1rArxMmKA==", null, false, "1ef967e7-5294-48f6-a519-57890f42573b", false, "nevena@gmail.com" },
                    { "cabfd9b8-4411-47f6-9639-df70d753c275", 0, "7b891321-e378-4702-a9b1-b654ca7250ef", "boris@gmail.com", false, "Nevena", "Ilieva", false, null, "BORIS@GMAIL.COM", "BORIS@GMAIL.COM", "AQAAAAEAACcQAAAAEEDi5qGOoJaSI0eQIpEDlybvjAc4cPWFyv1M95u9+weg7agIs3msMWEgKQX1KMHi9Q==", null, false, "06a83746-a433-42a3-a481-f5bcf3d4feef", false, "boris@gmail.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ad12700-11eb-4486-9141-73b5f0e47e04", "AQAAAAEAACcQAAAAEPAs+fiQ+zIbX9gw+wT0IY2u+aKUOL2GP3I7YpkSKoOnUVTxiCR6PkEQh8wSt44HiA==", "5c93fe23-8f8e-42cd-9524-2e719d8b90fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6966be5e-c4f2-4ac1-8c0d-e19ad7055fb6", "AQAAAAEAACcQAAAAEJk/INag6AIJcmYh8c0Vr0CLiHBXl/sMoOSSvBfcJJ7br8Y7qNxXTDPUJyrNkQRy3g==", "3404696d-6fec-41aa-9718-330d5e5602d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf1c9e7-0cbd-4483-8c17-93199b8f4fff", "AQAAAAEAACcQAAAAEC1v+JUDxxXv3zE+OiWjReJwjWDX1wMIAlKMgmdz2vgVCjU5aOziLYYsJc2MTSXo6g==", "0517bd55-6913-4b8a-b298-dd341bebe585" });
        }
    }
}
