using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
  public interface IToDoListRepository
  {
    Task<IEnumerable<ToDoListItem>> GetItems();
  }
}
