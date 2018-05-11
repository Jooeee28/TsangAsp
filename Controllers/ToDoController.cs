using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Services;
using AspNetCoreToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreToDo.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        
        private readonly IToDoItemService _toDoItemService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ToDoController(IToDoItemService toDoItemService, UserManager<ApplicationUser> userManager)
        {
            _toDoItemService = toDoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var toDoItems = await _toDoItemService.GetIncompleteItemsAsync(currentUser);

            // get todo items from DB
            
            // put items into a model
            var model = new ToDoViewModel()
            {
                items = toDoItems
            };

            //render view using the model
            return View(model);
        }

        public async Task<IActionResult> AddItem(NewToDoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var successful = await _toDoItemService.AddItemAsync(newItem, currentUser);
            if (!successful)
            {
                return BadRequest(new {error = "Could not add item" });
            }
            
            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid ID)
        {
            if (ID == Guid.Empty) return BadRequest();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var successful = await _toDoItemService.MarkDoneAsync(ID, currentUser);

            if(!successful) return BadRequest();

            return Ok();
        }
    }
}
