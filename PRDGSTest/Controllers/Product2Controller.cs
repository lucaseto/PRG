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
using PRDGSTest.Security;

namespace PRDGSTest.Controllers
{
    public class Product2Controller : ApiController
    {
        private POC_NumbersEntities db = new POC_NumbersEntities();

        // GET api/Product2
        [HttpGet]
        [PRDGSAuthorize(Roles = "admin,reporter")]
        public IQueryable<Product2> GetProduct2()
        {
            return db.Product2;
        }

        // GET api/Product2/5
        [PRDGSAuthorize(Roles = "admin,reporter")]
        [ResponseType(typeof(Product2))]
        public IHttpActionResult GetProduct2(int id)
        {
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return NotFound();
            }

            return Ok(product2);
        }

        // PUT api/Product2/5
        [PRDGSAuthorize(Roles = "admin,reporter")]
        public IHttpActionResult PutProduct2(int id, Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product2.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product2Exists(id))
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

        // POST api/Product2
        [ResponseType(typeof(Product2))]
        [PRDGSAuthorize(Roles = "admin,reporter")]
        public IHttpActionResult PostProduct2(Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product2.Add(product2);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Product2Exists(product2.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product2.ProductID }, product2);
        }

        // DELETE api/Product2/5
        [ResponseType(typeof(Product2))]
        [PRDGSAuthorize(Roles = "admin,reporter")]
        public IHttpActionResult DeleteProduct2(int id)
        {
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return NotFound();
            }

            db.Product2.Remove(product2);
            db.SaveChanges();

            return Ok(product2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product2Exists(int id)
        {
            return db.Product2.Count(e => e.ProductID == id) > 0;
        }
    }
}