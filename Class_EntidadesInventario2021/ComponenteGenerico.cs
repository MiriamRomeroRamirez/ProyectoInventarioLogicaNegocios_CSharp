using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_EntidadesInventario2021
{
    public class ComponenteGenerico
    {
        public int Id_Componente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ClaveSAT { get; set; }
        public string CodUnidad { get; set; }
        public string PiezasAlmacen { get; set; }
        public int F_Marca { get; set; }
        public int F_Categoria { get; set; }
    }
}
