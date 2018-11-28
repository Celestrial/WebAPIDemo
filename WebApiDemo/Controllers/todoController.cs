using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class todoController : ApiController
    {
        private WebApiDemoContext db = new WebApiDemoContext();

        // GET: api/todo
        public IQueryable<TODO> GetTODOes()
        {
            return db.TODOes;
        }

        // GET: api/todo/5
        [ResponseType(typeof(TODO))]
        public async Task<IHttpActionResult> GetTODO(string id)
        {
            TODO tODO = await db.TODOes.FindAsync(id);
            if (tODO == null)
            {
                return NotFound();
            }

            return Ok(tODO);
        }

        // PUT: api/todo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTODO(string id, TODO tODO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tODO.Id)
            {
                return BadRequest();
            }

            db.Entry(tODO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TODOExists(id))
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

        // POST: api/todo
        [ResponseType(typeof(TODO))]
        public async Task<IHttpActionResult> PostTODO(TODO tODO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TODOes.Add(tODO);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TODOExists(tODO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tODO.Id }, tODO);
        }

        // DELETE: api/todo/5
        [ResponseType(typeof(TODO))]
        public async Task<IHttpActionResult> DeleteTODO(string id)
        {
            TODO tODO = await db.TODOes.FindAsync(id);
            if (tODO == null)
            {
                return NotFound();
            }

            db.TODOes.Remove(tODO);
            await db.SaveChangesAsync();

            return Ok(tODO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TODOExists(string id)
        {
            return db.TODOes.Count(e => e.Id == id) > 0;
        }
    }
}