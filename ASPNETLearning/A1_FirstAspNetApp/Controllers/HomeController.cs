using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _01_FirstAPSNETApp.Models;

namespace _01_FirstAPSNETApp.Controllers;

// [Route("home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repository;

    public HomeController(IRepository repository, ILogger<HomeController> logger)
    {
        _repository = repository;
        _logger = logger;
        // _logger.LogInformation("NEW");
    }

    // [HttpGet("index")]
    public IActionResult Index()
    {
        return View(new HelloModel() {Name = "Nguyen Phuoc Thuan"});
    }

    public IActionResult Privacy()
    {
        return View("Index", new HelloModel() {Name = "Nguyen Phuoc Thuan"});
    }
    
    public IActionResult NewActionMethod(string name)
    {
        return Content("Hi from NewActionMethod!" + _repository.GetById("MYID"));
    }

    public IActionResult Contact()
    {
        return View();
    }
    
    // FromServices attribute
    [HttpGet]
    [Route("/api/users")]
    public IActionResult Users([FromHeader] string apiKey, [FromServices] IUserRepository userRepository)
    {
        _logger.LogInformation("[Users] METHOD: {m}, apiKey = {api}", Request.Method, apiKey);
        ValidateApiKey(apiKey);
        return Content($"Users: {string.Join(',', userRepository.Users)}");
    }
    
    [HttpPost]
    [Route("/api/users")]
    public IActionResult Users([FromHeader] string apiKey, [FromServices] IUserRepository userRepository, string user)
    {
        _logger.LogInformation("[Users] METHOD: {m}, apiKey = {api}", Request.Method, apiKey);
        ValidateApiKey(apiKey);
        userRepository.Add(user);
        return Ok();
    }

    private void ValidateApiKey(string apiKey)
    {
        if (apiKey == null)
        {
            throw new ArgumentNullException(nameof(apiKey));
        }
    }
    // End FromServices attribute

    // [HttpGet]
    // public IActionResult Users([FromHeader]string myParam)
    // {
    //     _logger.LogInformation("[Users] METHOD: {m}, myParam = {p}", Request.Method, myParam);
    //
    //     return Content("Users, myParam " + myParam);
    // }
    
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