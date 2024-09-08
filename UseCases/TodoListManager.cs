using Entity;

namespace UseCases;

public class TodoListManager(ITodoItemRepository repository)
{
    private readonly ITodoItemRepository _repository = repository;

    public IEnumerable<TodoItem> GetTodoItems()
    {
        return _repository.GetItems();
    }

    public void AddTodoItem(TodoItem item)
    {
        _repository.Add(item);
    }

    public void MarkComplete(int id)
    {
        var item = _repository.GetById(id);
        if (item != null)
        {
            item.IsCompleted = true;
            _repository.Update(item);
        }
    }
    
    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}