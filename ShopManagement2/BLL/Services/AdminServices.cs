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
    public class AdminServices
    {
        public static List<UserModel> Get()
        {
            var data = AdminRepo.Get();
            List<UserModel> list = new List<UserModel>();
            foreach (var item in data)
            {
                UserModel model = new UserModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Email = item.Email;
                model.Password = item.Password;
                model.Type = item.Type;
                model.Address = item.Address;
                list.Add(model);
            }
            return list;
        }
        public static UserModel AdminGetUser(int id)
        {
            var data = AdminRepo.AdminInfoGet(id);
            UserModel st = new UserModel();
            if (data != null)
            {
                st.Id = data.Id;
                st.Name = data.Name;
                st.Email = data.Email;
                st.Password = data.Password;
                st.Type = data.Type;
                st.Address = data.Address;
            }
            return st;
        }

        public static void AdminCreateUser(UserModel us)
        {
            User uk = new User();
            uk.Address = us.Address;
            uk.Email = us.Email;
            uk.Password = us.Password;
            uk.Type = us.Type;
            uk.Name = us.Name;
            AdminRepo.AdminCreateUser(uk);
        }

        public static int AdminEditUser(UserModel us)
        {
            User uk = new User();
            uk.Id = us.Id;
            uk.Address = us.Address;
            uk.Email = us.Email;
            uk.Password = us.Password;
            uk.Type = us.Type;
            uk.Name = us.Name;
          return  AdminRepo.AdminEditUser(uk);
        }

        public static int AdminDeleteUser(int id)
        {
            return AdminRepo.AdminDeleteUser(id);
        }

        public static List<ProductModel>AdminGetProduct()
        {
            var data = AdminRepo.AdminGetProduct();
            List<ProductModel>li = new List<ProductModel>();    
            foreach(Product p in data)
            {
                ProductModel pm = new ProductModel(); 
                pm.Id = p.Id;   
                pm.Name = p.Name;
                pm.Price = p.Price; 
                pm.CategoriesId = p.CategoriesId;
                li.Add(pm);
            }

            return li;
        }

        public static int AdminEditProduct(ProductModel pm)
        {
            Product model = new Product();
            model.Id = pm.Id;   
            model.Name = pm.Name;
            model.Price = pm.Price;
            model.CategoriesId = pm.CategoriesId;
            return AdminRepo.AdminEditProduct(model);
        }

        public static int AdminDeleteProduct(int id)
        {
            return AdminRepo.AdminDeleteProduct(id);
        }

        public static List<CategoriesModel> AdminGetCategory()
        {
            var data = AdminRepo.AdminGetCategories();
            List<CategoriesModel> li = new List<CategoriesModel>();
            foreach (Catagory p in data)
            {
                CategoriesModel pm = new CategoriesModel();
               pm.Name=p.Name;  
                pm.ShopId = p.ShopId;
                pm.Type = p.Type;
                pm.Id=p.Id;
                li.Add(pm);
            }

            return li;
        }

        public static int AdminEditCategory(CategoriesModel pm)
        {
            Catagory model = new Catagory();

            model.Id = pm.Id;
            model.ShopId = pm.ShopId;   
            model.Type = pm.Type;   
            model.Name=pm.Name;
           
            return AdminRepo.AdminEditCategories(model);
        }

        public static int AdminDeleteCateGory(int id)
        {
            return AdminRepo.AdminDeleteCategories(id);
        }

        public static List<ShopTypeModel> AdminGetShopType()
        {
            var data = AdminRepo.AdminGetShopType();
            List<ShopTypeModel> li = new List<ShopTypeModel>();
            foreach (ShopType p in data)
            {
                ShopTypeModel pm = new ShopTypeModel();
               pm.Id = p.Id;
                pm.UserId = p.UserId;
                pm.Name = p.Name;
                pm.Type = p.Type;
                li.Add(pm);
            }

            return li;
        }

        public static int AdminEditShopType(ShopTypeModel pm)
        {
            ShopType model = new ShopType();

           model.Name = pm.Name;
            model.Type = pm.Type;
            model.Id=pm.Id;
            model.UserId=pm.UserId; 

            return AdminRepo.AdminEditShopType(model);
        }

        public static int AdminDeleteShopType(int id)
        {
            return AdminRepo.AdminDeleteShopType(id);
        }


    }
}
