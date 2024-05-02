﻿using System;
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
    public class BateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BateriasController(AppDbContext context)
        {
            _context = context;
        }
        #region GETs
        // GET: api/Baterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bateria>>> GetBateria()
        {
            return await _context.Bateria.ToListAsync();
        }

        // GET: api/Baterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bateria>> GetBateria(int id)
        {
            var bateria = await _context.Bateria.FindAsync(id);

            if (bateria == null)
            {
                return NotFound();
            }

            return bateria;
        }
        #endregion
        #region POST
        // POST: api/Baterias
        [HttpPost("PostBateria")]
        public async Task<ActionResult<Bateria>> PostBateria(Bateria bateria)
        {
            if (bateria.ModeloBateria == "")
            {
                return BadRequest("Es necesario especificar un nombre para el modelo");
            }
            else if (bateria.Capacidad <= 0)
            {
                return BadRequest("La capacidad debe tener un valor positivo");
            }
            else if (bateria.PotenciaSalida <= 0)
            {
                return BadRequest("La potencia de salida debe tener un valor positivo");
            }
            else if (bateria.Modulos < 1 )
            {
                return BadRequest("El número de módulos no puede ser menor que 1");
            }
            else if (bateria.VoltajeNominal <= 0)
            {
                return BadRequest("El voltaje debe ser un valor positivo");
            }

            _context.Bateria.Add(bateria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBateria", new { id = bateria.Id }, bateria);
        }
        #endregion
        #region PUTs
        // PUT: api/Baterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBateria(int id, Bateria bateria)
        {
            if (id != bateria.Id)
            {
                return BadRequest();
            }

            _context.Entry(bateria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BateriaExists(id))
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

        [HttpPut("PutModeloBateria/{ModeloBateria}")]
        public async Task<IActionResult> PutModeloBateria(int Id, string ModeloBateria)
        {
            var Bateria = await _context.Bateria.FindAsync(Id);
            if (Bateria == null)
            {
                return NotFound();
            }
            else
            {
                if (ModeloBateria == "")
                {
                    return BadRequest("El modelo de la Bateria debe tener un nombre.");
                }
                else
                {
                    Bateria.ModeloBateria = ModeloBateria;
                    _context.Entry(Bateria).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Nombre del modelo de batería modificado correctamene");
                }

            }
        }

        [HttpPut("PutCapacidad/{Capacidad}")]
        public async Task<IActionResult> PutCapacidad(int Id, int Capacidad)
        {
            var Bateria = await _context.Bateria.FindAsync(Id);
            if (Bateria == null)
            {
                return NotFound();
            }
            else
            {
                if (Capacidad < 1)
                {
                    return BadRequest("El valor de la capacidad debe ser positivo");
                }
                else
                {
                    Bateria.Capacidad = Capacidad;

                    _context.Entry(Bateria).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modificada correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaSalida/{PotenciaSalida}")]
        public async Task<IActionResult> PutPotenciaSalida(int Id, int PotenciaSalida)
        {
            var Bateria = await _context.Bateria.FindAsync(Id);
            if (Bateria == null)
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
                    Bateria.PotenciaSalida = PotenciaSalida;
                    _context.Entry(Bateria).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia de salida modificada correctamente");
                }

            }
        }

        [HttpPut("PutModulos/{Modulos}")]
        public async Task<IActionResult> PutModulos(int Id, int Modulos)
        {
            var Bateria = await _context.Bateria.FindAsync(Id);
            if (Bateria == null)
            {
                return NotFound();
            }
            else
            {
                if (Modulos <= 0)
                {
                    return BadRequest("El número de módulos debe ser un valor entero y positivo");
                }
                else
                {
                    Bateria.Modulos = Modulos;
                    _context.Entry(Bateria).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Número de módulos modificado correctamente");
                }

            }
        }
        [HttpPut("PutVoltajeNominal/{VoltajeNominal}")]
        public async Task<IActionResult> PutVoltajeNominal(int Id, int VoltajeNominal)
        {
            var Bateria = await _context.Bateria.FindAsync(Id);
            if (Bateria == null)
            {
                return NotFound();
            }
            else
            {
                if (VoltajeNominal <= 0)
                {
                    return BadRequest("El valor del Voltaje no puede ser negativo.");
                }
                else
                {
                    Bateria.VoltajeNominal = Convert.ToInt32(VoltajeNominal);
                    _context.Entry(Bateria).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Voltaje nominal modificado correctamente");
                }

            }
        }




        #endregion
        #region DELETE
        // DELETE: api/Baterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBateria(int id)
        {
            var bateria = await _context.Bateria.FindAsync(id);
            if (bateria == null)
            {
                return NotFound();
            }

            _context.Bateria.Remove(bateria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BateriaExists(int id)
        {
            return _context.Bateria.Any(e => e.Id == id);
        }
        #endregion
    }
}
