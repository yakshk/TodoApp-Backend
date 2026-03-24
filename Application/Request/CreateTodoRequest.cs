using Application.DTOs;
using MediatR;

namespace Application.Request;

public class CreateTodoRequest : IRequest<TodoDto>
{
    // TODO YK check setter
    public string Title { get; set; } = string.Empty;
}