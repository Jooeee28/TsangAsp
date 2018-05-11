using System;

namespace AspNetCoreToDo.Models
{
    public class ToDoItem
    {
        public Guid ID { get; set; }

        public bool IsDone { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }

        public string OwnderId { get; set; }
    }
    
}