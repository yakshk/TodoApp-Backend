using Application.DTOs;
using MediatR;

namespace Application.Request;

public class GetTodoByIdRequest(Guid id) : IRequest<TodoDto?>
{
    public Guid Id { get; set; } = id;
}