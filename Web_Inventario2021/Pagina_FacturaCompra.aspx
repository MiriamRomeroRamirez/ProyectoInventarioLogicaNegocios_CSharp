<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_FacturaCompra.aspx.cs" Inherits="Web_Inventario2021.Pagina_FacturaCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido">
        <section id="submenu">
                <nav>
                    <ul>
                        <li><a href="Pagina_ComponenteVendido.aspx">Serie</a></li>
                        <li><a href="Pagina_FacturaCompra.aspx">Factura</a></li>
                    </ul>
                </nav>
            </section>
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Detalles de componente vendido"></asp:Label>
        <br />
        <br />
        
        <br />
        <asp:GridView ID="gridFacturas" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gridFacturas_RowCommand" Width="100%">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:Button ID="btnCargarFacturas" runat="server" Text="Mostrar TOTAL" CssClass="EstiloBoton" OnClick="btnCargarFacturas_Click" />
        <br />
        <asp:Label ID="lblRespuesta0" runat="server">TOTAL: </asp:Label>
        <asp:Label ID="lblRespuesta1" runat="server" BackColor="White" ForeColor="Maroon"></asp:Label>
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
</asp:Content>
