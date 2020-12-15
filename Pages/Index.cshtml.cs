using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Data;

namespace ToDoList
{
  [Authorize]
  public class HomeModel : PageModel
  {

    private readonly ToDoListContext _context;


    public HomeModel(ToDoListContext context
      )
    {
      _context = context;
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

    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostEditAsync()
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

      return RedirectToPage("Index");
    }

    private bool ToDoListItemExists(int id)
    {
      return _context.ToDoListItem.Any(e => e.Id == id);
    }

  }
}