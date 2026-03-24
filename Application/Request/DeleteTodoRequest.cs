using MediatR;

namespace Application.Request;

public class DeleteTodoRequest(Guid id) : IRequest<bool>
{
    public Guid Id { get; set; } = id;
}