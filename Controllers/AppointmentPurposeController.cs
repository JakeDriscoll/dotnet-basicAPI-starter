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
    public class AppointmentPurposeController : ControllerBase
    {
        private readonly AppointmentPurposeContext _context;

        public AppointmentPurposeController(AppointmentPurposeContext context)
        {
            _context = context;
        }

        // GET: api/AppointmentPurpose
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentPurpose>>> GetAppointmentPurposes()
        {
          if (_context.AppointmentPurposes == null)
          {
              return NotFound();
          }
            return await _context.AppointmentPurposes.ToListAsync();
        }

        // GET: api/AppointmentPurpose/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentPurpose>> GetAppointmentPurpose(long id)
        {
          if (_context.AppointmentPurposes == null)
          {
              return NotFound();
          }
            var appointmentPurpose = await _context.AppointmentPurposes.FindAsync(id);

            if (appointmentPurpose == null)
            {
                return NotFound();
            }

            return appointmentPurpose;
        }

        // PUT: api/AppointmentPurpose/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentPurpose(long id, AppointmentPurpose appointmentPurpose)
        {
            if (id != appointmentPurpose.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointmentPurpose).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentPurposeExists(id))
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

        // POST: api/AppointmentPurpose
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentPurpose>> PostAppointmentPurpose(AppointmentPurpose appointmentPurpose)
        {
          if (_context.AppointmentPurposes == null)
          {
              return Problem("Entity set 'AppointmentPurposeContext.AppointmentPurposes'  is null.");
          }
            _context.AppointmentPurposes.Add(appointmentPurpose);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentPurpose", new { id = appointmentPurpose.Id }, appointmentPurpose);
        }

        // DELETE: api/AppointmentPurpose/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentPurpose(long id)
        {
            if (_context.AppointmentPurposes == null)
            {
                return NotFound();
            }
            var appointmentPurpose = await _context.AppointmentPurposes.FindAsync(id);
            if (appointmentPurpose == null)
            {
                return NotFound();
            }

            _context.AppointmentPurposes.Remove(appointmentPurpose);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentPurposeExists(long id)
        {
            return (_context.AppointmentPurposes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
