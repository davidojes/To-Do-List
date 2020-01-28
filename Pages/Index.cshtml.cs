using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Resources;

namespace ToDoList
{
  [Authorize]
  public class HomeModel : PageModel
    {

    private readonly ToDoList.Data.ToDoListContext _context;
    private readonly ToDoList.Controllers.ToDoListController controller;
    

    public HomeModel(ToDoList.Data.ToDoListContext context, ToDoList.Controllers.ToDoListController controller)
    {
      _context = context;
      this.controller = controller;
    }

    public List<ToDoListItem> ToDoListItems { get; set; }
    [BindProperty]
    public ToDoListItem ToDoListItem { get; set; }

    public async Task OnGetAsync()
    {
      ToDoListItems = await _context.ToDoListItem.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.ToDoListItem.Add(ToDoListItem);
      await _context.SaveChangesAsync();

      return RedirectToPage("Index");
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

      return RedirectToPage("Index");
    }

  }
}