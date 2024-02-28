using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksCarts",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current Cart's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCarts", x => new { x.BookId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BooksCarts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksCarts_CartId",
                table: "BooksCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksCarts");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
