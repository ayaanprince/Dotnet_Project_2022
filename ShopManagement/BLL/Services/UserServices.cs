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
    public class UserServices
    {

        public static UserModel GetInfoCustomer(int id)
        {
            var data = UserRepo.CustomerInfoGet(id);
            UserModel st = new UserModel();
            st.Id = data.Id;
            st.Name = data.Name;
            st.Email = data.Email;
            st.Password = data.Password;
            st.Type = data.Type;
            st.Address = data.Address;
            return st;
        }

        public static void UpdateInfoCustomer(UserModel us)
        {
            User st = new User();
            st.Id = us.Id;
            st.Name = us.Name;
            st.Email = us.Email;
            st.Password = us.Password;
            st.Type = us.Type;
            st.Address = us.Address;
            UserRepo.CustomerInfoEdit(st);
        }

        public static void DeleteCustomer(int id)
        {

        }


    }
}
