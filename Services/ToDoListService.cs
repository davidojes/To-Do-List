using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Services
{
  public class ToDoListService : IToDoListService
  {

    public ToDoListService(IToDoListRepository toDoListRepository)
    {
      ToDoListRepository = toDoListRepository;
    }

    private readonly IToDoListRepository ToDoListRepository;

    public async Task<IEnumerable<ToDoListItem>> GetItems()
    {
      return await ToDoListRepository.GetItems();
    }

  }
}
