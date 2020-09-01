﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TesoreriaV2.Entidades
{
    public class ProveedorDeta
    {
        public string RUT { get; set; }
        public string REFTIPODOC { get; set; }
        public string REFNRODOC { get; set; }
        public string TIPODOC { get; set; }
        public string NRODOC { get; set; }
        public string CARGO { get; set; }
        public string ABONO { get; set; }
        public string CORRELATIVO { get; set; }
        public long MONTO { get; set; }
        public string CCOSTOS { get; set; }
        public string CODCLA { get; set; }
    }
}
