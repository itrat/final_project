using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndFyp.Models;
using System.Web.Script.Serialization;

namespace frontEndFyp.Controllers
{
    public class ReservationController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();


        //
        // GET: /Reservation/

        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Decoration).Include(r => r.Event).Include(r => r.Food).Include(r => r.Restaurant).Include(r => r.SoundSystem).Include(r => r.User);
            return View(reservations.ToList());
        }

        //
        // GET: /Reservation/Details/5

        public ActionResult Details(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }


        ////////////////////////////////////////////////////json


        public JsonResult GetCoursebydept(string did)
        {
            int intprovinceid = Convert.ToInt32(did);

            var dec = db.Decorations.Where(x => x.Restaurant_Id == intprovinceid).Select(x => new { x.Decoration_Id, x.Decoration_Type }).ToList();
            var food = db.Foods.Where(x => x.Restaurant_Id == intprovinceid).Select(x => new { x.Food_Id, x.Food_Item }).ToList();
            var events = db.Events.Where(x => x.Restaurant_Id == intprovinceid).Select(x => new { x.Event_Id, x.Event_Type }).ToList();
            var sound = db.SoundSystems.Where(x => x.Restaurant_Id == intprovinceid).Select(x => new { x.Sound_Id, x.Sound_Type }).ToList();
            object[] arr = new object[4];
            arr[0] = dec;
            arr[1] = food;
            arr[2] = events;
            arr[3] = sound;
            return Json(arr);

        }




        //
        // GET: /Reservation/Create

        public ActionResult Create(string eve1)
        {
            int h = Convert.ToInt32(eve1);
            List<Food> ft = new List<Food>();
            ft = db.Foods.Where(x => x.Restaurant_Id == h).ToList<Food>();
            ViewBag.Food_Id1 = ft;
            ViewBag.Decoration_Id = db.Decorations.Where(x => x.Restaurant_Id == h).ToList<Decoration>();
            ViewBag.Event_Id = db.Events.Where(x => x.Restaurant_Id == h).ToList<Event>();

            ViewBag.Restaurant_Id = db.Restaurants.Where(x => x.Restaurant_Id == h).ToList();
            ViewBag.Sound_Id = db.SoundSystems.Where(x => x.Restaurant_Id == h).ToList<SoundSystem>();
            ViewBag.User_Id = db.Users.ToList();
            ViewBag.rt_Id = h;
            Session["Rest_ID"] = h;
            return View();
        }
        [HttpPost]
        public JsonResult GetDecoration(string stateID)
        {
            int stateiD = Convert.ToInt32(stateID);
            List<Decoration> all_std = new List<Decoration>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            all_std = dc.Decorations.Where(x => x.Restaurant_Id == stateiD).ToList<Decoration>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all_std);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Reservation/Create

        [HttpPost]

        public ActionResult Create(FormCollection form)
        {
            int u = Convert.ToInt32(Session["Rest_ID"]);
            Reservation reservation = new Reservation();
            //  string f = form["fnhg"];
            reservation.Restaurant_Id = u;

            int y = Convert.ToInt32(form["Ana"]);
            reservation.Event_Id = y;
            reservation.Time_In = form["timein"];
            reservation.Time_Out = form["timeout"];
            reservation.Date = form["date"];
            reservation.Total_Persons = form["totalperson"];
            reservation.Total_Price = "1000";// form["totalprice"];


            reservation.Food_Id = Convert.ToInt32(form["Ana1"]);

            reservation.Sound_Id = Convert.ToInt32(form["Ana2"]);
            reservation.Decoration_Id = Convert.ToInt32(form["Ana3"]);


            //   reservation.User_Id = Convert.ToInt16(Session["UserId"]);
            reservation.User_Id = 1;


            db.Reservations.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("home", "Frontpages");


            ViewBag.Decoration_Id = new SelectList(db.Decorations, "Decoration_Id", "Decoration_Type", reservation.Decoration_Id);
            ViewBag.Event_Id = new SelectList(db.Events, "Event_Id", "Event_Type", reservation.Event_Id);
            ViewBag.Food_Id = new SelectList(db.Foods, "Food_Id", "Food_Item", reservation.Food_Id);
            ViewBag.Restaurant_Id = new SelectList(db.Restaurants, "Restaurant_Id", "Restaurant_Name", reservation.Restaurant_Id);
            ViewBag.Sound_Id = new SelectList(db.SoundSystems, "Sound_Id", "Sound_Type", reservation.Sound_Id);
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "User_Name", reservation.User_Id);
            return View();
        }

        //
        // GET: /Reservation/Edit/5
        [HttpPost]
        public JsonResult GetFood(string stateID)
        {
            int stateiD = Convert.ToInt32(stateID);
            List<Food> all_std = new List<Food>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            all_std = dc.Foods.Where(x => x.Restaurant_Id == stateiD).ToList<Food>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all_std);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetSound(string stateID)
        {
            int stateiD = Convert.ToInt32(stateID);
            List<SoundSystem> all_std = new List<SoundSystem>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            all_std = dc.SoundSystems.Where(x => x.Restaurant_Id == stateiD).ToList<SoundSystem>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all_std);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEvent(string stateID)
        {
            int stateiD = Convert.ToInt32(stateID);
            List<Event> all_std = new List<Event>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            all_std = dc.Events.Where(x => x.Restaurant_Id == stateiD).ToList<Event>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all_std);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }


            ViewBag.Decoration_Id = db.Decorations.ToList();
            ViewBag.Event_Id = db.Events.ToList();
            ViewBag.Food_Id = db.Foods.ToList();
            ViewBag.Restaurant_Id = db.Restaurants.ToList();
            ViewBag.Sound_Id = db.SoundSystems.ToList();
            ViewBag.User_Id = db.Users.ToList();

            return View(reservation);
        }

        //
        // POST: /Reservation/Edit/5

        [HttpPost]

        public ActionResult Edit(FormCollection form)
        {
            Reservation reservation = db.Reservations.Find(2);
            reservation.Time_In = form["timein"];
            reservation.Time_Out = form["timeout"];
            reservation.Date = form["date"];
            reservation.Total_Persons = form["totalperson"];
            reservation.Total_Price = "1000";// form["totalprice"];

            reservation.Decoration_Id = Convert.ToInt16(form["decorationid"]);

            reservation.Sound_Id = Convert.ToInt16(form["soundid"]);

            reservation.Food_Id = Convert.ToInt16(form["foodid"]);

            reservation.Event_Id = Convert.ToInt16(form["EventId"]);

            // reservation.User_Id = Convert.ToInt16(Session["UserId"]);

            reservation.Restaurant_Id = 2;

            Convert.ToInt16(form["restaurantid"]);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Reservation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //
        // POST: /Reservation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}