using CartMidTask2.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CartMidTask2.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        CartCRUDEntities db = new CartCRUDEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string temp)
        {
            if (temp == "Confirm")
            {
                Cart c = new Cart();
                Order o = new Order();
                db.Orders.Add(o);
                db.SaveChanges();
                var cartDes = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                foreach (Product p in cartDes)
                {
                    c.Pid = p.Id;
                    c.Oid = o.Id;
                    db.Carts.Add(c);
                    db.SaveChanges();
                }
                //var cartTot = (from ct in db.Carts where ct.Oid == o.Id select ct);

                Session["cart"] = null;
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Add(int id)
        {
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            string cartJson;
            if (Session["cart"] == null)
            {
                List<Product> products = new List<Product>();
                products.Add(product);
                cartJson = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = cartJson;
            }
            else
            {
                var cartDes = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                cartDes.Add(product);
                cartJson = new JavaScriptSerializer().Serialize(cartDes);
                Session["cart"] = cartJson;
            }
            return RedirectToAction("Index");
        }

        
	}
}