using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AdminRepo
    {
        public static List<Product> AdminGetProduct()
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Products select e).ToList();
            return data;
        }

        public static int AdminEditProduct(Product pt)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Products where e.Id == pt.Id select e).FirstOrDefault();
            if (data.Id == pt.Id && data.CategoriesId == pt.CategoriesId)
            {
                ap.Entry(data).CurrentValues.SetValues(pt);
                return 1;
            }
            return 0;
        }
        public static int AdminDeleteProduct(int id)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Products where e.Id == id select e).FirstOrDefault();
            if (data == null) return 0;
            if (data.Id == id)
            {
              ap.Products.Remove(data);
                ap.SaveChanges();
                return 1;
            }
            return 0;
        }

        public static List<Catagory> AdminGetCategories()
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Catagories select e).ToList();
            return data;
        }

        public static int AdminEditCategories(Catagory pt)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Catagories where e.Id == pt.Id select e).FirstOrDefault();
            if (data == null) return 0;
            if (data.Id == pt.Id && data.ShopId == pt.ShopId)
            {
                ap.Entry(data).CurrentValues.SetValues(pt);
                return 1;
            }
            return 0;
        }

        public static int AdminDeleteCategories(int id)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Catagories where e.Id == id select e).FirstOrDefault();
            if (data == null) return 0;
            if (data.Id == id)
            {
                var ddx = (from e in ap.Products where e.CategoriesId == data.Id select e).ToList();

                foreach (Product p in ddx)
                {
                    AdminDeleteProduct(p.Id);
                }

                ap.Catagories.Remove(data);
                ap.SaveChanges();
                return 1;
            }
            return 0;
        }

        public static List<ShopType>AdminGetShopType()
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.ShopTypes select e).ToList();
            return data;
        }

        public static int AdminEditShopType(ShopType st)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            ShopType data = (from e in ap.ShopTypes where e.Id == st.Id select e).FirstOrDefault();
            if(data.Id == st.Id && data.UserId == st.UserId)
            {
                ap.Entry(data).CurrentValues.SetValues(st);
                return 1;
            }
            return 0;
        }

        public static int AdminDeleteShopType(int id)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            ShopType data = (from e in ap.ShopTypes where e.Id == id select e).FirstOrDefault();

            if(data == null) return 0;  

            if (data.Id == id)
            {
                var ddx = (from e in ap.Catagories where e.ShopId == data.Id select e).ToList();

                foreach (Catagory p in ddx)
                {
                    AdminDeleteCategories(p.Id);
                }

                ap.ShopTypes.Remove(data);
                ap.SaveChanges();
                return 1;
            }
            return 0;
        }

      
        public static List<User>Get()
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            return ap.Users.ToList();
        }

        public static User AdminInfoGet(int id)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Users where e.Id == id select e).FirstOrDefault();
            return data;
        }

        public static void AdminInfoEdit(User us)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            var data = (from e in ap.Users where e.Id == us.Id select e).FirstOrDefault();
            ap.Entry(data).CurrentValues.SetValues(us);
            ap.SaveChanges();
        }

        public static void AdminCreateUser(User us)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            ap.Users.Add(us);
            ap.SaveChanges();
        }

        public static int AdminEditUser(User us)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
            
            var data = (from e in ap.Users where e.Id == us.Id select e).FirstOrDefault();  
            if(data == null)
            {
                return 0;
            }

            ap.Entry(data).CurrentValues.SetValues(us);
            ap.SaveChanges();
            return 1;
        }

        public static int AdminDeleteUser(int id)
        {
            ShopCasketEntities ap = new ShopCasketEntities();
           var data = (from e in ap.Users where e.Id == id select e).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }
            if(data.Type =="Admin")
            {
                ap.Users.Remove(data);
                ap.SaveChanges();
                return 1;
            }

            if(data.Type == "Customer")
            {
                var ddx = (from e in ap.Records where e.UserId == data.Id select e).ToList();
                var dx = (from e in ap.Deliveries where e.ShopId == data.Id select e).ToList();

                if (ddx.Count > 0)
                {
                    foreach (var item in ddx)
                    {
                        Record rd = new Record();
                        rd.Id = item.Id;
                        rd.ProductId = item.ProductId;
                        rd.UserId = item.UserId;
                        rd.ProductQuantity = item.ProductQuantity;
                        rd.Tot_amount = item.Tot_amount;
                        ap.Records.Remove(rd);
                    }
                }

                if (dx.Count > 0)
                {
                    foreach (var item in dx)
                    {
                        Delivery delivery = new Delivery();
                        delivery.Id = item.Id;
                        delivery.ProductId = item.ProductId;
                        delivery.CustomerId = item.CustomerId;
                        delivery.ShopId = item.ShopId;
                        delivery.Tot_price = item.Tot_price;
                        delivery.Time = item.Time;
                        ap.Deliveries.Remove(delivery);
                    }
                }

                ap.SaveChanges();
                return 1;

            }

            if(data.Type == "Shop")
            {
                var shopTypeList = (from e in ap.ShopTypes where e.UserId == data.Id select e).ToList();

                if (shopTypeList != null)
                {
                   foreach (var ddx in shopTypeList)
                    {
                        AdminDeleteShopType(data.Id);
                    }
                }
                
               
                ap.Users.Remove(data);

                ap.SaveChanges();

                return 1;

            }

            return 0;
           
        }

    }


}
