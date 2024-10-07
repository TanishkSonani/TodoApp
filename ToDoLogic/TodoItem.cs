using System;

namespace TodoApp
{
    public class TodoItem
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"{Id}. [ {(IsCompleted  ? " DONE " : "      ")} ]  {Title} ";
        }
    }
}
