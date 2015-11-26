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
using faizalNandoso.Models;

namespace faizalNandoso.Controllers
{
    public class commentsController : ApiController
    {
        private faizalNandosoContext db = new faizalNandosoContext();

        // GET: api/comments
        public IQueryable<comments> Getcomments()
        {
            return db.comments;
        }

        // GET: api/comments/5
        [ResponseType(typeof(comments))]
        public IHttpActionResult Getcomments(int id)
        {
            comments comments = db.comments.Find(id);
            if (comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        // PUT: api/comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcomments(int id, comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comments.ID)
            {
                return BadRequest();
            }

            db.Entry(comments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!commentsExists(id))
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

        // POST: api/comments
        [ResponseType(typeof(comments))]
        public IHttpActionResult Postcomments(comments comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.comments.Add(comments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comments.ID }, comments);
        }

        // DELETE: api/comments/5
        [ResponseType(typeof(comments))]
        public IHttpActionResult Deletecomments(int id)
        {
            comments comments = db.comments.Find(id);
            if (comments == null)
            {
                return NotFound();
            }

            db.comments.Remove(comments);
            db.SaveChanges();

            return Ok(comments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool commentsExists(int id)
        {
            return db.comments.Count(e => e.ID == id) > 0;
        }
    }
}