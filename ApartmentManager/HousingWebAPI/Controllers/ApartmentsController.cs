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
using HousingWebAPI.Models;

namespace HousingWebAPI.Controllers
{
    public class ApartmentsController : ApiController
    {
        private ApartmentsDataContext db = new ApartmentsDataContext();

        // GET: api/Apartments
        public IQueryable<Apartments> GetApartments()
        {
            return db.Apartments;
        }

        // GET: api/Apartments/5
        [ResponseType(typeof(Apartments))]
        public IHttpActionResult GetApartments(int id)
        {
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return NotFound();
            }

            return Ok(apartments);
        }

        // PUT: api/Apartments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartments(int id, Apartments apartments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartments.ApartmentNumber)
            {
                return BadRequest();
            }

            db.Entry(apartments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentsExists(id))
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

        // POST: api/Apartments
        [ResponseType(typeof(Apartments))]
        public IHttpActionResult PostApartments(Apartments apartments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartments.Add(apartments);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApartmentsExists(apartments.ApartmentNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartments.ApartmentNumber }, apartments);
        }

        // DELETE: api/Apartments/5
        [ResponseType(typeof(Apartments))]
        public IHttpActionResult DeleteApartments(int id)
        {
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return NotFound();
            }

            db.Apartments.Remove(apartments);
            db.SaveChanges();

            return Ok(apartments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmentsExists(int id)
        {
            return db.Apartments.Count(e => e.ApartmentNumber == id) > 0;
        }
    }
}