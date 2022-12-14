using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo
    {

        public static User CustomerInfoGet(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Users where e.Id == id select e).FirstOrDefault();
            return  data;
        }

        public static void CustomerInfoEdit(User us)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Users where e.Id == us.Id select e).FirstOrDefault();
            ap.Entry(data).CurrentValues.SetValues(us);
           ap.SaveChanges();
        }


    }
}
