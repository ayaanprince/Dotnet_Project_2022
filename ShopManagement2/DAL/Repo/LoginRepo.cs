using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class LoginRepo
    {
        public static User Get(string name,string password)
        {
            ShopCasketEntities db = new ShopCasketEntities();
            var data = (from e in db.Users where (e.Name.Equals(name) && e.Password.Equals(password)) select e) .FirstOrDefault();
            return data;
        }
        public static void UserLogin(int id)
        {
            ShopCasketEntities db = new ShopCasketEntities();
            var data = (from e in db.Users where (e.Id == id) select e).FirstOrDefault();
            string name  = data.Name;   
            string password = data.Password;
            var dat = new Login();
            dat.Name = name;    
            dat.Password = password;
            db.Logins.Add(dat);
            db.SaveChanges();
        }
    }
}
