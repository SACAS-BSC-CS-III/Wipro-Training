using Microsoft.AspNetCore.Mvc;

namespace ECommerceRoutingApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("Checkout")]
        public IActionResult Checkout()
        {
            if (!User?.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
