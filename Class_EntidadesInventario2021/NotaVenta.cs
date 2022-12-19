using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_EntidadesInventario2021
{
    public class NotaVenta
    {
        public int Id_Nota { get; set; }
        public string Fecha { get; set; }
        public string Folio { get; set; }
        public int F_Cliente { get; set; }
    }
}
