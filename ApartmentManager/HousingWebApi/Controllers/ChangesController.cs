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
    public class ChangesController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/Changes
        public IQueryable<Change> GetChanges()
        {
            return db.Changes;
        }

        // GET: api/Changes/5
        [ResponseType(typeof(Change))]
        public IHttpActionResult GetChange(int id)
        {
            Change change = db.Changes.Find(id);
            if (change == null)
            {
                return NotFound();
            }

            return Ok(change);
        }

        [Route("api/ChangesByApartmentId/{id}")]
        public IQueryable<Change> GetChangesByApartmentId(int id)
        {
            var changesList = from change in db.Changes
                              where (change.ApartmentId == id)
                              orderby change.ChangeId descending
                              select change;
            return changesList;
        }

        // PUT: api/Changes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChange(int id, Change change)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != change.ChangeId)
            {
                return BadRequest();
            }

            db.Entry(change).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeExists(id))
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

        // POST: api/Changes
        [ResponseType(typeof(Change))]
        public IHttpActionResult PostChange(Change change)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Changes.Add(change);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = change.ChangeId }, change);
        }

        // DELETE: api/Changes/5
        [ResponseType(typeof(Change))]
        public IHttpActionResult DeleteChange(int id)
        {
            Change change = db.Changes.Find(id);
            if (change == null)
            {
                return NotFound();
            }

            db.Changes.Remove(change);
            db.SaveChanges();

            return Ok(change);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeExists(int id)
        {
            return db.Changes.Count(e => e.ChangeId == id) > 0;
        }
    }
}