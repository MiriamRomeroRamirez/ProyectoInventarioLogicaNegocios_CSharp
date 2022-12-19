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
    public partial class Pagina_ComponenteVendido : System.Web.UI.Page
    {
        Logica_ComponenteVendido obj_CV = null;
        Logica_ContenidoFactura obj_CF = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                obj_CV = new Logica_ComponenteVendido(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Componente"] = obj_CV;
                obj_CF = new Logica_ContenidoFactura(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Factura"] = obj_CF;
            }
            else
            {//ya viene de un postback generado por el servidor
                obj_CV = (Logica_ComponenteVendido)Session["Componente"];
                obj_CF = (Logica_ContenidoFactura)Session["Factura"];
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            List<ContenidoFactura> lista = null;
            string m = "";
            lista = obj_CF.MandarListaIDs(ref m);
            ddlNoSerie.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlNoSerie.Items.Add(
                    new ListItem(
                        lista[i].Id_Cont + "." +
                        lista[i].NumSerie,
                        lista[i].NumSerie
                        ));
            }
        }

        protected void ddlNoSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCargar0_Click(object sender, EventArgs e)
        {
            string m = "";
            gridDetalles.DataSource = obj_CV.TablaComponenteVendido(ref m, ddlNoSerie.SelectedValue);
            gridDetalles.DataBind();
        }

        protected void gridDetalles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDetalles.PageIndex = e.NewPageIndex;
            gridDetalles.DataBind();
        }
    }
}