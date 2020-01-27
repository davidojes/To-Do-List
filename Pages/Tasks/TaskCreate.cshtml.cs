using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList
{
    public class CreateModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public CreateModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoListItem ToDoListItem { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoListItem.Add(ToDoListItem);
            await _context.SaveChangesAsync();

            return Page()/*RedirectToPage("Index")*/;
        }
    }
}
