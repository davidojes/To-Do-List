using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Resources;
using ToDoList.Services;

namespace ToDoList.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ToDoListController : ControllerBase
  {

    public ToDoListController(IToDoListService toDoListService, IMapper mapper)
    {
      ToDoListService = toDoListService;
      Mapper = mapper;
    }

    private readonly IToDoListService ToDoListService;
    private readonly IMapper Mapper;

    [HttpGet]
    public async Task<IEnumerable<ToDoListItem>> GetItemsAsync()
    {
      var toDoListItems = await ToDoListService.GetItems();
      //var resources = Mapper.Map<IEnumerable<ToDoListItem>, IEnumerable<ToDoListResource>>(toDoListItems);
      return toDoListItems;
    }

    //[HttpPost]
    //public async Task<IActionResult> PostAsync([FromBody] SaveToDoResource resource)
    //{
    //  // returns error message if the model state is invalid (from the request)
    //  if (!ModelState.IsValid)
    //    return BadRequest(ModelState.GetErrorMessages());


    //}
  }
}


