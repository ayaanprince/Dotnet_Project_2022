using OnlineShop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class UserLoginViewModel
    {
        public User Users { get; set; }
        public Login Login { get; set; }
    }
}