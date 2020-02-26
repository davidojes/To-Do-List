using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
  public class AppRole : IdentityRole<string>
  {
    public AppRole() { }

    public AppRole(string name) {
      Name = name;
    }
  }
}
