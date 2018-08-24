using InfragistcsDev.ASPNET.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfragistcsDev.ASPNET.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetData()
        {
            IList<DAQlmLicenseInfo> records = new List<DAQlmLicenseInfo>();

            var jsonDataObj = Json(new
            {
                recordCountKey = 0,
                responseDataKey = "data",
                Error = true,
                msg = ""
            });
            return Json(jsonDataObj, JsonRequestBehavior.AllowGet);

        }
    }
}