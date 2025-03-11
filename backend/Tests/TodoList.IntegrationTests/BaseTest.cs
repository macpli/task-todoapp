using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.WebApi;

namespace TodoList.IntegrationTests
{
    public abstract class BaseTest : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;

        public BaseTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        protected class TodoItem
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public bool IsCompleted { get; set; }
        }

    }
}
