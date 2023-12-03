using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CartController : Controller
{
    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Remove(int bookId)
    {
        // Assuming you have a CartService to manage the cart logic
        var cartService = new CartService(HttpContext);

        // Remove the selected book from the cart
        cartService.RemoveFromCart(bookId);

        // Redirect back to the cart page
        return RedirectToAction("Cart");
    }
}
