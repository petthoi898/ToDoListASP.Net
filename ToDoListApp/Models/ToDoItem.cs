using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoListApp.Models
{
	[Table("ToDoItems")]
	
	public class ToDoItem
	{
		public ToDoItem(string content)
		{
			this.content = content;
			isImportant = false;
			isCompleted = false;

		}
		public ToDoItem() { }
		public string id { get; set; }
		[Required]
		[Display(Prompt = "Add a task")]
		public string content { get; set; }
		public bool isImportant { get; set; }
		public bool isCompleted { get; set; }
	}
}