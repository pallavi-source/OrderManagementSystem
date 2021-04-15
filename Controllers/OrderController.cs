using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    [RoutePrefix("api/Order")] 
    //[Route("api/[controller]")]

    public class OrderController : ApiController
    {
        private OrderManagementSystemEntities18 entity = new OrderManagementSystemEntities18();

        [HttpGet]
        [Route("get")]
        public IHttpActionResult  GetAllOrders()
        {
            return Ok(entity.Orders);   
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostOrder(Order order)
        {
            entity.Orders.Add(order);
            entity.SaveChanges();
            return Created(" ", entity);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var abc = entity.Orders.Where(e => e.OrderID == id).Select(c => c);
            return Ok(abc);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid order id");


            var order = entity.Orders
                .Where(s => s.OrderID == id)
                .FirstOrDefault();

            entity.Entry(order).State = System.Data.Entity.EntityState.Deleted;
            entity.SaveChanges();


            return Ok(order);
        }

        [HttpPatch]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id, [FromBody]Order order)
        {
            var a = entity.Orders.FirstOrDefault(x => x.OrderID == id);
            //if (a != null) a.id = newValue;
            return Ok(order);

        }
    }
}
