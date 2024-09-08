namespace TodoList.Models;

public class TodoItemViewModel
{
    public required IEnumerable<Item> Items { get; init; }
}