using OnlineShop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        EShopEntities db = new EShopEntities();

        [Authorize] 
        [HttpGet]
        public ActionResult Index()
        {
            //Session["cart"] == null;
            var data = db.Products.ToList();
            return View(data);
        }

        [Authorize] 
        [HttpPost]
        public ActionResult Index(string nam, decimal? price)
        {
             if (!price.HasValue && nam == null)
            {
                var data = db.Products.ToList();
                return View(data);
            }
             else if (nam != null && !price.HasValue)
            {
                var data = (from p in db.Products
                            where p.Name.Contains(nam)
                            select p).ToList();
                return View(data);
            }
            else if (nam == null && price.HasValue)
            {
                var data = (from p in db.Products
                            where (p.SellPrice >= price)
                            select p).ToList();
                return View(data);
            }
            else {
                var data = (from p in db.Products
                            where (p.Name.Contains(nam) && p.SellPrice >= price)
                            select p).ToList();
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
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product new_p)
        {
            if (ModelState.IsValid)
            {
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
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id, int temp)
        {
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	
	}
}