using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BookStoreApp.Models
{
    public class AuthorViewModel 
    {
        Author author { get; set; }
        public PagedList<Author> PageResult { get; set; }
        public string SearchString { get; set; }
    }
}
