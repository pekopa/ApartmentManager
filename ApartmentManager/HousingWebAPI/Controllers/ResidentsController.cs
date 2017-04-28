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
    public class ResidentsController : ApiController
    {
        private ApartmentsDataContext db = new ApartmentsDataContext();

        // GET: api/Residents
        public IQueryable<Residents> GetResidents()
        {
            return db.Residents;
        }

        // GET: api/Residents/5
        [ResponseType(typeof(Residents))]
        public IHttpActionResult GetResidents(int id)
        {
            Residents residents = db.Residents.Find(id);
            if (residents == null)
            {
                return NotFound();
            }

            return Ok(residents);
        }

        // PUT: api/Residents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidents(int id, Residents residents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residents.ResidentNumber)
            {
                return BadRequest();
            }

            db.Entry(residents).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentsExists(id))
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

        // POST: api/Residents
        [ResponseType(typeof(Residents))]
        public IHttpActionResult PostResidents(Residents residents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residents.Add(residents);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ResidentsExists(residents.ResidentNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = residents.ResidentNumber }, residents);
        }

        // DELETE: api/Residents/5
        [ResponseType(typeof(Residents))]
        public IHttpActionResult DeleteResidents(int id)
        {
            Residents residents = db.Residents.Find(id);
            if (residents == null)
            {
                return NotFound();
            }

            db.Residents.Remove(residents);
            db.SaveChanges();

            return Ok(residents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidentsExists(int id)
        {
            return db.Residents.Count(e => e.ResidentNumber == id) > 0;
        }
    }
}