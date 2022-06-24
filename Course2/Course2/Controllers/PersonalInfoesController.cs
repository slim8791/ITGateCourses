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
    public class PersonalInfoesController : ApiController
    {
        private Course2Context db = new Course2Context();

        // GET: api/PersonalInfoes
        public IQueryable<PersonalInfo> GetPersonalInfoes()
        {
            return db.PersonalInfoes;
        }

        // GET: api/PersonalInfoes/5
        [ResponseType(typeof(PersonalInfo))]
        public IHttpActionResult GetPersonalInfo(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfoes.Find(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            return Ok(personalInfo);
        }

        // PUT: api/PersonalInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalInfo(int id, PersonalInfo personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalInfo.PersonalInfoId)
            {
                return BadRequest();
            }

            db.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        // POST: api/PersonalInfoes
        [ResponseType(typeof(PersonalInfo))]
        public IHttpActionResult PostPersonalInfo(PersonalInfo personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalInfoes.Add(personalInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonalInfoExists(personalInfo.PersonalInfoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personalInfo.PersonalInfoId }, personalInfo);
        }

        // DELETE: api/PersonalInfoes/5
        [ResponseType(typeof(PersonalInfo))]
        public IHttpActionResult DeletePersonalInfo(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfoes.Find(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            db.PersonalInfoes.Remove(personalInfo);
            db.SaveChanges();

            return Ok(personalInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalInfoExists(int id)
        {
            return db.PersonalInfoes.Count(e => e.PersonalInfoId == id) > 0;
        }
    }
}