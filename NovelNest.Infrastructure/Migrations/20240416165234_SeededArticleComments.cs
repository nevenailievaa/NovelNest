using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededArticleComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArticleComments",
                columns: new[] { "Id", "ArticleId", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 3, "Цялото ми семейство сме фенове на сиромахов. Най-накрая дойде в Бургас!", "Там сме!", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, 3, "Доста чаках да публикува новата си книга. Сега ще отида и за автограф!", "Очакван с нетърпение!", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 3, 3, "Изобщо не разбирам как може толкова хора да му се кефят на този човек, та чак и да ходят на събития свързани с него.", "Не разбирам", "64ce3106-ec7d-44cb-b167-bf946b88bb1b" },
                    { 4, 3, "Творчеството на Сиромахов винаги ми е било от любимите. Тази книга няма да е изключение.", "Отивам", "cabfd9b8-4411-47f6-9639-df70d753c275" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b4a602-f46b-4ec0-b3ba-d26f1a998d20", "AQAAAAEAACcQAAAAEGyBObU0rH0pxJdcir5WzVc37ROEJR+wNmJH06m9vlUqx/2L7wgInpMcrlTnqWCwFA==", "891ff14a-e15a-428a-99b8-71880ceedfc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ba59902-034d-4905-a458-ec675ab77900", "AQAAAAEAACcQAAAAECaiEHPgcLDgYzKhjy2WtlHfGtdi332Gr9slFHQQ6Ff1h6MEhVw/gpe+50IYd35aaA==", "26550703-262a-4fad-bcd9-7f925a1f0dba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63966b9a-2386-4165-ac9f-9f85e9d9d90d", "AQAAAAEAACcQAAAAEGpSjJ/aYx4v+12ZQsD5o/Hxynxx1UsO5fu/wSnNJWVrsreGYdbH59w6FoQ7FbAX7A==", "d4c0a8ef-2537-4ec6-8403-c59941abfb6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a5a9efc-2fe2-46c8-b0f0-7ee2a9b3c86c", "AQAAAAEAACcQAAAAEOnYORo/wZVteUMLT1fkenjREJbqksQhuvnGonQFJQqm9bxLB4psrJmlfFfgnMG0kQ==", "3e86b7ef-7317-49e6-823b-8f25130be4ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dafc2be-02a1-4af6-a89d-40d47df66d02", "AQAAAAEAACcQAAAAEIqESr2jpClsnpS4ki1ygBof3pofpYncZigpWh4Duya4VoI10PVLpZOwyCAp7QR8Zw==", "d4fcf822-098d-4bfb-9ad9-ff8addd6734d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleComments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticleComments",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
