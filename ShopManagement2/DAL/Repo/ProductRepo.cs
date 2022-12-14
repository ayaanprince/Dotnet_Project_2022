using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProductRepo : IRepo<Product, int, bool>
    {
        ShopCasketEntities1 db;
        internal ProductRepo()
        {
            db = new ShopCasketEntities1(); 
        }
        public bool Add(Product obj)
        {
            db.Products.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(db.Products.Find(id));
        }

        public bool Update(Product obj)
        {
            var temp = db.Products.Find(obj.Id);
            db.Entry(temp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
