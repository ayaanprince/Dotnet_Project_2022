using CartMidTask2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartMidTask2.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult Index()
        {
            //Session["cart"] == null;
            CartCRUDEntities db = new CartCRUDEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string nam, float price)
        {
            if (price == 0)
            {
                CartCRUDEntities db = new CartCRUDEntities();
                var data = (from p in db.Products
                            where p.Name.Contains(nam)
                            select p).ToList();
                return View(data);
            }
            else if (nam == null)
            {
                CartCRUDEntities db = new CartCRUDEntities();
                var data = (from p in db.Products
                            where (p.Price >= price)
                            select p).ToList();
                return View(data);

            }
            else if (nam != null && price != 0)
            {
                CartCRUDEntities db = new CartCRUDEntities();
                var data = (from p in db.Products
                            where (p.Name.Contains(nam) && p.Price >= price)
                            select p).ToList();
                return View(data);

            }
            else
            {
                CartCRUDEntities db = new CartCRUDEntities();
                var data = db.Products.ToList();
                return View(data);
            }
        }


        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                CartCRUDEntities db = new CartCRUDEntities();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CartCRUDEntities db = new CartCRUDEntities();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product new_p)
        {
            if (ModelState.IsValid)
            {
                CartCRUDEntities db = new CartCRUDEntities();
                var product = (from p in db.Products where p.Id == new_p.Id select p).FirstOrDefault();
                db.Entry(product).CurrentValues.SetValues(new_p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CartCRUDEntities db = new CartCRUDEntities();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id, int temp)
        {
            CartCRUDEntities db = new CartCRUDEntities();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}