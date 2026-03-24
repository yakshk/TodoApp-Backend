using Application.Interfaces;
using Application.Models;

namespace Infrastructure.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _items = [];

    public Task<List<TodoItem>> GetAllAsync()
    {
        return Task.FromResult(_items.ToList());
    }

    public Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_items.FirstOrDefault(x => x.Id == id));
    }

    public Task AddAsync(TodoItem item)
    {
        _items.Add(item);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _items.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }
}