using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Class_LogicaNegocios;
using Class_EntidadesInventario2021;

namespace Web_Inventario2021
{
    public partial class Pagina_ClienteModificar : System.Web.UI.Page
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
        }

        protected void btnCargarClientes_Click(object sender, EventArgs e)
        {
            List<Clientes> lista = null;
            string m = "";
            lista = log_clie.ListaClientes(ref m);
            ddlListaClientes.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlListaClientes.Items.Add(
                    new ListItem(
                        lista[i].Id_Cliente + "." +
                        lista[i].RazonSocial,
                        lista[i].Id_Cliente.ToString()
                        ));
            }
            lblRespuesta.Text = m;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Clientes modificacion = new Clientes
            {
                Id_Cliente = Convert.ToInt32(ddlListaClientes.SelectedValue)
            };
            log_clie.EliminarCliente(modificacion, ref mensaje);
            lblRespuesta.Text = mensaje;
            txtRazonSocial.Text = ""; txtTelefono.Text = ""; txtDireccion.Text = "";
            txtCPostal.Text = ""; txtCorreo.Text = "";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Clientes modificacion = new Clientes
            {
                Id_Cliente = Convert.ToInt32(ddlListaClientes.SelectedValue),
                RazonSocial = txtRazonSocial.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                CP = txtCPostal.Text,
                Correo = txtCorreo.Text
            };
            log_clie.ModificarCliente(modificacion, ref mensaje);
            lblRespuesta.Text = mensaje;
            txtRazonSocial.Text = ""; txtTelefono.Text = ""; txtDireccion.Text = "";
            txtCPostal.Text = ""; txtCorreo.Text = "";
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            Clientes RecibirDatos = null;
            string m = "";
            RecibirDatos = log_clie.DevolverDatos(ref m, Convert.ToInt32(ddlListaClientes.SelectedValue));
            txtRazonSocial.Text = RecibirDatos.RazonSocial;
            txtDireccion.Text = RecibirDatos.Direccion;
            txtTelefono.Text = RecibirDatos.Telefono;
            txtCPostal.Text = RecibirDatos.CP;
            txtCorreo.Text = RecibirDatos.Correo;
            lblRespuesta.Text = m;
        }
    }
}