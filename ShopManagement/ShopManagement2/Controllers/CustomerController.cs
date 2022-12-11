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
    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("Api/Customer/GetInfo/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = UserServices.GetInfoCustomer(id);
            if(data.Id != id || data.Type != "Customer")
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            var datajava = new JavaScriptSerializer().Serialize(data);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Customer/EditCustomer/{id}")]
        public IHttpActionResult Edit(UserModel us,int id)
        {
            if (!ModelState.IsValid ||us.Type!="Customer") return BadRequest("Enter write Information");
            us.Id = id;
            UserServices.UpdateInfoCustomer(us);
            return Ok();
        }


        [HttpPost, Route("Api/Customer/CheckChart/{id}")]
        public HttpResponseMessage CheckChartGet(int id)
        {
            var dat = CartServices.GetLoginId(id);

            if(dat == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var data = CartServices.Get(dat);
            var datajava = new JavaScriptSerializer().Serialize(data);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost, Route("Api/Customer/CreateChart/{User_id}/{Product_id}/{Quantity}")]
        public IHttpActionResult Create_Cart(int User_id, int Product_id,int Quantity)
        {
            var dat = CartServices.GetLoginId(User_id);
            var data = CartServices.GetProductId(Product_id);

            if (dat == 0)
            {
                return BadRequest("Please Login");
            }

            if (data == 0)
            {
                return BadRequest("Please Provide write Product Information");
            }

            if (Quantity == 0)
            {
                return BadRequest("Please add product");
            }



            CartServices.Create_cart(Product_id, dat,Quantity);

            return Ok();
        }

        [HttpPost, Route("Api/Customer/EditChart")]
        public IHttpActionResult Edit_Cart(CartModel ct)
        {
            var data = CartServices.Edit_Cart(ct);
            if(data == 0)
            {
                return BadRequest("Please Provide write Product Information");
            }
            else
            {
                return Ok();    
            }
            
        }
        [HttpPost, Route("Api/Customer/DeleteChart")]
        public IHttpActionResult Delete_Cart(CartModel ct)
        {
            var data = CartServices.Delete_Cart(ct);
            if (data == 0)
            {
                return BadRequest("Please Provide write Product Information");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        [Route("Api/Customer/GetRecords/{id}")]
        public HttpResponseMessage GetRecords(int id)
        {
            var data = RecordServices.GetUserRecords(id);
            var datajava = new JavaScriptSerializer().Serialize(data);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("Api/Customer/EditRecords")]
        public IHttpActionResult Edit_Records(RecordsModel rm)
        {
            var data = RecordServices.EditRecords(rm);
            if (data == 0)
            {
                return BadRequest("Please Provide write Product Information");
            }
            else
            {
                return Ok();
            }

        }

        [HttpPost]
        [Route("Api/Customer/DeleteRecords")]
        public IHttpActionResult Delete_Records(RecordsModel rm)
        {
            var data = RecordServices.DeleteRecords(rm);
            if (data == 0)
            {
                return BadRequest("Please Provide write Product Information");
            }
            else
            {
                return Ok();
            }

        }

        [HttpPost]
        [Route("Api/Customer/Checkout/{id}")]

        public IHttpActionResult Checkout(int id)
        {
            var dat = CartServices.GetLoginId(id);

            if(dat == 0)
            {
                return BadRequest("Please Login");
            }
            
            var data = CartServices.CheckOut(dat);
            if(data == 0)
            {
                return BadRequest("Nothing to record");
            }
            else
            {
                return Ok();
            }
        }



    }
}
