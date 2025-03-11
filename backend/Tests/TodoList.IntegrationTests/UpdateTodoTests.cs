using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.WebApi;

namespace TodoList.IntegrationTests
{
    public class UpdateTodoTests : BaseTest
    {
        public UpdateTodoTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Update_TodoItem_Should_Return_NoContent()
        {
            var newTodo = new TodoItem { Title = "Old Task", IsCompleted = false };
            var createResponse = await _client.PostAsJsonAsync("/api/todo", newTodo);
            var createdTodo = await createResponse.Content.ReadFromJsonAsync<TodoItem>();

            createdTodo!.Title = "Updated Task";
            createdTodo.IsCompleted = true;

            var updateResponse = await _client.PutAsJsonAsync($"/api/todo/{createdTodo.Id}", createdTodo);
            updateResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            var getResponse = await _client.GetAsync($"/api/todo/{createdTodo.Id}");
            var updatedTodo = await getResponse.Content.ReadFromJsonAsync<TodoItem>();

            updatedTodo!.Title.Should().Be("Updated Task");
            updatedTodo.IsCompleted.Should().BeTrue();
        }
    }
}
