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
    public class ChangeCommentsController : ApiController
    {
        private DataModel db = new DataModel();

        //GET: api/ChangeCommentsById
        [Route("api/ChangeCommentsById/{id}")]
        public IQueryable<ChangeComment> GetChangeCommentsById(int id)
        {
            var commentsList = from changeComment in db.ChangeComments
                                where (changeComment.ChangeId == id)
                orderby changeComment.CommentId descending
                
                                select changeComment;
            return commentsList;
        }

        // GET: api/ChangeComments
        public IQueryable<ChangeComment> GetChangeComments()
        {
            return db.ChangeComments;
        }

        // GET: api/ChangeComments/5
        [ResponseType(typeof(ChangeComment))]
        public IHttpActionResult GetChangeComment(int id)
        {
            ChangeComment changeComment = db.ChangeComments.Find(id);
            if (changeComment == null)
            {
                return NotFound();
            }

            return Ok(changeComment);
        }

        // PUT: api/ChangeComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChangeComment(int id, ChangeComment changeComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeComment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(changeComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeCommentExists(id))
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

        // POST: api/ChangeComments
        [ResponseType(typeof(ChangeComment))]
        public IHttpActionResult PostChangeComment(ChangeComment changeComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChangeComments.Add(changeComment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChangeCommentExists(changeComment.CommentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = changeComment.CommentId }, changeComment);
        }

        // DELETE: api/ChangeComments/5
        [ResponseType(typeof(ChangeComment))]
        public IHttpActionResult DeleteChangeComment(int id)
        {
            ChangeComment changeComment = db.ChangeComments.Find(id);
            if (changeComment == null)
            {
                return NotFound();
            }

            db.ChangeComments.Remove(changeComment);
            db.SaveChanges();

            return Ok(changeComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeCommentExists(int id)
        {
            return db.ChangeComments.Count(e => e.CommentId == id) > 0;
        }
    }
}