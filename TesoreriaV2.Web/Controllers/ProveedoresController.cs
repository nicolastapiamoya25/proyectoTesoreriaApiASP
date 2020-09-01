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
    public class ProveedoresController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public ProveedoresController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/Proveedores/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorViewModel>> Listar()
        {
            var proveedor = await _context.proveedores.ToListAsync();

            return proveedor.Select(pr => new ProveedorViewModel
            {
                rut = pr.rut,
                nombres = pr.nombres,
                paterno = pr.paterno,
                materno = pr.materno,
                correo = pr.correo,
                direccion = pr.direccion
            });
        }


        // GET: api/Proveedores/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute]int id)
        {
            var proveedor = await _context.proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(new ProveedorViewModel
            {
                rut = proveedor.rut,
                nombres = proveedor.nombres,
                paterno = proveedor.paterno,
                materno = proveedor.materno,
                correo = proveedor.correo,
                direccion = proveedor.direccion
            });
        }

        private bool ProveedoresExists(int id)
        {
            return _context.proveedores.Any(e => e.rut == id);
        }
    }
}
