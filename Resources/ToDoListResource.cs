using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Resources
{
  public class ToDoListResource
  {

    public int Id { get; set; }

    public string UserEmail { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
  }
}
