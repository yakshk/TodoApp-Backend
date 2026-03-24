using Application.DTOs;
using Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpGet("getAll")]
    public Task<List<TodoDto>> Get()
    {
        return mediator.Send(new GetAllTodosRequest());
    }

    [HttpPost("create")]
    public Task<TodoDto> Create([FromBody] CreateTodoRequest request)
    {
        var result = mediator.Send(request);
        return result;
    }

    [HttpPatch("toggleComplete/{id:guid}")]
    public async Task<IActionResult> Update(Guid id) // TODO YK
    {
        var result = await mediator.Send(new ToggleTodoCompleteRequest(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await mediator.Send(new DeleteTodoRequest(id));
        return success ? Ok(new { message = "Todo deleted successfully" }) : NotFound();
    }
}