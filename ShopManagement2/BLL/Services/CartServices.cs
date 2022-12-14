using BLL.BEnt;
using DAL.Database;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartServices
    {

        public static int GetLoginId(int id)
        {
            int re = CartRepo.GetLogInId(id);
            return re;
        }

        public static int GetProductId(int id)
        {
            int re = CartRepo.GetProductId(id);
            return re;
        }

        public static List<CartModel>Get(int id)
        {
            var data = CartRepo.Get(id);
           List<CartModel> li = new List<CartModel>();
           foreach(var c in data)
            {
                CartModel model = new CartModel();
                model.Id = c.Id;
                model.UserId = c.UserId;
                model.ProductName = c.ProductName;
                model.ProductPrice= c.ProductPrice;
                model.ProductQuantity= c.ProductQuantity;
                li.Add(model);
            }
            return li;
        }

        public static void Create_cart(int Product_id,int UserId,int quantity)
        {
            CartRepo.Create_cart(Product_id,UserId, quantity);
        }

        public static int Edit_Cart(CartModel cm)
        {
            Cart cr  = new Cart();  
            cr.Id = cm.Id;
            cr.UserId = cm.UserId;
            cr.ProductName = cm.ProductName;
            cr.ProductPrice = cm.ProductPrice;
            cr.ProductQuantity = cm.ProductQuantity;
            return CartRepo.Edit_Cart(cr);
        }

        public static int Delete_Cart(CartModel cm)
        {
            Cart cr = new Cart();
            cr.Id = cm.Id;
            cr.UserId = cm.UserId;
            cr.ProductName = cm.ProductName;
            cr.ProductPrice = cm.ProductPrice;
            cr.ProductQuantity = cm.ProductQuantity;
            return CartRepo.Delete_cart(cr);
        }

        public static int CheckOut(int id)
        {
            return CartRepo.CheckOut(id); 
        }


    }
}
