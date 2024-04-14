using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class SeededRemainingClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 4, "user:fullname", "Nevena Ilieva", "64ce3106-ec7d-44cb-b167-bf946b88bb1b" },
                    { 5, "user:fullname", "Boris Vladov", "cabfd9b8-4411-47f6-9639-df70d753c275" }
                });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc90d746-5c19-49e8-984a-65f33d951f46", "AQAAAAEAACcQAAAAEArqzM0rlQmngn4V/mXAeJZ8RhZFtu52/KzwXsDd3MNKQHwNhsVXBiy++bgjnadLqQ==", "55f532db-f220-47d9-84f6-31d7cf8fcb1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36859dd5-8b0e-4ef4-883d-b0db02f8baaf", "AQAAAAEAACcQAAAAEGP46UwyyRkOq0pq9vRS9bYCQc2posKh+TH6nWtyijBK5gPx/MzG/flaMcuVsn9lyA==", "9ff1d229-b99d-438a-bde0-1db9a66f6ff0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
