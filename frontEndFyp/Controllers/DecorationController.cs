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
    public class DecorationController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /Decoration/

        public ActionResult Index()
        {
            var decorations = db.Decorations.Include(d => d.Restaurant);
            return View(decorations.ToList());
        }

        //
        // GET: /Decoration/Details/5

        public ActionResult Details(int id = 0)
        {
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        //
        // GET: /Decoration/Create

        public ActionResult Create()
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
            List<Restaurant> res = new List<Restaurant>();
            res = db.Restaurants.Where(x => x.Restaurant_Id == u).ToList();
            ViewBag.Name = res;
            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name");
            return View();
        }

        //
        // POST: /Decoration/Create

        [HttpPost]

        public ActionResult Create(Decoration dec, FormCollection form)
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);

            dec.Decoration_Type = form["Decoration_Type"];
            dec.Decoration_Price = Convert.ToInt16(form["Decoration_Price"]);
            dec.Restaurant_Id = u;
            db.Decorations.Add(dec);

            db.SaveChanges();
            return RedirectToAction("index", "hallcreation");

            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", dec.Restaurant_Id);
            return View(dec);
        }

        //
        // GET: /Decoration/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", decoration.Restaurant_Id);
            return View(decoration);
        }

        //
        // POST: /Decoration/Edit/5

        [HttpPost]

        public ActionResult Edit(FormCollection form, int id = 0)
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
            Decoration dec = db.Decorations.Find(id);

            dec.Decoration_Type = form["Decoration_Type"];
            dec.Decoration_Price = Convert.ToInt16(form["Decoration_Price"]);
            dec.Restaurant_Id = u;
            db.SaveChanges();
            return RedirectToAction("index", "hallcreation");
            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", dec.Restaurant_Id);
            return View(dec);
        }
        //
        // GET: /Decoration/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        //
        // POST: /Decoration/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decoration decoration = db.Decorations.Find(id);
            db.Decorations.Remove(decoration);
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