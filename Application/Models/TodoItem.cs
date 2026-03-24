namespace Application.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; set; }
}