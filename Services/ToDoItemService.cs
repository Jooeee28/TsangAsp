using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreToDo.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser user)
        {
            return await _context.items
                .Where(x => x.IsDone == false && x.OwnderId == user.Id)
                .ToArrayAsync();

        }

        public async Task<bool> AddItemAsync(NewToDoItem newItem, ApplicationUser user)
        {
            var entity = new ToDoItem
            {
                ID = Guid.NewGuid(),
                OwnderId = user.Id,
                IsDone = false,
                Title = newItem.Title,
                DueAt = DateTimeOffset.Now.AddDays(3)
            };
        
            _context.items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid ID, ApplicationUser user)
        {
            var item = await _context.items
                .Where(x => x.ID == ID && x.OwnderId == user.Id)
                .SingleOrDefaultAsync();
        

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; //1 entity should have been updated
        }
    }
}