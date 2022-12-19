using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_EntidadesInventario2021
{
    public class ContenidoFactura
    {
        public int Id_Cont { get; set; }
        public double PrecioCompra { get; set; }
        public string NumSerie { get; set; }
        public short Estado { get; set; }
        public bool Descontinuado { get; set; }
        public int F_Factura { get; set; }
        public int F_Componente { get; set; }
    }
}
