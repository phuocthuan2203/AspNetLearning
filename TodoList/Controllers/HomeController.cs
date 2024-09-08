using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers;

public class HomeController(TodoListManager listManager, ILogger<HomeController> logger)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly TodoListManager _listManager = listManager;

    public IActionResult Index()
    {
        var todoItems = _listManager.GetTodoItems();
        
        return View(new TodoItemViewModel()
        {
            Items = todoItems.Select(ti => new Item()
            {
                Id = ti.Id,
                Text = ti.Text,
                IsCompleted = ti.IsCompleted
            })
        });
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost]
    public IActionResult Add(Item item)
    {
        _listManager.AddTodoItem(new TodoItem()
        {
            Id = item.Id,
            Text = item.Text,
            IsCompleted = false
        });

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}