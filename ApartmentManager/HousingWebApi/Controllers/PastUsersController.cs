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
    public class PastUsersController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/PastUsers
        public IQueryable<PastUser> GetPastUsers()
        {
            return db.PastUsers;
        }

        // GET: api/PastUsers/5
        [ResponseType(typeof(PastUser))]
        public IHttpActionResult GetPastUser(string id)
        {
            PastUser pastUser = db.PastUsers.Find(id);
            if (pastUser == null)
            {
                return NotFound();
            }

            return Ok(pastUser);
        }

        // PUT: api/PastUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPastUser(string id, PastUser pastUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pastUser.Username)
            {
                return BadRequest();
            }

            db.Entry(pastUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastUserExists(id))
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

        // POST: api/PastUsers
        [ResponseType(typeof(PastUser))]
        public IHttpActionResult PostPastUser(PastUser pastUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PastUsers.Add(pastUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PastUserExists(pastUser.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pastUser.Username }, pastUser);
        }

        // DELETE: api/PastUsers/5
        [ResponseType(typeof(PastUser))]
        public IHttpActionResult DeletePastUser(string id)
        {
            PastUser pastUser = db.PastUsers.Find(id);
            if (pastUser == null)
            {
                return NotFound();
            }

            db.PastUsers.Remove(pastUser);
            db.SaveChanges();

            return Ok(pastUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PastUserExists(string id)
        {
            return db.PastUsers.Count(e => e.Username == id) > 0;
        }
    }
}