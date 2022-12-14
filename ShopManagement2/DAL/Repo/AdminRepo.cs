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
        public static List<User> Get()
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            return ap.Users.ToList();
        }

        public static User AdminInfoGet(int id)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Users where e.Id == id select e).FirstOrDefault();
            return data;
        }

        public static void AdminInfoEdit(User us)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            var data = (from e in ap.Users where e.Id == us.Id select e).FirstOrDefault();
            ap.Entry(data).CurrentValues.SetValues(us);
            ap.SaveChanges();
        }

        public static void AdminCreateUser(User us)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            ap.Users.Add(us);
        }

        public static int AdminEditUser(User us)
        {
            ShopCasketEntities1 ap = new ShopCasketEntities1();
            
            var data = (from e in ap.Users where e.Id == us.Id select e).FirstOrDefault();  
            if(data == null)
            {
                return 0;
            }

            ap.Entry(data).CurrentValues.SetValues(us);
            ap.SaveChanges();
            return 1;
        }

    }
}
