namespace Application.DTOs;

public class TodoDto
{
    public Guid Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; init; }
}