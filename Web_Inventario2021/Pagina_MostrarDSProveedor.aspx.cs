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
    public partial class Pagina_MostrarDSClientes : System.Web.UI.Page
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
            gridProveedores.DataSource = obj_Provee.TablaProveedores(ref m);
            gridProveedores.DataBind();
            lblRespuesta.Text = m; 
        }


        protected void gridProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProveedores.PageIndex = e.NewPageIndex;
            gridProveedores.DataBind();
        }
    }
}