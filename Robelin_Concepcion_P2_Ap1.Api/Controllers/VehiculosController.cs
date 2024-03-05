using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Robelin_Concepcion_P2_Ap1.Api.DAL;

namespace Robelin_Concepcion_P2_Ap1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly Contexto _context;

        public VehiculosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculos>>> GetVehiculos()
        {
            return await _context.Vehiculos.Include(v => v.vehiculosDetalle).ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculos>> GetVehiculos(int id)
        {
            var vehiculos = await _context.Vehiculos.FindAsync(id);

            if (vehiculos == null)
            {
                return NotFound();
            }

            return vehiculos;
        }

        // PUT: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculos(int id, Vehiculos vehiculos)
        {
            if (id != vehiculos.VehiculoId)
            {
                return BadRequest();
            }

            _context.Entry(vehiculos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosExists(id))
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

        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculos>> PostVehiculos(Vehiculos vehiculos)
        {
        

            if (vehiculos.VehiculoId <= 0 || !VehiculosExists(vehiculos.VehiculoId))
            {
                _context.Vehiculos.Add(vehiculos);
            }
            else
            {
                _context.Vehiculos.Update(vehiculos);
            }
            await _context.SaveChangesAsync();
            return Ok(vehiculos);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)


        {
            if (_context.Vehiculos == null)
            {
                return NotFound();
            }
            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Vehiculos
        [HttpDelete("DeleteDetalle/{id}")]
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Detalle = await _context.Vehiculos.FirstOrDefaultAsync(v => v.VehiculoId == id);
            if (Detalle is null)
            {
                return NotFound();
            }
            _context.Vehiculos.Remove(Detalle);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.VehiculoId == id);
        }
    }
}