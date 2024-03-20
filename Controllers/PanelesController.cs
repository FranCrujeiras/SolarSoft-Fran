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
    public class PanelesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PanelesController(AppDbContext context)
        {
            _context = context;
        }

        #region POSTs

        // POST: api/Panels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPost("PostPanel")]
        public async Task<ActionResult<Panel>> PostPanel(Panel panel)
        {


            _context.Paneles.Add(panel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanel", new { Id = panel.Id }, panel);
        }
        #endregion

        #region GETs
        // GET: api/Panels
        [HttpGet("GetPanel")]
        public async Task<ActionResult<IEnumerable<Panel>>> GetPaneles()
        {
            return await _context.Paneles.ToListAsync();
        }       

        // GET: api/Panels/5
        [HttpGet("GetId/{Id}")]
        public async Task<ActionResult<Panel>> GetPanel(int Id)
        {
            var panel = await _context.Paneles.FindAsync(Id);

            if (panel == null)
            {
                return NotFound();
            }

            return panel;
        }        

        [HttpGet("getModelos/{ModeloPanel}")]
        public async Task<ActionResult<IEnumerable<Panel>>> GetPanel(string ModeloPanel)
        {
            var coincIdencias = await _context.Paneles.Where(x => x.ModeloPanel.Equals(ModeloPanel)).ToListAsync();

            if (coincIdencias.Count > 0)
            {
                return Ok(coincIdencias);
            }
            else
            {
                return NotFound("No hay ningún panel del modelo indicado");

            }

        }
        [HttpGet("getEstructura/{Estructura}")]
        public async Task<ActionResult<IEnumerable<Panel>>> GetEstructura(int Estructura)
        {
            var coincIdencias = await _context.Paneles.Where(x => x.AnguloEstructura.Equals(Estructura)).ToListAsync();

            if (coincIdencias.Count > 0)
            {
                return Ok(coincIdencias);
            }
            else
            {
                return NotFound("No hay ninguna instalación con la estructura seleccionada");

            }

        }

        #endregion

        #region PUTs

        // PUT: api/Panels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPut("PutLatitud/{Latitud}")]
        public async Task<IActionResult> PutLatitud(int Id, double Latitud)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Latitud >90 || Latitud < -90) 
                {
                    return BadRequest("El valor de la Latitud debe ser entre -90º y 90º.");
                }
                else
                {
                    panel.Latitud = Latitud;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modifcada correctamente");
                }
                
            }
        }
        [HttpPut("PutLongitud/{Longitud}")]
        public async Task<IActionResult> PutLongitud(int Id, double Longitud)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (Longitud > 180 || Longitud < -180)
                {
                    return BadRequest("El valor de la Latitud debe ser entre -180º y 180º.");
                }
                else
                {
                    panel.Longitud = Longitud;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Longitud modifcada correctamente");
                }

            }
        }
        [HttpPut("PutModeloPanel/{ModeloPanel}")]
        public async Task<IActionResult> PutModeloPanel(int Id, string ModeloPanel)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (ModeloPanel == "")
                {
                    return BadRequest("El modelo debe tener un nombre.");
                }
                else
                {
                    panel.ModeloPanel = ModeloPanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Nombre del modelo modificado correctamente");
                }

            }
        }
        [HttpPut("PutLargoPanel/{LargoPanel}")]
        public async Task<IActionResult> PutLargoPanel(int Id, double LargoPanel)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (LargoPanel > 5 || LargoPanel <= 0)
                {
                    return BadRequest("El valor de la Longitud el panel debe ser entre 0 y 5 metros.");
                }
                else
                {
                    panel.LongitudPanel = LargoPanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Longitud del panel modifcada correctamente");
                }

            }
        }
        [HttpPut("PutAnchoPanel/{AnchoPanel}")]
        public async Task<IActionResult> PutAnchoPanel(int Id, double AnchoPanel)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (AnchoPanel > 5 || AnchoPanel <= 0)
                {
                    return BadRequest("El valor del ancho del panel debe ser entre 0 y 5 metros.");
                }
                else
                {
                    panel.AnchoPanel = AnchoPanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del panel modifcado correctamente");
                }

            }
        }
        [HttpPut("PutAnchoTerreno/{AnchoTerreno}")]
        public async Task<IActionResult> PutAnchoTerreno(int Id, double AnchoTerreno)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (AnchoTerreno <= 0 )
                {
                    return BadRequest("El valor del ancho del terreno debe ser entre un valor positivo.");
                }
                else
                {
                    panel.AnchoTerreno = AnchoTerreno;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del terreno modifcado correctamente");
                }

            }
        }
            [HttpPut("PutLargoTerreno/{LargoTerreno}")]
        public async Task<IActionResult> PutLargoTerreno(int Id, double LargoTerreno)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (LargoTerreno <= 0)
                {
                    return BadRequest("El valor del largo del terreno no puede ser negativo.");
                }
                else
                {
                    panel.LargoTerreno = LargoTerreno;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Largo del terreno modifcado correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaPanel/{PotenciaPanel}")]
        public async Task<IActionResult> PutPotenciaPanel(int Id, int PotenciaPanel)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (PotenciaPanel <= 0)
                {
                    return BadRequest("El valor de la Potencia no puede ser negativo.");
                }
                else
                {
                    panel.Potencia = PotenciaPanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia del panel modificada correctamente");
                }

            }
        }
        [HttpPut("PutAnguloEstructura/{AnguloEstructura}")]
        public async Task<IActionResult> PutAnguloEstructura(int Id, int AnguloEstructura)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (AnguloEstructura != 0 ^ AnguloEstructura !=15 ^ AnguloEstructura!= 30)
                {
                    return BadRequest("El valor del ángulo de la estructura debe ser 0º, 15º o 30º.");
                }
                else
                {
                    panel.AnguloEstructura = AnguloEstructura;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ángulo de la estructura modificado correctamente");
                }

            }
        }
        [HttpPut("PutVoltajePanel/{VoltajePanel}")]
        public async Task<IActionResult> PutVoltajePanel(int Id, double VoltajePanel)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                if (VoltajePanel <= 0)
                {
                    return BadRequest("El valor del Voltaje no puede ser negativo.");
                }
                else
                {
                    panel.Voltaje = VoltajePanel;
                    _context.Entry(panel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Voltaje del panel modificado correctamente");
                }

            }
        }

        #endregion

        #region DELETEs
        // DELETE: api/Panels/5
        [HttpDelete("DeleteId/{Id}")]
        public async Task<IActionResult> DeletePanel(int Id)
        {
            var panel = await _context.Paneles.FindAsync(Id);
            if (panel == null)
            {
                return NotFound();
            }

            _context.Paneles.Remove(panel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanelExists(int Id)
        {
            return _context.Paneles.Any(e => e.Id == Id);
        }
        #endregion
    }
}
