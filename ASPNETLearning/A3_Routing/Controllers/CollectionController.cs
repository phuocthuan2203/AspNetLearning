using Microsoft.AspNetCore.Mvc;

namespace _03_Routing.Controllers;

public class CollectionController : Controller
{
    public IActionResult Index(string id)
    {
        // return View("Index", id);
        return View((object?)id);
    }
}