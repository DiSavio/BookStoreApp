using BookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {

        private BookstoreContext context { get; set; }
        public BookController(BookstoreContext ctx) =>  context = ctx;
        public IActionResult Index(int page = 1, int pageSize = 5, int selectedGenreId = 0)
        {

			int skip = (page - 1) * pageSize;
			var genres = context.Genres.ToList();

			// Search the books based on the selected genre.
			var booksQuery = context.Books.Include(m => m.Genre).Include(m => m.authorObject).OrderBy(m => m.Title);
			if (selectedGenreId != 0)
			{
				booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.GenreId == selectedGenreId);
			}
			var totalCount = booksQuery.Count();
			var books = booksQuery.Skip(skip).Take(pageSize).ToList();

			var pagedList = new PagedList<Book>
			{
				Items = books,
				PageNumber = page,
				PageSize = pageSize,
				TotalCount = totalCount
			};

			var viewModel = new BookViewModel
			{
				PageResult = pagedList,
				Genres = new SelectList(genres, "GenreId", "Name"),
				SelectedGenreId = selectedGenreId
			};

			return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            // Assuming you have a CartService to manage the cart logic
            var cartService = new CartService(HttpContext);

            // Add the selected book to the cart
            cartService.AddToCart(model.Book.BookId, model.Book.Title);

            // Optionally, you can set a message to display on the cart page
            TempData["message"] = $"{model.Book.Title} has been added to your cart.";

            // Redirect back to the book catalog page
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string isbn)
		{
			var book = context.Books.Find(isbn); 
			if (book == null)
			{
				return NotFound();
			}
			context.Books.Remove(book);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult Edit(string isbn)
        {
            var bookToEdit = context.Books.Find(isbn);

            ViewBag.Authors = context.Authors.ToList();
            ViewBag.Genres = context.Genres.ToList();

            return View(bookToEdit);
        }


        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingGenre = context.Genres.FirstOrDefault(g => g.Name == book.Genre.Name);
                var existingAuthor = context.Authors.FirstOrDefault(a => a.AuthorId == book.authorObject.AuthorId);

                if (existingGenre != null)
                {
                    book.GenreId = existingGenre.GenreId;
                    book.Genre = null;
                }
                else
                {
                    ViewBag.ErrorMessage = "The provided genre does not exist.";
                    return View("Edit", book);
                }

                if (existingAuthor != null)
                {
                    book.AuthorId = existingAuthor.AuthorId;
                    book.authorObject = null;
                }
                else
                {

                    ViewBag.ErrorMessage = "The provided author does not exist.";
                    return View("Edit", book);
                }

                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Oops! Something went wrong. Please check the entered information.";
                return View("Edit", book);
            }
        }


        }
}
