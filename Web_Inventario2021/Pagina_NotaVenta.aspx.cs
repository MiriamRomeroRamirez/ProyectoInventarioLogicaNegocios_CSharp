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
    public partial class Pagina_NotaVenta : System.Web.UI.Page
    {
        Logica_NotaVenta log_nota = null;
        Logica_Clientes log_clie = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {//si se carga por primera vez la pagina
                log_nota = new Logica_NotaVenta(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Nota"] = log_nota;
                log_clie = new Logica_Clientes(ConfigurationManager.ConnectionStrings["CadCon"].ConnectionString);
                Session["Cliente"] = log_clie;
            }
            else
            {//ya viene de un postback generado por el servidor
                log_nota = (Logica_NotaVenta)Session["Nota"];
                log_clie = (Logica_Clientes)Session["Cliente"];
            }
            string m = "";
            lblRespuesta.Text = m;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            NotaVenta nuevo = new NotaVenta
            {
                Fecha = $"2021-{ddlIDMes.SelectedValue}-{ddlIDMes.SelectedValue}",
                Folio = txtFolio.Text,
                F_Cliente = Convert.ToInt32(ddlIDClientes.SelectedValue)
            };
            log_nota.InsertarNota(nuevo, ref mensaje);
            lblRespuesta.Text = mensaje;
            txtFolio.Text = "";
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            List<Clientes> lista = null;
            string m = "";
            lista = log_clie.ListaClientes(ref m);
            ddlIDClientes.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                ddlIDClientes.Items.Add(
                    new ListItem(
                        lista[i].Id_Cliente + "." +
                        lista[i].RazonSocial,
                        lista[i].Id_Cliente.ToString()
                        ));
            }
            lblRespuesta.Text = m;
        }
    }
}