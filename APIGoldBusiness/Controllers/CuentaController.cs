using APIGoldBusiness.Data;
using GoldBusiness.Shared;
using GoldBusiness.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIGoldBusiness.Controllers
{
    /// <summary>
    /// Controlador para la gestión de Cuentas.
    /// Implementa operaciones CRUD con borrado lógico (soft delete).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CuentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las cuentas activas (no canceladas).
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaDTO>>> GetCuenta()
        {
            var result = await _context.Cuenta
                .Where(c => !c.Cancelado)
                .Select(c => new CuentaDTO
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    Descripcion = c.Descripcion,
                    GrupoCuentaDescripcion = c.SubGrupoCuentaNavigation.GrupoCuentaNavigation.Descripcion,
                    SubGrupoCuenta = c.SubGrupoCuenta,
                    SubGrupoCuentaDescripcion = c.SubGrupoCuentaNavigation.Descripcion,
                    Cancelado = c.Cancelado,
                    CreadoPor = c.CreadoPor,
                    FechaHoraCreado = c.FechaHoraCreado,
                    ModificadoPor = c.ModificadoPor,
                    FechaHoraModificado = c.FechaHoraModificado
                })
                .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Obtiene una cuenta por su identificador.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaDTO>> GetCuenta(int id)
        {
            var cuenta = await _context.Cuenta
                .Where(c => c.Id == id)
                .Select(c => new CuentaDTO
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    Descripcion = c.Descripcion,
                    GrupoCuentaDescripcion = c.SubGrupoCuentaNavigation.GrupoCuentaNavigation.Descripcion,
                    SubGrupoCuenta = c.SubGrupoCuenta,
                    SubGrupoCuentaDescripcion = c.SubGrupoCuentaNavigation.Descripcion,
                    Cancelado = c.Cancelado,
                    CreadoPor = c.CreadoPor,
                    FechaHoraCreado = c.FechaHoraCreado,
                    ModificadoPor = c.ModificadoPor,
                    FechaHoraModificado = c.FechaHoraModificado
                })
                .FirstOrDefaultAsync();

            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        /// <summary>
        /// Actualiza una cuenta existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(int id, CuentaDTO cuentaDTO)
        {
            if (id != cuentaDTO.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el objeto enviado.");
            }

            var entity = await _context.Cuenta.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Actualizamos solo campos editables
            entity.Codigo = cuentaDTO.Codigo;
            entity.Descripcion = cuentaDTO.Descripcion;
            entity.SubGrupoCuenta = cuentaDTO.SubGrupoCuenta;
            entity.Cancelado = cuentaDTO.Cancelado;

            // No tocar CreadoPor ni FechaHoraCreado
            entity.ModificadoPor = User?.Identity?.Name ?? "system";
            entity.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(cuentaDTO);
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
        /// Crea una nueva cuenta.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CuentaDTO>> PostCuenta(CuentaDTO cuentaDTO)
        {
            var entity = new Cuenta
            {
                Codigo = cuentaDTO.Codigo,
                Descripcion = cuentaDTO.Descripcion,
                SubGrupoCuenta = cuentaDTO.SubGrupoCuenta,
                Cancelado = cuentaDTO.Cancelado,
                CreadoPor = User?.Identity?.Name ?? "system",
                FechaHoraCreado = DateTime.UtcNow,
                ModificadoPor = User?.Identity?.Name ?? "system",
                FechaHoraModificado = DateTime.UtcNow
            };

            try
            {
                _context.Cuenta.Add(entity);
                await _context.SaveChangesAsync();

                // Devolvemos lo que realmente se guardó
                cuentaDTO.Id = entity.Id;
                cuentaDTO.CreadoPor = entity.CreadoPor;
                cuentaDTO.FechaHoraCreado = entity.FechaHoraCreado;
                cuentaDTO.ModificadoPor = entity.ModificadoPor;
                cuentaDTO.FechaHoraModificado = entity.FechaHoraModificado;

                return Ok(cuentaDTO);
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
        /// Cancela (soft delete) una cuenta existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            cuenta.Cancelado = true;
            cuenta.ModificadoPor = User?.Identity?.Name ?? "system";
            cuenta.FechaHoraModificado = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new CuentaDTO
                {
                    Id = cuenta.Id,
                    Codigo = cuenta.Codigo,
                    Descripcion = cuenta.Descripcion,
                    GrupoCuentaDescripcion = cuenta.SubGrupoCuentaNavigation.GrupoCuentaNavigation.Descripcion,
                    SubGrupoCuenta = cuenta.SubGrupoCuenta,
                    SubGrupoCuentaDescripcion = cuenta.SubGrupoCuentaNavigation.Descripcion,
                    Cancelado = cuenta.Cancelado,
                    ModificadoPor = cuenta.ModificadoPor,
                    FechaHoraModificado = cuenta.FechaHoraModificado
                });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}