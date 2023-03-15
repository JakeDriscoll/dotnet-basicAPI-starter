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
    public class BasicSettingController : ControllerBase
    {
        private readonly BasicSettingContext _context;

        public BasicSettingController(BasicSettingContext context)
        {
            _context = context;
        }

        // GET: api/BasicSetting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicSetting>>> GetBasicSettings()
        {
          if (_context.BasicSettings == null)
          {
              return NotFound();
          }
            return await _context.BasicSettings.ToListAsync();
        }

        // GET: api/BasicSetting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicSetting>> GetBasicSetting(long id)
        {
          if (_context.BasicSettings == null)
          {
              return NotFound();
          }
            var basicSetting = await _context.BasicSettings.FindAsync(id);

            if (basicSetting == null)
            {
                return NotFound();
            }

            return basicSetting;
        }

        // PUT: api/BasicSetting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicSetting(long id, BasicSetting basicSetting)
        {
            if (id != basicSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicSettingExists(id))
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

        // POST: api/BasicSetting
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicSetting>> PostBasicSetting(BasicSetting basicSetting)
        {
          if (_context.BasicSettings == null)
          {
              return Problem("Entity set 'BasicSettingContext.BasicSettings'  is null.");
          }
            _context.BasicSettings.Add(basicSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicSetting", new { id = basicSetting.Id }, basicSetting);
        }

        // DELETE: api/BasicSetting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicSetting(long id)
        {
            if (_context.BasicSettings == null)
            {
                return NotFound();
            }
            var basicSetting = await _context.BasicSettings.FindAsync(id);
            if (basicSetting == null)
            {
                return NotFound();
            }

            _context.BasicSettings.Remove(basicSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasicSettingExists(long id)
        {
            return (_context.BasicSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
