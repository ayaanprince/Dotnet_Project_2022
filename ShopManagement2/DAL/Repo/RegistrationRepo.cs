using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class RegistrationRepo
    {
        public static void Create(User us)
        {
            ShopCasketEntities1 et = new ShopCasketEntities1();   
            et.Users.Add(us);
            et.SaveChanges();
        }
    }
}
