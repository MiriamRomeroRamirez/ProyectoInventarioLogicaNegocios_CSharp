<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_NotaVenta.aspx.cs" Inherits="Web_Inventario2021.Pagina_NotaVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido">
        <section id="submenu">
                <nav>
                    <ul>
                        <li><a href="Pagina_NotaVenta.aspx">Crear</a></li>
                        <li><a href="Pagina_ContenidoNota.aspx">Contenido</a></li>
                        <li><a href="Pagina_MostrarNotas.aspx">Tabla</a></li>
                    </ul>
                </nav>
            </section>
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Notas de ventas"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Día: "></asp:Label>
        <asp:DropDownList ID="ddlIDia" runat="server" CssClass="EstiloBoton">
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Text="Mes: "></asp:Label>
        <asp:DropDownList ID="ddlIDMes" runat="server" CssClass="EstiloBoton">
            <asp:ListItem Value="01">Enero</asp:ListItem>
            <asp:ListItem Value="02">Febrero</asp:ListItem>
            <asp:ListItem Value="03">Marzo</asp:ListItem>
            <asp:ListItem Value="04">Abril</asp:ListItem>
            <asp:ListItem Value="05">Mayo</asp:ListItem>
            <asp:ListItem Value="06">Junio</asp:ListItem>
            <asp:ListItem Value="07">Julio</asp:ListItem>
            <asp:ListItem Value="08">Agosto</asp:ListItem>
            <asp:ListItem Value="09">Septiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Folio: "></asp:Label>
        <asp:TextBox ID="txtFolio" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="ID Cliente: "></asp:Label>
        <asp:DropDownList ID="ddlIDClientes" runat="server" CssClass="EstiloBoton">
        </asp:DropDownList>
        <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" CssClass="EstiloBoton" />
        <br />
        <br />
        <asp:Button ID="btnInsertar" runat="server" Text="Registrar nota" OnClick="btnInsertar_Click" CssClass="EstiloBoton" />
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
    </asp:Content>
