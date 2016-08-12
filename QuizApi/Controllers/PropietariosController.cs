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
using QuizApi.Models;

namespace QuizApi.Controllers
{
    public class PropietariosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Propietarios
        public IQueryable<Propietario> GetPropietarios()
        {
            return db.Propietarios;
        }

        // GET: api/Propietarios/5
        [ResponseType(typeof(Propietario))]
        public async Task<IHttpActionResult> GetPropietario(int id)
        {
            Propietario propietario = await db.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }

            return Ok(propietario);
        }

        // PUT: api/Propietarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropietario(int id, Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propietario.Id)
            {
                return BadRequest();
            }

            db.Entry(propietario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropietarioExists(id))
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

        // POST: api/Propietarios
        [ResponseType(typeof(Propietario))]
        public async Task<IHttpActionResult> PostPropietario(Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Propietarios.Add(propietario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = propietario.Id }, propietario);
        }

        // DELETE: api/Propietarios/5
        [ResponseType(typeof(Propietario))]
        public async Task<IHttpActionResult> DeletePropietario(int id)
        {
            Propietario propietario = await db.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }

            db.Propietarios.Remove(propietario);
            await db.SaveChangesAsync();

            return Ok(propietario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropietarioExists(int id)
        {
            return db.Propietarios.Count(e => e.Id == id) > 0;
        }
    }
}