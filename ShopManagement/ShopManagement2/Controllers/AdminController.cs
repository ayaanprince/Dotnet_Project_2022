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
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpPost]
        [Route("Api/Admin/AdminDeleteUser/{id}")]
        public IHttpActionResult AdminDeleteUser(int id)
        {
            var data = AdminServices.AdminDeleteUser(id);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }


        [HttpGet]
        [Route("Api/Admin/AdminGetShopType")]
        public HttpResponseMessage AdminGetShopType()
        {
            var li = AdminServices.AdminGetShopType();
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Admin/AdminEditShopType")]
        public IHttpActionResult AdminEditShopType(ShopTypeModel us)
        {
            var data = AdminServices.AdminEditShopType(us);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpPost]
        [Route("Api/Admin/AdminDeleteShopType/{id}")]
        public IHttpActionResult AdminDeleteShopType(int id)
        {
            var data = AdminServices.AdminDeleteShopType(id);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpGet]
        [Route("Api/Admin/AdminGetCategories")]
        public HttpResponseMessage AdminGetCategories()
        {
            var li = AdminServices.AdminGetCategory();
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Admin/AdminEditCategories")]
        public IHttpActionResult AdminEditCategory(CategoriesModel us)
        {
            var data = AdminServices.AdminEditCategory(us);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpPost]
        [Route("Api/Admin/AdminDeleteCategory/{id}")]
        public IHttpActionResult AdminDeleteCategory(int id)
        {
            var data = AdminServices.AdminDeleteCateGory(id);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpGet]
        [Route("Api/Admin/AdminGetProduct")]
        public HttpResponseMessage AdminGetProduct()
        {
            var li = AdminServices.AdminGetProduct();
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Admin/AdminEditProduct")]
        public IHttpActionResult AdminEditProduct(ProductModel us)
        {
            var data = AdminServices.AdminEditProduct(us);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }

        [HttpPost]
        [Route("Api/Admin/AdminDeleteProduct/{id}")]
        public IHttpActionResult AdminDeleteProduct(int id)
        {
            var data = AdminServices.AdminDeleteProduct(id);
            if (data != 1) BadRequest("Enter write Information");
            return Ok();
        }




    }
}
