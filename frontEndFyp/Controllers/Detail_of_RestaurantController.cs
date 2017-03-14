using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndFyp.Models;
namespace frontEndFyp.Controllers
{
    public class Detail_of_RestaurantController : Controller
    {
        public ActionResult Index(string eve1)
        {
            int h = Convert.ToInt32(eve1);
            List<Restaurant> all_st = new List<Restaurant>();
           
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            all_st = dc.Restaurants.Where(x => x.Restaurant_Id == h).ToList<Restaurant>();
            ViewBag.detail = all_st;
            ViewBag.Res_Id = h;
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Detail_of_Restaurant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Detail_of_Restaurant/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Detail_of_Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Detail_of_Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Detail_of_Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Detail_of_Restaurant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
