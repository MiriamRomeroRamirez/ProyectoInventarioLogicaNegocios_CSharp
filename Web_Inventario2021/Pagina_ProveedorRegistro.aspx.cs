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
    public partial class Pagina_Proveedor : System.Web.UI.Page
    {
        Logica_Proveedor obj_Provee = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                obj_Provee = new Logica_Proveedor(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["PROVEEDOR"] = obj_Provee;
            }
            else
            {//ya viene de un postback generado por el servidor
                obj_Provee = (Logica_Proveedor)Session["PROVEEDOR"];
            }
            string m = "";
            lblRespuesta.Text = m;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Proveedor nuevo = new Proveedor
            {
                Contacto = txtContacto.Text,
                CP = txtCPostal.Text,
                RFC = txtRFC.Text,
                Direccion = txtDireccion.Text,
                NombreProvee = txtNomProv.Text,
                PaginaWeb = txtPagWeb.Text,
                Telefono = txtTelefono.Text
            };
            obj_Provee.InsertarProveedor(nuevo, ref mensaje);
            lblRespuesta.Text = mensaje;
            txtContacto.Text = ""; txtCPostal.Text = ""; txtDireccion.Text = "";
            txtNomProv.Text = ""; txtPagWeb.Text = ""; txtRFC.Text = ""; txtTelefono.Text = "";
        }
    }
}