using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class CrearEncaProveedoresViewModel
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
        public long IVA { get; set; }
        public long CARGO { get; set; }
        public long ABONO { get; set; }
        public string GLOSA { get; set; }
        public string FECHAVENCE { get; set; }
        public string NROCLIENTE { get; set; }
        public long bruto { get; set; }
        public string ANTICIPO_FACTURA { get; set; }
        public long NRO_MENSUAL { get; set; }
        public long id_tabla { get; set; }
    }
}
