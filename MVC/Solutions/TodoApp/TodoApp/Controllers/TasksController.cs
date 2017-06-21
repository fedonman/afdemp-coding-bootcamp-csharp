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
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private MyContext db = new MyContext();
        // GET: api/Tasks/email@email.com
        [Route("get/{email}/")]
        [HttpGet]
        public IHttpActionResult GetTasksOfUser(string email)
        {
            var tasks = db.Tasks.Where(x => x.User.Email == email).Select(x => new { Id = x.Id, Title = x.Title, IsCompleted = x.IsCompleted }).ToList();
            return Ok(tasks);
        }

        // PUT: api/Tasks/5
        [Route("complete/{id}/")]
        [HttpPut]
        public IHttpActionResult ToggleTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            task.IsCompleted = !task.IsCompleted;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        [Route("create/")]
        [HttpPost]
        public IHttpActionResult CreateTask([FromUri] Task task)
        {
            Console.WriteLine(task);

            db.Tasks.Add(task);
            db.SaveChanges();

            return Ok(task.Id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}