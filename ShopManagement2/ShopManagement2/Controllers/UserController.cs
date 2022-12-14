using BLL.BEnt;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ShopManagement2.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("Api/ShopCasket/Login/{Id}")]
        public IHttpActionResult log(LoginModel lg,int Id)
        {
            UserModel data = LoginService.Get(lg.Name,lg.Password);
            if (data.Name != lg.Name || data.Password != lg.Password)
            {
                return BadRequest("Please Enter write info"); 
              }
            LoginService.LoginUser(Id);
            return Ok();
        }
        [HttpPost]
        [Route("Api/ShopCasket/Registration")]
        public IHttpActionResult Registration(UserModel us)
        {
            if (us.Name == null || us.Email == null || us.Password == null || us.Type == null || us.Address == null)
            {
                return BadRequest("Please Enter write info");
            }

            RegistrationService.Create(us);
            return Ok();

        }

    }
}
