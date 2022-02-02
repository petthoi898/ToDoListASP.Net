using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoItemsController : Controller
    {
        private ToDoDBContext db = new ToDoDBContext();

        // GET: ToDoItems
        public ActionResult Index()
        {
            
            return View(db.todoItems.ToList());
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "id,content")] ToDoItem toDoItem)
        {
            if (toDoItem.content == null) return RedirectToAction("Index"); ;
            ToDoItem item = new ToDoItem();
            var lastemployee = db.todoItems.OrderByDescending(c => c.id).FirstOrDefault();
            if (lastemployee == null)
            {
                item.id = "BICS SFDC001";
            }
            else
            {
                //using string substring method to get the number of the last inserted employee's EmployeeID 
                item.id = "BICS SFDC" + (Convert.ToInt32(lastemployee.id.Substring(9, lastemployee.id.Length - 9)) + 1).ToString("D3");
            }
            toDoItem.id = item.id;
            if (ModelState.IsValid)
            {
                db.todoItems.Add(toDoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoItem);
        }
        // GET: Important
        public ActionResult IndexImportant()
        {
            return View(db.todoItems.Where(m => m.isImportant).ToList());
        }
        // GET: Completed
        public ActionResult IndexCompleted()
        {
            return View(db.todoItems.Where(m => m.isCompleted).ToList());
        }
        // GET: ToDoItems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = db.todoItems.Find(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }


        // GET: ToDoItems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = db.todoItems.Find(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,content,isImportant,isCompleted")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoItem);
        }

        // GET: ToDoItems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = db.todoItems.Find(id);
            ViewData["isImportant"] = toDoItem.isImportant;
            ViewData["isCompleted"] = toDoItem.isCompleted;
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ToDoItem toDoItem = db.todoItems.Find(id);
            db.todoItems.Remove(toDoItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Change Status Importannt
        // GET: ToDoItems/Important/5
        public ActionResult Important(string id)
        {
            var item = db.todoItems.Find(id);
            //db.categories.Remove(category);
            item.isImportant = item.isImportant ? false : true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Change Status Importannt
        // GET: ToDoItems/Important/5
        public ActionResult Completed(string id)
        {
            var item = db.todoItems.Find(id);
            //db.categories.Remove(category);
            item.isCompleted = item.isCompleted ? false : true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
