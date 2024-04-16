using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededMoreEventsAndUpdatedConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                comment: "The current Event's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "The current Event's Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b55002e2-21aa-442a-8fe8-8aaff81b313c", "AQAAAAEAACcQAAAAEP51GE+rXfclERmxhGclE0KL+DkN1TOVPP/R8W5avD4dkS7TsTigD6mwgNhaZiXt4w==", "a19a3321-64ec-46c5-a1d1-a238ff29a079" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a494e5a-a98e-4f8d-98ee-3e4a8cbc699b", "AQAAAAEAACcQAAAAEJcc5zt2HJD5OKZG21sWnHgUwVFF1Igj4O3Z/4+VYc5ZBgDbRnmA3Ji8A2ODZA/rDg==", "fc0e8a2d-7dd5-48d7-baac-8eb23777e403" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad161076-3b0c-40a4-a424-f78dae1b4c2a", "AQAAAAEAACcQAAAAEBrr01vv9I5a6cjPGudq3AH0a/kzcukxdw9lHlNcWnWIDVRs+lLnVCPQJRakp76PNQ==", "b4a47c3c-ebe6-4fd8-8d56-49365951d5c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f253d0c1-3b43-47e8-87c2-de105201af2a", "Boris", "Vladov", "AQAAAAEAACcQAAAAEEcw8iFa3joUCCZbB+7fTUTgtS4aWZpKtmG7Ry5pF9u9kfLVa35GxvrBM64U/oTpGA==", "2952f55c-2b51-4a5c-a261-c7f9f41e390b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6214e6f-bee3-4304-bdd2-41b9702e0149", "AQAAAAEAACcQAAAAEN+ojdQgSjLNj8qBD/qrZnhI6LE3eFox3cLVyWkP79qawWWyu7WPgHkLfDNMCCelQA==", "13deca83-2207-4d74-8e92-ff59bf8a7c39" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 16, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 4, 16, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 5, 20m });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 200, 5m });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 10, 15m });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "ImageUrl", "Location", "Seats", "StartDate", "TicketPrice", "Topic" },
                values: new object[,]
                {
                    { 4, "На 17 април от 19:00 ч. в \"Червената къща\" (ул. Любен Каравелов 15) ще представим \"Смъртта на Бялата лисица\". Повече ще разкаже самата Анна Заркова. Модератор на събитието: Светлозар Желев Какво да очаквате от книгата? На 2 октомври 1996 г. пред дома му е застрелян Андрей Луканов – знаков политик на българския преход, министър-председател в две правителства, депутат. От кого и защо? И до днес нито една от версиите не е отречена или потвърдена. Делото „Луканов” е прекратено.", new DateTime(2025, 4, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2024/04/zarkova_event.jpg", "\"Червената къща\" (ул. Любен Каравелов 15)", 100, new DateTime(2025, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 10m, "ПРЕМИЕРА | Смъртта на Бялата лисица" },
                    { 5, "На 21 март в 19:00 ч. ще отбележим появата на „Минало несвършено“ - криминален психологически роман по култовия сериал на NOVA „Отдел „Издирване“. Майсторски замислена, динамична и завладяваща история, която разширява света на героите от екрана и позволява на читателя да надникне в най-съкровените им мисли! С нас ще бъдат Александър Чобанов, Владимир Полеганов, Юлиан Вергов и Ана Пападопулу. Специално участие ще вземе и криминалният психолог Росен Йорданов.", new DateTime(2024, 3, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2024/03/minalonesvarsheno_event.jpg", "Сцена Дерида", 7, new DateTime(2024, 3, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), 10m, "Премиера: „Минало несвършено“" },
                    { 6, "На 8 декември от 18:00 ч. ви очакваме на щанд 315 в НДК за среща с авторите, които ни зарадваха с творбите си през 2023 г. Ще ви очакват Светлозар Желев, Божидар Манов, Селя Ахава, Милена Кирова, Искрен Красимиров, Мария Касимова-Моасе, Иван Шишиев, Алберт Бенбасат! Вземете книгите им с отстъпка и получете автограф! Проектът е реализиран с финансовата подкрепа на Национален фонд „Култура“ по програма „Програма за възстановяване и развитие на частни културни организации“.", new DateTime(2024, 12, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2023/12/sreshta-s-avtograf.jpg", "Щанд 315, НДК", 200, new DateTime(2024, 12, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Среща с автограф с авторите на „Колибри“" },
                    { 7, "Софийски международен литературен фестивал и издателство „Колибри“ ви канят на среща със Селя Ахава в разговор с Егил Бяртнасон на 8 декември, петък, от 14:00 ч. в НДК, етаж 2, мраморно фоайе. Модератор на събитието ще бъде Силвия Недкова. Финландската писателка Селя Ахава (1974 г.) придобива известност с романа „Неща, които падат от небето“, който печели наградата за литература на ЕС и наградата за разпространение на финландска литература „Факлоносци“. С логото на „Колибри“ в България е издадена и шокиращата автофикция „Преди да изчезне мъжът ми“. „Жената, която обичаше насекоми“ (превод: Росица Цветанова ) е четвъртият роман на Ахава, в който тя изследва връзката между човека и природата. Това е завладяваща творба за съвършенството на мирозданието, написана с изключително майсторство и оригинален подход към необичайното. Книгите ѝ могат да бъдат намерени и на щанд 315 в рамките на Коледния панаир на книгата с отстъпка! Очакваме ви!", new DateTime(2023, 12, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2023/12/ahava_event.jpg", "НДК, етаж 2, мраморно фоайе", 44, new DateTime(2023, 12, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 5m, "Среща с автограф с авторите на „Колибри“" },
                    { 8, "Имаме удоволствието да ви поканим на премиерата на „От авторите и читателите ЗА КНИГИТЕ И ЧЕТЕНЕТО“ със съставители Анна Лазарова и Светлозар Желев. Събитието ще се състои на 29 ноември (сряда) от 19:00 ч. в Литературния клуб на Столична библиотека (етаж -1). Носете си доброто настроение и любовта към книгите! Вход свободен! ЗА КНИГАТА: Още през 1978 година в „Пътеводител на галактическия стопаджия“ Дъглъс Адамс дава отговор на „Великия въпрос за Живота, Вселената и Всичко останало“. Четиридесет и две. Това число обикаля света, бива разнищвано и изследвано, анализирано и свръхинтерпретирано. То се превръща в разпознавам белег на книгата, а чрез него единствено литературата измежду изкуствата и науките дръзва да застане зад отговор на неотговоримото.", new DateTime(2023, 11, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2023/11/za-knigite-i-cheteneto-sofia.jpg", "Литературen клуб на Столична библиотека (етаж -1)", 27, new DateTime(2023, 11, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 2m, "Премиера: От авторите и читателите ЗА КНИГИТЕ И ЧЕТЕНЕТО" },
                    { 9, "След лепкавата жега на Буенос Айрес тук всичко е чисто, свежо и хрупкаво като прясно изпрани чаршафи, уютно като планинско селце, пролетно като лютиче, цветно като шепа бонбони, усмихнато като слънчев лъч, синенебо като детски сън. Добродушно и смайващо самотно. Далече, далече от глъчката и шумотевицата, от тълпите и цивилизацията, от бързането и стреса, чак най-отдолу, най-на юг, най-накрая на земята. Fin del Mundo. Краят на света. Така Изабела Шопова описва Ушуая, градчето в най-южната част на Земята, краят на света, който със сигурност няма да сложи край на пътешествията ѝ.След „На изток – в рая“, „На запад от рая“, „На юг от разума“, „Подир сянката на кондора“ и съвсем между другото, „Самоучител за преднамерено убийство на скуката“, Изабела ни предлага поредната си завладяваща сага – „Приказки от Горната и Долната земя“.", new DateTime(2024, 7, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://www.colibri.bg/uploads/2023/06/shopova_event_sofia.jpg", "Casa Libri", 200, new DateTime(2024, 7, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 3m, "Премиера в София | „Приказки от Горната и Долната земя“" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "The current Event's Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldComment: "The current Event's Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64ce3106-ec7d-44cb-b167-bf946b88bb1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4fd970f-bbc7-4180-afef-181262b1670c", "AQAAAAEAACcQAAAAED7seNwMfxeV01MShe5JsPwI+3t0EOvAJf3tr5DKwJV3jCDcv7BA2ca+8+dIbU/wFg==", "e7408103-5f22-48ea-8ff9-3529ba1d772d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9176d369-8ac8-49c5-9dba-9b27a52055ce", "AQAAAAEAACcQAAAAENGy9zgLOD4hprh+XNjxZNxuj0yBiJnJhuufn6uo6jA7tYdO2rR/VQYZn6M5CVBdQw==", "6ef663a0-151b-4184-ac16-546bb6bb819c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8508ce82-1a5a-4f4b-8980-5a69d3907588", "AQAAAAEAACcQAAAAEGEcLKvQadUTAOFiftNou/PdEJcTRtj9BqOdG9+kvWqSpYLVDZKTthanvJQouxTtfw==", "794431ba-1466-4e05-8ccb-0730bfe4b535" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabfd9b8-4411-47f6-9639-df70d753c275",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc90d746-5c19-49e8-984a-65f33d951f46", "Nevena", "Ilieva", "AQAAAAEAACcQAAAAEArqzM0rlQmngn4V/mXAeJZ8RhZFtu52/KzwXsDd3MNKQHwNhsVXBiy++bgjnadLqQ==", "55f532db-f220-47d9-84f6-31d7cf8fcb1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36859dd5-8b0e-4ef4-883d-b0db02f8baaf", "AQAAAAEAACcQAAAAEGP46UwyyRkOq0pq9vRS9bYCQc2posKh+TH6nWtyijBK5gPx/MzG/flaMcuVsn9lyA==", "9ff1d229-b99d-438a-bde0-1db9a66f6ff0" });

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 0, 10m });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 0, 10m });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Seats", "TicketPrice" },
                values: new object[] { 0, 10m });
        }
    }
}
