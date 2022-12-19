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
    public class Logica_FacturaCompra
    {
        AccesoSQL OpFacCom_SQL = null;
        public Logica_FacturaCompra(string CadCon)
        {
            OpFacCom_SQL = new AccesoSQL(CadCon);
        }
        public object TotalPrecioCompra(int id, ref string m)
        {
            string consulta = $"SELECT SUM(PRECIOCOMPRA) FROM CONTENIDOFACTURA WHERE F_FACTURA = {id}";
            object Resp = OpFacCom_SQL.Mandar1RespConsult(consulta, OpFacCom_SQL.AbrirConexion(ref m), ref m);
            return Resp;
        } 
        public DataTable TablaFacturaCompra(ref string mensaje)
        {
            string consulta = "SELECT ID_FACTURA, FOLIO, FECHA, NombreProvee, ANOTACIONEXTRA FROM FACTURACOMPRA AS FAC " +
                "INNER JOIN PROVEEDOR AS PRO ON FAC.F_Proveedor = PRO.Id_Provee"; 
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = OpFacCom_SQL.ConsultasDS(consulta, OpFacCom_SQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
