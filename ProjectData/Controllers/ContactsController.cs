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
using ProjectData.Models;


namespace ProjectData.Controllers
{
    public class ContactsController : ApiController
    {
        private ProjectDatabaseEntities db = new ProjectDatabaseEntities();

        // GET: api/Contacts
        public IQueryable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }


        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // GET: api/Contacts/removeProject/5
        [HttpGet]
        [Route("api/Contacts/RemoveProject/{ContactId}")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult SetContactToProject(int ContactId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ContactId <= 0)
            {
                return BadRequest();
            }

            Contact contact = db.Contacts.Where(a => a.Id == ContactId).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            contact.ProjectId = null;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return Ok(contact);
        }

        // GET: api/Contacts/NotProjectMember/5
        [HttpGet]
        [Route("api/Contacts/NotProjectMember/{ProjectId}")]
        public IQueryable<Contact> GetContactsNotProjectMember(int ProjectId)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            if (ProjectId == 0)
            {
                return null;
            }

            return db.Contacts.Where(a => a.ProjectId != ProjectId);
        }


        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}