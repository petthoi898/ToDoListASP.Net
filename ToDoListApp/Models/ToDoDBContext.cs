using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoListApp.Models
{
	public class ToDoDBContext : DbContext
	{
		public ToDoDBContext() : base("name = ToDoList") { }
		public DbSet<ToDoItem> todoItems { get; set; }
	}
}