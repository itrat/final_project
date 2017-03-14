using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndFyp.Models;

namespace frontEndFyp.Controllers
{
    public class EventsController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /Events/

        public ActionResult Index()
        {
            var events1 = db.Events.Include(e => e.Restaurant);
            return View(events1.ToList());
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
            List<Restaurant> res = new List<Restaurant>();
            res = db.Restaurants.Where(x => x.Restaurant_Id == u).ToList();
            ViewBag.Name = res;
            return View();
        }

        //
        // POST: /Events/Create

        [HttpPost]

        public ActionResult Create(FormCollection form)
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);


            Event even = new Event();
            even.Restaurant_Id = u;
            even.Event_Price = form["Totalprice"];
            even.Event_Type = form["EventType"];
            even.Status = form["Status"];
            even.Time_In = form["timein"];
            even.Time_Out = form["timeout"];

            db.Events.Add(even);
            db.SaveChanges();
            return RedirectToAction("create", "food");


            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", even.Restaurant_Id);
            return View();
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

            ViewBag.Restaurant_Id = db.Restaurants.ToList();
            return View(events);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", events.Restaurant_Id);
            return View(events);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}