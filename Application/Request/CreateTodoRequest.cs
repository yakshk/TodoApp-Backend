using Application.DTOs;
using MediatR;

namespace Application.Request;

public class CreateTodoRequest : IRequest<TodoDto>
{
    public string Title { get; set; } = string.Empty;
}