using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        [HttpPut("{id}/{latitud}")]
        public async Task<IActionResult> PutLatitud(int id, double latitud)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (latitud >90 || latitud < -90) 
                {
                    return BadRequest("El valor de la latitud debe ser entre -90º y 90º.");
                }
                else
                {
                    panel.LATITUD = latitud;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modifcada correctamente");
                }
                
            }
        }
        [HttpPut("{id}/{longitud}")]
        public async Task<IActionResult> PutLongitud(int id, double longitud)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (longitud > 180 || longitud < -180)
                {
                    return BadRequest("El valor de la latitud debe ser entre -180º y 180º.");
                }
                else
                {
                    panel.LONGITUD = longitud;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Longitud modifcada correctamente");
                }

            }
        }
        [HttpPut("{id}/{largopanel}")]
        public async Task<IActionResult> PutLargopanel(int id, double largopanel)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (largopanel > 5 || largopanel <= 0)
                {
                    return BadRequest("El valor de la longitud el panel debe ser entre 0 y 5 metros.");
                }
                else
                {
                    panel.LONGITUDPANEL = largopanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Longitud del panel modifcada correctamente");
                }

            }
        }
        [HttpPut("{id}/{anchopanel}")]
        public async Task<IActionResult> PutAnchopanel(int id, double anchopanel)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (anchopanel > 5 || anchopanel <= 0)
                {
                    return BadRequest("El valor del ancho del panel debe ser entre 0 y 5 metros.");
                }
                else
                {
                    panel.ANCHOPANEL = anchopanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del panel modifcado correctamente");
                }

            }
        }
        [HttpPut("{id}/{largoterreno}")]
        public async Task<IActionResult> PutLargoterreno(int id, double largoterreno)
        {
            var panel = await _context.Paneles.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (largoterreno <= 0)
                {
                    return BadRequest("El valor del largo del terreno no puede ser negativo.");
                }
                else
                {
                    panel.ANCHOPANEL = largoterreno;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Largo del terreno modifcado correctamente");
                }

            }
        }

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
