using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Resources;

namespace ToDoList.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      // maps (connects) the ToDoListItemModel to the ToDoListResource 
      CreateMap<ToDoListItem, ToDoListResource>();
    }
  }
}
