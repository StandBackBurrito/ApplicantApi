using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ApplicantApi.Models;

namespace ApplicantApi.Controllers
{
    public class ApplicantsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Applicants
        public IQueryable<Applicant> GetApplicants()
        {
            return db.Applicants;
        }

        // GET: api/Applicants/5
        [ResponseType(typeof(Applicant))]
        public IHttpActionResult GetApplicant(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        // PUT: api/Applicants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicant(int id, Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicant.Id)
            {
                return BadRequest();
            }

            db.Entry(applicant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantExists(id))
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

        // POST: api/Applicants
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplicant(Application app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicant = new Applicant
            {
                FullName = app.FullName,
                Email = app.Email,
                PhoneNumber = app.PhoneNumber,
                IpAddress = HttpContext.Current.Request.UserHostAddress,
            };

            db.Applicants.Add(applicant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applicant.Id }, applicant);
        }

        // DELETE: api/Applicants/5
        [ResponseType(typeof(Applicant))]
        public IHttpActionResult DeleteApplicant(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return NotFound();
            }

            db.Applicants.Remove(applicant);
            db.SaveChanges();

            return Ok(applicant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicantExists(int id)
        {
            return db.Applicants.Count(e => e.Id == id) > 0;
        }
    }
}