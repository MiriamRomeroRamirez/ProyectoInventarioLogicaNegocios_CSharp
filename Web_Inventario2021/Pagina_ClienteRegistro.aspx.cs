using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Class_LogicaNegocios;
using Class_EntidadesInventario2021;

namespace Web_Inventario2021
{
    public partial class Pagina_Cliente : System.Web.UI.Page
    {
        Logica_Clientes log_clie = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                log_clie = new Logica_Clientes(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Reiniciar"] = log_clie;
            }
            else
            {//ya viene de un postback generado por el servidor
                log_clie = (Logica_Clientes)Session["Reiniciar"];
            }
            string m = "";
            lblRespuesta.Text = m;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Clientes nuevo_registro = new Clientes
            {
                RazonSocial = txtRazonSocial.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                CP = txtCPostal.Text,
                Correo = txtCorreo.Text
            };
            log_clie.InsertarCliente(nuevo_registro, ref mensaje);
            lblRespuesta.Text = mensaje; txtRazonSocial.Text = ""; txtDireccion.Text = "";
            txtTelefono.Text = ""; txtCPostal.Text = ""; txtCorreo.Text = "";
        }
    }
}