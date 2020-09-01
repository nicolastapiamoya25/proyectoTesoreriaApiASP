using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TesoreriaV2.Datos;
using TesoreriaV2.Entidades;
using TesoreriaV2.Web.Models;

namespace TesoreriaV2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesController : ControllerBase
    {
        private readonly DbContextTesoreria _context;
        private IConfiguration _config;

        public PerfilesController(DbContextTesoreria context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Perfiles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PerfilViewModel>> Listar()
        {
            var perfil = await _context.perfiles.ToListAsync();

            return perfil.Select(p => new PerfilViewModel
            {
                cod_perfil = p.cod_perfil,
                nombre = p.nombre,
                usuario = p.usuario,
                contrasena = p.contrasena,
                contrasena_maestra = p.contrasena_maestra,
                estado = p.estado
            });
        }


        // GET: api/Perfiles/Mostrar/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute]int id)
        {
            var perfil = await _context.perfiles.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(new PerfilViewModel
            {
                cod_perfil = perfil.cod_perfil,
                nombre = perfil.nombre,
                usuario = perfil.usuario,
                contrasena = perfil.contrasena,
                contrasena_maestra = perfil.contrasena_maestra,
                estado = perfil.estado
            });
        }
        
        private void CrearPasswordHash(string contrasena, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
            }
        }
    
        // API LOGIN POST
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var usuario = model.usuario;

            var perfil = await _context.perfiles.FirstOrDefaultAsync(p => p.usuario == usuario);

            if (perfil == null)
            {
                return NotFound();
            }

            //if (!VerificarPasswordHash(model.contrasena, perfil.password_hash, perfil.password_salt))
            //{
            //    return NotFound();
            //}

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, perfil.cod_perfil.ToString()),
                new Claim(ClaimTypes.Name, usuario),
                new Claim("idusuario", perfil.cod_perfil.ToString()),
                new Claim("nombre",perfil.usuario)
            };

            return Ok(
                    new { token = GenerarToken(claims) }
                );
        }

        // GENERAR TOKEN
        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // VERIFICAR PASSWORD HASH
        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }
        

        private bool PerfilExists(int id)
        {
            return _context.perfiles.Any(e => e.cod_perfil == id);
        }
    }
}
