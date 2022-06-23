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
using Course2.Data;
using Course2.Models;

namespace Course2.Controllers
{
    public class EmployesController : ApiController
    {
        private Course2Context db = new Course2Context();


        //Returns all the items
        // GET: api/Employes
        public IQueryable<Employe> GetEmployes()
        {
            return db.Employes;
        }

        //returns one item (provided id)
        // GET: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult GetEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }

        [HttpPost]
        [Route("api/Employes/Email")]
        public IHttpActionResult GetEmployeByEmai([FromBody]Employe email)
        {
            var result = db.Employes.Where(e => e.Email.Contains(email.Email)).ToList();
            if(result.Count > 0)
                return Ok(result);
            return BadRequest();
        }



        // PUT: api/Employes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmploye(int id, Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employe.EmployeId)
            {
                return BadRequest();
            }

            db.Entry(employe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        // POST: api/Employes
        [ResponseType(typeof(Employe))]
        public IHttpActionResult PostEmploye(Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employes.Add(employe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employe.EmployeId }, employe);
        }

        // DELETE: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult DeleteEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeExists(int id)
        {
            return db.Employes.Count(e => e.EmployeId == id) > 0;
        }
    }
}