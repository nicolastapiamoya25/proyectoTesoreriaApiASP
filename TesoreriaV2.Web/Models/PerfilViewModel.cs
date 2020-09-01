using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class PerfilViewModel
    {
        public int cod_perfil { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string contrasena_maestra { get; set; }
        public int estado { get; set; }
        public string permisos { get; set; }
        public byte[] password_hash { get; set; }
    }
}
