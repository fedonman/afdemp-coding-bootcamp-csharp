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
        
        // GET: api/tasks/get/email@email.com
        [Route("get/{email}/")]
        [HttpGet]
        public IHttpActionResult GetTasksOfUser(string email)
        {
            var tasks = db.Tasks.Where(x => x.User.Email == email).Select(x => new { Id = x.Id, Title = x.Title, IsCompleted = x.IsCompleted }).ToList();
            return Ok(tasks);
        }

        // POST: api/tasks/complete/5
        [Route("complete/{id}/")]
        [HttpPost]
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

        // POST: api/tasks/delete/5
        [Route("delete/{id}/")]
        [HttpPost]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            db.Entry(task).State = EntityState.Deleted;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tasks/create/?Title=read source code&UserEmail=fedonman@gmail.com&IsCompleted=false
        [ResponseType(typeof(Task))]
        [Route("create/")]
        [HttpPost]
        public IHttpActionResult CreateTask([FromUri] Task task)
        {
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