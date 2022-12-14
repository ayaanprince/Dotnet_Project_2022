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
    public class LoginService
    {
        public static UserModel Get(string name, string password)
        {
            var data = LoginRepo.Get(name, password);

            UserModel model = new UserModel();
            if (data != null)
            {
                model.Name = data.Name;
                model.Password = data.Password;
            }
            return model;
        }

        public static void LoginUser(int id)
        {
            LoginRepo.UserLogin(id);
        }
    }
}
