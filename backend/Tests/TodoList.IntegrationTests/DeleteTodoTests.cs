using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.WebApi;

namespace TodoList.IntegrationTests
{
    public class DeleteTodoTests : BaseTest
    {
        public DeleteTodoTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Delete_TodoItem_Should_Return_NoContent()
        {
            var newTodo = new TodoItem { Title = "Task to Delete", IsCompleted = false };
            var createResponse = await _client.PostAsJsonAsync("/api/todo", newTodo);
            var createdTodo = await createResponse.Content.ReadFromJsonAsync<TodoItem>();

            var deleteResponse = await _client.DeleteAsync($"/api/todo/{createdTodo!.Id}");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            var getDeletedResponse = await _client.GetAsync($"/api/todo/{createdTodo.Id}");
            getDeletedResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
