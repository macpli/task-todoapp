using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.WebApi;

namespace TodoList.IntegrationTests
{
    public class ReadTodoTests : BaseTest
    {
        public ReadTodoTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Get_TodoItems_Should_Return_Ok()
        {
            var response = await _client.GetAsync("/api/todo");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var todos = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
            todos.Should().NotBeNull();
        }
    }
}
