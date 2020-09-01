using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class CrearProveedorEncaViewModel
    {
        public long CORRELATIVO { get; set; }
        public string FECHA { get; set; }
        public long RUT { get; set; }
        public char DVRUT { get; set; }
        public string FECHARECEPCION { get; set; }
        public long REFTIPODOC { get; set; }
        public long REFNRODOC { get; set; }
        public long TIPODOC { get; set; }
        public long NRODOC { get; set; }
        public long NETO { get; set; }
        public long IMPUESTO { get; set; }
        public long CARGO { get; set; }
        public long ABONO { get; set; }
        public string GLOSA { get; set; }
    }
}
