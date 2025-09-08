using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    public IActionResult Details(string category, int id)
    {
        ViewData["Category"] = category;
        ViewData["ProductId"] = id;
        return View();
    }
}
