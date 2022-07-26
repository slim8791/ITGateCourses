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
    public class EmployesController : ApiController
    {
        private Course3Context db = new Course3Context();

        // GET: api/Employes
        public IQueryable<Employe> GetEmployes()
        {
            return db.Employes;
        }

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
            employe.DateNaissance = DateTime.Now;
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

        [HttpGet]
        [Route("api/Employes/byaddress/{adresse}")]
        public IHttpActionResult GetEmployeByAdress([FromUri] string adresse, [FromUri] string matricule)
        {
            //var result = db.Employes.SqlQuery(string.Format("select * from Employe e , personalinfo pi where e.PersonalIfoId = pi.PersonalIfoId " +
            //    "and upper(pi.Adresse) like '{0}' and pi.matricule = {1}", adresse.ToUpper(), matricule)).ToList();

            var result = from e in db.Employes
                         join pi in db.PersonalInfoes
                         on e.PersonalIfoId equals pi.PersonalInfoId
                         where pi.Adresse.ToUpper().Equals(adresse.ToUpper()) && pi.Matricule == int.Parse(matricule)
                         select new { e.Nom, e.Prenom};


            if (result.ToList().Count == 0)
                return NotFound();
            return Ok(result);
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