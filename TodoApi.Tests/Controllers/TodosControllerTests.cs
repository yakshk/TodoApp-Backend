using Application.DTOs;
using Application.Request;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApi.Controllers;
using TodoApi.Tests.TestData;
using Xunit;

namespace TodoApi.Tests.Controllers;

public class TodosControllerTests
{
    private readonly TodosController _controller;
    private readonly Mock<IMediator> _mediator = new();

    public TodosControllerTests()
    {
        _controller = new TodosController(_mediator.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnListOfTodos()
    {
        var expected = new List<TodoDto> { TodoTestData.SampleTodoDto() };

        _mediator.Setup(m => m.Send(It.IsAny<GetAllTodosRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        var result = await _controller.GetAll();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmptyList_WhenNoTodosExist()
    {
        _mediator.Setup(m => m.Send(It.IsAny<GetAllTodosRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        var result = await _controller.GetAll();

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Create_ShouldReturnCreatedTodo()
    {
        var request = TodoTestData.SampleCreateTodoRequest();
        var expected = TodoTestData.SampleTodoDto();
        expected.Title = request.Title;

        _mediator.Setup(m => m.Send(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        var result = await _controller.Create(request);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Create_ShouldThrow_WhenMediatorThrows()
    {
        var request = TodoTestData.SampleCreateTodoRequest();

        _mediator.Setup(m => m.Send(request, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Failure"));

        Func<Task> act = async () => await _controller.Create(request);

        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Failure");
    }

    [Fact]
    public async Task ToggleComplete_ShouldReturnOk_WhenTodoExists()
    {
        var id = Guid.NewGuid();
        var dto = TodoTestData.SampleTodoDto();

        _mediator.Setup(m => m.Send(It.IsAny<ToggleTodoCompleteRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(dto);

        var result = await _controller.ToggleComplete(id);

        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(dto);
    }

    [Fact]
    public async Task ToggleComplete_ShouldReturnNotFound_WhenTodoDoesNotExist()
    {
        var id = Guid.NewGuid();

        _mediator.Setup(m => m.Send(It.IsAny<ToggleTodoCompleteRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((TodoDto?)null);

        var result = await _controller.ToggleComplete(id);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task ToggleComplete_ShouldThrow_WhenMediatorThrows()
    {
        var id = Guid.NewGuid();

        _mediator.Setup(m => m.Send(It.IsAny<ToggleTodoCompleteRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Unexpected"));

        Func<Task> act = async () => await _controller.ToggleComplete(id);

        await act.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public async Task Delete_ShouldReturnOk_WhenDeleteSucceeds()
    {
        var id = Guid.NewGuid();

        _mediator.Setup(m => m.Send(It.IsAny<DeleteTodoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.Delete(id);

        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(new { message = "Todo deleted successfully" });
    }

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenDeleteFails()
    {
        var id = Guid.NewGuid();

        _mediator.Setup(m => m.Send(It.IsAny<DeleteTodoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.Delete(id);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Delete_ShouldThrow_WhenMediatorThrows()
    {
        var id = Guid.NewGuid();

        _mediator.Setup(m => m.Send(It.IsAny<DeleteTodoRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Failure"));

        Func<Task> act = async () => await _controller.Delete(id);

        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Failure");
    }
}