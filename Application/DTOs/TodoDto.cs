namespace Application.DTOs;

public class TodoDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; init; }
}