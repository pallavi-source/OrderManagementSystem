using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    [RoutePrefix("api/OrderItems")]
    public class OrderItemController : ApiController
    {
        private OrderManagementSystemEntities19 entities = new OrderManagementSystemEntities19();
        [HttpGet]
        [Route("get")]
        //public IHttpActionResult GetOrderItems()
        //{
        //    var result = entities.Orders;
        //    return Ok(result);
        //}
        public IHttpActionResult GetAllOrders()
        {
            return Ok(entities.OrderItems);
        }
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostOrderItems(OrderItem orderitem)
        {
            var result= entities.OrderItems.Add(orderitem);
            //entity.SaveChanges();
            return Created(" ", result);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var abc = entities.OrderItems.Where(e => e.OrderID == id).Select(c => c);
            return Ok(abc);
        }

    }
}
