using OnlineShop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        EShopEntities db = new EShopEntities();
         static Cart crt;
         static int crtId;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string temp, string address)
        {
            if (temp == "Confirm")
            {
                Cart_Itemes crtItems = new Cart_Itemes();
                var cartDes = new JavaScriptSerializer().Deserialize<List<Cart_Itemes>>(Session["cart"].ToString());
                foreach (Cart_Itemes ci in cartDes)
                {
                    crtItems.Cid = ci.Cid;
                    crtItems.Pid = ci.Pid;
                    crtItems.Qty = ci.Qty;
                    crtItems.ItemPrice = ci.ItemPrice;
                    db.Cart_Itemes.Add(crtItems);
                    db.SaveChanges();
                    UpdateQuantity(ci.Pid, ci.Qty);
                }
                Order o = new Order();
                o.Cid = crtId;
                o.Uid = 2;
                o.CreationDate = System.DateTime.Now;
                o.Status = "Processing";
                o.Address = address;
                o.DeliveryDate = System.DateTime.Now;
                o.TotalPrice = (from c in db.Cart_Itemes where (c.Cid == o.Cid) select (c.ItemPrice)).Sum();
                db.Orders.Add(o);
                db.SaveChanges();

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
            if (CheckQty(id))
            {
                if (Session["cart"] == null)
                {
                    crt = new Cart();
                    crt.Date = System.DateTime.Now;
                    crt.Uid = 2;
                    db.Carts.Add(crt);
                    db.SaveChanges();
                    crtId = (from c in db.Carts where c.Uid == 2 orderby c.Id descending select c.Id).Take(1).SingleOrDefault();
                    List<Cart_Itemes> cartItems = new List<Cart_Itemes>();

                    cartItems.Add(new Cart_Itemes { Cid = crtId, Pid = id, Qty = 1, ItemPrice = product.SellPrice });
                    cartJson = new JavaScriptSerializer().Serialize(cartItems);
                    Session["cart"] = cartJson;
                }
                else
                {
                    var cartDes = new JavaScriptSerializer().Deserialize<List<Cart_Itemes>>(Session["cart"].ToString());
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cartDes[index].Qty++;
                        cartDes[index].ItemPrice = (cartDes[index].Qty * product.SellPrice);
                    }
                    else
                    {
                        cartDes.Add(new Cart_Itemes { Cid = crtId, Pid = id, Qty = 1, ItemPrice = product.SellPrice });
                    }
                    cartJson = new JavaScriptSerializer().Serialize(cartDes);
                    Session["cart"] = cartJson;
                }
            }
            else {
                return RedirectToAction("Index","Product");
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var cartDes = new JavaScriptSerializer().Deserialize<List<Cart_Itemes>>(Session["cart"].ToString());
            int index = isExist(id);
            cartDes.RemoveAt(index);
            string cartJson = new JavaScriptSerializer().Serialize(cartDes);
            Session["cart"] = cartJson;
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            var cartDes = new JavaScriptSerializer().Deserialize<List<Cart_Itemes>>(Session["cart"].ToString());
            for (int i = 0; i < cartDes.Count; i++)
                if (cartDes[i].Pid.Equals(id))
                    return i;
            return -1;
        }
        private void UpdateQuantity(int id, int nqty)
        {
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            Product newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Category = product.Category;
            newProduct.SellPrice = product.SellPrice;
            newProduct.PurchasePrice = product.PurchasePrice;
            newProduct.Quantity = (product.Quantity - nqty);
            db.Entry(product).CurrentValues.SetValues(newProduct);
            db.SaveChanges();
        }

        private bool CheckQty(int id)
        {
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            if (product.Quantity > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
	}
}