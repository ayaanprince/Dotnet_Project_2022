using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ShopTypeRepo : IRepo<ShopType, int, ShopType>
    {
        ShopCasketEntities1 db;
        internal ShopTypeRepo()
        {
            db = new ShopCasketEntities1();
        }
        public ShopType Add(ShopType obj)
        {
            db.ShopTypes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.ShopTypes.Remove(db.ShopTypes.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<ShopType> Get()
        {
            return db.ShopTypes.ToList();
        }

        public ShopType Get(int id)
        {
            return db.ShopTypes.Find(id);
        }

        public bool Update(ShopType obj)
        {
            var temp = db.ShopTypes.Find(obj.Id);
            db.Entry(temp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
