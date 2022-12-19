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
    public partial class Pagina_FacturaCompra : System.Web.UI.Page
    {
        Logica_FacturaCompra log_fac = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                log_fac = new Logica_FacturaCompra(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Reiniciar"] = log_fac;
            }
            else
            {//ya viene de un postback generado por el servidor
                log_fac = (Logica_FacturaCompra)Session["Reiniciar"];
            }
            string m = "";
            gridFacturas.DataSource = log_fac.TablaFacturaCompra(ref m); 
            gridFacturas.DataBind();
            lblRespuesta.Text = m; 
        }

        protected void gridFacturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int numRenglon = Convert.ToInt16(e.CommandArgument.ToString());
            int idfac = Convert.ToInt16(gridFacturas.Rows[numRenglon].Cells[1].Text);
            Session["ID"] = idfac;
        }

        protected void btnCargarFacturas_Click(object sender, EventArgs e)
        {
            string m = "";
            int idfac = (int)Session["ID"];
            decimal total = (decimal)log_fac.TotalPrecioCompra(idfac, ref m);

            lblRespuesta1.Text = "$" + total.ToString();
        }
    }
}