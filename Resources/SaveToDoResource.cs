using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Resources
{
  public class SaveToDoResource
  {
    [Required]
    public string UserEmail { get; set; }
    [Required]
    public string Description { get; set; }
  }
}
