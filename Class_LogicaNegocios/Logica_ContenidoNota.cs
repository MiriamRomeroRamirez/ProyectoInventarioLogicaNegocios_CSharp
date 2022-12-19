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
    public class Logica_ContenidoNota
    {
        AccesoSQL obj_ContNotaSQL = null;
        public Logica_ContenidoNota(string CadCon)
        {
            obj_ContNotaSQL = new AccesoSQL(CadCon);
        }

        public int DevolverUnID(ref string mensaje)
        {
            int id = 0;
            string consulta = "SELECT MAX(ID_CONTNOTA) FROM CONTENIDONOTA";
            string m = "";
            object Resp = obj_ContNotaSQL.Mandar1RespConsult(consulta, obj_ContNotaSQL.AbrirConexion(ref m), ref m);
            if (Resp != null)
            {
                consulta = "SELECT MAX(ID_CONTNOTA)+1 FROM CONTENIDONOTA";
                Resp = obj_ContNotaSQL.Mandar1RespConsult(consulta, obj_ContNotaSQL.AbrirConexion(ref m), ref m);
                id = (int)Resp;
            }
            else
            {
                id = 1;
            }
            mensaje = m;
            return id;
        }

        public Boolean InsertarContenidoNota(ContenidoNota nuevo, ref string mensaje)
        {
            string insertar = "";
            insertar = $"INSERT INTO CONTENIDONOTA ([PRECIOVENTA], [DIASGARANTIA]," +
                $"[EXTRA], [F_NOTA], [F_CONTFACTURA])" +
                $"VALUES (@PREVE, @DGARAN, @EXTRA, @IDNOT, @IDCONTFAC);";

            Boolean salida = false;
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("PREVE", SqlDbType.Money),
                new SqlParameter("DGARAN", SqlDbType.SmallInt),
                new SqlParameter("EXTRA", SqlDbType.VarChar, 60),
                new SqlParameter("IDNOT", SqlDbType.Int),
                new SqlParameter("IDCONTFAC", SqlDbType.Int)
            };
            arregloPars[0].Value = nuevo.PrecioVenta;
            arregloPars[1].Value = nuevo.DiasGarantia;
            arregloPars[2].Value = nuevo.Extra;
            arregloPars[3].Value = nuevo.F_Nota;
            arregloPars[4].Value = nuevo.F_ContFactura;

            string h = "";
            salida = obj_ContNotaSQL.OperacionModificacionBD(insertar, obj_ContNotaSQL.AbrirConexion(ref h), ref h, arregloPars);
            mensaje = h;
            return salida;
        }

        public DataTable TablaContenidoNota(ref string mensaje)
        {
            string consulta = "SELECT * FROM CONTENIDONOTA";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = obj_ContNotaSQL.ConsultasDS(consulta, obj_ContNotaSQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
