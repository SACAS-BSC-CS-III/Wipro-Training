using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        // Simulate user role check
        var isAdmin = HttpContext.User.IsInRole("Admin");

        if (isAdmin)
            return RedirectToAction("AdminDashboard");
        else
            return RedirectToAction("UserDashboard");
    }

    public IActionResult AdminDashboard()
    {
        return View();
    }

    public IActionResult UserDashboard()
    {
        return View();
    }
}
