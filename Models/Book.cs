using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStoreApp.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }  // primary key

        public int BookId { get; set; }  
        [Required]
        [StringLength(200)]
        public string Title { get; set; } // not nullable

        public double Price { get; set; }

        public int AuthorId { get; set; } = 0; // foreign key property

        public Author authorObject { get; set; } = null!;

        // foreign key property
        public int GenreId { get; set; } = 0; // foreign key property

        // navigation property
        public Genre Genre { get; set; } = null!;



    }
}
