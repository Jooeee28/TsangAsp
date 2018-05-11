using System.Collections.Generic;

namespace AspNetCoreToDo.Models
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> items { get; set; }
    }
}

