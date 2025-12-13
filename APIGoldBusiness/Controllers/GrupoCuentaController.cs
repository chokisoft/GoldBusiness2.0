using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGoldBusiness.Data;
using GoldBusiness.Shared;
using GoldBusiness.Shared.DTOs;

namespace APIGoldBusiness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoCuentaController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        // GET: api/GrupoCuenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoCuentaDTO>>> GetGrupoCuenta()
        {
            var result = await _context.GrupoCuenta
                .Where(s => !s.Cancelado)
                .Select(g => new GrupoCuentaDTO
                {
                    Id = g.Id,
                    Codigo = g.Codigo,
                    Descripcion = g.Descripcion,
                    Cancelado = g.Cancelado
                })
                .ToListAsync();

            return Ok(result);
        }

        // GET: api/GrupoCuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoCuentaDTO>> GetGrupoCuenta(int id)
        {
            var grupoCuenta = await _context.GrupoCuenta
                .Where(g => g.Id == id)
                .Select(g => new GrupoCuentaDTO
                {
                    Id = g.Id,
                    Codigo = g.Codigo,
                    Descripcion = g.Descripcion,
                    Cancelado = g.Cancelado
                })
                .FirstOrDefaultAsync();

            if (grupoCuenta == null)
            {
                return NotFound();
            }

            return Ok(grupoCuenta);
        }

        // PUT: api/GrupoCuenta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoCuenta(int id, GrupoCuentaDTO grupoCuentaDTO)
        {
            if (id != grupoCuentaDTO.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el objeto enviado.");
            }

            var entity = await _context.GrupoCuenta.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Actualizamos solo campos editables
            entity.Codigo = grupoCuentaDTO.Codigo;
            entity.Descripcion = grupoCuentaDTO.Descripcion;
            entity.Cancelado = grupoCuentaDTO.Cancelado;

            // No tocar CreadoPor ni FechaHoraCreado
            entity.ModificadoPor = User?.Identity?.Name ?? "system";
            entity.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(grupoCuentaDTO);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/GrupoCuenta
        [HttpPost]
        public async Task<ActionResult<GrupoCuentaDTO>> PostGrupoCuenta(GrupoCuentaDTO grupoCuentaDTO)
        {
            var entity = new GrupoCuenta
            {
                Codigo = grupoCuentaDTO.Codigo,
                Descripcion = grupoCuentaDTO.Descripcion,
                Cancelado = grupoCuentaDTO.Cancelado,
                CreadoPor = User?.Identity?.Name ?? "system",
                FechaHoraCreado = DateTime.UtcNow,
                ModificadoPor = User?.Identity?.Name ?? "system",
                FechaHoraModificado = DateTime.UtcNow
            };

            try
            {
                _context.GrupoCuenta.Add(entity);
                await _context.SaveChangesAsync();

                grupoCuentaDTO.Id = entity.Id;
                grupoCuentaDTO.CreadoPor = entity.CreadoPor;
                grupoCuentaDTO.FechaHoraCreado = entity.FechaHoraCreado;
                grupoCuentaDTO.ModificadoPor = entity.ModificadoPor;
                grupoCuentaDTO.FechaHoraModificado = entity.FechaHoraModificado;

                return Ok(grupoCuentaDTO);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/GrupoCuenta/5 (soft delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoCuenta(int id)
        {
            var grupoCuenta = await _context.GrupoCuenta.FindAsync(id);
            if (grupoCuenta == null)
            {
                return NotFound();
            }

            grupoCuenta.Cancelado = true;
            grupoCuenta.ModificadoPor = User?.Identity?.Name ?? "system";
            grupoCuenta.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new GrupoCuentaDTO
                {
                    Id = grupoCuenta.Id,
                    Codigo = grupoCuenta.Codigo,
                    Descripcion = grupoCuenta.Descripcion,
                    Cancelado = grupoCuenta.Cancelado,
                    ModificadoPor = grupoCuenta.ModificadoPor,
                    FechaHoraModificado = grupoCuenta.FechaHoraModificado
                });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}