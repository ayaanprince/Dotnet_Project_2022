using MIDTERM_ASSIGNMENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERM_ASSIGNMENT.Controllers
{
    public class ZeroController : Controller
    {
        // GET: Zero
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Info()
        {
            var db = new Zero_HungerEntities();
            var employee = db.Employees.ToList();
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            var db = new Zero_HungerEntities();
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        public ActionResult Collect()
        {
            var db = new Zero_HungerEntities();
            var order = db.Employees.ToList();
            return View(order);
        }
        [HttpPost]
        public ActionResult Collect(Order o)
        {
            var db = new Zero_HungerEntities();
            db.Orders.Add(o);
            db.SaveChanges();
            return View("Dashboard");
        }
        public ActionResult Collected()
        {
            var db = new Zero_HungerEntities();
            var order = db.Orders.ToList();
            return View(order);
        }
    }
}