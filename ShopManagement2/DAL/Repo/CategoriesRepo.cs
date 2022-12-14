using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoriesRepo : IRepo<Category, int, Category>
    {
        ShopCasketEntities1 db;
        internal CategoriesRepo()
        {
            db = new ShopCasketEntities1();
        }
        public Category Add(Category obj)
        {
            db.Categories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(db.Categories.Find(id));
        }

        public bool Update(Category obj)
        {
            var temp = db.Categories.Find(obj.Id);
            db.Entry(temp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
