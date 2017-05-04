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
using HousingWebApi;

namespace HousingWebApi.Controllers
{
    public class PastContractOwnersController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/PastContractOwners
        public IQueryable<PastContractOwner> GetPastContractOwners()
        {
            return db.PastContractOwners;
        }

        // GET: api/PastContractOwners/5
        [ResponseType(typeof(PastContractOwner))]
        public IHttpActionResult GetPastContractOwner(int id)
        {
            PastContractOwner pastContractOwner = db.PastContractOwners.Find(id);
            if (pastContractOwner == null)
            {
                return NotFound();
            }

            return Ok(pastContractOwner);
        }

        // PUT: api/PastContractOwners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPastContractOwner(int id, PastContractOwner pastContractOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pastContractOwner.Id)
            {
                return BadRequest();
            }

            db.Entry(pastContractOwner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastContractOwnerExists(id))
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

        // POST: api/PastContractOwners
        [ResponseType(typeof(PastContractOwner))]
        public IHttpActionResult PostPastContractOwner(PastContractOwner pastContractOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PastContractOwners.Add(pastContractOwner);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PastContractOwnerExists(pastContractOwner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pastContractOwner.Id }, pastContractOwner);
        }

        // DELETE: api/PastContractOwners/5
        [ResponseType(typeof(PastContractOwner))]
        public IHttpActionResult DeletePastContractOwner(int id)
        {
            PastContractOwner pastContractOwner = db.PastContractOwners.Find(id);
            if (pastContractOwner == null)
            {
                return NotFound();
            }

            db.PastContractOwners.Remove(pastContractOwner);
            db.SaveChanges();

            return Ok(pastContractOwner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PastContractOwnerExists(int id)
        {
            return db.PastContractOwners.Count(e => e.Id == id) > 0;
        }
    }
}