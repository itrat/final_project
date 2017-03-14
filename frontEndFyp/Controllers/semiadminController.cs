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
    public class semiadminController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]

        public ActionResult Create(FormCollection form)
        {
            User user = new User();
            user.User_F_Name = form["First_Name"];
            user.User_L_Name = form["Last_Name"];
            user.User_Email = form["Email"];
            user.User_Phone_ = form["phoneno"];
            user.User_CNIC = form["CNIC"];
            user.User_Address = form["Address"];
            db.Users.Add(user);
            db.SaveChanges();

            Session["UserId"] = db.Users.Max(item => item.User_Id);

            return RedirectToAction("create", "restaurant");
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            User user = db.Users.Find(2);
            user.User_F_Name = form["First_Name"];
            user.User_L_Name = form["Last_Name"];
            user.User_Email = form["Email"];
            user.User_Phone_ = form["phoneno"];
            user.User_CNIC = form["CNIC"];
            user.User_Address = form["Address"];
            db.SaveChanges();

            Session["UserId"] = db.Users.Max(item => item.User_Id);

            return View();
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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