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
    public class ProveedoresDetasController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public ProveedoresDetasController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/ProveedoresDetas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorDetaViewModel>> Listar()
        {
            var deta = await _context.proveedoresdetas.Select(ep => ep).OrderBy(ep=>ep.MONTO).ToListAsync();

            return deta.Select(ep => new ProveedorDetaViewModel
            {
                CORRELATIVO = ep.CORRELATIVO,
                MONTO = ep.MONTO,
                CCOSTOS = ep.CCOSTOS,
                CODCLA = ep.CODCLA
            });
        }

        // GET: api/ProveedoresDetas/ListarDeta
        [HttpGet("[action]/{correlativo}")]
        public async Task<IEnumerable<ProveedorDetaViewModel>> ListarDeta([FromRoute] long correlativo)
        {
            var deta = await _context.proveedoresdetas.Where(ep => ep.CORRELATIVO==correlativo).ToListAsync();
            //var deta = await _context.proveedoresdetas.ToListAsync();
            return deta.Select(ep => new ProveedorDetaViewModel
            {
                CORRELATIVO = ep.CORRELATIVO,
                MONTO = ep.MONTO,
                CCOSTOS = ep.CCOSTOS,
                CODCLA = ep.CODCLA
            });
        }

        // POST: api/ProveedoresDetas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearProveedorDetaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProveedorDeta detaProv = new ProveedorDeta
            {

                RUT = model.RUT,
                REFTIPODOC = model.TIPODOC,
                REFNRODOC = model.NRODOC,
                TIPODOC = model.TIPODOC,
                NRODOC = model.NRODOC,
                CARGO = model.CARGO,
                ABONO = model.ABONO,
                CORRELATIVO = model.CORRELATIVO,
                MONTO = model.MONTO,
                CCOSTOS = model.CCOSTOS,
                CODCLA = model.CODCLA

            };
            _context.proveedoresdetas.Add(detaProv);

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

        // PUT: api/ProveedoresDetas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarProveedorDetaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Int32.Parse(model.RUT) <= 0)
            {
                return BadRequest();
            }

            var detaprov = await _context.proveedoresdetas.FirstOrDefaultAsync(c => c.RUT == model.RUT);

            if (detaprov == null)
            {
                return NotFound();
            }

            detaprov.RUT = model.RUT;
            detaprov.REFTIPODOC = model.TIPODOC;
            detaprov.REFNRODOC = model.NRODOC;
            detaprov.TIPODOC = model.TIPODOC;
            detaprov.NRODOC = model.NRODOC;
            detaprov.CARGO = model.CARGO;
            detaprov.ABONO = model.ABONO;
            detaprov.CORRELATIVO = model.CORRELATIVO;
            detaprov.MONTO = model.MONTO;
            detaprov.CCOSTOS = model.CCOSTOS;
            detaprov.CODCLA = model.CODCLA;


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

        private bool ProveedorDetaExists(int id)
        {
            return _context.proveedoresdetas.Any(e => e.ID == id);
        }
    }
}
