using System;

namespace TodoApp
{
    public class MenuController
    {
        private readonly ITodoService _todoService;

        public MenuController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public void DisplayMenu()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("\n--- To-Do List Menu ---");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("3. Mark a task as completed");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var userInput = Console.ReadLine() ?? string.Empty;

                switch (userInput)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ShowTasks();
                        break;
                    case "3":
                        MarkTaskAsCompleted();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        ExitApp();
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddTask()
        {
            Console.Clear();
            Console.Write("Enter the title of the new task: ");
            string? title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title))
            {
                _todoService.AddTask(title);
            }
            else
            {
                Console.WriteLine("Task title cannot be empty.");
            }
        }

        private void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("\n--- To-Do List ---");
            var tasks = _todoService.GetAllTasks();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
            Console.ReadLine(); 
        }

        private void MarkTaskAsCompleted()
        {
            Console.Clear();
            Console.Write("Enter the ID of the task to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                _todoService.MarkTaskAsCompleted(taskId);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void DeleteTask()
        {
            Console.Clear();
            Console.Write("Enter the ID of the task to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                _todoService.DeleteTask(taskId);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void ExitApp()
        {
            Console.Clear();
            Console.WriteLine("Exiting the application...");
        }
    }
}
