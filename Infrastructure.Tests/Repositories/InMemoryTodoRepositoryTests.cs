using FluentAssertions;
using Infrastructure.Repositories;
using Infrastructure.Tests.TestData;
using Xunit;

namespace Infrastructure.Tests.Repositories;

public class InMemoryTodoRepositoryTests
{
    private readonly InMemoryTodoRepository _repo = new();

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoItemsExist()
    {
        var result = await _repo.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnCopyOfList_NotReference()
    {
        var item = TodoTestData.SampleTodoItem();

        await _repo.AddAsync(item);

        var list1 = await _repo.GetAllAsync();
        var list2 = await _repo.GetAllAsync();

        list1.Should().NotBeSameAs(list2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenItemDoesNotExist()
    {
        var result = await _repo.GetByIdAsync(Guid.NewGuid());

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectItem_WhenExists()
    {
        var id = Guid.NewGuid();
        var item = TodoTestData.SampleTodoItem();
        item.Id = id;

        await _repo.AddAsync(item);

        var result = await _repo.GetByIdAsync(id);

        result.Should().NotBeNull();
        result!.Id.Should().Be(id);
    }

    [Fact]
    public async Task AddAsync_ShouldAddItemToRepository()
    {
        var item = TodoTestData.SampleTodoItem();

        await _repo.AddAsync(item);

        var all = await _repo.GetAllAsync();
        all.Should().Contain(item);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDoNothing_WhenItemDoesNotExist()
    {
        await _repo.DeleteAsync(Guid.NewGuid());

        var all = await _repo.GetAllAsync();
        all.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveItem_WhenExists()
    {
        var id = Guid.NewGuid();
        var item = TodoTestData.SampleTodoItem();
        item.Id = id;

        await _repo.AddAsync(item);
        await _repo.DeleteAsync(id);

        var result = await _repo.GetByIdAsync(id);
        result.Should().BeNull();
    }
}