using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontEndFyp.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Helpers;
namespace frontEndFyp.Controllers
{
    public class FrontpagesController : Controller
    {
        Event_MangementEntities3 db = new Event_MangementEntities3();
        //
        // GET: /Frontpages/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult home()
        {
            return View();
        }
        public ActionResult faq()
        {
            return View();
        }
        public ActionResult privacypolicy()
        {
            return View();
        }


        [HttpGet]
        public ActionResult services(string eve1,string eve2)
        {
            
            int evr = Convert.ToInt32(eve2);
            string h = eve1.ToString();
            ViewBag.home10 = h;
            if (evr == 2)
            {
                List<Event> all_std = new List<Event>();
                List<Restaurant> all_st = new List<Restaurant>();
                string e = eve1.ToString();
                Event_MangementEntities3 dc = new Event_MangementEntities3();
                  all_std = dc.Events.Where(x => x.Event_Type == e).ToList<Event>();
                var events = db.Events.Select(x => x.Restaurant_Id).ToList();
                var events1 = db.Events.Where(x => x.Event_Type == e).Select(x => x.Restaurant_Id).ToList();
               // all_st = dc.Restaurants.Where(x => x.Restaurant_Id == events).ToList<Restaurant>();
                int f = events.Count();
                var all = from item in dc.Restaurants
                          where events1.Contains(item.Restaurant_Id)
                          select item;
                var all1 = from item in dc.Restaurants
                          where events.Contains(item.Restaurant_Id)
                          select item.Restaurant_Id;
                int u = all1.Count();
                ViewBag.r_img = all;
                ViewBag.r_img_1 = all1;
                ViewBag.home1 = eve2;
                ViewBag.length_of_list = u;
            }

            else if(evr == 1)
            {
               
                List<Restaurant> all_std = new List<Restaurant>();
                List<string> all_st = new List<string>();
                Event_MangementEntities3 dc = new Event_MangementEntities3();
              
                all_std = dc.Restaurants.Where(x => x.Restaurant_Name.StartsWith(eve1)).ToList<Restaurant>();

                int u = all_std.Count();
                ViewBag.r_img = all_std;
                ViewBag.r_img_1 = all_std;
                ViewBag.home1 = eve2;
                ViewBag.length_of_list = u;
            }
            return View();
        }

        [HttpPost]
        public JsonResult name_for_restaurant_detail(string eve1, string eve2)
        {
             JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
             string result=null;
            int evr = Convert.ToInt32(eve2);
            if (evr == 2)
            {
                List<Event> all_std = new List<Event>();
                List<Restaurant> all_st = new List<Restaurant>();
                string e = eve1.ToString();
                Event_MangementEntities3 dc = new Event_MangementEntities3();
                all_std = dc.Events.Where(x => x.Event_Type == e).ToList<Event>();
                var events = db.Events.Where(x => x.Event_Type == e).Select(x => x.Restaurant_Id).ToList();
                int f = events.Count();
                var all1 = from item in dc.Restaurants
                           where events.Contains(item.Restaurant_Id) select item;
                result = javaScriptSerializer.Serialize(all_std);
               
            }

            else if (evr == 1)
            {

                List<Restaurant> all_std = new List<Restaurant>();
                List<string> all_st = new List<string>();
                Event_MangementEntities3 dc = new Event_MangementEntities3();

                all_std = dc.Restaurants.Where(x => x.Restaurant_Name.StartsWith(eve1)).ToList<Restaurant>();
                result = javaScriptSerializer.Serialize(all_std);
                ViewBag.r_img = all_std;
                ViewBag.home_value = eve1;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult On_Load_get(string cate)
        {
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            var all = from item in db.Restaurants
                      where event1.Contains(item.Restaurant_Id)
                      select item;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Through_Area(string stateID, string cate)
        {
          //  int stateiD = Convert.ToInt32(stateID);
            // List<Restaurant> all_std = new List<Restaurant>();
            List<string> all_st = new List<string>();
            List<Event> events = new List<Event>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            var all_std = db.Restaurants.Where(x => x.Area == stateID).ToList();
            int f = event1.Count();
            var all = from item in all_std
                      where event1.Contains(item.Restaurant_Id)
                      select item;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Through_Event_CheckBox(string[] even, string cate)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
          
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            int f = event1.Count();
                      if (even != null)
            {
                var all_std1 = from item in dc.Events
                               where even.Contains(item.Event_Type)
                               select item.Restaurant_Id;
                var all_std2 = from item in dc.Restaurants
                               where all_std1.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x=> x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Through_Rating_CheckBox(string[] even, string cate)
        {
            List<FeedBack> all_std = new List<FeedBack>();
            List<Restaurant> all_st = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
            result = javaScriptSerializer.Serialize(all_st);
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList(); 
            int f = event1.Count();
            List<int> IDs;
            if(even!=null)
            { 
            int[] intArr = Array.ConvertAll<string, int>(even, new Converter<string, int>(Convert.ToInt32));
            IDs = intArr.ToList();
            int len = even.Length;
            var all_std1 = from item in dc.FeedBacks
                           where IDs.Contains(item.Ratings)
                           select item;
                
            var all = from item in all_std1
                      where event1.Contains(item.Restaurant_Id)
                      select item.Restaurant_Id;
            var all_std2 = from item in dc.Restaurants
                           where all.Contains(item.Restaurant_Id)
                           select item;

           
                result = javaScriptSerializer.Serialize(all_std2);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x=> x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
      
        [HttpPost]
        public JsonResult Through_Search(string even, string cate)
        {
            string e = even.ToString();
            List<Restaurant> all_std = new List<Restaurant>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            all_std = dc.Restaurants.Where(x => x.Restaurant_Name.StartsWith(e)).ToList<Restaurant>();
            var all = from item in all_std
                      where event1.Contains(item.Restaurant_Id)
                      select item;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(all);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Through_Categories_and_Ratings(string[] even, string cate,string[] eve1)
        {
            List<FeedBack> all_std = new List<FeedBack>();
            List<Restaurant> all_st = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
            result = javaScriptSerializer.Serialize(all_st);
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            int f = event1.Count();
            List<int> IDs;
            if (even != null && eve1!=null)
            {
                int[] intArr = Array.ConvertAll<string, int>(even, new Converter<string, int>(Convert.ToInt32));
                IDs = intArr.ToList();
                int len = even.Length;
                var all_std1 = from item in dc.FeedBacks
                               where IDs.Contains(item.Ratings)
                               select item;
                var all_std3 = from item in dc.Events
                               where eve1.Contains(item.Event_Type)
                               select item.Restaurant_Id;
                var all = from item in all_std1
                          where event1.Contains(item.Restaurant_Id)
                          select item;
                var all1 = from item in all
                           where all_std3.Contains(item.Restaurant_Id)
                           select item.Restaurant_Id;
                var all_std2 = from item in dc.Restaurants
                               where all1.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Through_Categories_and_Area(string even, string cate, string[] eve1)
        {
            List<FeedBack> all_std = new List<FeedBack>();
            List<Restaurant> all_st = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
            //int stateiD = Convert.ToInt32(even);
            result = javaScriptSerializer.Serialize(all_st);
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            int f = event1.Count();
            List<int> IDs;
            List<Restaurant> all_std4 = new List<Restaurant>();
            if (eve1 != null)
            {
                
                
                var all_std3 = from item in dc.Events
                               where eve1.Contains(item.Event_Type)
                               select item.Restaurant_Id;
                 all_std4 = dc.Restaurants.Where(x => x.Area == even).ToList<Restaurant>();
                var all_std2 = from item in all_std4
                               where all_std3.Contains(item.Restaurant_Id)
                               select item;
              
                result = javaScriptSerializer.Serialize(all_std2);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Through_Categories_and_Area_and_Ratings(string[] even, string cate, string[] eve1,string eve2)
        {
            List<FeedBack> all_std = new List<FeedBack>();
            List<Restaurant> all_st = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
           
            result = javaScriptSerializer.Serialize(all_st);
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            int f = event1.Count();
            List<int> IDs;
            List<Restaurant> all_std4 = new List<Restaurant>();
            if (eve1 != null)
            {
                int[] intArr = Array.ConvertAll<string, int>(even, new Converter<string, int>(Convert.ToInt32));
                IDs = intArr.ToList();
                int len = even.Length;
                var all_std1 = from item in dc.FeedBacks
                               where IDs.Contains(item.Ratings)
                               select item.Restaurant_Id;
                var all_std3 = from item in dc.Events
                               where eve1.Contains(item.Event_Type)
                               select item.Restaurant_Id;
                var allop = from item in dc.Restaurants
                            where all_std1.Contains(item.Restaurant_Id)
                            select item;
                var allop1 = from item in allop
                             where all_std3.Contains(item.Restaurant_Id)
                             select item.Restaurant_Id;
                var re = db.Restaurants.Where(x => x.Area == eve2).ToList();
                var allop2 = from item in re
                             where allop1.Contains(item.Restaurant_Id)
                             select item;
                result = javaScriptSerializer.Serialize(allop2);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Through_Ratings_and_Area(string even, string cate, string[] eve1)
        {
            List<FeedBack> all_std = new List<FeedBack>();
            List<Restaurant> all_st = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            string result;
            //int stateiD = Convert.ToInt32(even);
            result = javaScriptSerializer.Serialize(all_st);
            List<Event> events = new List<Event>();
            var event1 = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
            int f = event1.Count();
            List<int> IDs;
            List<Restaurant> all_std4 = new List<Restaurant>();
            if (eve1 != null)
            {

                int[] intArr = Array.ConvertAll<string, int>(eve1, new Converter<string, int>(Convert.ToInt32));
                IDs = intArr.ToList();
               
                var all_std3 = from item in dc.FeedBacks
                               where IDs.Contains(item.Ratings)
                               select item.Restaurant_Id;
               var all_st4 = dc.Restaurants.Where(x => x.Area == even).Select(x=> x.Restaurant_Id).ToList();
                
                var all_std2 = from item in dc.Restaurants
                               where event1.Contains(item.Restaurant_Id)
                               select item;
                var all_std6 = from item in all_std2
                               where all_std3.Contains(item.Restaurant_Id)
                               select item;
                var all_std7 = from item in all_std6
                               where all_st4.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std7);
            }
            else
            {
                var ev = db.Events.Where(x => x.Event_Type == cate).Select(x => x.Restaurant_Id).ToList();
                var all_std2 = from item in dc.Restaurants
                               where ev.Contains(item.Restaurant_Id)
                               select item;
                result = javaScriptSerializer.Serialize(all_std2);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_Event_for_Home(string even)
        {
            List<Event> all_std = new List<Event>();
            List<string> all_st = new List<string>();
            Event_MangementEntities3 dc = new Event_MangementEntities3();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            all_std = dc.Events.Where(x => x.Event_Type == even).ToList<Event>();
            string result = javaScriptSerializer.Serialize(all_std);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Get_Restaurant_for_Home(string[] eve1)
        {
            // int len = eve1.Length;
            List<int> IDs;
            int[] intArr = Array.ConvertAll<string, int>(eve1, new Converter<string, int>(Convert.ToInt32));
            IDs = intArr.ToList();

            List<Restaurant> all_std = new List<Restaurant>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Event_MangementEntities3 dc = new Event_MangementEntities3();

            // for (int i = 0; i < len; i++)

            //   int e = Convert.ToInt32(eve1);
            var all = from item in dc.Restaurants
                      where IDs.Contains(item.Restaurant_Id)
                      select item;
            string result1 = javaScriptSerializer.Serialize(all);
            return Json(result1, JsonRequestBehavior.AllowGet);
        }
    }
}

