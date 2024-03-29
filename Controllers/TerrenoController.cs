﻿using System;
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
    public class TerrenoController : ControllerBase
    {
        private readonly AppDbContext _context;

        private Dictionary<string, string> ModelosPanel = new Dictionary<string, string>()

        {
            {"Canadian Solar - HiKu7","2278x1134" },
            {"JA Solar - Deep Blue 3.0","1722x1134" },
            {"Jinko Solar - Tiger NEO","2465x1134" },
            {"Trina Solar - Vertex S","1762x1134" },
            {"Trina Solar - Vertex","2382x1134" }
        };

        public TerrenoController(AppDbContext context)
        {
            _context = context;
        }

        #region POSTs

        //En la definición de las request, modifica los nombres que contengan ...Panel... por ...Terreno...
        //Así a futuro, no lleva a confusión al consumir las request en el front

        // POST: api/Panels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPost("PostTerreno")]
        public async Task<ActionResult<Terreno>> PostTerreno(Terreno terreno)
        {
            //El objeto terreno que se pasa como parámetro, tiene todos los campos
            //Por eso te decía ayer que no tuvieras miedo a pasar cuantos parámetros necesites a las funciones de cálculo,
            //ya que todo va a salir de aquí
            //Te dejo preparado este ejemplo con la latitud, tendrías que ver qué umbrales no puede pasar simplemente

            //Chuleta rápida de comprobaciones:
            // || -> Significa ó. Es decir, si esta latitud es menor a tal, Ó si esta latitud es mayor a tal, no guardes, que has metido mal los datos
            // && -> Significa Y. Es decir, si esta latitud es menor a tal, Y si esta latitud es mayor a tal, no guardes, se deben cumplir las dos premisas
            if (terreno.Latitud > 90 || terreno.Latitud < -90)
            {
                return BadRequest("La latitud debe tener un valor entre -90º y 90º");
            }
            else if (terreno.Longitud > 180 || terreno.Longitud < -180)
            {
                return BadRequest("La longitud debe tener un valor entre -180º y 180º");
            }
            else if (terreno.LargoTerreno <= 0 || terreno.AnchoTerreno <=0)
            {
                return BadRequest("Las dimensiones del terreno deben tener un valor positivo");
            }
            else if (!ModelosPanel.Any(x => x.Key.Equals(terreno.ModeloPanel)))
            {
                return BadRequest("El modelo de panel introducido no existe");
            }
            else if (terreno.AnguloEstructura != 0 && terreno.AnguloEstructura != 15 && terreno.AnguloEstructura != 30) //Tienes razón!            
            {
                return BadRequest("El ángulo de la estructura debe ser de 0º, 15º o 30º");
            }
            else if (terreno.Voltaje <= 0)
            {
                return BadRequest("El voltaje debe tener un valor positivo");
            }
            else
            {
                terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                _context.Terrenos.Add(terreno);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTerreno", new { Id = terreno.Id }, terreno);
            }                    
            
        }

        #endregion

        #region GETs
        // GET: api/Panels
        [HttpGet("GetTerreno")]
        public async Task<ActionResult<IEnumerable<Terreno>>> GetTerrenos()
        {
            return await _context.Terrenos.ToListAsync();
        }

        // GET: api/Panels/5
        [HttpGet("GetId/{Id}")]
        public async Task<ActionResult<Terreno>> GetTerreno(int Id)
        {
            var panel = await _context.Terrenos.FindAsync(Id);

            if (panel == null)
            {
                return NotFound();
            }

            return panel;
        }

        [HttpGet("getModelos/{ModeloPanel}")]
        public async Task<ActionResult<IEnumerable<Terreno>>> GetModelos(string ModeloPanel)
        {
            var coincIdencias = await _context.Terrenos.Where(x => x.ModeloPanel.Equals(ModeloPanel)).ToListAsync();

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
        public async Task<ActionResult<IEnumerable<Terreno>>> GetEstructura(int Estructura)
        {
            var coincIdencias = await _context.Terrenos.Where(x => x.AnguloEstructura.Equals(Estructura)).ToListAsync();

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
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
            {
                return NotFound();
            }
            else
            {
                if (Latitud > 90 || Latitud < -90)
                {
                    return BadRequest("El valor de la Latitud debe ser entre -90º y 90º.");
                }
                else
                {
                    terreno.Latitud = Latitud;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);

                    _context.Entry(terreno).State = EntityState.Modified;                   
                    await _context.SaveChangesAsync();
                    return Ok("Latitud modificada correctamente");
                }

            }
        }
        [HttpPut("PutLongitud/{Longitud}")]
        public async Task<IActionResult> PutLongitud(int Id, double Longitud)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
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
                    terreno.Longitud = Longitud;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Longitud modifcada correctamente");
                }

            }
        }
        [HttpPut("PutModeloPanel/{ModeloPanel}")]
        public async Task<IActionResult> PutModeloPanel(int Id, string ModeloPanel)
        {
            if (!ModelosPanel.Keys.Any(X => X.ToLower().Equals(ModeloPanel.ToLower())))
            {
                return BadRequest("El modelo de panel no es válido");
            }
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
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
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.ModeloPanel = ModeloPanel;
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Nombre del modelo modificado correctamente");
                }

            }
        }

        [HttpPut("PutAnchoTerreno/{AnchoTerreno}")]
        public async Task<IActionResult> PutAnchoTerreno(int Id, double AnchoTerreno)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
            {
                return NotFound();
            }
            else
            {
                if (AnchoTerreno <= 0)
                {
                    return BadRequest("El valor del ancho del terreno debe ser entre un valor positivo.");
                }
                else
                {
                    terreno.AnchoTerreno = AnchoTerreno;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ancho del terreno modifcado correctamente");
                }

            }
        }
        [HttpPut("PutLargoTerreno/{LargoTerreno}")]
        public async Task<IActionResult> PutLargoTerreno(int Id, double LargoTerreno)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
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
                    terreno.LargoTerreno = LargoTerreno;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Largo del terreno modifcado correctamente");
                }

            }
        }
        [HttpPut("PutPotenciaPanel/{PotenciaPanel}")]
        public async Task<IActionResult> PutPotenciaPanel(int Id, int PotenciaPanel)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
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
                    terreno.Potencia = PotenciaPanel;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Potencia del panel modificada correctamente");
                }

            }
        }
        [HttpPut("PutAnguloEstructura/{AnguloEstructura}")]
        public async Task<IActionResult> PutAnguloEstructura(int Id, int AnguloEstructura)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
            {
                return NotFound();
            }
            else
            {
                if (AnguloEstructura != 0 ^ AnguloEstructura != 15 ^ AnguloEstructura != 30)
                {
                    return BadRequest("El valor del ángulo de la estructura debe ser 0º, 15º o 30º.");
                }
                else
                {
                    terreno.AnguloEstructura = AnguloEstructura;
                    terreno.Separacion = SeparacionMinima(terreno.Latitud, terreno.ModeloPanel, terreno.AnguloEstructura);
                    terreno.TotalPaneles = NumeroPaneles(terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    terreno.PotenciaTotal = PotenciaTotal(terreno.Potencia, terreno.ModeloPanel, terreno.LargoTerreno, terreno.AnchoTerreno, terreno.Latitud, terreno.AnguloEstructura);
                    _context.Entry(terreno).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Ángulo de la estructura modificado correctamente");
                }

            }
        }
        [HttpPut("PutVoltajePanel/{VoltajePanel}")]
        public async Task<IActionResult> PutVoltajePanel(int Id, double VoltajePanel)
        {
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
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
                    terreno.Voltaje = VoltajePanel;
                    _context.Entry(terreno).State = EntityState.Modified;
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
            var terreno = await _context.Terrenos.FindAsync(Id);
            if (terreno == null)
            {
                return NotFound();
            }

            _context.Terrenos.Remove(terreno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PanelExists(int Id)
        {
            return _context.Terrenos.Any(e => e.Id == Id);
        }
        #endregion

        #region Aux Functions

        //SEPARACIÓN MÍNIMA ENTRE PANELES DE PIE//
        //Función que calcula la separación mínima entre paneles en función de la latitud, la longitud del panel y el ángulo de la estructura
        private double SeparacionMinima(double Latitud, string ModeloPanel, int AnguloEstructura)
        {
            //Se pasan los ángulos a radianes
            var latitudRad = Latitud * Math.PI / 180;
            var AnguloEstructuraRad = AnguloEstructura * Math.PI / 180;
            //Se calcula la altura solar en el solsticio de invierno para la latitud indicada, a las 2pm hora solar.
            //Nota: La declinación solar en el solsticio de invierno es siempre de -23.5º para cualquier parte del mundo.
            double anguloHorarioRad = 30 * Math.PI / 180;
            double declinacionRad = -23.5 * Math.PI / 180;
            double alturaSolar = Math.Asin(Math.Sin(latitudRad) * Math.Sin(declinacionRad) +
                                      Math.Cos(latitudRad) * Math.Cos(declinacionRad) * Math.Cos(anguloHorarioRad));

            //Se obtiene la longitud del modelo de panel y se convierte a metros
            double LargoPanel = ObtenerLargoPanel(ModeloPanel) / 1000;

            //Se procede al cálculo de la separación mínima entre paneles para evitar sombras en las dos horas anteriores y posteriores al mediodía solar

            double Separacion = LargoPanel * Math.Cos(AnguloEstructuraRad) + LargoPanel * (Math.Cos(anguloHorarioRad) * Math.Sin(AnguloEstructuraRad) / Math.Tan(alturaSolar));

            return Separacion;
        }

        //SEPARACIÓN MÍNIMA ENTRE PANELES TUMBADOS//
        //Función que calcula la separación mínima entre paneles tumbados en función de la latitud, la longitud del panel y el ángulo de la estructura
        private double SeparacionMinimaTumbados(double Latitud, string ModeloPanel, int AnguloEstructura)
        {
            //Se pasan los ángulos a radianes
            var latitudRad = Latitud * Math.PI / 180;
            var AnguloEstructuraRad = AnguloEstructura * Math.PI / 180;
            //Se calcula la altura solar en el solsticio de invierno para la latitud indicada, a las 2pm hora solar.
            //Nota: La declinación solar en el solsticio de invierno es siempre de -23.5º para cualquier parte del mundo.
            double anguloHorarioRad = 30 * Math.PI / 180;
            double declinacionRad = -23.5 * Math.PI / 180;
            double alturaSolar = Math.Asin(Math.Sin(latitudRad) * Math.Sin(declinacionRad) +
                                      Math.Cos(latitudRad) * Math.Cos(declinacionRad) * Math.Cos(anguloHorarioRad));

            //Se obtiene la anchura del modelo de panel y se convierte a metros
            double AnchoPanel = ObtenerAnchoPanel(ModeloPanel) / 1000;

            //Se procede al cálculo de la separación mínima entre paneles para evitar sombras en las dos horas anteriores y posteriores al mediodía solar

            double Separacion = AnchoPanel * Math.Cos(AnguloEstructuraRad) + AnchoPanel * (Math.Cos(anguloHorarioRad) * Math.Sin(AnguloEstructuraRad) / Math.Tan(alturaSolar));

            return Separacion;
            //Para la separación, sería igual
        }

        //NÚMERO DE PANELES//
        //Función que calcula el número máximo de paneles que caben en un terreno rectangular
        /*El total de paneles no deberían ser un número entero?*/
        private int NumeroPaneles(string ModeloPanel, double LargoTerreno, double AnchoTerreno, double Latitud, int AnguloEstructura)
        {

            //Se obtienen las dimensiones del modelo de panel y se convierten a metros
            double LargoPanel = ObtenerLargoPanel(ModeloPanel) / 1000;
            double AnchoPanel = ObtenerAnchoPanel(ModeloPanel) / 1000;

            //Se calcula la separación entre paneles con orientación vertical
            double Separacion = SeparacionMinima(Latitud, ModeloPanel, AnguloEstructura);
            //Luego se calcula la separación entre paneles con orientación horizontal
            double SeparacionTumbados = SeparacionMinimaTumbados(Latitud, ModeloPanel, AnguloEstructura);
            //Se calcula el número de paneles que entran con una orientación vertical
            int NumeroOrientacionVertical = Convert.ToInt32(Math.Floor(LargoTerreno / Separacion) * Math.Floor(AnchoTerreno / AnchoPanel));
            //Se calcula el número de paneles que entran con una orientación 
            int NumeroOrientacionHorizontal = Convert.ToInt32(Math.Floor(LargoTerreno / SeparacionTumbados) * Math.Floor(AnchoTerreno / LargoPanel));

            //Se evalúa en qué caso caben más paneles
            if (NumeroOrientacionHorizontal <= NumeroOrientacionVertical)
            {
                return NumeroOrientacionVertical;
            }
            else
            {
                return NumeroOrientacionHorizontal;
            }
            //Ahora, podrías llamar a las funciones creadas desde aquí, añadiendo a las variables que recibe, el modelo de panel, para obtener su 
            //largo y ancho
        }


        //POTENCIA TOTAL//
        //Función que calcula la potencia total en base al número total de paneles        
        private int PotenciaTotal(int Potencia, string ModeloPanel, double LargoTerreno, double AnchoTerreno, double Latitud, int AnguloEstructura)
        {

            int Cantidad = Convert.ToInt32(Potencia * NumeroPaneles(ModeloPanel, LargoTerreno, AnchoTerreno, Latitud, AnguloEstructura));

            return Cantidad;
        }
        #endregion

        #region Funciones prueba obtención largo y ancho paneles en base a modelo

        //Podemos hacerlo de la siguiente forma
        private double ObtenerLargoPanel(string modelo)
        {
            if (ModelosPanel.Any(x => x.Key.Equals(modelo)))
            {
                var dimensiones = ModelosPanel.First(x => x.Key.Equals(modelo)).Value;
                return double.Parse(dimensiones.Split('x').First());
            }
            else
            {
                return 0;
            }
        }

        private double ObtenerAnchoPanel(string modelo)
        {
            if (ModelosPanel.Any(x => x.Key.Equals(modelo)))
            {
                var dimensiones = ModelosPanel.First(x => x.Key.Equals(modelo)).Value;
                return double.Parse(dimensiones.Split('x').Last());
            }
            else
            {
                return 0;
            }
        }

        #endregion


    }
}
