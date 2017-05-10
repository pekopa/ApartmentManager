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
    public class ApartmentResidentsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/ApartmentResidents
        public IQueryable<ApartmentResident> GetApartmentResidents()
        {
            return db.ApartmentResidents;
        }

        // GET: api/ApartmentResidents/5
        [ResponseType(typeof(ApartmentResident))]
        public IHttpActionResult GetApartmentResident(int id)
        {
            ApartmentResident apartmentResident = db.ApartmentResidents.Find(id);
            if (apartmentResident == null)
            {
                return NotFound();
            }

            return Ok(apartmentResident);
        }

        // PUT: api/ApartmentResidents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartmentResident(int id, ApartmentResident apartmentResident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartmentResident.ApartmentNumber)
            {
                return BadRequest();
            }

            db.Entry(apartmentResident).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentResidentExists(id))
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

        // POST: api/ApartmentResidents
        [ResponseType(typeof(ApartmentResident))]
        public IHttpActionResult PostApartmentResident(ApartmentResident apartmentResident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApartmentResidents.Add(apartmentResident);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApartmentResidentExists(apartmentResident.ApartmentNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartmentResident.ApartmentNumber }, apartmentResident);
        }

        // DELETE: api/ApartmentResidents/5
        [ResponseType(typeof(ApartmentResident))]
        public IHttpActionResult DeleteApartmentResident(int id)
        {
            ApartmentResident apartmentResident = db.ApartmentResidents.Find(id);
            if (apartmentResident == null)
            {
                return NotFound();
            }

            db.ApartmentResidents.Remove(apartmentResident);
            db.SaveChanges();

            return Ok(apartmentResident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmentResidentExists(int id)
        {
            return db.ApartmentResidents.Count(e => e.ApartmentNumber == id) > 0;
        }
    }
}