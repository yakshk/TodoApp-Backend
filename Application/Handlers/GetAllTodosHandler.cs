using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Request;
using MediatR;

namespace Application.Handlers;

public class GetAllTodosHandler(ITodoRepository repo) : IRequestHandler<GetAllTodosRequest, List<TodoDto>>
{
    public async Task<List<TodoDto>> Handle(GetAllTodosRequest request, CancellationToken ct)
    {
        var items = await repo.GetAllAsync();
        return items.Select(x => x.ToDto()).ToList();
    }
}