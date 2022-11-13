using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View("Index");
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
            Request r = R;
            return View(r);
        }
    }
}