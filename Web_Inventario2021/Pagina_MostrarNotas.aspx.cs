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
    public partial class Pagina_MostrarNotas : System.Web.UI.Page
    {
        Logica_NotaVenta obj_Provee = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                obj_Provee = new Logica_NotaVenta(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["PROVEEDOR"] = obj_Provee;
            }
            else
            {//ya viene de un postback generado por el servidor
                obj_Provee = (Logica_NotaVenta)Session["PROVEEDOR"];
            }
            
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            List<NotaVenta> lista = null;
            string m = "";
            lista = obj_Provee.MandarListaNotas(ref m);
            ddlIDNotas.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlIDNotas.Items.Add(
                    new ListItem(
                        lista[i].Id_Nota + "." +
                        lista[i].Folio,
                        lista[i].Id_Nota.ToString()
                        ));
            }
        }

        protected void btnCargar0_Click(object sender, EventArgs e)
        {
            string m = "";
            GridView1.DataSource = obj_Provee.TablaNotaVenta(ref m, Convert.ToInt32(ddlIDNotas.SelectedValue));
            GridView1.DataBind();
            lblRespuesta.Text = m;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}