using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.WebApi;

namespace TodoList.IntegrationTests
{
    public class CreateTodoTests : BaseTest
    {
        public CreateTodoTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Create_TodoItem_Should_Return_Created()
        {
            var newTodo = new TodoItem { Title = "Test Task", IsCompleted = false };
            var response = await _client.PostAsJsonAsync("/api/todo", newTodo);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var createdTodo = await response.Content.ReadFromJsonAsync<TodoItem>();

            createdTodo.Should().NotBeNull();
            createdTodo!.Title.Should().Be("Test Task");
        }
    }
}
