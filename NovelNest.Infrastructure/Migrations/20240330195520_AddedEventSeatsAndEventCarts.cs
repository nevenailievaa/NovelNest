using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedEventSeatsAndEventCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Event's seats");

            migrationBuilder.CreateTable(
                name: "EventsCarts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "The current Event's Identifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current Cart's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCarts", x => new { x.EventId, x.CartId });
                    table.ForeignKey(
                        name: "FK_EventsCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsCarts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "157a2d22-95a6-449b-b5c4-4b15b2df05e1", "AQAAAAEAACcQAAAAEBPw6eHLEzZTfOkcy+nlfeFvGBCgicDQ7pIiesc/SV+i2Ucj6Kr5GQ3CzSvB4tfu0w==", "bcb0a7b7-356e-4e43-a344-e22e8537f23a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e22a8847-65eb-4f1b-a65f-1636a0c3d1ab", "AQAAAAEAACcQAAAAEItDU4Y/g7odhaArgyqenbL9qpeFtlAD5yoB0yTQ+7BNDFNOAbHJQ7VbnaWLsU3f1w==", "2d3124e4-dc60-4faf-a5a9-c82c5517ea90" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_EventsCarts_CartId",
                table: "EventsCarts",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsCarts");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fc11dd2-61f2-4598-a56e-17e888b37a71", "AQAAAAEAACcQAAAAEBSLeOTPCYcojy0w9dxQ4a1EYXBxa3J+SzKmN4tigD3w1GzoOzMVOlFgC34eQvSdWg==", "7992ca43-ca96-4342-a114-2d8a5b77ffa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e8ac6a3-902d-47d3-b895-b466de10c5e1", "AQAAAAEAACcQAAAAEASUee2fyL7minld4FNTceZku4W08J1ZFtT1bFfkrPD0rFkW+S3sfddTkw6G8zSM+A==", "38b34f59-7bde-4717-91f8-af96ebe74117" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
