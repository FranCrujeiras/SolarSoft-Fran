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
    public class PanelesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PanelesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Paneles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panel>>> GetPanel()
        {
            return await _context.Panel.ToListAsync();
        }

        // GET: api/Paneles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panel>> GetPanel(int id)
        {
            var Panel = await _context.Panel.FindAsync(id);

            if (Panel == null)
            {
                return NotFound();
            }

            return Panel;
        }

        // PUT: api/Paneles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanel(int id, Panel Panel)
        {
            if (id != Panel.Id)
            {
                return BadRequest();
            }

            _context.Entry(Panel).State = EntityState.Modified;

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
        // PUT: api/Panels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPut("PutLargo/{Largo}")]
        public async Task<IActionResult> PutLargo(int Id, int Largo)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Largo > 10000|| Largo < 1)
                {
                    return BadRequest("El valor del largo del Panel debe ser positivo");
                }
                else
                {
                    Panel.Largo = Largo;
                  
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modificada correctamente");
                }

            }
        }
        [HttpPut("PutAncho/{Ancho}")]
        public async Task<IActionResult> PutAncho(int Id, int Ancho)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Ancho > 5000 || Ancho <1)
                {
                    return BadRequest("El valor del ancho del Panel debe ser positivo");
                }
                else
                {
                    Panel.Ancho = Ancho;
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho modifcada correctamente");
                }

            }
        }

        [HttpPut("PutPotencia/{Potencia}")]
        public async Task<IActionResult> PutPotencia(int Id, int Potencia)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Potencia <= 0)
                {
                    return BadRequest("El valor de la potencia debe ser un valor positivo.");
                }
                else
                {
                    Panel.Potencia = Potencia;
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del Panel modificado correctamente");
                }

            }
        }
        [HttpPut("PutLargoPanel/{LargoPanel}")]
        public async Task<IActionResult> PutVoltaje(int Id, double Voltaje)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Voltaje <= 0)
                {
                    return BadRequest("El valor del Voltaje no puede ser negativo.");
                }
                else
                {
                    Panel.Voltaje = Voltaje;
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Largo del Panel modifcado correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaPanel/{PotenciaPanel}")]
        public async Task<IActionResult> PutNombreModelo(int Id, string NombreModelo)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (NombreModelo == "")
                {
                    return BadRequest("El Panel debe tener un nombre.");
                }
                else
                {
                    Panel.NombreModelo = NombreModelo;
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia del Panel modificada correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaPanel/{PotenciaPanel}")]
        public async Task<IActionResult> PutMaterial(int Id, string Material)
        {
            var Panel = await _context.Panel.FindAsync(Id);
            if (Panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Material == "")
                {
                    return BadRequest("Es necesario especificar el tipo de material del panel");
                }
                else
                {
                    Panel.Material = Material;
                    _context.Entry(Panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia del Panel modificada correctamente");
                }

            }
        }

        // POST: api/Paneles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Panel>> PostPanel(Panel Panel)
        {
            _context.Panel.Add(Panel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanel", new { id = Panel.Id }, Panel);
        }

        // DELETE: api/Paneles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanel(int id)
        {
            var Panel = await _context.Panel.FindAsync(id);
            if (Panel == null)
            {
                return NotFound();
            }

            _context.Panel.Remove(Panel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanelExists(int id)
        {
            return _context.Panel.Any(e => e.Id == id);
        }
    }
}
