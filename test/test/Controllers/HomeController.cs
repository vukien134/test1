using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Controllers;
namespace test.Controllers
{
    public class HomeController : Controller
    {
        TestController db = new TestController();
        public ActionResult Index()
        {
            

            return View();
        }
        //public JsonResult List()
        //{
        //    return Json(db.Get(), JsonRequestBehavior.AllowGet);
        //}
       
    


    }
}
