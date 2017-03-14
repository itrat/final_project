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
    public class soundsystemController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /soundsystem/

        public ActionResult Index()
        {
            var soundsystems = db.SoundSystems.Include(s => s.Restaurant);
            return View(soundsystems.ToList());
        }

        //
        // GET: /soundsystem/Details/5

        public ActionResult Details(int id = 0)
        {
            SoundSystem soundsystem = db.SoundSystems.Find(id);
            if (soundsystem == null)
            {
                return HttpNotFound();
            }
            return View(soundsystem);
        }

        //
        // GET: /soundsystem/Create

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
        // POST: /soundsystem/Create

        [HttpPost]
        
        public ActionResult Create(FormCollection form)
        {
            int u = Convert.ToInt32(Session["RestaurantId"]);
           
          
            SoundSystem sound = new SoundSystem();
            sound.Restaurant_Id = u;
            sound.Sound_Price = Convert.ToInt16(form["Sound_Price"]); 
            sound.Sound_Type = form["Sound_Type"]; 
            
            db.SoundSystems.Add(sound);
            db.SaveChanges();
            return RedirectToAction("create", "Decoration");


        }

        //
        // GET: /soundsystem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SoundSystem soundsystem = db.SoundSystems.Find(id);
            if (soundsystem == null)
            {
                return HttpNotFound();
            }
          ViewBag.Restaurant_Id = db.Restaurants.ToList(); 
            return View(soundsystem);
        }

        //
        // POST: /soundsystem/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            SoundSystem soundsystem = db.SoundSystems.Find(2);
            soundsystem.Restaurant_Id = Convert.ToInt16(form["restaurantid"]);
            soundsystem.Sound_Price = Convert.ToInt32(form["Sound_Price"]); 
            soundsystem.Sound_Type = form["Sound_Type"];

            db.SaveChanges();
            ViewBag.Restaurant_Id = db.Restaurants.ToList(); 
            return View(soundsystem);
        }

        //
        // GET: /soundsystem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SoundSystem soundsystem = db.SoundSystems.Find(id);
            if (soundsystem == null)
            {
                return HttpNotFound();
            }
            return View(soundsystem);
        }

        //
        // POST: /soundsystem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoundSystem soundsystem = db.SoundSystems.Find(id);
            db.SoundSystems.Remove(soundsystem);
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