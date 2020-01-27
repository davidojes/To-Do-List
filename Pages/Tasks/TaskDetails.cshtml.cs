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
    public class DetailsModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public DetailsModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

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
    }
}
