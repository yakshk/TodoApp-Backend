using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Application.Request;
using MediatR;

namespace Application.Handlers;

public class CreateTodoHandler(ITodoRepository repo) : IRequestHandler<CreateTodoRequest, TodoDto>
{
    public async Task<TodoDto> Handle(CreateTodoRequest request, CancellationToken ct)
    {
        var item = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            IsCompleted = false
        };

        await repo.AddAsync(item);

        return item.ToDto();
    }
}