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
    public class Logica_NotaVenta
    {
        AccesoSQL OpNota_SQL = null;
        public Logica_NotaVenta(string CadCon)
        {
            OpNota_SQL = new AccesoSQL(CadCon);
        }
        public int DevolverUnID(ref string mensaje)
        {
            int id = 0;
            string consulta = "SELECT MAX(ID_NOTA) FROM NOTAVENTA";
            string m = "";
            object Resp = OpNota_SQL.Mandar1RespConsult(consulta, OpNota_SQL.AbrirConexion(ref m), ref m);
            if (Resp != null)
            {
                consulta = "SELECT MAX(ID_NOTA)+1 FROM NOTAVENTA";
                Resp = OpNota_SQL.Mandar1RespConsult(consulta, OpNota_SQL.AbrirConexion(ref m), ref m);
                id = (int)Resp;
            }
            else
            {
                id = 1;
            }
            mensaje = m;
            return id;
        }

        public Boolean InsertarNota(NotaVenta nuevo, ref string mensaje)
        {
            string insertar = "";
            insertar = $"INSERT INTO NOTAVENTA ([FECHA], [FOLIO], " +
                $"[F_CLIENTE]) " +
                $"VALUES(@FEC, @FOL, @F_C); ";

            Boolean salida = false;
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("FEC", SqlDbType.Date),
                new SqlParameter("FOL", SqlDbType.VarChar, 20),
                new SqlParameter("F_C", SqlDbType.Int)
            };
            arregloPars[0].Value = nuevo.Fecha;
            arregloPars[1].Value = nuevo.Folio;
            arregloPars[2].Value = nuevo.F_Cliente;

            string h = "";
            salida = OpNota_SQL.OperacionModificacionBD(insertar, OpNota_SQL.AbrirConexion(ref h), ref h, arregloPars);
            mensaje = h;
            return salida;
        }

        public List<NotaVenta> MandarListaNotas(ref string mensaje)
        {
            string consulta = "SELECT * FROM NOTAVENTA";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            List<NotaVenta> Nota
                = new List<NotaVenta>();
            cntemp = OpNota_SQL.AbrirConexion(ref mensaje);
            contenedor = OpNota_SQL.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    Nota.Add(
                        new NotaVenta
                        {
                            Id_Nota = (int)contenedor[0],
                            Folio = (string)contenedor[2]
                        });
                }
            }
            return Nota;
        }
        public DataTable TablaNotaVenta(ref string mensaje, int id)
        {
            string consulta =
                $"SELECT ID_NOTA, FECHA, FOLIO, PRECIOVENTA, PRECIOCOMPRA, " +
                $"F_CONTFACTURA, (PrecioVenta - PrecioCompra) AS TOTAL FROM NOTAVENTA AS NOTA " +
                $"INNER JOIN ContenidoNota AS CONT ON NOTA.Id_Nota = CONT.F_Nota " +
                $"INNER JOIN ContenidoFactura AS CFAC ON CONT.F_ContFactura = CFAC.Id_Cont " +
                $"WHERE ID_NOTA = {id}";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = OpNota_SQL.ConsultasDS(consulta, OpNota_SQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
