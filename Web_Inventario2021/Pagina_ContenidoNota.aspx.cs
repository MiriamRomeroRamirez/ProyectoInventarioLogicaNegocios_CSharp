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
    public partial class Pagina_ContenidoNota : System.Web.UI.Page
    {
        
        Logica_ContenidoNota obj_ConNota = null;
        Logica_NotaVenta obj_NV = null;
        Logica_ContenidoFactura ob_CF = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                obj_ConNota = new Logica_ContenidoNota(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["CONOTA"] = obj_ConNota;
                obj_NV = new Logica_NotaVenta(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["NOTA"] = obj_NV;
                ob_CF = new Logica_ContenidoFactura(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["CONFAC"] = ob_CF;
            }
            else
            {//ya viene de un postback generado por el servidor
                obj_ConNota = (Logica_ContenidoNota)Session["CONOTA"];
                obj_NV = (Logica_NotaVenta)Session["NOTA"];
                ob_CF = (Logica_ContenidoFactura)Session["CONFAC"];
            }
            string m = "";
            lblRespuesta.Text = m;

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            ContenidoNota nuevo = new ContenidoNota
            {
                PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text),
                DiasGarantia = Convert.ToInt16(txtDiasGarant.Text),
                Extra = txtExtra.Text,
                F_ContFactura = Convert.ToInt32(ddlIDContFac.SelectedValue),
                F_Nota = Convert.ToInt32(ddlIDdeNota.SelectedValue)
            };
            obj_ConNota.InsertarContenidoNota(nuevo, ref mensaje);
            lblRespuesta.Text = mensaje;
            txtPrecioVenta.Text = ""; 
            txtExtra.Text = ""; txtDiasGarant.Text = "";
            lblRespuesta.Text = mensaje;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            string m = "";
            List<NotaVenta> lista = null;
            lista = obj_NV.MandarListaNotas(ref m);
            ddlIDdeNota.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlIDdeNota.Items.Add(
                    new ListItem(
                        lista[i].Id_Nota + "." +
                        lista[i].Folio,
                        lista[i].Id_Nota.ToString()
                        ));
            }
            lblRespuesta.Text = m;
        }

        protected void btnCargar0_Click(object sender, EventArgs e)
        {
            string m = "";
            List<ContenidoFactura> listaC = null;
            listaC = ob_CF.MandarListaIDs(ref m);
            ddlIDContFac.Items.Clear();
            for (int i = 0; i < listaC.Count; i++)
            {
                ddlIDContFac.Items.Add(
                    new ListItem(
                        listaC[i].Id_Cont + "." +
                        listaC[i].NumSerie,
                        listaC[i].Id_Cont.ToString()
                        ));
            }
            lblRespuesta.Text = m;

        }
    }
}