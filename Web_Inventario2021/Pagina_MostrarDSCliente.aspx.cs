using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Class_LogicaNegocios;
using Class_EntidadesInventario2021;

namespace Web_Inventario2021
{
    public partial class Pagina_MostrarDSCliente : System.Web.UI.Page
    {
        Logica_Clientes log_clie = null;
        string mensaje = "";
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
            GridView1.DataSource = log_clie.TablaClientes(ref mensaje);
            GridView1.DataBind();
            lblRespuesta.Text = mensaje;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}