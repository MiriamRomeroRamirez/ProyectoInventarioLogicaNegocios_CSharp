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
    public class Logica_Proveedor
    {
        AccesoSQL OpProvee_SQL = null;
        public Logica_Proveedor(string CadCon)
        {
            OpProvee_SQL = new AccesoSQL(CadCon);
        }
        public object DevolverUnSoloDato(ref string mensaje)
        {
            string consulta = "SELECT MAX(ID_PROVEE) FROM PROVEEDOR";
            string m = "";
            object Resp = OpProvee_SQL.Mandar1RespConsult(consulta, OpProvee_SQL.AbrirConexion(ref m), ref m);
            if (Resp == null)
            {
                Resp = 1;
            }
            else
            {
                consulta = "SELECT MAX(ID_PROVEE)+1 FROM PROVEEDOR";
                Resp = OpProvee_SQL.Mandar1RespConsult(consulta, OpProvee_SQL.AbrirConexion(ref m), ref m);
            }
            mensaje = m;
            return Resp;
        }
        public Boolean InsertarProveedor(Proveedor nuevo, ref string mensaje)
        {
            string insertar = "";
            insertar = $"INSERT INTO PROVEEDOR ([NombreProvee],[Contacto],[Direcccion]," +
                $"[Telefono],[PaginaWeb],[RFC],[CP]) " +
                $"VALUES(@NOM, @CONT, @DIREC, @TEL, @WEB, @RFC, @CODP);";

            Boolean salida = false;
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("NOM", SqlDbType.VarChar, 250),
                new SqlParameter("CONT", SqlDbType.VarChar, 200),
                new SqlParameter("DIREC", SqlDbType.VarChar, 250),
                new SqlParameter("TEL", SqlDbType.VarChar, 20),
                new SqlParameter("WEB", SqlDbType.VarChar, 150),
                new SqlParameter("RFC", SqlDbType.VarChar, 50),
                new SqlParameter("CODP", SqlDbType.VarChar, 50)
            };
            arregloPars[0].Value = nuevo.NombreProvee;
            arregloPars[1].Value = nuevo.Contacto;
            arregloPars[2].Value = nuevo.Direccion;
            arregloPars[3].Value = nuevo.Telefono;
            arregloPars[4].Value = nuevo.PaginaWeb;
            arregloPars[5].Value = nuevo.RFC;
            arregloPars[6].Value = nuevo.CP;

            string h = "";
            salida = OpProvee_SQL.OperacionModificacionBD(insertar, OpProvee_SQL.AbrirConexion(ref h), ref h, arregloPars);
            mensaje = h;
            return salida;
        }

        public Boolean ModificarProveedor(Proveedor cambio, ref string mensaje)
        {
            string modificar =
                $"UPDATE [dbo].[PROVEEDOR]" +
                $" SET [NOMBREPROVEE] = @NOMPROVE," +
                $"[CONTACTO] = @CONT," +
                $"[DIRECCCION] = @DIREC," +
                $"[TELEFONO] = @TEL," +
                $"[PAGINAWEB] = @WEB," +
                $"[RFC] = @RFCS," +
                $"[CP] = @CODP" +
                $" WHERE [ID_PROVEE] = @ID;";
            Boolean salida = false;
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("ID", SqlDbType.Int),
                new SqlParameter("NOMPROVE", SqlDbType.VarChar, 250),
                new SqlParameter("CONT", SqlDbType.VarChar, 200),
                new SqlParameter("DIREC", SqlDbType.VarChar, 250),
                new SqlParameter("TEL", SqlDbType.VarChar, 20),
                new SqlParameter("WEB", SqlDbType.VarChar, 150),
                new SqlParameter("RFCS", SqlDbType.VarChar, 50),
                new SqlParameter("CODP", SqlDbType.VarChar, 50)
            };
            arregloPars[0].Value = cambio.Id_Provee;
            arregloPars[1].Value = cambio.NombreProvee;
            arregloPars[2].Value = cambio.Contacto;
            arregloPars[3].Value = cambio.Direccion;
            arregloPars[4].Value = cambio.Telefono;
            arregloPars[5].Value = cambio.PaginaWeb;
            arregloPars[6].Value = cambio.RFC;
            arregloPars[7].Value = cambio.CP;
            string m = "";
            salida = OpProvee_SQL.OperacionModificacionBD(modificar, OpProvee_SQL.AbrirConexion(ref m), ref m, arregloPars);
            mensaje = m;
            return salida;
        }
        public List<Proveedor> ListaProveedores(ref string mensaje)
        {
            string consulta = "SELECT * FROM PROVEEDOR";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            List<Proveedor> Clie
                = new List<Proveedor>();
            cntemp = OpProvee_SQL.AbrirConexion(ref mensaje);
            contenedor = OpProvee_SQL.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    Clie.Add(
                        new Proveedor
                        {
                            Id_Provee = (int)contenedor[0],
                            NombreProvee = (string)contenedor[1]
                        });
                }
            }
            return Clie;
        }

        public Boolean EliminarProveedor(Proveedor elimi, ref string mensaje)
        {
            string eliminar = "DELETE FROM [PROVEEDOR] WHERE [ID_PROVEE] = @ID_";
            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("ID_", SqlDbType.Int)
            };
            arregloPars[0].Value = elimi.Id_Provee;
            Boolean salida = false;
            string m = "";
            salida = OpProvee_SQL.OperacionModificacionBD(eliminar, OpProvee_SQL.AbrirConexion(ref m), ref m, arregloPars);
            mensaje = m;
            return salida;
        }

        public DataTable TablaProveedores(ref string mensaje)
        {
            string consulta = "SELECT * FROM PROVEEDOR";
            DataTable salidaDT = null;
            DataSet contenedorDS = null;
            contenedorDS = OpProvee_SQL.ConsultasDS(consulta, OpProvee_SQL.AbrirConexion(ref mensaje), ref mensaje);
            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
        public Proveedor DevolverDatos(ref string mensaje, int id)
        {
            Proveedor DatosProveedor = null;
            string consulta = "SELECT * FROM PROVEEDOR WHERE ID_PROVEE = " + id;
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;

            cntemp = OpProvee_SQL.AbrirConexion(ref mensaje);
            contenedor = OpProvee_SQL.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor.HasRows)
            {
                while (contenedor.Read())
                {
                    DatosProveedor = new Proveedor
                    {
                        Id_Provee = (int)contenedor[0],
                        NombreProvee = (string)contenedor[1],
                        Contacto = (string)contenedor[2],
                        Direccion = (string)contenedor[3],
                        Telefono = (string)contenedor[4],
                        PaginaWeb = (string)contenedor[5],
                        RFC = (string)contenedor[6],
                        CP = (string)contenedor[7]
                    };

                }
            }
            return DatosProveedor;
        }
    }
}

