<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_ContenidoNota.aspx.cs" Inherits="Web_Inventario2021.Pagina_ContenidoNota" %>
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
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Formulario de Notas"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Precio venta: "></asp:Label>
        <asp:TextBox ID="txtPrecioVenta" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Días garantía: "></asp:Label>
        <asp:TextBox ID="txtDiasGarant" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Extra: "></asp:Label>
        <asp:TextBox ID="txtExtra" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="ID de Nota: "></asp:Label>
        <asp:DropDownList ID="ddlIDdeNota" runat="server" CssClass="EstiloBoton">
        </asp:DropDownList>
        <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" CssClass="EstiloBoton" />
        <br />
        <asp:Label ID="Label9" runat="server" Text="ID contenido de factura: "></asp:Label>
        <asp:DropDownList ID="ddlIDContFac" runat="server" CssClass="EstiloBoton">
        </asp:DropDownList>
        <asp:Button ID="btnCargar0" runat="server" Text="Cargar" OnClick="btnCargar0_Click" CssClass="EstiloBoton" />
        <br />
        <br />
        <asp:Button ID="btnInsertar" runat="server" Text="Guardar detalles" OnClick="btnInsertar_Click" CssClass="EstiloBoton" />
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
    </asp:Content>
