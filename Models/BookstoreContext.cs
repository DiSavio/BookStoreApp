using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Models
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Genre>().HasData(
		  new Genre { GenreId = 1, Name = "Novel" },
		  new Genre { GenreId = 2, Name = "SciFi" },
		  new Genre { GenreId = 3, Name = "Drama" },
		  new Genre { GenreId = 4, Name = "Horror" },
		  new Genre { GenreId = 5, Name = "Mystery" },
		  new Genre { GenreId = 6, Name = "history" },
		  new Genre { GenreId = 7, Name = "Fantasy" }

	  );

			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					BookId = 1,
					Title = "Carrie",
					ISBN = "978-0-385-08695-0",
					GenreId = 4,
					AuthorId = 1,
					Price = 14.94
				},
				new Book
				{
					BookId = 2,
					Title = "Christine",
					ISBN = "978-0-670-22026-7",
					GenreId = 1,
					AuthorId = 1,
					Price = 17.99
				},

				new Book
				{
					BookId = 3,
					Title = "The Dark Tower: The Gunslinger",
					ISBN = "978-0-937986-50-9",
					GenreId = 1,
					AuthorId = 1,
					Price = 11.62
				},
				new Book
				{
					BookId = 4,
					Title = "It",
					ISBN = "0-670-81302-8",
					GenreId = 4,
					AuthorId = 1,
					Price = 15.24
				},
				new Book
				{
					BookId = 5,
					GenreId = 1,
					AuthorId = 1,
					Title = "Misery",
					ISBN = "978-0-670-81364-3",
					Price = 13.69
				},
				new Book
				{
					BookId = 6,
					GenreId = 5,
					AuthorId = 2,
					Title = "The Murder of Roger Ackroyd",
					ISBN = "978-0062073563",
					Price = 14.99
				},
				new Book
				{
					BookId = 7,
					GenreId = 5,
					AuthorId = 2,
					Title = "Peril at End House",
					ISBN = "978-0062074027",
					Price = 19.99
				},
				new Book
				{
					BookId = 8,
					GenreId = 5,
					AuthorId = 2,
					Title = "Murder on the Orient Express",
					ISBN = "978-0062073501",
					Price = 11.99
				},
				new Book
				{
					BookId = 9,
					GenreId = 5,
					AuthorId = 2,
					Title = "And Then There Were None",
					ISBN = "978-0062073488",
					Price = 12.99
				},
				new Book
				{
					BookId = 10,
					GenreId = 5,
					AuthorId = 2,
					Title = "The ABC Murders",
					ISBN = "978-0062073587",
					Price = 20.87
				},
				new Book
				{
					BookId = 11,
					GenreId = 3,
					AuthorId = 3,
					Title = "Safe Harbour",
					ISBN = "978-1459745186",
					Price = 12.99
				},
				new Book
				{
					BookId = 12,
					GenreId = 1,
					AuthorId = 3,
					Title = "The Gift",
					ISBN = "978-0552142458",
					Price = 25.74
				},
				new Book
				{
					BookId = 13,
					GenreId = 3,
					AuthorId = 3,
					Title = "All That Glitters",
					ISBN = "978-0593339169",
					Price = 27.80
				},
				new Book
				{
					BookId = 14,
					GenreId = 1,
					AuthorId = 3,
					Title = "Finding Ashley",
					ISBN = "978-1984821461",
					Price = 24.73
				},
				new Book
				{
					BookId = 15,
					GenreId = 3,
					AuthorId = 3,
					Title = "His Bright Light",
					ISBN = "978-0385334679",
					Price = 24.01
				},









				new Book
				{
					BookId = 16,
					GenreId = 1,
					AuthorId = 14,
					Title = "To Kill a Mockingbird",
					ISBN = "00000006",
					Price = 10.99
				},
				new Book
				{
					BookId = 17,
					GenreId = 3,
					AuthorId = 15,
					Title = "Romeo and Juliet",
					ISBN = "00000007",
					Price = 16.99
				},
				new Book
				{
					BookId = 18,
					GenreId = 4,
					AuthorId = 16,
					Title = "The Shining",
					ISBN = "00000008",
					Price = 35.78
				},
				new Book
				{
					BookId = 19,
					GenreId = 6,
					AuthorId = 17,
					Title = "A People's History of the United States",
					ISBN = "00000009",
					Price = 24.09
				},
				new Book
				{
					BookId = 20,
					GenreId = 2,
					AuthorId = 18,
					Title = "Dune",
					ISBN = "00000010",
					Price = 19.99
				},
				new Book
				{
					BookId = 11,
					GenreId = 1,
					AuthorId = 19,
					Title = "Pride and Prejudice",
					ISBN = "00000011",
					Price = 12.99
				},
				new Book
				{
					BookId = 22,
					GenreId = 3,
					AuthorId = 15,
					Title = "Hamlet",
					ISBN = "00000012",
					Price = 50.89
				},
				new Book
				{
					BookId = 23,
					GenreId = 4,
					AuthorId = 20,
					Title = "The Exorcist",
					ISBN = "00000013",
					Price = 14.99
				},
				new Book
				{
					BookId = 24,
					GenreId = 6,
					AuthorId = 21,
					Title = "Sapiens: A Brief History of Humankind",
					ISBN = "000000014",
					Price = 15.99
				},
				new Book
				{
					BookId = 25,
					GenreId = 2,
					AuthorId = 22,
					Title = "Neuromancer",
					ISBN = "00000015",
					Price = 21.25
				},
				new Book
				{
					BookId = 26,
					GenreId = 1,
					AuthorId = 23,
					Title = "The Great Gatsby",
					ISBN = "00000016",
					Price = 60.99
				},
				new Book
				{
					BookId = 27,
					GenreId = 3,
					AuthorId = 15,
					Title = "Macbeth",
					ISBN = "00000017",
					Price = 28
				},
				new Book
				{
					BookId = 28,
					GenreId = 4,
					AuthorId = 16,
					Title = "It",
					ISBN = "00000018",
					Price = 16.50
				},
				new Book
				{
					BookId = 29,
					GenreId = 6,
					AuthorId = 14,
					Title = "The Wright Brothers",
					ISBN = "00000019",
					Price = 32.99
				},
				new Book
				{
					BookId = 30,
					GenreId = 2,
					AuthorId = 15,
					Title = "Foundation",
					ISBN = "00000020",
					Price = 13.99
				},

				new Book
				{
					BookId = 32,
					Title = "The Lord of the Rings",
					ISBN = "000092",
					GenreId = 7,
					AuthorId = 14,
					Price = 14.99
				},

				 new Book
				 {
					 BookId = 33,
					 Title = "The Silmarillion",
					 ISBN = "000096",
					 GenreId = 7,
					 AuthorId = 14,
					 Price = 17.99
				 },


				 new Book
				 {
					 BookId = 34,
					 GenreId = 1,
					 AuthorId = 19,
					 Title = "Love in the Night",
					 ISBN = "00000095",
					 Price = 18.99
				 },
				 new Book
				 {
					 BookId = 35,
					 GenreId = 1,
					 AuthorId = 23,
					 Title = "The Catcher in the Rye",
					 ISBN = "00000097",
					 Price = 13.67
				 }

			);

            modelBuilder.Entity<Author>().HasData(
			   new Author
			   {
				   AuthorId = 1,
				   FirstName = "Stephen",
				   LastName = "King"
			   },
				new Author
				{
					AuthorId = 2,
					FirstName = "Agatha",
					LastName = "Christie"
				},

				new Author
				{
					AuthorId = 3,
					FirstName = "Danielle",
					LastName = "Steel"
				},




				new Author
				{
					AuthorId = 11,
					FirstName = "David",
					LastName = "McCullough"
				},
				new Author
				{
					AuthorId = 12,
					FirstName = "George",
					LastName = "Orwell"
				},
				new Author
				{
					AuthorId = 13,
					FirstName = "J.K.",
					LastName = "Rowling"
				},
				new Author
				{
					AuthorId = 14,
					FirstName = "J.R.R.",
					LastName = "Tolkien"
				},
				new Author
				{
					AuthorId = 15,
					FirstName = "Augusten",
					LastName = "Burroughs"
				},
				new Author
				{
					AuthorId = 16,
					FirstName = "Harper",
					LastName = "Lee"
				},
				new Author
				{
					AuthorId = 17,
					FirstName = "Leo",
					LastName = "Tolstoy"
				},
				new Author
				{
					AuthorId = 18,
					FirstName = "Jane",
					LastName = "Austen"
				},
				new Author
				{
					AuthorId = 19,
					FirstName = "F. Scott",
					LastName = "Fitzgerald"
				},
				new Author
				{
					AuthorId = 20,
					FirstName = "Agatha",
					LastName = "Christie"
				},
				new Author
				{
					AuthorId = 21,
					FirstName = "Dan",
					LastName = "Brown"
				},
				new Author
				{
					AuthorId = 22,
					FirstName = "Mark",
					LastName = "Twain"
				},
				new Author
				{
					AuthorId = 23,
					FirstName = "J.D.",
					LastName = "Salinger"
				},
				new Author
				{
					AuthorId = 24,
					FirstName = "Ernest",
					LastName = "Hemingway"
				},
				new Author
				{
					AuthorId = 25,
					FirstName = "Aldous",
					LastName = "Huxley"
				},
				new Author
				{
					AuthorId = 26,
					FirstName = "Herman",
					LastName = "Melville"
				},
				new Author
				{
					AuthorId = 27,
					FirstName = "Stephen",
					LastName = "King"
				},
				new Author
				{
					AuthorId = 28,
					FirstName = "J.R.R.",
					LastName = "Tolkien"
				},
				new Author
				{
					AuthorId = 29,
					FirstName = "Lewis",
					LastName = "Carroll"
				},
				new Author
				{
					AuthorId = 30,
					FirstName = "Andy",
					LastName = "Weir"
				}
			);
        }
    }
}
