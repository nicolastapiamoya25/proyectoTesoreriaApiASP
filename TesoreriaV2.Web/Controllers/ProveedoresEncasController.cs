using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesoreriaV2.Datos;
using TesoreriaV2.Entidades;
using TesoreriaV2.Web.Models;

namespace TesoreriaV2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresEncasController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public ProveedoresEncasController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/ProveedoresEncas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorEncaViewModel>> Listar()
        {
            var enca = await _context.proveedoresencas.ToListAsync();

            return enca.Select(ep => new ProveedorEncaViewModel
            {
                CORRELATIVO = ep.CORRELATIVO,
                FECHA = ep.FECHA,
                RUT = ep.RUT,
                DVRUT = ep.DVRUT,
                FECHARECEPCION = ep.FECHARECEPCION,
                REFTIPODOC = ep.REFTIPODOC,
                REFNRODOC = ep.REFNRODOC,
                TIPODOC = ep.TIPODOC,
                NRODOC = ep.NRODOC,
                NETO = ep.NETO,
                IMPUESTO = ep.IMPUESTO,
                CARGO = ep.CARGO,
                ABONO = ep.ABONO,
                GLOSA = ep.GLOSA
            });
        }

        // POST: api/ProveedoresEncas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearProveedorEncaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProveedorEnca encaProv = new ProveedorEnca
            {
                CORRELATIVO = model.CORRELATIVO,
                FECHA = model.FECHA,
                RUT = model.RUT,
                DVRUT = model.DVRUT,
                FECHARECEPCION = model.FECHARECEPCION,
                REFTIPODOC = model.TIPODOC,
                REFNRODOC = model.NRODOC,
                TIPODOC = model.TIPODOC,
                NRODOC = model.NRODOC,
                NETO = model.NETO,
                IMPUESTO = model.IMPUESTO,
                CARGO = model.CARGO,
                ABONO = model.ABONO,
                GLOSA = model.GLOSA
            };
            _context.proveedoresencas.Add(encaProv);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/ProveedoresEncas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarProveedorEncaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.CORRELATIVO <= 0)
            {
                return BadRequest();
            }

            var encaprov = await _context.proveedoresencas.FirstOrDefaultAsync(c => c.CORRELATIVO == model.CORRELATIVO);

            if (encaprov == null)
            {
                return NotFound();
            }

            encaprov.CORRELATIVO = model.CORRELATIVO;
            encaprov.FECHA = model.FECHA;
            encaprov.RUT = model.RUT;
            encaprov.DVRUT = model.DVRUT;
            encaprov.FECHARECEPCION = model.FECHARECEPCION;
            encaprov.REFTIPODOC = model.TIPODOC;
            encaprov.REFNRODOC = model.NRODOC;
            encaprov.TIPODOC = model.TIPODOC;
            encaprov.NRODOC = model.NRODOC;
            encaprov.NETO = model.NETO;
            encaprov.IMPUESTO = model.IMPUESTO;
            encaprov.CARGO = model.CARGO;
            encaprov.ABONO = model.ABONO;
            encaprov.GLOSA = model.GLOSA;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar Exception
                return BadRequest();
            }

            return Ok();
        }

        private bool ProveedorEncaExists(long id)
        {
            return _context.proveedoresencas.Any(e => e.CORRELATIVO == id);
        }
    }
}
