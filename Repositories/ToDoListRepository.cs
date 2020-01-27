using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories
{
  public class ToDoListRepository : BaseRepository, IToDoListRepository
  {
    public ToDoListRepository(ToDoListContext toDoListContext) : base(toDoListContext)
    {

    }


    public async Task<IEnumerable<ToDoListItem>> GetItems()
    {
      return await toDoListContext.ToDoListItem.ToListAsync();
    }
  }
}
