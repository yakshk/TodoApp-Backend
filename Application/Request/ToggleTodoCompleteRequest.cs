using Application.DTOs;
using MediatR;

namespace Application.Request;

public class ToggleTodoCompleteRequest(Guid id) : IRequest<TodoDto?>
{
    public Guid Id { get; set; } = id;
}