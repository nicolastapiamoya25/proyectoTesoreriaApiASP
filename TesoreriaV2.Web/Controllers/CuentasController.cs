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
    public class CuentasController : ControllerBase
    {
        private readonly DbContextContabilidad _context;

        public CuentasController(DbContextContabilidad context)
        {
            _context = context;
        }

        // GET: api/Cuentas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectCuentaViewModel>> Select()
        {
            var cuenta = await _context.cuentas.Where(a => a.FACTURAS == 1).OrderBy(a => a.DESCRIPCION).ToListAsync();

            return cuenta.Select(c => new SelectCuentaViewModel
            {
                CUENTA = c.CUENTA,
                DESCRIPCION = c.DESCRIPCION,
                CODCLA = c.CODCLA
    });
        }

        private bool CuentaExists(string id)
        {
            return _context.cuentas.Any(e => e.CUENTA == id);
        }
    }
}
