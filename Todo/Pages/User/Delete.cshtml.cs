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

namespace Todo.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly Todo.Data.TodoContext _context;

        public DeleteModel(Todo.Data.TodoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTask UserTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTask = await _context.UserTasks.FirstOrDefaultAsync(m => m.Id == id);

            if (UserTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTask = await _context.UserTasks.FindAsync(id);

            if (UserTask != null)
            {
                _context.UserTasks.Remove(UserTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/User/Index");
        }
    }
}
