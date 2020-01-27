using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;

namespace ToDoList.Repositories
{
  // this is the design all other repositories will follow
  public abstract class BaseRepository
  {
    protected readonly ToDoListContext toDoListContext;

    public BaseRepository(ToDoListContext toDoListContext)
    {
      this.toDoListContext = toDoListContext;
    }
  }
}
