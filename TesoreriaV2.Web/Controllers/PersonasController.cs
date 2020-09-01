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
    public class PersonasController : ControllerBase
    {
        private readonly DbContextTesoreria _context;

        public PersonasController(DbContextTesoreria context)
        {
            _context = context;
        }

        // GET: api/Personas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectPersonasViewModel>> Select()
        {
            var persona = await _context.personas.ToListAsync();

            return persona.Select(c => new SelectPersonasViewModel
            {
                RUT = c.RUT,
                Nombres = c.Nombres,
                Paterno = c.Paterno,
                Materno = c.Materno
            });
        }


        private bool PersonasExists(int id)
        {
            return _context.personas.Any(e => e.RUT == id);
        }
    }
}
