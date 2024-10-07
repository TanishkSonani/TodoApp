using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todoList;
        private int _idCounter;

        public TodoService()
        {
            _todoList = new List<TodoItem>();
            _idCounter = 1;
        }

        public void AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Task title cannot be empty.");

            _todoList.Add(new TodoItem(_idCounter++, title));
            Console.WriteLine("Task added successfully.");
        }

        public List<TodoItem> GetAllTasks()
        {
            return _todoList.ToList();
        }

        public TodoItem? GetTaskById(int id) 
        {
            return _todoList.FirstOrDefault(t => t.Id == id);
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            task.IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            _todoList.Remove(task);
            Console.WriteLine("Task deleted successfully.");
        }
    }
}
