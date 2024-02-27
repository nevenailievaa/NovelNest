using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNest.Infrastructure.Migrations
{
    public partial class AddedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksBookStores_BookStore_BookStoreId",
                table: "BooksBookStores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStore",
                table: "BookStore");

            migrationBuilder.RenameTable(
                name: "BookStore",
                newName: "BookStores");

            migrationBuilder.AlterColumn<int>(
                name: "YearPublished",
                table: "Books",
                type: "int",
                nullable: false,
                comment: "The date on which the curent Book was published",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The date on which the cuurent Book was published");

            migrationBuilder.AddColumn<int>(
                name: "CoverTypeId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Book's CoverType's Identifier");

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current Book's Pages Count");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStores",
                table: "BookStores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BooksUsersCurrentlyReading",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier"),
                    CurrentPage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersCurrentlyReading", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersCurrentlyReading_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersCurrentlyReading_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksUsersRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksUsersWantToRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersWantToRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersWantToRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersWantToRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersCurrentlyReading_UserId",
                table: "BooksUsersCurrentlyReading",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersRead_UserId",
                table: "BooksUsersRead",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersWantToRead_UserId",
                table: "BooksUsersWantToRead",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CoverTypes_CoverTypeId",
                table: "Books",
                column: "CoverTypeId",
                principalTable: "CoverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksBookStores_BookStores_BookStoreId",
                table: "BooksBookStores",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CoverTypes_CoverTypeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksBookStores_BookStores_BookStoreId",
                table: "BooksBookStores");

            migrationBuilder.DropTable(
                name: "BooksUsersCurrentlyReading");

            migrationBuilder.DropTable(
                name: "BooksUsersRead");

            migrationBuilder.DropTable(
                name: "BooksUsersWantToRead");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStores",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "CoverTypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "BookStores",
                newName: "BookStore");

            migrationBuilder.AlterColumn<int>(
                name: "YearPublished",
                table: "Books",
                type: "int",
                nullable: false,
                comment: "The date on which the cuurent Book was published",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The date on which the curent Book was published");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStore",
                table: "BookStore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksBookStores_BookStore_BookStoreId",
                table: "BooksBookStores",
                column: "BookStoreId",
                principalTable: "BookStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
