using Microsoft.AspNetCore.Mvc;
using System;

public class OrdersController : Controller
{
    public IActionResult Details(Guid orderId)
    {
        ViewData["OrderId"] = orderId;
        return View();
    }
}
