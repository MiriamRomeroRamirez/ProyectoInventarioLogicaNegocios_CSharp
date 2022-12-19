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
    public class Logica_Clientes
    {
        AccesoSQL OpClien_SQL = null;
        public Logica_Clientes(string CadCon)
        {
            OpClien_SQL = new AccesoSQL(CadCon);
        }

        public object DevolverUnSoloDato(ref string mensaje)
        {
            string consulta = "SELECT COUNT(ID_CLIENTE)+1 FROM CLIENTE";
            string m = "";
            object Resp = OpClien_SQL.Mandar1RespConsult(consulta, OpClien_SQL.AbrirConexion(ref m), ref m);
            mensaje = m;
            return Resp;
        }
        public Boolean InsertarCliente(Clientes nuevo, ref string mensaje)
        {
            string insertar = "";
            insertar = $"INSERT INTO Cliente([RAZONSOCIAL], [DIRECCION], [TELEFONO], [CP], [CORREO])" +
                $"VALUES (@RAZONSOC, @DIREC, @TEL, @CODP, @CORR);";

            Boolean salida = false;
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("RAZONSOC", SqlDbType.VarChar, 250),
                new SqlParameter("DIREC", SqlDbType.VarChar, 250),
                new SqlParameter("TEL", SqlDbType.VarChar, 20),
                new SqlParameter("CODP", SqlDbType.VarChar, 20),
                new SqlParameter("CORR", SqlDbType.VarChar, 250)
            };
            
            arregloPars[0].Value = nuevo.RazonSocial;
            arregloPars[1].Value = nuevo.Direccion;
            arregloPars[2].Value = nuevo.Telefono;
            arregloPars[3].Value = nuevo.CP;
            arregloPars[4].Value = nuevo.Correo;

            string h = "";
            salida = OpClien_SQL.OperacionModificacionBD(insertar, OpClien_SQL.AbrirConexion(ref h), ref h, arregloPars);
            mensaje = h;
            return salida;
        }
        public Boolean ModificarCliente(Clientes cambio, ref string mensaje)
        {
            string modificar =
                $"UPDATE [dbo].[CLIENTE]" +
                $" SET [RAZONSOCIAL] = @RAZONS," +
                $"[DIRECCION] = @DIR," +
                $"[Telefono] = @TELEF," +
                $"[CP] = @CPOS," +
                $"[CORREO] = @CORR" +
                $" WHERE [ID_CLIENTE] = @IDC;";
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("IDC", SqlDbType.Int),
                new SqlParameter("RAZONS", SqlDbType.VarChar, 250),
                new SqlParameter("DIR", SqlDbType.VarChar, 250),
                new SqlParameter("TELEF", SqlDbType.VarChar, 20),
                new SqlParameter("CPOS", SqlDbType.VarChar, 20),
                new SqlParameter("CORR", SqlDbType.VarChar, 250)
            };

            arregloPars[0].Value = cambio.Id_Cliente;
            arregloPars[1].Value = cambio.RazonSocial;
            arregloPars[2].Value = cambio.Direccion;
            arregloPars[3].Value = cambio.Telefono;
            arregloPars[4].Value = cambio.CP;
            arregloPars[5].Value = cambio.Correo;
            Boolean salida = false;
            string m = "";
            salida = OpClien_SQL.OperacionModificacionBD(modificar, OpClien_SQL.AbrirConexion(ref m), ref m, arregloPars);
            mensaje = m;
            return salida;
        }

        public List<Clientes> ListaClientes(ref string mensaje)
        {
            string consulta = "SELECT ID_CLIENTE, RAZONSOCIAL FROM CLIENTE";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            List<Clientes> Clie
                = new List<Clientes>();
            cntemp = OpClien_SQL.AbrirConexion(ref mensaje);
            contenedor = OpClien_SQL.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    Clie.Add(
                        new Clientes
                        {
                            Id_Cliente = (int)contenedor[0],
                            RazonSocial = (string)contenedor[1]
                        });
                }
            }
            return Clie;
        }

        public Boolean EliminarCliente(Clientes elimi, ref string mensaje)
        {
            string eliminar = "DELETE FROM [CLIENTE] WHERE [ID_CLIENTE] = @ID_;";
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("ID_", SqlDbType.Int)
            };
            arregloPars[0].Value = elimi.Id_Cliente;
            Boolean salida = false;
            string m = "";
            salida = OpClien_SQL.OperacionModificacionBD(eliminar, OpClien_SQL.AbrirConexion(ref m), ref m, arregloPars);
            mensaje = m;
            return salida;
        }

        public DataTable TablaClientes(ref string mensaje)
        {
            string consulta = "SELECT * FROM CLIENTE";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = OpClien_SQL.ConsultasDS(consulta, OpClien_SQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }

        public Clientes DevolverDatos(ref string mensaje, int id)
        {
            Clientes DatosCliente = null;
            string consulta = "SELECT * FROM CLIENTE WHERE ID_CLIENTE = " + id;
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            cntemp = OpClien_SQL.AbrirConexion(ref mensaje);
            contenedor = OpClien_SQL.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor.HasRows)
            {
                while (contenedor.Read())
                {
                    DatosCliente = new Clientes 
                    {
                        Id_Cliente = (int)contenedor[0],
                        RazonSocial = (string)contenedor[1],
                        Direccion = (string)contenedor[2],
                        Telefono = (string)contenedor[3],
                        CP = (string)contenedor[4],
                        Correo = (string)contenedor[5]
                    };
                        
                }
            }
            return DatosCliente;
        }
    }
}
