using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model_DB;

namespace WebBooking.Controllers
{
    public class IssuesController : ApiController
    {
        private dat154_18_2Entities db = new dat154_18_2Entities();

        // GET: api/Issues
        public IQueryable<Issue>  GetIssue()
        {
            //ObservableCollection < Issue >
            //db.Issue.Load();
            //return db.Issue.Local;
            return db.Issue;
        }

        // GET: api/Issues/5
        [ResponseType(typeof(Issue))]
        public IHttpActionResult GetIssue(int id)
        {
            Issue issue = db.Issue.Find(id);
            if (issue == null)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        // PUT: api/Issues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIssue(int id, Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issue.issueID)
            {
                return BadRequest();
            }

            db.Entry(issue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        // POST: api/Issues
        [ResponseType(typeof(Issue))]
        public IHttpActionResult PostIssue(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Issue.Add(issue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = issue.issueID }, issue);
        }

        // DELETE: api/Issues/5
        [ResponseType(typeof(Issue))]
        public IHttpActionResult DeleteIssue(int id)
        {
            Issue issue = db.Issue.Find(id);
            if (issue == null)
            {
                return NotFound();
            }

            db.Issue.Remove(issue);
            db.SaveChanges();

            return Ok(issue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IssueExists(int id)
        {
            return db.Issue.Count(e => e.issueID == id) > 0;
        }
    }
}