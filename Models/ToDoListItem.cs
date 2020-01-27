﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
  public class ToDoListItem
  {
    [Key]
    public int Id { get; set; }

    public string UserEmail { get; set; }
    public string Description { get; set; }
    public bool IsCompeleted { get; set; }
  }
}
