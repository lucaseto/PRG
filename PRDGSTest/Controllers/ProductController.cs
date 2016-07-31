using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PRDGSTest.Models;

namespace PRDGSTest.Controllers
{
    public class ProductController : ApiController
    {
        private prodigiousEntities db = new prodigiousEntities();

        // GET api/Product
        public IQueryable<Product> GetProducts()
        {
            
            return db.Products;
        }

        // GET api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/Product/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (product.Name == null)
            {
                ModelState.AddModelError("product.Name","product.Name empty");
                return BadRequest(ModelState);
            }

            if (product.ProductNumber == null)
            {
                ModelState.AddModelError("product.ProductNumber", "product.ProductNumber empty");
                return BadRequest(ModelState);
            }
            if (product.StandardCost == null)
            {
                ModelState.AddModelError("product.StandardCost", "product.StandardCost empty");
                return BadRequest(ModelState);
            }
            if (product.ListPrice == null)
            {
                ModelState.AddModelError("product.ListPrice", "product.ListPrice empty");
                return BadRequest(ModelState);
            }
            if (product.SellStartDate == null)
            {
                ModelState.AddModelError("product.SellStartDate", "product.SellStartDate empty");
                return BadRequest(ModelState);
            }
            if (product.rowguid == null)
            {
                ModelState.AddModelError("product.rowguid", "product.rowguid empty");
                return BadRequest(ModelState);
            }
            if (product.ModifiedDate == null)
            {
                ModelState.AddModelError("product.ModifiedDate", "product.ModifiedDate empty");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (product.Name == null)
            {
                ModelState.AddModelError("product.Name", "product.Name empty");
                return BadRequest(ModelState);
            }

            if (product.ProductNumber == null)
            {
                ModelState.AddModelError("product.ProductNumber", "product.ProductNumber empty");
                return BadRequest(ModelState);
            }
            if (product.StandardCost == null)
            {
                ModelState.AddModelError("product.StandardCost", "product.StandardCost empty");
                return BadRequest(ModelState);
            }
            if (product.ListPrice == null)
            {
                ModelState.AddModelError("product.ListPrice", "product.ListPrice empty");
                return BadRequest(ModelState);
            }
            if (product.SellStartDate == null)
            {
                ModelState.AddModelError("product.SellStartDate", "product.SellStartDate empty");
                return BadRequest(ModelState);
            }
            if (product.rowguid == null)
            {
                ModelState.AddModelError("product.rowguid", "product.rowguid empty");
                return BadRequest(ModelState);
            }
            if (product.ModifiedDate == null)
            {
                ModelState.AddModelError("product.ModifiedDate", "product.ModifiedDate empty");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}