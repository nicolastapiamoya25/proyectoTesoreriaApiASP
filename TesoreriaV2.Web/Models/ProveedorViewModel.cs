using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class ProveedorViewModel
    {
        public long rut { get; set; }
        public string dvrut { get; set; }
        public string razon_social { get; set; }
        public string comuna { get; set; }
        public string direccion { get; set; }
        public string sector { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string giro { get; set; }
        public string contacto { get; set; }
        public string tipocta { get; set; }
        public string banco { get; set; }
        public string cuenta { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
    }
}
