using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
  public class ToDoListContext : IdentityDbContext<ApplicationUser, AppRole, string>
  {
    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<ApplicationUser>()
    .Property(e => e.Id)
    .ValueGeneratedOnAdd();
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);


    }

    public DbSet<ToDoListItem> ToDoListItem { get; set; }

  }
}
