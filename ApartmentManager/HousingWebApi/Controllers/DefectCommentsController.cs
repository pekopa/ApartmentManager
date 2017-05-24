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
    public class DefectCommentsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/DefectComments
        public IQueryable<DefectComment> GetDefectComments()
        {
            return db.DefectComments;
        }

        // GET: api/DefectComments/5
        [ResponseType(typeof(DefectComment))]
        public IHttpActionResult GetDefectComment(int id)
        {
            DefectComment defectComment = db.DefectComments.Find(id);
            if (defectComment == null)
            {
                return NotFound();
            }

            return Ok(defectComment);
        }

        // PUT: api/DefectComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDefectComment(int id, DefectComment defectComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defectComment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(defectComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectCommentExists(id))
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

        // POST: api/DefectComments
        [ResponseType(typeof(DefectComment))]
        public IHttpActionResult PostDefectComment(DefectComment defectComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DefectComments.Add(defectComment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DefectCommentExists(defectComment.CommentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = defectComment.CommentId }, defectComment);
        }

        // DELETE: api/DefectComments/5
        [ResponseType(typeof(DefectComment))]
        public IHttpActionResult DeleteDefectComment(int id)
        {
            DefectComment defectComment = db.DefectComments.Find(id);
            if (defectComment == null)
            {
                return NotFound();
            }

            db.DefectComments.Remove(defectComment);
            db.SaveChanges();

            return Ok(defectComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefectCommentExists(int id)
        {
            return db.DefectComments.Count(e => e.CommentId == id) > 0;
        }
    }
}