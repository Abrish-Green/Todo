#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;
using Microsoft.AspNetCore.Identity;
using Todo.Areas.Identity.Data;

namespace Todo.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;
        private readonly UserManager<TodoUser> _userManager;


        public IndexModel(Todo.Data.TodoContext context, UserManager<TodoUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<UserTask> UserTask { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var UserId = await _userManager.GetUserIdAsync(user);
            UserTask = await _context.UserTasks.Where(task=> task.UserId == UserId).ToListAsync();
        }
    }
}
