using APIGoldBusiness.Data;
using GoldBusiness.Shared;
using GoldBusiness.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIGoldBusiness.Controllers
{
    /// <summary>
    /// Controlador para la gestión de SubGrupoCuentas.
    /// Implementa operaciones CRUD con borrado lógico (soft delete).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubGrupoCuentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubGrupoCuentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los subgrupos de cuentas activos (no cancelados).
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubGrupoCuentaDTO>>> GetSubGrupoCuenta()
        {
            var result = await _context.SubGrupoCuenta
                .Where(s => !s.Cancelado)
                .Select(s => new SubGrupoCuentaDTO
                {
                    Id = s.Id,
                    Codigo = s.Codigo,
                    GrupoCuenta = s.GrupoCuenta,
                    GrupoCuentaDescripcion = s.GrupoCuentaNavigation.Descripcion,
                    Descripcion = s.Descripcion,
                    Deudora = s.Deudora,
                    Cancelado = s.Cancelado,
                    CreadoPor = s.CreadoPor,
                    FechaHoraCreado = s.FechaHoraCreado,
                    ModificadoPor = s.ModificadoPor,
                    FechaHoraModificado = s.FechaHoraModificado
                })
                .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Obtiene un subgrupo de cuentas por su identificador.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<SubGrupoCuentaDTO>> GetSubGrupoCuenta(int id)
        {
            var subGrupoCuenta = await _context.SubGrupoCuenta
                .Where(s => s.Id == id)
                .Select(s => new SubGrupoCuentaDTO
                {
                    Id = s.Id,
                    Codigo = s.Codigo,
                    GrupoCuenta = s.GrupoCuenta,
                    GrupoCuentaDescripcion = s.GrupoCuentaNavigation.Descripcion,
                    Descripcion = s.Descripcion,
                    Deudora = s.Deudora,
                    Cancelado = s.Cancelado,
                    CreadoPor = s.CreadoPor,
                    FechaHoraCreado = s.FechaHoraCreado,
                    ModificadoPor = s.ModificadoPor,
                    FechaHoraModificado = s.FechaHoraModificado
                })
                .FirstOrDefaultAsync();

            if (subGrupoCuenta == null)
            {
                return NotFound();
            }

            return Ok(subGrupoCuenta);
        }

        /// <summary>
        /// Actualiza un subgrupo de cuentas existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubGrupoCuenta(int id, SubGrupoCuentaDTO subGrupoCuentaDTO)
        {
            if (id != subGrupoCuentaDTO.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el objeto enviado.");
            }

            var entity = await _context.SubGrupoCuenta.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Actualizamos solo campos editables
            entity.Codigo = subGrupoCuentaDTO.Codigo;
            entity.GrupoCuenta = subGrupoCuentaDTO.GrupoCuenta;
            entity.Descripcion = subGrupoCuentaDTO.Descripcion;
            entity.Deudora = subGrupoCuentaDTO.Deudora;
            entity.Cancelado = subGrupoCuentaDTO.Cancelado;

            // No tocar CreadoPor ni FechaHoraCreado
            entity.ModificadoPor = User?.Identity?.Name ?? "system";
            entity.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(subGrupoCuentaDTO);
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

        /// <summary>
        /// Crea un nuevo subgrupo de cuentas.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<SubGrupoCuentaDTO>> PostSubGrupoCuenta(SubGrupoCuentaDTO subGrupoCuentaDTO)
        {
            var entity = new SubGrupoCuenta
            {
                Codigo = subGrupoCuentaDTO.Codigo,
                GrupoCuenta = subGrupoCuentaDTO.GrupoCuenta,
                Descripcion = subGrupoCuentaDTO.Descripcion,
                Deudora = subGrupoCuentaDTO.Deudora,
                Cancelado = subGrupoCuentaDTO.Cancelado,
                CreadoPor = User?.Identity?.Name ?? "system",
                FechaHoraCreado = DateTime.UtcNow,
                ModificadoPor = User?.Identity?.Name ?? "system",
                FechaHoraModificado = DateTime.UtcNow
            };

            try
            {
                _context.SubGrupoCuenta.Add(entity);
                await _context.SaveChangesAsync();

                // Devolvemos lo que realmente se guardó
                subGrupoCuentaDTO.Id = entity.Id;
                subGrupoCuentaDTO.CreadoPor = entity.CreadoPor;
                subGrupoCuentaDTO.FechaHoraCreado = entity.FechaHoraCreado;
                subGrupoCuentaDTO.ModificadoPor = entity.ModificadoPor;
                subGrupoCuentaDTO.FechaHoraModificado = entity.FechaHoraModificado;

                return Ok(subGrupoCuentaDTO);
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

        /// <summary>
        /// Cancela (soft delete) un subgrupo de cuentas existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubGrupoCuenta(int id)
        {
            var subGrupoCuenta = await _context.SubGrupoCuenta.FindAsync(id);
            if (subGrupoCuenta == null)
            {
                return NotFound();
            }

            subGrupoCuenta.Cancelado = true;
            subGrupoCuenta.ModificadoPor = User?.Identity?.Name ?? "system";
            subGrupoCuenta.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new SubGrupoCuentaDTO
                {
                    Id = subGrupoCuenta.Id,
                    Codigo = subGrupoCuenta.Codigo,
                    GrupoCuenta = subGrupoCuenta.GrupoCuenta,
                    Descripcion = subGrupoCuenta.Descripcion,
                    Deudora = subGrupoCuenta.Deudora,
                    Cancelado = subGrupoCuenta.Cancelado,
                    ModificadoPor = subGrupoCuenta.ModificadoPor,
                    FechaHoraModificado = subGrupoCuenta.FechaHoraModificado
                });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}