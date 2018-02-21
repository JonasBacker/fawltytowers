using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;


namespace WebBooking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Fawlty Towers";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Fawlty Towers";

            return View();
        }
        public ActionResult Login(string name)
        {
            ViewBag.Name = name;
            ViewBag.Message = "The login page";

            return View();
        }
        public ActionResult Signup()
        {
            ViewBag.Message = "The Signup page";

            return View();
        }
        public ActionResult YourAccount(string name, string pass)
        {
            ViewBag.Name = name;
            ViewBag.Pass = pass;
            ViewBag.Message = "Your account.";
            ViewBag.Title = "Your account ";

            return View();
        }
        //public ActionResult YourAccount()
        //{
        //    ViewBag.Message = "Your account.";
        //    ViewBag.Title = "Your account ";

        //    return View();
        //}
    }
}