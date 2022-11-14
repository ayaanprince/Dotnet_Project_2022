using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class ZeroController : Controller
    {
        // GET: Zero
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRequest(Request R)
        {
            var db = new Zero_HungerEntities();
            db.Requests.Add(R);
            db.SaveChanges();
            return View("ViewRequest");
        }        
        public ActionResult ViewRequest()
        {
            var db = new Zero_HungerEntities();
            var R = db.Requests.ToList();
            return View(R);
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee E)
        {
            var db = new Zero_HungerEntities();
            db.Employees.Add(E);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult ViewEmployee()
        {
            var db = new Zero_HungerEntities();
            var em = db.Employees.ToList();
            return View(em);
        }
        public ActionResult Assign(Request R)
        {
            var db = new Zero_HungerEntities();
            var n = db.Employees.ToList();
            ViewBag.Id = R.Id;
            ViewBag.Rname = R.RetaurantName;
            ViewBag.Fname = R.FoodName;
            ViewBag.Q = R.Quantity;
            return View(n);
        }
        [HttpPost]
        public ActionResult Assign(Collection C)
        {
            var db = new Zero_HungerEntities();
            db.Collections.Add(C);
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult Collected()
        {
            var db = new Zero_HungerEntities();
            var collections = db.Collections.ToList();
            return View(collections);
        }
        public ActionResult RequestView(int id)
        {
            var db = new Zero_HungerEntities();
            var request = (from r in db.Collections where r.RequestId == id select rb).First();
        }
    }
}