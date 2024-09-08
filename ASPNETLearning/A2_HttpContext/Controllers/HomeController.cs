using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _02_HttpContext.Models;

namespace _02_HttpContext.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Accessing the HttpContext object
        // Request is a property of HttpContext that represents the incoming request
        var method = HttpContext.Request.Method;  // e.g., "GET"
        
        // Accessing a specific header
        var userAgent = HttpContext.Request.Headers.UserAgent!;
        
        // Creating a response based on the request information
        var responseMessage = $"Request Method: {method}, User-Agent: {userAgent}";
        
        return Content(responseMessage);
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
}