using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _02_Attribute.Models;

namespace _02_Attribute.Controllers;

// [NonController]
public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // [NonAction]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpGet]
    [Route("/api/users")]
    public IActionResult Users([FromHeader]string apiKey, [FromServices]IUserRepository userRepository)
    {
        _logger.LogInformation("[Users] METHOD: {m}, apiKey = {api}", Request.Method, apiKey);
        
        return Content($"Users: {string.Join(',', userRepository.Users)}"); // join each user together
    }
    
    [HttpPost]
    [Route("/api/users")]
    public IActionResult Users([FromHeader]string apiKey, [FromServices]IUserRepository userRepository, string user)
    {
        _logger.LogInformation("[Users] METHOD: {m}, apiKey = {api}", Request.Method, apiKey);
        userRepository.Add(user);
        ValidateApiKey(apiKey);
        return Ok();
    }

    private static void ValidateApiKey(string apiKey)
    {
        ArgumentNullException.ThrowIfNull(apiKey);
    }

    // [HttpPost]
    // public IActionResult Users(string user)
    // {
    //     _logger.LogInformation("[Users] METHOD: {m}", Request.Method);
    //     
    //     return Content("User added: " + user);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}