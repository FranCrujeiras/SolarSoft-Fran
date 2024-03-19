using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarSoft_1._0.Context;
using SolarSoft_1._0.Models;

namespace SolarSoft_1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PanelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Panels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panel>>> GetPaneles()
        {
            return await _context.Paneles.ToListAsync();
        }

        // GET: api/Panels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panel>> GetPanel(int id)
        {
            var panel = await _context.Paneles.FindAsync(id);

            if (panel == null)
            {
                return NotFound();
            }

            return panel;
        }

        // PUT: api/Panels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanel(int id, Panel panel)
        {
            if (id != panel.ID)
            {
                return BadRequest();
            }

            _context.Entry(panel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanelExists(id))
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

        // POST: api/Panels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Panel>> PostPanel(Panel panel)
        {
            _context.Paneles.Add(panel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanel", new { id = panel.ID }, panel);
        }

        // DELETE: api/Panels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanel(int id)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }

            _context.Paneles.Remove(panel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanelExists(int id)
        {
            return _context.Paneles.Any(e => e.ID == id);
        }
    }
}
