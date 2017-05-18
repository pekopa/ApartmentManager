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
    public class AllResidentsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/AllResidents
        public IQueryable<AllResident> GetAllResidents()
        {
            return db.AllResidents;
        }

        // GET: api/AllResidents/5
        [ResponseType(typeof(AllResident))]
        public IHttpActionResult GetAllResident(string id)
        {
            AllResident allResident = db.AllResidents.Find(id);
            if (allResident == null)
            {
                return NotFound();
            }

            return Ok(allResident);
        }

        // PUT: api/AllResidents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAllResident(string id, AllResident allResident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allResident.FirstName)
            {
                return BadRequest();
            }

            db.Entry(allResident).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllResidentExists(id))
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

        // POST: api/AllResidents
        [ResponseType(typeof(AllResident))]
        public IHttpActionResult PostAllResident(AllResident allResident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AllResidents.Add(allResident);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AllResidentExists(allResident.FirstName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = allResident.FirstName }, allResident);
        }

        // DELETE: api/AllResidents/5
        [ResponseType(typeof(AllResident))]
        public IHttpActionResult DeleteAllResident(string id)
        {
            AllResident allResident = db.AllResidents.Find(id);
            if (allResident == null)
            {
                return NotFound();
            }

            db.AllResidents.Remove(allResident);
            db.SaveChanges();

            return Ok(allResident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllResidentExists(string id)
        {
            return db.AllResidents.Count(e => e.FirstName == id) > 0;
        }
    }
}