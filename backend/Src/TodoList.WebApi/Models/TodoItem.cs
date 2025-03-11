using System;

namespace TodoList.WebApi.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }

}
