using Microsoft.AspNetCore.Mvc;

namespace RoleAuthApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
