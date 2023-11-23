namespace BookStoreApp.Models
{
    public class AuthorViewModel
    {
        Author author { get; set; }
        public PagedList<Author> PageResult { get; set; }
        public string SearchString { get; set; }
    }
}
