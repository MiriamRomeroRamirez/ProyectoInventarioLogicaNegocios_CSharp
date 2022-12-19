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
    public partial class Pagina_ProveedorModificar : System.Web.UI.Page
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string m = "";
            Proveedor cambio = new Proveedor
            {
                Id_Provee = Convert.ToInt32(ddlListaProveedores.SelectedValue),
                NombreProvee = txtNomProv.Text,
                Contacto = txtContacto.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                PaginaWeb = txtPagWeb.Text,
                CP = txtCPostal.Text,
                RFC = txtRFC.Text
            };
            txtContacto.Text = ""; txtCPostal.Text = ""; txtDireccion.Text = "";
            txtNomProv.Text = ""; txtPagWeb.Text = ""; txtRFC.Text = ""; txtTelefono.Text = "";
            obj_Provee.ModificarProveedor(cambio, ref m);
            lblRespuesta.Text = m; 
        }

        protected void btnCargarProv_Click(object sender, EventArgs e)
        {
            string m = "";
            List<Proveedor> lista = null;
            lista = obj_Provee.ListaProveedores(ref m);
            ddlListaProveedores.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlListaProveedores.Items.Add(
                    new ListItem(
                        lista[i].Id_Provee + "." +
                        lista[i].NombreProvee,
                        lista[i].Id_Provee.ToString()
                        ));
            }
            lblRespuesta.Text = m;
        }
        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            Proveedor recibir = null;
            string m = "";
            recibir = obj_Provee.DevolverDatos(ref m, Convert.ToInt32(ddlListaProveedores.SelectedValue));
            txtContacto.Text = recibir.Contacto;
            txtCPostal.Text = recibir.CP;
            txtDireccion.Text = recibir.Direccion;
            txtNomProv.Text = recibir.NombreProvee;
            txtPagWeb.Text = recibir.PaginaWeb;
            txtRFC.Text = recibir.RFC;
            txtTelefono.Text = recibir.Telefono;
            lblRespuesta.Text = m;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            Proveedor cambio = new Proveedor
            {
                Id_Provee = Convert.ToInt32(ddlListaProveedores.SelectedValue)
            };
            txtContacto.Text = ""; txtCPostal.Text = ""; txtDireccion.Text = "";
            txtNomProv.Text = ""; txtPagWeb.Text = ""; txtRFC.Text = ""; txtTelefono.Text = "";
            obj_Provee.EliminarProveedor(cambio, ref m);
            lblRespuesta.Text = m;
        }
    }
}