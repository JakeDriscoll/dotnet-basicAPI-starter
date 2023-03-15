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
    public class PracticeSettingController : ControllerBase
    {
        private readonly PracticeSettingContext _context;

        public PracticeSettingController(PracticeSettingContext context)
        {
            _context = context;
        }

        // GET: api/PracticeSetting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeSetting>>> GetPracticeSettings()
        {
          if (_context.PracticeSettings == null)
          {
              return NotFound();
          }
            return await _context.PracticeSettings.ToListAsync();
        }

        // GET: api/PracticeSetting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeSetting>> GetPracticeSetting(long id)
        {
          if (_context.PracticeSettings == null)
          {
              return NotFound();
          }
            var practiceSetting = await _context.PracticeSettings.FindAsync(id);

            if (practiceSetting == null)
            {
                return NotFound();
            }

            return practiceSetting;
        }

        // PUT: api/PracticeSetting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracticeSetting(long id, PracticeSetting practiceSetting)
        {
            if (id != practiceSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(practiceSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticeSettingExists(id))
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

        // POST: api/PracticeSetting
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PracticeSetting>> PostPracticeSetting(PracticeSetting practiceSetting)
        {
          if (_context.PracticeSettings == null)
          {
              return Problem("Entity set 'PracticeSettingContext.PracticeSettings'  is null.");
          }
            _context.PracticeSettings.Add(practiceSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPracticeSetting", new { id = practiceSetting.Id }, practiceSetting);
        }

        // DELETE: api/PracticeSetting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracticeSetting(long id)
        {
            if (_context.PracticeSettings == null)
            {
                return NotFound();
            }
            var practiceSetting = await _context.PracticeSettings.FindAsync(id);
            if (practiceSetting == null)
            {
                return NotFound();
            }

            _context.PracticeSettings.Remove(practiceSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracticeSettingExists(long id)
        {
            return (_context.PracticeSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
