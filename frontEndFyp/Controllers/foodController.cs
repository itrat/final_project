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
    public class foodController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /Food/

        public ActionResult Index()
        {
            var foods = db.Foods.Include(f => f.Restaurant);
            return View(foods.ToList());
        }

        //
        // GET: /Food/Details/5

        public ActionResult Details(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        //
        // GET: /Food/Create

        public ActionResult Create()
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
            List<Restaurant> res = new List<Restaurant>();
            res = db.Restaurants.Where(x => x.Restaurant_Id == u).ToList();
            ViewBag.Name = res;
            ViewBag.Restaurant_Id = db.Restaurants.ToList();
            return View();
        }

        //
        // POST: /Food/Create

        [HttpPost]

        public ActionResult Create(FormCollection form)
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
            Food food = new Food();
           food.Restaurant_Id = u;
            food.Food_Price = Convert.ToInt16(form["Food_Price"]);
            food.Food_Item = form["Food_item"];
            db.Foods.Add(food);
            db.SaveChanges();
            return RedirectToAction("create","soundsystem");


        }

        //
        // GET: /Food/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurant_Id = db.Restaurants.ToList();
            return View(food);
        }

        //
        // POST: /Food/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            Food food = db.Foods.Find(2);
            food.Food_Price = Convert.ToInt16(form["Food_Price"]);
            food.Food_Item = form["Food_item"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Food/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        //
        // POST: /Food/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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