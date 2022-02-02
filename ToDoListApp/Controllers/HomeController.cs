using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{   
    public class HomeController : Controller
    {
        private ToDoDBContext db = new ToDoDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.NumberItem = db.todoItems.Count();
            return View();
        }
    }
}