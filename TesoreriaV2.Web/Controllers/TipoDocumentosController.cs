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
    public class TipoDocumentosController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public TipoDocumentosController(DbContextTesoreria context)
        {
            _context = context;
        }


        // GET: api/TipoDocumentos/SelectTipoDocumento
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectTipoDocumentoViewModel>> SelectTipoDocumento()
        {
            var tipoDocumento = await _context.tipodocumentos.ToListAsync();

            return tipoDocumento.Select(c => new SelectTipoDocumentoViewModel
            {
                CODIGO = c.CODIGO,
                DESCRIPCION = c.DESCRIPCION

            });
        }


        private bool TipoDocumentoExists(int id)
        {
            return _context.tipodocumentos.Any(e => e.CODIGO == id);
        }
    }
}
