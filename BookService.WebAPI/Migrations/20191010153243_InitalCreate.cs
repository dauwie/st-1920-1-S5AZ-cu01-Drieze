using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.WebAPI.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Title = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true),
                    ReaderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Sharp" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophie", "Netty" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elisa", "Yammy" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "UK", "IT-publishers" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 2, "Sweden", "FoodBooks" });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 10, 17, 32, 43, 869, DateTimeKind.Local).AddTicks(4348), "Joe", "Pageturner" },
                    { 2, new DateTime(2019, 10, 10, 17, 32, 43, 869, DateTimeKind.Local).AddTicks(4432), "Linda", "Bookslaughter" },
                    { 3, new DateTime(2019, 10, 10, 17, 32, 43, 869, DateTimeKind.Local).AddTicks(4522), "Wendy", "Allreader" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 1, 1, "book1.jpg", "123456789", 420, 24.99m, 1, "Learning C#", "2019" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 2, 2, "book2.jpg", "45689132", 360, 20.99m, 1, "Mastering Linq", "2017" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 3, 1, "book3.jpg", "15856135", 360, 24.00m, 1, "Mastering Xamarin", "2019" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 4, 2, "book1.jpg", "56789564", 360, 13.99m, 1, "Exploring ASP.Net Core 2.0", "2013" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 5, 2, "book2.jpg", "234546684", 420, 34.99m, 1, "Unity Game Development", "2010" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 6, 3, "book3.jpg", "789456258", 40, 22.99m, 2, "Cooking is fun", "2012" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 7, 3, "book3.jpg", "94521546", 53, 27.99m, 2, "Secret recipes", "2017" });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "Created", "ReaderId", "Score" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(6969), 1, 3 },
                    { 4, 1, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(7176), 2, 4 },
                    { 2, 2, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(7073), 1, 2 },
                    { 5, 2, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(7226), 3, 2 },
                    { 3, 3, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(7127), 2, 5 },
                    { 6, 3, new DateTime(2019, 10, 10, 17, 32, 43, 860, DateTimeKind.Local).AddTicks(7273), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReaderId",
                table: "Rating",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
