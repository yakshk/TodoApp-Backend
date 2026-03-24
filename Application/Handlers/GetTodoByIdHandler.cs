using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Request;
using MediatR;

namespace Application.Handlers;

public class GetTodoByIdHandler(ITodoRepository repo) : IRequestHandler<GetTodoByIdRequest, TodoDto?>
{
    public async Task<TodoDto?> Handle(GetTodoByIdRequest request, CancellationToken ct)
    {
        var item = await repo.GetByIdAsync(request.Id);
        return item?.ToDto();
    }
}