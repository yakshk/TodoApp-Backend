using Application.Interfaces;
using Application.Request;
using MediatR;

namespace Application.Handlers;

public class DeleteTodoHandler(ITodoRepository repo) : IRequestHandler<DeleteTodoRequest, bool>
{
    public async Task<bool> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
    {
        var existing = await repo.GetByIdAsync(request.Id);
        if (existing is null) return false;

        await repo.DeleteAsync(request.Id);
        return true;
    }
}