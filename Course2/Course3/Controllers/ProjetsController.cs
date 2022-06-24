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
using Course3.Data;
using Course3.Models;

namespace Course3.Controllers
{
    public class ProjetsController : ApiController
    {
        private Course3Context db = new Course3Context();

        // GET: api/Projets
        public IQueryable<Projet> GetProjets()
        {
            return db.Projets;
        }

        // GET: api/Projets/5
        [ResponseType(typeof(Projet))]
        public IHttpActionResult GetProjet(int id)
        {
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return NotFound();
            }

            return Ok(projet);
        }

        // PUT: api/Projets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjet(int id, Projet projet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projet.ProjetId)
            {
                return BadRequest();
            }

            db.Entry(projet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetExists(id))
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

        // POST: api/Projets
        [ResponseType(typeof(Projet))]
        public IHttpActionResult PostProjet(Projet projet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projets.Add(projet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projet.ProjetId }, projet);
        }

        // DELETE: api/Projets/5
        [ResponseType(typeof(Projet))]
        public IHttpActionResult DeleteProjet(int id)
        {
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return NotFound();
            }

            db.Projets.Remove(projet);
            db.SaveChanges();

            return Ok(projet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjetExists(int id)
        {
            return db.Projets.Count(e => e.ProjetId == id) > 0;
        }
    }
}