using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Class_AccesoDatos;
using Class_EntidadesInventario2021;

namespace Class_LogicaNegocios
{
    public class Logica_ContenidoFactura
    {
        AccesoSQL opContFac = null;
        public Logica_ContenidoFactura(string CadCon)
        {
            opContFac = new AccesoSQL(CadCon);
        }

        public List<ContenidoFactura> MandarListaIDs(ref string mensaje)
        {
            string consulta = "SELECT ID_CONT, NUMSERIE FROM CONTENIDOFACTURA";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            List<ContenidoFactura> contfac
                = new List<ContenidoFactura>();
            cntemp = opContFac.AbrirConexion(ref mensaje);
            contenedor = opContFac.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    contfac.Add(
                        new ContenidoFactura
                        {
                            Id_Cont = (int)contenedor[0],
                            NumSerie = (string)contenedor[1]
                        });
                }
            }
            return contfac;
        }

        public DataTable TablaContenidoFactura(ref string mensaje)
        {
            string consulta = "SELECT * FROM CONTENIDOFACTURA";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = opContFac.ConsultasDS(consulta, opContFac.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
