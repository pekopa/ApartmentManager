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
    public class ApartmentChangesController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/ApartmentChanges
        public IQueryable<ApartmentChange> GetApartmentChanges()
        {
            return db.ApartmentChanges;
        }
        [Route("api/ApartmentChangesByid/{id}")]
        public IQueryable<ApartmentChange> GetApartmentChangesByid(int id)
        {
            var changetlist = from change in db.ApartmentChanges
                where (change.ApartmentId == id)
                orderby change.ChangeId descending
                select change;
            return changetlist;
        }
        // GET: api/ApartmentChanges/5
        [ResponseType(typeof(ApartmentChange))]
        public IHttpActionResult GetApartmentChange(int id)
        {
            ApartmentChange apartmentChange = db.ApartmentChanges.Find(id);
            if (apartmentChange == null)
            {
                return NotFound();
            }

            return Ok(apartmentChange);
        }

        // PUT: api/ApartmentChanges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartmentChange(int id, ApartmentChange apartmentChange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartmentChange.ChangeId)
            {
                return BadRequest();
            }

            db.Entry(apartmentChange).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentChangeExists(id))
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

        // POST: api/ApartmentChanges
        [ResponseType(typeof(ApartmentChange))]
        public IHttpActionResult PostApartmentChange(ApartmentChange apartmentChange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApartmentChanges.Add(apartmentChange);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApartmentChangeExists(apartmentChange.ChangeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartmentChange.ChangeId }, apartmentChange);
        }

        // DELETE: api/ApartmentChanges/5
        [ResponseType(typeof(ApartmentChange))]
        public IHttpActionResult DeleteApartmentChange(int id)
        {
            ApartmentChange apartmentChange = db.ApartmentChanges.Find(id);
            if (apartmentChange == null)
            {
                return NotFound();
            }

            db.ApartmentChanges.Remove(apartmentChange);
            db.SaveChanges();

            return Ok(apartmentChange);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmentChangeExists(int id)
        {
            return db.ApartmentChanges.Count(e => e.ChangeId == id) > 0;
        }
    }
}