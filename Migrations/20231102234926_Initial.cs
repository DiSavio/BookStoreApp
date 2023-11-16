using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Stephen", "King" },
                    { 2, "Agatha", "Christie" },
                    { 3, "Danielle", "Steel" },
                    { 11, "David", "McCullough" },
                    { 12, "George", "Orwell" },
                    { 13, "J.K.", "Rowling" },
                    { 14, "J.R.R.", "Tolkien" },
                    { 15, "Augusten", "Burroughs" },
                    { 16, "Harper", "Lee" },
                    { 17, "Leo", "Tolstoy" },
                    { 18, "Jane", "Austen" },
                    { 19, "F. Scott", "Fitzgerald" },
                    { 20, "Agatha", "Christie" },
                    { 21, "Dan", "Brown" },
                    { 22, "Mark", "Twain" },
                    { 23, "J.D.", "Salinger" },
                    { 24, "Ernest", "Hemingway" },
                    { 25, "Aldous", "Huxley" },
                    { 26, "Herman", "Melville" },
                    { 27, "Stephen", "King" },
                    { 28, "J.R.R.", "Tolkien" },
                    { 29, "Lewis", "Carroll" },
                    { 30, "Andy", "Weir" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Novel" },
                    { 2, "SciFi" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Mystery" },
                    { 6, "history" },
                    { 7, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "AuthorId", "BookId", "GenreId", "Price", "Title" },
                values: new object[,]
                {
                    { "0-670-81302-8", 1, 4, 4, 15.24, "It" },
                    { "000000014", 21, 24, 6, 15.99, "Sapiens: A Brief History of Humankind" },
                    { "00000006", 14, 16, 1, 10.99, "To Kill a Mockingbird" },
                    { "00000007", 15, 17, 3, 16.989999999999998, "Romeo and Juliet" },
                    { "00000008", 16, 18, 4, 35.780000000000001, "The Shining" },
                    { "00000009", 17, 19, 6, 24.09, "A People's History of the United States" },
                    { "00000010", 18, 20, 2, 19.989999999999998, "Dune" },
                    { "00000011", 19, 11, 1, 12.99, "Pride and Prejudice" },
                    { "00000012", 15, 22, 3, 50.890000000000001, "Hamlet" },
                    { "00000013", 20, 23, 4, 14.99, "The Exorcist" },
                    { "00000015", 22, 25, 2, 21.25, "Neuromancer" },
                    { "00000016", 23, 26, 1, 60.990000000000002, "The Great Gatsby" },
                    { "00000017", 15, 27, 3, 28.0, "Macbeth" },
                    { "00000018", 16, 28, 4, 16.5, "It" },
                    { "00000019", 14, 29, 6, 32.990000000000002, "The Wright Brothers" },
                    { "00000020", 15, 30, 2, 13.99, "Foundation" },
                    { "00000095", 19, 34, 1, 18.989999999999998, "Love in the Night" },
                    { "00000097", 23, 35, 1, 13.67, "The Catcher in the Rye" },
                    { "000092", 14, 32, 7, 14.99, "The Lord of the Rings" },
                    { "000096", 14, 33, 7, 17.989999999999998, "The Silmarillion" },
                    { "978-0-385-08695-0", 1, 1, 4, 14.94, "Carrie" },
                    { "978-0-670-22026-7", 1, 2, 1, 17.989999999999998, "Christine" },
                    { "978-0-670-81364-3", 1, 5, 1, 13.69, "Misery" },
                    { "978-0-937986-50-9", 1, 3, 1, 11.619999999999999, "The Dark Tower: The Gunslinger" },
                    { "978-0062073488", 2, 9, 5, 12.99, "And Then There Were None" },
                    { "978-0062073501", 2, 8, 5, 11.99, "Murder on the Orient Express" },
                    { "978-0062073563", 2, 6, 5, 14.99, "The Murder of Roger Ackroyd" },
                    { "978-0062073587", 2, 10, 5, 20.870000000000001, "The ABC Murders" },
                    { "978-0062074027", 2, 7, 5, 19.989999999999998, "Peril at End House" },
                    { "978-0385334679", 3, 15, 3, 24.010000000000002, "His Bright Light" },
                    { "978-0552142458", 3, 12, 1, 25.739999999999998, "The Gift" },
                    { "978-0593339169", 3, 13, 3, 27.800000000000001, "All That Glitters" },
                    { "978-1459745186", 3, 11, 3, 12.99, "Safe Harbour" },
                    { "978-1984821461", 3, 14, 1, 24.73, "Finding Ashley" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
