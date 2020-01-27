using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList
{
    public class EditModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public EditModel(ToDoList.Data.ToDoListContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoListItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListItemExists(ToDoListItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./TaskIndex");
        }

        private bool ToDoListItemExists(int id)
        {
            return _context.ToDoListItem.Any(e => e.Id == id);
        }
    }
}
