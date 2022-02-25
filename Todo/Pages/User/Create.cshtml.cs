#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo.Data;
using Todo.Models;
using Todo.Areas.Identity.Data;

namespace Todo.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;
        private readonly UserManager<TodoUser> _userManager;


        public CreateModel(Todo.Data.TodoContext context, UserManager<TodoUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserTask UserTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           
            
            // Get Current User ID
            var user = await _userManager.GetUserAsync(User);
            var UserId = await _userManager.GetUserIdAsync(user);

            // Create A New Task
            var NewTask = new UserTask()
            {
                TaskTitle = UserTask.TaskTitle,
                TaskDescription = UserTask.TaskDescription,
                TaskCreatedDate = DateTimeKind.Utc,
                TaskStatus = true,
                UserId = UserId
            };

            //Add Task
            _context.UserTasks.Add(NewTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("/User/Index");
        }
    }
}
