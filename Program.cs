using System;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuController = new MenuController(new TodoService());
            menuController.DisplayMenu();
        }
    }
}