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
    public class ResidentsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/Residents
        public IQueryable<Resident> GetResidents()
        {
            return db.Residents;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Resident))]
        public IHttpActionResult GetResident(int id)
        {
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
        // GET: api/Residents/1

        //[Route("api/ApartmentResidents/{id}")]
        //[ResponseType(typeof(ResidentList))]
        //public IQueryable<ResidentList> GetResidents(int id)
        //{
        //    var roomlist = from resident in db.Residents
        //        where (resident.ApartmentNr == id)
        //        select new ResidentList
        //        {
        //            ResidentNr = resident.ResidentNr,
        //            ApartmentNr = resident.ApartmentNr,
        //            FirstName = resident.FirstName,
        //            LastName = resident.LastName,
        //            BirthDate = resident.BirthDate,
        //            Phone = resident.Phone,
        //            Email = resident.Email,
        //            Picture = resident.Picture 
        //        };
        //    return roomlist;
        //}

        // PUT: api/Residents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResident(int id, Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resident.ResidentNr)
            {
                return BadRequest();
            }

            db.Entry(resident).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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
        [ResponseType(typeof(Resident))]
        public IHttpActionResult PostResident(Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residents.Add(resident);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ResidentExists(resident.ResidentNr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = resident.ResidentNr }, resident);
        }

        // DELETE: api/Residents/5
        [ResponseType(typeof(Resident))]
        public IHttpActionResult DeleteResident(int id)
        {
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            db.Residents.Remove(resident);
            db.SaveChanges();

            return Ok(resident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidentExists(int id)
        {
            return db.Residents.Count(e => e.ResidentNr == id) > 0;
        }
    }
}