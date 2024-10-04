using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        private static List<TodoItem> todoList = new List<TodoItem>();
        private static int idCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                string userInput = Console.ReadLine();
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
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n--- To-Do List Menu ---");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Mark a task as completed");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        private static void AddTask()
        {
            Console.Write("Enter the title of the new task: ");
            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Task title cannot be empty.");
                return;
            }

            todoList.Add(new TodoItem(idCounter++, title));
            Console.WriteLine("Task added successfully.");
        }

        private static void ShowTasks()
        {
            Console.WriteLine("\n--- To-Do List ---");
            if (todoList.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in todoList)
            {
                Console.WriteLine(task);
            }
        }

        private static void MarkTaskAsCompleted()
        {
            Console.Write("Enter the ID of the task to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = todoList.Find(t => t.Id == taskId);
                if (task != null)
                {
                    task.IsCompleted = true;
                    Console.WriteLine("Task marked as completed.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private static void DeleteTask()
        {
            Console.Write("Enter the ID of the task to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = todoList.Find(t => t.Id == taskId);
                if (task != null)
                {
                    todoList.Remove(task);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private static void ExitApp()
        {
            Console.WriteLine("Exiting the application...");
        }
    }
}
