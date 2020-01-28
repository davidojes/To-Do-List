using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public DeleteModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoListItem ToDoListItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoListItem = await _context.ToDoListItem.FirstOrDefaultAsync(m => m.Id == id);

            if (ToDoListItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoListItem = await _context.ToDoListItem.FindAsync(id);

            if (ToDoListItem != null)
            {
                _context.ToDoListItem.Remove(ToDoListItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./TaskIndex");
        }
    }
}
