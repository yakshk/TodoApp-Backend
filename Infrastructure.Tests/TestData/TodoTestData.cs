using Application.Models;

namespace Infrastructure.Tests.TestData;

public static class TodoTestData
{
    public static TodoItem SampleTodoItem()
    {
        return new TodoItem
        {
            Id = Guid.Parse("105d8261-f8ab-43a0-9dd3-09974968002f"),
            Title = "Buy milk",
            IsCompleted = true
        };
    }
}