using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_EntidadesInventario2021
{
    public class ContenidoNota
    {
        public int Id_ContNota { get; set; }
        public double PrecioVenta { get; set; }
        public short DiasGarantia { get; set; }
        public string Extra { get; set; }
        public int F_Nota { get; set; }
        public int F_ContFactura { get; set; }
    }
}
