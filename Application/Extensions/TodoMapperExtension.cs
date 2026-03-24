using Application.DTOs;
using Application.Models;

namespace Application.Extensions;

internal static class TodoMapperExtension
{
    internal static TodoDto ToDto(this TodoItem item)
    {
        return new TodoDto
        {
            Id = item.Id,
            Title = item.Title,
            IsCompleted = item.IsCompleted
        };
    }
}