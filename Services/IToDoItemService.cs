using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser user);

        Task<bool> AddItemAsync(NewToDoItem newItem, ApplicationUser user);
        Task<bool> MarkDoneAsync(Guid ID, ApplicationUser user);
    }
}