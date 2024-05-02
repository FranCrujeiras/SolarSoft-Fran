using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SolarSoft_1._0.Context;
using SolarSoft_1._0.Models;

namespace SolarSoft_1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InversoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InversoresController(AppDbContext context)
        {
            _context = context;
        }

        #region GETs
        // GET: api/Inversores
        [HttpGet("GetInversor")]
        public async Task<ActionResult<IEnumerable<Inversor>>> GetInversor()
        {
            return await _context.Inversor.ToListAsync();
        }

        // GET: api/Inversores/5
        [HttpGet("GetInversor/{id}")]
        public async Task<ActionResult<Inversor>> GetInversor(int id)
        {
            var inversor = await _context.Inversor.FindAsync(id);

            if (inversor == null)
            {
                return NotFound();
            }

            return inversor;
        }
        #endregion
        #region POST
        // POST: api/Inversores
        [HttpPost("PostInversor")]
        public async Task<ActionResult<Inversor>> PostInversor(Inversor inversor)
        {
            if (inversor.ModeloInversor == "")
            {
                return BadRequest("Es necesario especificar un modelo de panel");

            }
            else if (inversor.PotenciaEntrada <= 0)
            {
                return BadRequest("La potencia de entrada debe tener un valor positivo");
            }
            else if (inversor.PotenciaSalida <= 0)
            {
                return BadRequest("La potencia de salida debe tener un valor positivo");
            }
            else if (inversor.EficienciaEuropea <= 0 || inversor.EficienciaEuropea >1)
            {
                return BadRequest("La eficiencia debe ser un valor comprendido entre 0 y 1");
            }
            else if (inversor.VoltajeMaximoMPPT <=0 || inversor.VoltajeMaximoMPPT < inversor.VoltajeMinimoMPPT)
            {
                return BadRequest("El voltaje máximo debe ser un valor positivo y mayor que el voltaje mínimo");
            }
            else if (inversor.VoltajeMinimoMPPT <=0 || inversor.VoltajeMinimoMPPT > inversor.VoltajeMaximoMPPT)
            {
                return BadRequest("El voltaje mínimo debe ser un valor positivo y menor que el voltaje máximo");
            }
            else if (inversor.NumeroMPPT < 1)
            {
                return BadRequest("El número de MPPT debe ser un valor entero positivo");
            }
            
            _context.Inversor.Add(inversor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInversor", new { id = inversor.Id }, inversor);
        }
        #endregion
        #region PUTs
        // PUT: api/Paneles/5
        [HttpPut("PutInversor/{id}")]
        public async Task<IActionResult> PutInversor(int id, Inversor Inversor)
        {
            if (id != Inversor.Id)
            {
                return BadRequest();
            }

            _context.Entry(Inversor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InversorExists(id))
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

        [HttpPut("PutPotenciaEntrada/{PotenciaEntrada}")]
        public async Task<IActionResult> PutPotenciaEntrada(int Id, int PotenciaEntrada)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (PotenciaEntrada < 1)
                {
                    return BadRequest("El valor de la potencia de entrada debe ser positivo");
                }
                else
                {
                    Inversor.PotenciaEntrada = PotenciaEntrada;

                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modificada correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaSalida/{PotenciaSalida}")]
        public async Task<IActionResult> PutPotenciaSalida(int Id, int PotenciaSalida)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (PotenciaSalida < 1)
                {
                    return BadRequest("El valor de la potencia de salida debe ser positivo");
                }
                else
                {
                    Inversor.PotenciaSalida = PotenciaSalida;
                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia de salida modifcada correctamente");
                }

            }
        }

        [HttpPut("PutVoltajeMinimoMPPT/{VoltajeMinimoMPPT}")]
        public async Task<IActionResult> PutVoltajeMinimoMPPT(int Id, int VoltajeMinimoMPPT)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (VoltajeMinimoMPPT <= 0)
                {
                    return BadRequest("El valor del voltaje mínimo debe ser un valor positivo.");
                }
                else
                {
                    Inversor.VoltajeMinimoMPPT = VoltajeMinimoMPPT;
                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del Panel modificado correctamente");
                }

            }
        }
        [HttpPut("PutVoltajeMaximoMPPT/{VoltajeMaximoMPPT}")]
        public async Task<IActionResult> PutVoltajeMaximoMPPT(int Id, double VoltajeMaximoMPPT)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (VoltajeMaximoMPPT <= 0)
                {
                    return BadRequest("El valor del Voltaje no puede ser negativo.");
                }
                else
                {
                    Inversor.VoltajeMaximoMPPT = Convert.ToInt32(VoltajeMaximoMPPT);
                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Voltaje máximo MPPT modificado correctamente");
                }

            }
        }


        [HttpPut("PutModeloInversor/{ModeloInversor}")]
        public async Task<IActionResult> PutModeloInversor(int Id, string ModeloInversor)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (ModeloInversor == "")
                {
                    return BadRequest("El Inversor debe tener un nombre.");
                }
                else
                {
                    Inversor.ModeloInversor = ModeloInversor;
                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Nombre del inversor modificado correctamene");
                }

            }
        }

        [HttpPut("PutEficienciaEuropea/{EficienciaEuropea}")]
        public async Task<IActionResult> PutEficienciaEuropea(int Id, double EficienciaEuropea)
        {
            var Inversor = await _context.Inversor.FindAsync(Id);
            if (Inversor == null)
            {
                return NotFound();
            }
            else
            {
                if (EficienciaEuropea <0 || EficienciaEuropea>1)
                {
                    return BadRequest("El valor de la eficiencia debe ser entre 0 y 1");
                }
                else
                {
                    Inversor.EficienciaEuropea = EficienciaEuropea;
                    _context.Entry(Inversor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Eficiencia europea del inversor modificada correctamente");
                }

            }
        }
        #endregion
        #region DELETE
        // DELETE: api/Inversores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInversor(int id)
        {
            var inversor = await _context.Inversor.FindAsync(id);
            if (inversor == null)
            {
                return NotFound();
            }

            _context.Inversor.Remove(inversor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InversorExists(int id)
        {
            return _context.Inversor.Any(e => e.Id == id);
        }
        #endregion
    }
}
