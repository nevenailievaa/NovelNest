using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededBookReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfb653df-a741-434f-bfe8-9484c6f1e5de", "AQAAAAEAACcQAAAAEOSiJfqKNDIc9eJyWbzev3RrYWKCly3NV5Hjhsl2Mp/+DkudLiVcN7rcXyzSwy/Dyg==", "04c4ce1b-f77e-4417-a18d-55978abcbfc4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31a4b7bf-5763-4f6e-9969-16332b661ec6", "AQAAAAEAACcQAAAAEBIc7q9g0u8vpzS+vLOYvlMiVg6FnixMQlxYaLb+hPIz5WZ66rSnbgWwUlT/ln/NFA==", "b7f56f46-0774-4cdc-9f42-74a3f0ff9ef7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b865319b-be43-4bfd-9c65-1a384e7508f4", "AQAAAAEAACcQAAAAEBGg9hxldHvlzOAQWsFsERuImfkD+HkFT11/0LQ5AStG/LSfG0ZqFqAuP/neoAyZjQ==", "f95c1ed7-55cd-488f-96d9-f719249f7659" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8989f1f0-7d18-4d22-8a0f-98cd73568f23", "AQAAAAEAACcQAAAAEMY33dJILo7piRCRXkVGc08zzGMrY3oEkH90IPYnF7JBEhxOjqLv0Ru9JA5EgFCUmA==", "b94434b2-42fc-4af0-a045-063d2bcbf6b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65c93941-9553-448c-8959-14211c0c0c29", "AQAAAAEAACcQAAAAECEcxHfJOmfKqNW7GiPYAkrWEFY6CjEQ2HlODrW7nQ/BpuLlxD4S6iGqyDFj9qWuKg==", "fb5897c2-f773-41c7-9500-6ccdb086725f" });

            migrationBuilder.InsertData(
                table: "BookReviews",
                columns: new[] { "Id", "BookId", "Description", "Rate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 3, "Книгата ме остави без думи! Изключително добре написана. Разбира се любим персонаж за мен е Лисбет Саландер. Препоръчвам!", 9, "Много ми хареса!", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, 3, "Фен съм на кримитата, но тази книга не ме грабна. Стори ми се прекалено повърхностна и не толкова добре описателна. Все пак не е зле.", 6, "Не мога да кажа, че е нещо особено.", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, 3, "Току-що приключих с “Мъжете, които мразеха жените” на Стиг Ларшон. Слушах книгата в Storytel, тъй като заглавието ми звучеше изключително тривиално и ненужно драматично, пък и честно казано в последно време ми писна да слушам за мъже, които мразят жените. Болна тема. При това и оригиналното заглавие повече ми харесва - “The girl with the dragon tattoo”.\r\n\r\nКниги, които не ми звучат чак толкова интересно, a и какво значи книга да ти “звучи интересно”, но пък са високо оценени от читателите, оставям да изслушам в Storytel. Впрочем така направих и с книгите за детектива Робърт Хънтър на Крис Картър - нещо, за което съжалявам, но това не ми попречи да се вманиача по поредицата и да тъгувам, че няма още двеста книги от нея, които да изслушам.\r\n\r\nСъщото се случи и с “Мъжете, които мразеха жените” - първоначално гледах на нея със скептицизъм, но си казах: “Какво пък толкова, все пак ще я слушам докато се занимавам с нещо друго, нали затова се абонирах за Storytel в крайна сметка”. Е, отново сгреших в преценката си и тази книга се оказа заслужено високо оценена.\r\n\r\nАз съм фен на трилъра, особено на криминалетата. Първоначално даже не знаех и какъв е жанрът на четивото ми, просто започнах да го слушам без никакви очаквания. Оказа се, че съм попаднала на един особен и увлекателен криминален роман. Образите бяха изградени старателно, а най-много ми хареса този на Лизбет Саландер. Тя изненадващо се превърна в любимия ми такъв. Странно момиче, част от “Емо” културата, разбира се с татуировки и пиърсинги по тялото си. Изключително нетипична и интелигентна. Не очаквах, че точно такъв образ толкова много ще ме завладее.\r\n\r\nИсторията около семейство Вангер е ужасяваща, но няма да казвам повече, за да не разкривам от сюжета на тези, които все още не са се спрели на този заслужен безспорен бестселър.\r\n\r\nРазбрах, че има и филм от 2011-та година. Разбира се - ще го гледам, макар и да съм сигурна, че няма да е същото. В книгата имаше доста части, отделени на това да те вкарат в ума на героя и да ти опишат в детайли как се чувства той. Макар че не бива да се съди толкова бързо - филма по “Червеният дракон” от прочутата поредица на Томас Харис, се оказа също толкова хубав, колкото и книгата.\r\n\r\nНе искам да вдигам очакванията. Може би останах толкова приятно изненадана от тази книга именно защото нямах никакви очаквания и изисквания към нея. Може би за някои хора това ще е просто поредната криминална боза, през която предстои да преминат и скоро след това ще забравят. Аз обаче я оценявам високо и се надявам този отзив да накара някой да я включи в “To do” листа си, а аз продължавам със следващата, а именно - “Момичето, което си играеше с огъня”.", 10, "Превърна се в любимата ми!", "64ce3106-ec7d-44cb-b167-bf946b88bb1b" },
                    { 4, 3, "Изобщо не е написана добре. Сюжета е плосък и безинтересен.", 3, "Грам не ми хареса", "cabfd9b8-4411-47f6-9639-df70d753c275" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86aad5c5-5556-4017-bfea-b6729342c5c6", "AQAAAAEAACcQAAAAEN57sLoYK8xwkTmBOvGPx74MO7iL+mpaC7ot2BZ+SeqhWAQshdjvFBKDZ1rArxMmKA==", "1ef967e7-5294-48f6-a519-57890f42573b" });

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
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b891321-e378-4702-a9b1-b654ca7250ef", "AQAAAAEAACcQAAAAEEDi5qGOoJaSI0eQIpEDlybvjAc4cPWFyv1M95u9+weg7agIs3msMWEgKQX1KMHi9Q==", "06a83746-a433-42a3-a481-f5bcf3d4feef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e9aaa12-110c-4fae-9542-e4e31a8598ce", "AQAAAAEAACcQAAAAEHwxhsTl0U/GoIHoHZhPQgQ1MfPoc75e48Gy0wF/+vL06RMnZuvzkoMtnlgtVytN2w==", "6756383e-4179-43d9-be4c-b01abe5073e9" });
        }
    }
}
