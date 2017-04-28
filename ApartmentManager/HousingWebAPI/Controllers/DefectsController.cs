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
    public class DefectsController : ApiController
    {
        private ApartmentsDataContext db = new ApartmentsDataContext();

        // GET: api/Defects
        public IQueryable<Defects> GetDefects()
        {
            return db.Defects;
        }

        // GET: api/Defects/5
        [ResponseType(typeof(Defects))]
        public IHttpActionResult GetDefects(int id)
        {
            Defects defects = db.Defects.Find(id);
            if (defects == null)
            {
                return NotFound();
            }

            return Ok(defects);
        }

        // PUT: api/Defects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDefects(int id, Defects defects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defects.DefectNumber)
            {
                return BadRequest();
            }

            db.Entry(defects).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectsExists(id))
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

        // POST: api/Defects
        [ResponseType(typeof(Defects))]
        public IHttpActionResult PostDefects(Defects defects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Defects.Add(defects);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DefectsExists(defects.DefectNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = defects.DefectNumber }, defects);
        }

        // DELETE: api/Defects/5
        [ResponseType(typeof(Defects))]
        public IHttpActionResult DeleteDefects(int id)
        {
            Defects defects = db.Defects.Find(id);
            if (defects == null)
            {
                return NotFound();
            }

            db.Defects.Remove(defects);
            db.SaveChanges();

            return Ok(defects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefectsExists(int id)
        {
            return db.Defects.Count(e => e.DefectNumber == id) > 0;
        }
    }
}