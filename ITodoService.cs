using System.Collections.Generic;

namespace TodoApp
{
    public interface ITodoService
    {
        void AddTask(string title);
        List<TodoItem> GetAllTasks();
        TodoItem GetTaskById(int id);
        void MarkTaskAsCompleted(int id);
        void DeleteTask(int id);
    }
}