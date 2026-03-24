using Application.DTOs;
using Application.Request;

namespace TodoApi.Tests.TestData;

public static class TodoTestData
{
    public static TodoDto SampleTodoDto()
    {
        return new TodoDto
        {
            Id = Guid.Parse("43fad32b-39f1-49f6-b538-f1d3da0bad43"),
            Title = "Buy cereal",
            IsCompleted = false
        };
    }

    public static CreateTodoRequest SampleCreateTodoRequest()
    {
        return new CreateTodoRequest
        {
            Title = "Clean car"
        };
    }
}