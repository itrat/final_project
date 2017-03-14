using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndFyp.Models;

namespace frontEndFyp.Controllers
{
    public class hallcreationController : Controller
    {
        private Event_MangementEntities3 db = new Event_MangementEntities3();
        //
        // GET: /hallcreation/

        public ActionResult Index()
        {
            var intprovinceid = Convert.ToInt16(Session["RestaurantId"]);
            List<Restaurant> Res = new List<Restaurant>();
            Res = db.Restaurants.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Name1 = Res;


            var id =Convert.ToInt16( db.Users.Max(item => item.User_Id));


            List<User> use = new List<User>();
            use = db.Users.Where(x => x.User_Id == id).ToList();
            ViewBag.Name2 = use;

            List<Food> use1 = new List<Food>();
            use1 = db.Foods.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Name3 = use1;

            List<Decoration> use2 = new List<Decoration>();
            use2 = db.Decorations.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Name4 = use2;

            List<Event> use4 = new List<Event>();
            use4 = db.Events.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Name5 = use4;


            ViewBag.firstname = db.Users.Where(x => x.User_Id == id).Select(x => x.User_F_Name);
            ViewBag.lastname = db.Users.Where(x => x.User_Id == id).Select(x => x.User_L_Name);
            ViewBag.email = db.Users.Where(x => x.User_Id == id).Select(x => x.User_Email);
            ViewBag.phone = db.Users.Where(x => x.User_Id == id).Select(x => x.User_Phone_);
         //   res = db.Restaurants.Where(x => x.Restaurant_Id == u).ToList();
            ViewBag.resname = db.Restaurants.Where(x => x.Restaurant_Id == intprovinceid).Select(x => x.Restaurant_Name);
            ViewBag.timein = db.Restaurants.Where(x => x.Restaurant_Id == intprovinceid).Select(x => x.Time_In);
            ViewBag.timeout = db.Restaurants.Where(x => x.Restaurant_Id == intprovinceid).Select(x => x.Time_Out);
            ViewBag.Decoration_Id = db.Decorations.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Foo = db.Foods.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            ViewBag.Event_Id = db.Events.Where(x => x.Restaurant_Id == intprovinceid).ToList();
            return View();
        }

    }
}
