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
    public class CentrosCostosController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public CentrosCostosController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/CentrosCostos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectCentroCostoViewModel>> Select()
        {
            var centro = await _context.centrocostos.ToListAsync();

            return centro.Select(c => new SelectCentroCostoViewModel
            {
                Id = c.Id,
                Descripcion = c.Descripcion
            });
        }

        private bool CentroCostoExists(string id)
        {
            return _context.centrocostos.Any(e => e.Id == id);
        }
    }
}
