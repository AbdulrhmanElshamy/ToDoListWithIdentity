using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoListWithIdentity.Cores.Models;
using ToDoListWithIdentity.Filters;
using ToDoListWithIdentity.Services;

namespace ToDoListWithIdentity.Controllers
{
    [Authorize]
    public class ToDoListsController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoListsController(
            IToDoService toDoService, 
            UserManager<ApplicationUser> userManager)
        {
            _toDoService = toDoService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var crruntUser = await _userManager.GetUserAsync(HttpContext.User);

            var todos = await _toDoService.GetAllAsync(crruntUser.Id);

            return View(todos);

        }
        


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return  View("Form");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDo toDo)
        {
            if (!ModelState.IsValid)
                return View(toDo);

            toDo.ApplicationUserId = _userManager.GetUserId(HttpContext.User);
            var isAdd = await _toDoService.AddAsync(toDo);

            if (!isAdd)
                return View(toDo);

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var crrentUser = await _userManager.GetUserAsync(HttpContext.User);

            var todo = await _toDoService.GetByIdAsync(crrentUser.Id, id);

            if (todo is null)
                return NotFound();

            return View("Form",todo);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ToDo model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var crrentUser = await _userManager.GetUserAsync(HttpContext.User);

            var todo = await _toDoService.GetByIdAsync(crrentUser.Id, model.Id);

            todo.Title = model.Title;
            todo.Description = model.Description;

            var isUpdated = await _toDoService.UpdateAsync(todo);

            if (!isUpdated)
                return View(model);

            return RedirectToAction(nameof(Index));
        }





    }
}
