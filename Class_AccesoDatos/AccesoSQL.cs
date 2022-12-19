using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Class_AccesoDatos
{
    public class AccesoSQL
    {
        private string cadconexion;
        public AccesoSQL(string cadenaDB)
        {
            cadconexion = cadenaDB;
        }
        public SqlConnection AbrirConexion(ref string mensaje)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = cadconexion;
            try
            {
                conexion.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conexion = null;
                mensaje = "ERROR" + r.Message;
            }
            return conexion;
        }

        public Boolean OperacionModif_ElimBD(string sentenciaSQL, SqlConnection cnAb, ref string msj)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                carrito = new SqlCommand();
                //se carga la operacion sql en el carrito
                carrito.CommandText = sentenciaSQL;
                carrito.Connection = cnAb;
                try
                {
                    carrito.ExecuteNonQuery();
                    msj = "Modificación a la BD CORRECTA";
                    salida = true;
                }
                catch (Exception s)
                {
                    msj = "Error: " + s.Message;
                    salida = false;
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            else
            {
                msj = "No hay conexión abierta a la BD";
                salida = false;
            }
            return salida;
        }

        public object Mandar1RespConsult(string sentenciaSQL, SqlConnection cnAb, ref string msj)
        {
            SqlCommand carrito = null;
            object resp = null;
            if (cnAb != null)
            {
                carrito = new SqlCommand();
                //se carga la operacion sql en el carrito
                carrito.CommandText = sentenciaSQL;
                carrito.Connection = cnAb;
                //se asignan los parametros
                try
                {
                    resp = carrito.ExecuteScalar();
                    msj = "Se encontro una respuesta";
                    return resp;
                }
                catch (Exception s)
                {
                    msj = "Error: " + s.Message;
                    resp = null;
                    return resp;
                }
            }
            else
            {
                msj = "No hay conexión abierta a la BD";
                resp = null;
            }
            cnAb.Close();
            cnAb.Dispose(); 
            return resp;
        }

        public Boolean OperacionModificacionBD(string sentenciaSQL, SqlConnection cnAb, ref string msj, SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                carrito = new SqlCommand();
                //se carga la operacion sql en el carrito
                carrito.CommandText = sentenciaSQL;
                carrito.Connection = cnAb;
                //se asignan los parametros
                foreach (SqlParameter w in parametros)
                {
                    carrito.Parameters.Add(w);
                }
                try
                {
                    carrito.ExecuteNonQuery();
                    msj = "Modificación a la BD CORRECTA";
                    salida = true;
                }
                catch (Exception s)
                {
                    msj = "Error: " + s.Message;
                    salida = false;
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            else
            {
                msj = "No hay conexión abierta a la BD";
                salida = false;
            }
            return salida;
        }

        public DataSet ConsultasDS(string querySQL, SqlConnection cnAb, ref string msj)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();
            if (cnAb == null)
            {
                msj = "No hay conexión a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySQL;
                carrito.Connection = cnAb;
                //se va a subir el carrito al trailer
                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;
                //se manda el trailer al servidor
                try
                {
                    trailer.Fill(DS_salida, "Consulta");
                    msj = "Consulta correcta DataSet";
                }
                catch (Exception a)
                {
                    DS_salida = null;
                    msj = "Error: " + a.Message;
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            return DS_salida;
        }

        public SqlDataReader ConsultaReader(string querySQL, SqlConnection cnAb, ref string msj)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (cnAb == null)
            {
                msj = "No hay conexión a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySQL;
                carrito.Connection = cnAb;
                try
                {
                    contenedor = carrito.ExecuteReader();
                    msj = "Consulta correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    msj = "Error: " + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDS(string querySQL, SqlConnection cnAb, ref string msj, ref DataSet dasl, string nomconsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;
            if (cnAb == null)
            {
                msj = "No hay conexión a la BD";
                salida = false;
            }
            else
            {
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = querySQL;
                    carrito.Connection = cnAb;
                    //se va a subir el carrito al trailer
                    using (trailer = new SqlDataAdapter())
                    {
                        trailer.SelectCommand = carrito;
                        //se manda el trailer al servidor
                        try
                        {
                            trailer.Fill(dasl, nomconsulta);
                            msj = "Consulta correcta DataSet";
                        }
                        catch (Exception a)
                        {
                            msj = "Error: " + a.Message;
                        }
                        cnAb.Close();
                        cnAb.Dispose();
                    }
                }
            }
            return salida;
        }
    }
}
