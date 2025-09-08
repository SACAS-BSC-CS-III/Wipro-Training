using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcAuthDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue("UserId") ?? "UNKNOWN";
            ViewBag.UserId = userId;
            return View();
        }
    }
}
