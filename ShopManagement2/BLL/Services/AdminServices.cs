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

    }
}
