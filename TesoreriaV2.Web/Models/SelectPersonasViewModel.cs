using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class SelectPersonasViewModel
    {
        public int RUT { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
    }
}
