using Entity;

namespace UseCases;

public interface ITodoItemRepository
{
    IEnumerable<TodoItem> GetItems();
    void Add(TodoItem item);
    TodoItem? GetById(int id);
    void Update(TodoItem item);
    void Delete(int id);
}