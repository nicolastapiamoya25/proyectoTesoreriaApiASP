﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class ActualizarProveedorDetaViewModel
    {
        public string RUT { get; set; }
        public string REFTIPODOC { get; set; }
        public string REFNRODOC { get; set; }
        public string TIPODOC { get; set; }
        public string NRODOC { get; set; }
        public string CARGO { get; set; }
        public string ABONO { get; set; }
        public long CORRELATIVO { get; set; }
        public string MONTO { get; set; }
        public string CCOSTOS { get; set; }
        public string CODCLA { get; set; }
    }
}
