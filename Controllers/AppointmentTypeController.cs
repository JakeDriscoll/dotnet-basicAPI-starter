using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using basicAPI.Models;

namespace basicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly AppointmentTypeContext _context;

        public AppointmentTypeController(AppointmentTypeContext context)
        {
            _context = context;
        }

        // GET: api/AppointmentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentType>>> GetAppointmentTypes()
        {
          if (_context.AppointmentTypes == null)
          {
              return NotFound();
          }
            return await _context.AppointmentTypes.ToListAsync();
        }

        // GET: api/AppointmentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentType>> GetAppointmentType(long id)
        {
          if (_context.AppointmentTypes == null)
          {
              return NotFound();
          }
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);

            if (appointmentType == null)
            {
                return NotFound();
            }

            return appointmentType;
        }

        // PUT: api/AppointmentType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentType(long id, AppointmentType appointmentType)
        {
            if (id != appointmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppointmentType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentType appointmentType)
        {
          if (_context.AppointmentTypes == null)
          {
              return Problem("Entity set 'AppointmentTypeContext.AppointmentTypes'  is null.");
          }
            _context.AppointmentTypes.Add(appointmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentType", new { id = appointmentType.Id }, appointmentType);
        }

        // DELETE: api/AppointmentType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(long id)
        {
            if (_context.AppointmentTypes == null)
            {
                return NotFound();
            }
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentTypeExists(long id)
        {
            return (_context.AppointmentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
