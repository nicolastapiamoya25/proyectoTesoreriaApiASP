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
    public class EncaProveedoresController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public EncaProveedoresController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/EncaProveedores/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EncaProveedoresViewModel>> Listar()
        {
            var enca = await _context.encaproveedores.ToListAsync();

            return enca.Select(ep => new EncaProveedoresViewModel
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
                IVA = ep.IVA,
                CARGO = ep.CARGO,
                ABONO = ep.ABONO,
                GLOSA = ep.GLOSA,
                FECHAVENCE = ep.FECHAVENCE,
                NROCLIENTE = ep.NROCLIENTE,
                bruto = ep.bruto,
                ANTICIPO_FACTURA = ep.ANTICIPO_FACTURA,
                NRO_MENSUAL = ep.NRO_MENSUAL,
                id_tabla = ep.id_tabla
            });
    }

        // POST: api/EncaProveedores/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearEncaProveedoresViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EncaProveedores encaProv = new EncaProveedores
            {
                CORRELATIVO = model.CORRELATIVO,
                FECHA = model.FECHA,
                RUT = model.RUT,
                DVRUT = model.DVRUT,
                FECHARECEPCION = model.FECHARECEPCION,
                REFTIPODOC = model.REFTIPODOC,
                REFNRODOC = model.REFNRODOC,
                TIPODOC = model.TIPODOC,
                NRODOC = model.NRODOC,
                NETO = model.NETO,
                IVA = model.IVA,
                CARGO = model.CARGO,
                ABONO = model.ABONO,
                GLOSA = model.GLOSA,
                FECHAVENCE = model.FECHAVENCE,
                NROCLIENTE = model.NROCLIENTE,
                bruto = model.bruto,
                ANTICIPO_FACTURA = model.ANTICIPO_FACTURA,
                NRO_MENSUAL = model.NRO_MENSUAL,
                id_tabla = model.id_tabla
            };
            _context.encaproveedores.Add(encaProv);

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

        // PUT: api/EncaProveedores/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarEncaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.CORRELATIVO <= 0)
            {
                return BadRequest();
            }

            var ecaproveedor = await _context.encaproveedores.FirstOrDefaultAsync(c => c.CORRELATIVO == model.CORRELATIVO);

            if (ecaproveedor == null)
            {
                return NotFound();
            }

            ecaproveedor.FECHA = model.FECHA;
            ecaproveedor.TIPODOC = model.TIPODOC;
            ecaproveedor.NRODOC = model.NRODOC;
            ecaproveedor.RUT = model.RUT;
            ecaproveedor.IVA = model.IVA;
            ecaproveedor.NETO = model.NETO;
            ecaproveedor.CARGO = model.CARGO;
            ecaproveedor.GLOSA = model.GLOSA;
            ecaproveedor.ABONO = model.ABONO;

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


        private bool EncaProveedoresExists(long id)
        {
            return _context.encaproveedores.Any(e => e.CORRELATIVO == id);
        }
    }
}
