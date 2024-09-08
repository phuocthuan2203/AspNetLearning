using _03_Routing.Models;
using Microsoft.AspNetCore.Mvc;

namespace _03_Routing.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("/p/{id:int}")]
    public IActionResult Details(int id)
    {
        return View(new Product()
        {
            Id = id.ToString(),
            Name = $"Product name: {id} (int)"
        });
    }
    
    [Route("/p/{name}")]
    public IActionResult Details(string name)
    {
        return View(new Product()
        {
            Id = name,
            Name = $"Product name: {name} (string)"
        });
    }
}