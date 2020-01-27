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
    public class IndexModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IList<ToDoListItem> ToDoListItem { get;set; }

        public async Task OnGetAsync()
        {
            ToDoListItem = await _context.ToDoListItem.ToListAsync();
        }
    }
}
