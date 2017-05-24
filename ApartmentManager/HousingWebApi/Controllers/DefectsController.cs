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
    public class DefectsController : ApiController
    {
        private DataModel db = new DataModel();

        [Route("api/ApartmentDefects/{id}")]
        public IQueryable<Defect> GetApartmentDefects(int id)
        {
            var defectlist = from defect in db.Defects
                where (defect.ApartmentId == id)
                select defect;
            return defectlist;
        }
        // GET: api/Defects
        public IQueryable<Defect> GetDefects()
        {
            return db.Defects;
        }

        // GET: api/Defects/5
        [ResponseType(typeof(Defect))]
        public IHttpActionResult GetDefect(int id)
        {
            Defect defect = db.Defects.Find(id);
            if (defect == null)
            {
                return NotFound();
            }

            return Ok(defect);
        }

        // PUT: api/Defects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDefect(int id, Defect defect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defect.DefectId)
            {
                return BadRequest();
            }

            db.Entry(defect).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.Created);
        }

        // POST: api/Defects
        [ResponseType(typeof(Defect))]
        public IHttpActionResult PostDefect(Defect defect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Defects.Add(defect);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DefectExists(defect.DefectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = defect.DefectId }, defect);
            
        }

        // DELETE: api/Defects/5
        [ResponseType(typeof(Defect))]
        public IHttpActionResult DeleteDefect(int id)
        {
            Defect defect = db.Defects.Find(id);
            if (defect == null)
            {
                return NotFound();
            }

            db.Defects.Remove(defect);
            db.SaveChanges();

            return Ok(defect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefectExists(int id)
        {
            return db.Defects.Count(e => e.DefectId == id) > 0;
        }
    }
}