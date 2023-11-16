using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApp.Models
{
	public class BookViewModel
	{
		public Book Book { get; set; }
		public PagedList<Book> PageResult { get; set; }
		public SelectList Genres { get; set; }
		public int SelectedGenreId { get; set; }
	}
}
