using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    public IActionResult Orders(string username)
    {
        ViewData["Username"] = username;
        return View();
    }
}
