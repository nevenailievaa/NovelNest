using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededMoreBookStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ebc0d1f-e331-4364-99d8-130601098056", "AQAAAAEAACcQAAAAEJARhuRgBAeqy+NN4nq/Hub9t67ogsr5VwWftUuE+yM8NZDghAy4vXZuVyWDB+CZhA==", "176697dc-e3a1-476f-af3a-41a24416bd75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dd13941-b508-4b77-9ca5-43e20575faf1", "AQAAAAEAACcQAAAAEHp19H3975LAua1o4h4dHyJhxZ7dCuZuxjFHPq0sONnxlamFrGaU4T+oivb/5tzX8Q==", "cf1ae72a-e0ec-441f-8801-478f0e9f83b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bba3860f-06ab-4c02-962c-82730043b9eb", "AQAAAAEAACcQAAAAEMFoaW1Ov7akR7eq//ZhvJN0B5uZ9UnDMBYPlV6/aQHpjFGZ07P19Rk32TIeZ/K6uA==", "9afaaa40-574b-478a-b112-1da76293229f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cdd02ed-1379-422a-8cde-d3830b022d59", "AQAAAAEAACcQAAAAEJIFQmO7aaMZ87hf5x1Lz42klak7IXpSLc9yPOdbVw2Qx2c2znUwcGOkzH9K7VFH0g==", "cf9d390a-5dbf-4ebd-ab2c-cc7f3ad9c7f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78dd23ad-a6de-46c2-a846-75fd464d0822", "AQAAAAEAACcQAAAAECK/Rps0Utoa/DAwLMIkDdP+S8KG6msbzMCNgjSpmpw80oK2f50e2/1q2X2UzXfwzg==", "f78e490c-74ce-4e5d-92e5-436ed07b2fa0" });

            migrationBuilder.InsertData(
                table: "BookStores",
                columns: new[] { "Id", "ClosingTime", "Contact", "ImageUrl", "Location", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 4, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), "032 207 621", "https://cdn.oink.bg/gallery/23010/05adf581-0397-4f92-a9fa-65a087cd918f_large.webp", "ул. „Княз Александър I-ви“ 29, Пловдив", "Helikon - Пловдив Център", new DateTime(2024, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 4, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), "0878929358", "https://lh3.googleusercontent.com/p/AF1QipPgXofDl2u9d6h6aNNQ6Phs0i7mzeVYEwU5ssQX=s680-w680-h510-rw", "ж.к. Лозенец, ул. „Драгалевска“ 1, 1407 София", "От А до Я - София Център", new DateTime(2024, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), "0876211144", "https://lh3.googleusercontent.com/p/AF1QipNKR7OEDjOL8kyn96Fz8P-EFTLP5VQvpi0i1CSi=s680-w680-h510-rw", "Казарми Източен, ул. „Д-р Георги Странски“ №3, етаж 2, 4019 Пловдив", "Ciela Books & Music - Пловдив", new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 4, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), "0879228009", "https://lh3.googleusercontent.com/p/AF1QipOoQHzIG3B8LxmxLjyoCSlDD93L6ftaFLVYFWzX=s680-w680-h510-rw", "Варна Център Одесос, ул. „Цар Симеон I“ 1, 9000 Варна", "Bookpoint - Варна", new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 4, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), "0882560013", "https://lh3.googleusercontent.com/p/AF1QipPbLF_2y5KAuPxHse21tPodoOooVGlsa1R5gJ4p=s680-w680-h510-rw", "бул. Липник 121 Д, 7000 Русе", "Ciela - Русе", new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), "0877257199", "https://lh3.googleusercontent.com/p/AF1QipONKzh539ObWS-NI_g3XohjjChkUr2khxVk7bP6=s680-w680-h510-rw", "Северна промишлена зона, бул. „Янко Комитов“, 8001 Бургас", "Ciela - Бургас", new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "990f78f6-0cdd-49e0-88f4-ac3a0b52c80e", "AQAAAAEAACcQAAAAEGks5i9gvEcQeua9x+iBkynuXbzcRoroDhEuCc6PFqtjedx4s5ckKjNbjL/TayrdBQ==", "159746f4-1fca-4b47-8d57-8e5b45cb0ce7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69178d1a-f5dc-44cd-bad3-2cb4a4c3189a", "AQAAAAEAACcQAAAAEBR8fuDVqUFuGRWOgDhuugxN1woTvM6sTPx8y6dsVKQpRvQ1+ItRzHWE3762ISBETA==", "2a83e624-a890-4445-bbfa-bf86698d2f03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db51db50-0343-4822-a88d-0b7470d1f1bb", "AQAAAAEAACcQAAAAEKIVm3lE6mNHm9iw6PjrGUc38WgxV1LHxLTT3QiijLytz+caqEqoxjquxmroto/Nzg==", "63516e9a-ad44-4f65-8d29-23f3279a68d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24559cf7-a868-4475-96ec-d5d3a93adc4f", "AQAAAAEAACcQAAAAENoKirKK4+djAqIH2/Vyd7MXQNuZsAqk5c4FsAlDfc+G4tm+ZqC6X2O7c0CL60CL9Q==", "6b507bd7-4e87-4b29-8944-37ca22568d70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49a35917-3d9d-48db-b3a6-019f1476e3db", "AQAAAAEAACcQAAAAEOq9oMTxsCdS6UDWTWBNdQb84CccDn2QFhKBPEPSN7Nu6tiWsOTpwBkU7ny9nw09Xg==", "16ba008d-9f06-4f9d-a089-2fef23bcfe28" });
        }
    }
}
