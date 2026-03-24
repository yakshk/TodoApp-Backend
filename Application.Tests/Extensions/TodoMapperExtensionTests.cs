using Application.Extensions;
using Application.Models;
using Xunit;

namespace Application.Tests.Extensions;

public class TodoMapperExtensionTests
{
    [Fact]
    public Task TodoItem_ToDto_ShouldReturnDto()
    {
        var item = new TodoItem
        {
            Id = Guid.Parse("87205af5-5894-447c-8c0f-a39734d923cb"),
            Title = "Buy milk",
            IsCompleted = true
        };

        var result = item.ToDto();

        // Using Assert rather than Should here to demonstrate knowledge.
        Assert.Equal(item.Id, result.Id);
        Assert.Equal(item.Title, result.Title);
        Assert.Equal(item.IsCompleted, result.IsCompleted);
        return Task.CompletedTask;
    }
}