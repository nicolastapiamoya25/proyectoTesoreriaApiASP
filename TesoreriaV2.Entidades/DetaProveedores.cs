﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TesoreriaV2.Entidades
{
    public class DetaProveedores
    {
        public long CORRELATIVO { get; set; }
        public char ITEM { get; set; }
        public long MONTO { get; set; }
        public long ABONO { get; set; }
        public long ID { get; set; }
        public char CCOSTOS { get; set; }
        public string CODCLA { get; set; }
    }
}
