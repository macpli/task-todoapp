using System.Collections.Generic;
using System.Linq;
using TodoList.WebApi.Models;


namespace TodoList.WebApi.Repositories
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();
        private int _nextId = 1;

        public IEnumerable<TodoItem> GetAll() 
        { 
            return _todoItems; 
        }

        public TodoItem GetById(Guid id) 
        {
            return _todoItems.FirstOrDefault(item => item.Id == id);
        }

        public void Add(TodoItem todoItem)
        {
            todoItem.Id = Guid.NewGuid();
            _todoItems.Add(todoItem);
        }

        public void Update(TodoItem todoItem)
        {
            var existingItem = GetById(todoItem.Id);
            if (existingItem != null)
            {
                existingItem.Title = todoItem.Title;
                existingItem.IsCompleted = todoItem.IsCompleted;
            }

        }

        public void Delete(Guid id)
        {
            var todoItem = GetById(id);
            if (todoItem != null)
            {
                _todoItems.Remove(todoItem);
            }
        }
    }
}
