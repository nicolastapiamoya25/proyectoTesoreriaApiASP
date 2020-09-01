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
    public class DetaProveedoresController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public DetaProveedoresController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/DetaProveedores/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<DetaProveedoresViewModel>> Listar()
        {
            var deta = await _context.detaproveedores.ToListAsync();

            return deta.Select(dp => new DetaProveedoresViewModel
            {
                CORRELATIVO = dp.CORRELATIVO,
                ITEM = dp.ITEM,
                MONTO = dp.MONTO,
                ABONO = dp.ABONO,
                ID = dp.ID,
                CCOSTOS = dp.CCOSTOS,
                CODCLA = dp.CODCLA
            });
        }

        // POST: api/DetaProveedores/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearDetaProveedoresViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DetaProveedores detaProv = new DetaProveedores
            {
                CORRELATIVO = model.CORRELATIVO,
                ITEM = model.ITEM,
                MONTO = model.MONTO,
                ABONO = model.ABONO,
                ID = model.ID,
                CCOSTOS = model.CCOSTOS,
                CODCLA = model.CODCLA

            };
            _context.detaproveedores.Add(detaProv);

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

        private bool DetaProveedoresExists(long id)
        {
            return _context.detaproveedores.Any(e => e.ID == id);
        }
    }
}
