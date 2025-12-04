using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BWDotNetTrainingBatch5.MvcApp.Models;

namespace BWDotNetTrainingBatch5.MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = "How are you?";
        ViewData["Message2"] = "As for me, I'm fine.";

        HomeResponseModel model = new HomeResponseModel();
        model.AlertMessage = "I hope you're well.";
        
        // return Redirect("/Home/Privacy");
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index2()
    {
        return View();
    }
}