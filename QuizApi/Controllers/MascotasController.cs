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
    public class MascotasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Mascotas
        public IQueryable<Mascota> GetMascotas()
        {
            return db.Mascotas;
        }

        // GET: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> GetMascota(int id)
        {
            Mascota mascota = await db.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            return Ok(mascota);
        }

        // PUT: api/Mascotas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMascota(int id, Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mascota.Id)
            {
                return BadRequest();
            }

            db.Entry(mascota).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
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

        // POST: api/Mascotas
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> PostMascota(Mascota mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mascotas.Add(mascota);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mascota.Id }, mascota);
        }

        // DELETE: api/Mascotas/5
        [ResponseType(typeof(Mascota))]
        public async Task<IHttpActionResult> DeleteMascota(int id)
        {
            Mascota mascota = await db.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            db.Mascotas.Remove(mascota);
            await db.SaveChangesAsync();

            return Ok(mascota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MascotaExists(int id)
        {
            return db.Mascotas.Count(e => e.Id == id) > 0;
        }
    }
}