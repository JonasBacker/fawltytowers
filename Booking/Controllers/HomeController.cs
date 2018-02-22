using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using Model_DB;


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
        public ActionResult Login(int? id, string error)
        {
            ViewBag.Error = error;
            ViewBag.Message = "The login page";
            if (id == null)
                return View();
            else
                return View(id);
        }
        public ActionResult Signup()
        {
            ViewBag.Message = "The Signup page";

            return View();
        }
        public ActionResult YourAccount(Customer customer)
        {
            ViewBag.Message = "Your account.";
            ViewBag.Title = "Your account ";

            return View(customer);
        }
    }
}