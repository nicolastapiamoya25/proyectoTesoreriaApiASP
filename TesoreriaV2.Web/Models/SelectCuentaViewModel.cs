using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesoreriaV2.Web.Models
{
    public class SelectCuentaViewModel
    {
        public string CUENTA { get; set; }
        public string DESCRIPCION { get; set; }
        public int FACTURAS { get; set; }
        public string CODCLA { get; set; }
    }
}
