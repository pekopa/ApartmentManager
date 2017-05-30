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
    public class ChangeDocumentsController : ApiController
    {
        private DataModel db = new DataModel();

        //GET: api/ChangeDocumentsById
        [Route("api/ChangeDocumentsById/{id}")]
        public IQueryable<ChangeDocument> GetChangeDocumentsById(int id)
        {
            var documentsList = from changeDocument in db.ChangeDocuments
                               where (changeDocument.ChangeId == id)
                               select changeDocument;
            return documentsList;
        }

        // GET: api/ChangeDocuments
        public IQueryable<ChangeDocument> GetChangeDocuments()
        {
            return db.ChangeDocuments;
        }

        // GET: api/ChangeDocuments/5
        [ResponseType(typeof(ChangeDocument))]
        public IHttpActionResult GetChangeDocument(int id)
        {
            ChangeDocument changeDocument = db.ChangeDocuments.Find(id);
            if (changeDocument == null)
            {
                return NotFound();
            }

            return Ok(changeDocument);
        }

        // PUT: api/ChangeDocuments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChangeDocument(int id, ChangeDocument changeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeDocument.DocumentId)
            {
                return BadRequest();
            }

            db.Entry(changeDocument).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeDocumentExists(id))
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

        // POST: api/ChangeDocuments
        [ResponseType(typeof(ChangeDocument))]
        public IHttpActionResult PostChangeDocument(ChangeDocument changeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChangeDocuments.Add(changeDocument);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChangeDocumentExists(changeDocument.DocumentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = changeDocument.DocumentId }, changeDocument);
        }

        // DELETE: api/ChangeDocuments/5
        [ResponseType(typeof(ChangeDocument))]
        public IHttpActionResult DeleteChangeDocument(int id)
        {
            ChangeDocument changeDocument = db.ChangeDocuments.Find(id);
            if (changeDocument == null)
            {
                return NotFound();
            }

            db.ChangeDocuments.Remove(changeDocument);
            db.SaveChanges();

            return Ok(changeDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeDocumentExists(int id)
        {
            return db.ChangeDocuments.Count(e => e.DocumentId == id) > 0;
        }
    }
}