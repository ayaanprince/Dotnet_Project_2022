using BLL.BEnt;
using BLL.Services;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ShopManagement2.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("Api/Admin/AdminGetUser")]
        public HttpResponseMessage GetUser()
        {
            var li = AdminServices.Get();
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }
        [HttpPost]
        [Route("Api/Admin/AdminGetUser/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            var li = AdminServices.AdminGetUser(id);
            if(li.Id != id)return Request.CreateResponse(HttpStatusCode.NotFound);
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Admin/AdminCreateUser")]
        public IHttpActionResult AdminCreateUser(UserModel us)
        {
            AdminServices.AdminCreateUser(us);
            return Ok();
        }

        [HttpPost]
        [Route("Api/Admin/AdminEditUser")]
        public IHttpActionResult AdminEditUser(UserModel us)
        {
            var data = AdminServices.AdminEditUser(us);
            if (data != 1) return Ok();
            else return BadRequest("Enter write Information");
        }





    }
}
