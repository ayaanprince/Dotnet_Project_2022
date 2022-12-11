using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class RecordsRepo
    {
        public static List<Record> GetUserRecords(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Records where e.UserId == id select e).ToList();
            return data;
        }

        public static int EditRecords(Record rd)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Records where e.Id == rd.Id select e).FirstOrDefault();
            if (data.Id != rd.Id||data.UserId != rd.UserId || data.ProductId != rd.ProductId) return 0;
            ap.Entry(data).CurrentValues.SetValues(rd);
            ap.SaveChanges();
            return 1;
        }

        public static int deleteRecords(Record rd)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Records where e.Id == rd.Id select e).FirstOrDefault();
            if (data.Id != rd.Id || data.UserId != rd.UserId || data.ProductId != rd.ProductId) return 0;
            ap.Records.Remove(data);
            ap.SaveChanges();
            return 1;
        }



    }
}
