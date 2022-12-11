using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CartRepo
    {
        public static int GetLogInId(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            string name = (from e in ap.Users where e.Id == id select e.Name).First();
            string password = (from e in ap.Users where e.Id == id select e.Password).First();
            var data = (from e in ap.Logins where e.Name == name && e.Password.Equals(password) select e.Id).FirstOrDefault();
            return data;
        }

        public static int GetProductId(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Products where e.Id == id select e.Id).FirstOrDefault();
                return data;
        }

        public static List<Cart> Get(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Carts where e.UserId == id select e).ToList();
            return data;
        }

        public static  void Create_cart(int Product_id,int UserId,int quantity)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            string productName = (from e in ap.Products where e.Id == Product_id select  e.Name).First();
            int productPrice = (from e in ap.Products where e.Id == Product_id select e.Price).First();

           Cart cart = new Cart();
            cart.ProductQuantity = quantity;
            cart.ProductName = productName;   
            cart.UserId = UserId;
            cart.ProductPrice = productPrice;

          ap.Carts.Add(cart);
            ap.SaveChanges();
        }


        public static int Edit_Cart(Cart cs)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Carts where e.Id == cs.Id select e).FirstOrDefault();
            if (data.Id != cs.Id) return 0;
            ap.Entry(data).CurrentValues.SetValues(cs);
            ap.SaveChanges();
            return 1;
        }

        public static int Delete_cart(Cart cs)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Carts where e.Id == cs.Id select e).FirstOrDefault();
            if (data.Id != cs.Id) return 0;
             ap.Carts.Remove(data);
            ap.SaveChanges();
            return 1;
        }

        public static int CheckOut(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Carts where e.UserId == id select e).ToList();
            if (data.Count == 0) return 0;
            foreach (var item in data)
            {
                Record rd = new Record();


                var pk = (from e in ap.Products where e.Name == item.ProductName select e.Id).FirstOrDefault();

                rd.UserId = item.UserId;
                rd.ProductQuantity = item.ProductQuantity;
                int rk = item.ProductPrice * item.ProductQuantity;
                rd.Tot_amount = rk;
                rd.ProductId = pk;
                ap.Records.Add(rd);
            }
            ap.SaveChanges();
            return 1;
        }



    }
}
