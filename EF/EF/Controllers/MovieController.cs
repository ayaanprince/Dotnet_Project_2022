using EF.Models.Database;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /Movie/
        public ActionResult Index()
        {
            MovieRentEntities db = new MovieRentEntities();
            var data = db.Movies.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Movy());
        }

        [HttpPost]
        public ActionResult Create(Movy m)
        {
            if (ModelState.IsValid)
            {
                MovieRentEntities db = new MovieRentEntities();
                db.Movies.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
        }
	}
}