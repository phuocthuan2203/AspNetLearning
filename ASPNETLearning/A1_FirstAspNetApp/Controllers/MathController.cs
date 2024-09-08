using Microsoft.AspNetCore.Mvc;

namespace _01_FirstAPSNETApp.Controllers;

public class MathController : Controller
{
    // GET
    public IActionResult Sum(int firstNum, int secondNum)
    {
        return Content((firstNum + secondNum).ToString());
    }
}