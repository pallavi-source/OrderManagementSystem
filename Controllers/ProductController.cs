using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    [RoutePrefix("api/Product")]
    //[Route("api/[controller]")]
    public class ProductController : ApiController
    {
        private OrderManagementSystemEntities17 entity = new OrderManagementSystemEntities17();

        [HttpGet]
        [Route("get")]

        public IHttpActionResult GetAllProducts()
        {
            return Ok(entity.Products);

        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostProduct(Product product)
        {
            entity.Products.Add(product);
            entity.SaveChanges();
            return Created(" ", entity);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var abc = entity.Products.Where(e => e.ProductID == id).Select(c => c);
            return Ok(abc);
        }
        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid product id");


            var product = entity.Products
                .Where(s => s.ProductID == id)
                .FirstOrDefault();

            entity.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            entity.SaveChanges();


            return Ok(product);
        }
        [HttpPatch]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id, [FromBody]Product product)
        {
            var a = entity.Products.FirstOrDefault(x => x.ProductID == id);
            //if (a != null) a.id = newValue;
            return Ok(product);

        }
    }
}
