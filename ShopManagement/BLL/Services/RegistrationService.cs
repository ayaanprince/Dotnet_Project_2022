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
    public class RegistrationService
    {
        public static void Create(UserModel us)
        {
            User st = new User();
            st.Address = us.Address;
            st.Password = us.Password;
            st.Email = us.Email;
            st.Name = us.Name;  
            st.Type = us.Type;
            RegistrationRepo.Create(st);
        }
    }
}
