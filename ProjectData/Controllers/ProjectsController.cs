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
    public class ProjectsController : ApiController
    {
        private ProjectDatabaseEntities db = new ProjectDatabaseEntities();

        // GET: api/Projects
        public IQueryable<Project> GetProjects()
        {
            return db.Projects;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // GET: api/Projects/5/Contacts
        [Route("api/Projects/{ProjectId}/Contacts")]
        public IQueryable<Contact> GetProjectContact(int ProjectId)
        {
            var allContacts = db.Contacts.Where(a => a.ProjectId == ProjectId);
            if (allContacts == null || !allContacts.Any())
            {
                return null;
            }

            return allContacts;
        }

        // GET: api/Projects/5/Contacts/3
        [HttpGet]
        [Route("api/Projects/{ProjectId}/Contacts/{ContactId}")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult SetProjectContact(int ProjectId, int ContactId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ProjectId == 0 || ContactId == 0)
            {
                return BadRequest();
            }

            Contact contact = db.Contacts.Where(a => a.Id == ContactId).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            if (!ProjectExists(ProjectId))
            {
                return NotFound();
            }

            contact.ProjectId = ProjectId;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return Ok(contact);
        }


        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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


        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}