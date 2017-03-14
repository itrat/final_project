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
    public class RestaurantController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]

        public ActionResult Create(FormCollection form, HttpPostedFileBase file)
        {

            Restaurant restaurant = new Restaurant();

            restaurant.Restaurant_Name = form["Restaurant_Name"];
            restaurant.Restaurant_Address = form["Restaurant_Address"];
            restaurant.Area = form["Area"];
            restaurant.Time_In = form["Time_In"];
            restaurant.Time_Out = form["Time_Out"];

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Images"), pic);
                file.SaveAs(path);
                restaurant.Restaurant_Image = "/Content/Images/" + pic;
            }
            else
            {
                restaurant.Restaurant_Image = null;
            }
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            Session["RestaurantId"] = db.Restaurants.Max(item => item.Restaurant_Id);

            return RedirectToAction("Create", "Events");

        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]

        public ActionResult Edit(FormCollection form)
        {
            Restaurant restaurant = db.Restaurants.Find(2);

            restaurant.Restaurant_Name = form["Restaurant_Name"];
            restaurant.Restaurant_Address = form["Restaurant_Address"];
            restaurant.Time_In = form["Time_In"];
            restaurant.Time_Out = form["Time_Out"];

            db.SaveChanges();
            return View();

        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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