using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace BookStoreApp.Controllers
{
    public class AuthorController : Controller
    {
        private BookstoreContext context { get; set; }
        public AuthorController(BookstoreContext ctx) => context = ctx;

        public IActionResult Index(int page = 1, int pageSize = 5, int selectedGenreId = 0, string searchString = null)
        {
            int skip = (page - 1) * pageSize;
            var genres = context.Genres.ToList();

			// Search the books based on the selected genre.
			IQueryable<Author> authorQuery = context.Authors.OrderBy(a => a.LastName);


			if (!string.IsNullOrEmpty(searchString))
			{
				authorQuery = authorQuery.Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString));
			}


			var totalCount = authorQuery.Count();
            var author = authorQuery.Skip(skip).Take(pageSize).ToList();

            var pagedList = new PagedList<Author>
            {
                Items = author,
                PageNumber = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            var viewModel = new AuthorViewModel
            {
                PageResult = pagedList,
                SearchString = searchString

            };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await context.Authors.FindAsync(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FirstName,LastName")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(author);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        private bool AuthorExists(int id)
        {
            return context.Authors.Any(e => e.AuthorId == id);
        }


    }
}
