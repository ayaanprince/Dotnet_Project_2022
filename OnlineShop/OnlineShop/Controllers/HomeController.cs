using OnlineShop.Models.Database;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        EShopEntities db = new EShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {

            return View(new User());
        }

        [HttpPost]
        public ActionResult Register(UserLoginViewModel u)
        {
            if (ModelState.IsValid)
            {
                User us = new User();
                us = u.Users;
                db.Users.Add(us);
                db.SaveChanges();
                Login lg = new Login();
                lg.Uid = (from ui in db.Users where ui.Email == u.Users.Email select ui.Id).FirstOrDefault();
                lg.Username = u.Login.Username;
                lg.Password = u.Login.Password;
                lg.Type = "customer";
                db.Logins.Add(lg);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(u);
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) { return RedirectToAction("Index"); }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login user)
        {
            var data = (from e in db.Logins
                        where e.Password.Equals(user.Password) &&
                        e.Username.Equals(user.Username)
                        select e).FirstOrDefault();
            if (data != null)
            {
               // FormsAuthentication.SetAuthCookie(data.Username, false);
                //Session["role"] = data.Type;
                return RedirectToAction("Index", "Product");
            }

            TempData["msg"] = "Invalid Crdentials";
            return RedirectToAction("Login");
        }
    }
}