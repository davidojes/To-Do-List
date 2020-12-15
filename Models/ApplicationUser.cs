﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
  public class ApplicationUser : IdentityUser<string>
  {
    public string DisplayName { get; set; }
  }
}
