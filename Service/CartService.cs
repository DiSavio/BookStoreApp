using BookStoreApp.Models;
using Newtonsoft.Json;

public class CartService
{
    private readonly HttpContext _httpContext;

    public CartService(HttpContext httpContext)
    {
        _httpContext = httpContext;
    }

    public void AddToCart(int bookId, string bookTitle)
    {
        var cart = GetCart();

        // Add the book to the cart
        cart.Add(new CartItem { BookId = bookId, Title = bookTitle });

        // Save the updated cart to the cookie
        SaveCart(cart);
    }

    public void RemoveFromCart(int bookId)
    {
        var cart = GetCart();

        // Remove the first matching book from the cart
        var itemToRemove = cart.FirstOrDefault(item => item.BookId == bookId);
        if (itemToRemove != null)
        {
            cart.Remove(itemToRemove);
            SaveCart(cart);
        }
    }

    public List<CartItem> GetCart()
    {
        var cartCookie = _httpContext.Request.Cookies["cart"];

        if (cartCookie != null)
        {
            // Deserialize the cart from the cookie
            return JsonConvert.DeserializeObject<List<CartItem>>(cartCookie);
        }

        // If no cart exists, create a new one
        return new List<CartItem>();
    }

    public void SaveCart(List<CartItem> cart)
    {
        // Serialize the cart and save it to the cookie
        var cartJson = JsonConvert.SerializeObject(cart);

        _httpContext.Response.Cookies.Append("cart", cartJson, new CookieOptions
        {
            // Set the cookie to expire in 30 days
            Expires = DateTime.Now.AddDays(30)
        });
    }
}
