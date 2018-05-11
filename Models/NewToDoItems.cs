using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreToDo.Models
{
    public class NewToDoItem
    {
        [Required]
        public string Title { get; set; }
    }
}