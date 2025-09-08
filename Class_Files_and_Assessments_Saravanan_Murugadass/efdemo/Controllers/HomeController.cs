using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efdemo.Models;
using EFCoreExamples.Models;

namespace efdemo.Controllers;
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    public class HomeController : Controller
{
    private CompanyContext context;

    public HomeController(CompanyContext cc)
    {
        context = cc;
    }

    public IActionResult Index()
    {
        var dept = new Department()
        {
            Name = "Designing"
        };

        context.Entry(dept).State = EntityState.Added;
        context.SaveChanges();

        return View();
    }
}

