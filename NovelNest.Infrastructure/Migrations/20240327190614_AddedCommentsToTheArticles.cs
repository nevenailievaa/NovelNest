using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedCommentsToTheArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Article Comment's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Article Comment's Title"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false, comment: "The current Article Comment's Description"),
                    ArticleId = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc086dc-2c2b-470c-817b-d7b34b6c1662", "AQAAAAEAACcQAAAAEDOISqFr5k7Pa7Q0PH4WtIaEUADpihNO4EcpkvgJ8X8r1m6l0zzb9s5Di36JgnHERA==", "7dbae72b-7b65-4305-9201-7dd101cec7d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00931b13-c44d-4d92-9843-50d0396c898d", "AQAAAAEAACcQAAAAEFB0pYh5owJVnoaBgBRev0rbxumSHexxtumaujUjzqChB4W0cGUrRbcctP619q0Ykw==", "1524e83b-7a2a-4c7f-8c62-84266784b153" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_UserId",
                table: "ArticleComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "740b2e32-ce11-4546-b3a3-bfb1d365705f", "AQAAAAEAACcQAAAAELh8RewMHelwEoethqf9VUjv87cfBE1zCBGB1gkGKazYhge07QE1R+DGPHLBXvfFNA==", "f11054ff-863f-4e74-9b4c-0e859b055e48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65244e87-ba44-41a3-ba7c-a51802db725e", "AQAAAAEAACcQAAAAEDm37ljiwYEb+Ic50ehIUMSDAJOZXx8a0tcyWPtRR0g/1qJaGAtuYL+kdlwM9OMROg==", "8af549a9-5f08-4e9c-985b-e83a59f9e98e" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 3, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
