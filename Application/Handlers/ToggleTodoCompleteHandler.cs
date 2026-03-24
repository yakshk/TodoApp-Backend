using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Request;
using MediatR;

namespace Application.Handlers;

public class ToggleTodoCompleteHandler(ITodoRepository repo) : IRequestHandler<ToggleTodoCompleteRequest, TodoDto?>
{
    public async Task<TodoDto?> Handle(ToggleTodoCompleteRequest request, CancellationToken cancellationToken)
    {
        var item = await repo.GetByIdAsync(request.Id);
        if (item is null) return null;

        item.IsCompleted = !item.IsCompleted;

        return item.ToDto();
    }
}