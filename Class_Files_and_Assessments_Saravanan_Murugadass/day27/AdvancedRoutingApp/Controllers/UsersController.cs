using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    [Route("Dashboard")]
    public IActionResult Dashboard()
    {
        var role = HttpContext.Session.GetString("UserRole") ?? "guest";

        if (role == "admin")
            return View("AdminDashboard");
        else
            return View("UserDashboard");
    }
}
