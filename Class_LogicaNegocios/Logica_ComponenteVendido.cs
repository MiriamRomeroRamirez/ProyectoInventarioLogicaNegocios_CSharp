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
    public class Logica_ComponenteVendido
    {
        AccesoSQL OpCOMV_SQL = null;
        public Logica_ComponenteVendido(string CadCon)
        {
            OpCOMV_SQL = new AccesoSQL(CadCon);
        }
        public DataTable TablaComponenteVendido(ref string mensaje, string NumSerie)
        {
            string consulta =
                $"SELECT NOMBRE AS COMPONENTE, MARCA, NOMBRECATE AS CATEGORIA, ID_NOTA, FOLIO," +
                $"RAZONSOCIAL AS CLIENTE, FECHA, DIASGARANTIA FROM ComponenteGenerico AS GENE" +
                $" INNER JOIN Marca AS MAR ON MAR.id_Marca = GENE.F_Marca" +
                $" INNER JOIN Categoria AS CATE ON CATE.Id_Categoria = GENE.F_Categoria" +
                $" INNER JOIN ContenidoFactura AS CONFAC ON CONFAC.F_Componente = GENE.Id_Componente" +
                $" INNER JOIN ContenidoNota AS CONO ON CONO.F_ContFactura = CONFAC.Id_Cont" +
                $" INNER JOIN NotaVenta AS NOTA ON NOTA.Id_Nota = CONO.F_Nota" +
                $" INNER JOIN CLIENTE AS CLIE ON CLIE.Id_Cliente = NOTA.F_Cliente" +
                $" WHERE NumSerie = '{NumSerie}';";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = OpCOMV_SQL.ConsultasDS(consulta, OpCOMV_SQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
