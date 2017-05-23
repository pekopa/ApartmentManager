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
    public class DefectPicturesController : ApiController
    {
        private DataModel db = new DataModel();

        [Route("api/DefectPictures/{id}")]
        public IQueryable<DefectPicture> GetResidents(int id)
        {
            var pictureslist = from defectPicture in db.DefectPictures
                where (defectPicture.DefectId == id)
                select defectPicture;
            return pictureslist;
        }
        

        // GET: api/DefectPictures/5
        [ResponseType(typeof(DefectPicture))]
        public IHttpActionResult GetDefectPicture(int id)
        {
            DefectPicture defectPicture = db.DefectPictures.Find(id);
            if (defectPicture == null)
            {
                return NotFound();
            }

            return Ok(defectPicture);
        }

        // PUT: api/DefectPictures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDefectPicture(int id, DefectPicture defectPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defectPicture.PictureId)
            {
                return BadRequest();
            }

            db.Entry(defectPicture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectPictureExists(id))
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

        // POST: api/DefectPictures
        [ResponseType(typeof(DefectPicture))]
        public IHttpActionResult PostDefectPicture(DefectPicture defectPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DefectPictures.Add(defectPicture);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DefectPictureExists(defectPicture.PictureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = defectPicture.PictureId }, defectPicture);
        }

        // DELETE: api/DefectPictures/5
        [ResponseType(typeof(DefectPicture))]
        public IHttpActionResult DeleteDefectPicture(int id)
        {
            DefectPicture defectPicture = db.DefectPictures.Find(id);
            if (defectPicture == null)
            {
                return NotFound();
            }

            db.DefectPictures.Remove(defectPicture);
            db.SaveChanges();

            return Ok(defectPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefectPictureExists(int id)
        {
            return db.DefectPictures.Count(e => e.PictureId == id) > 0;
        }
    }
}