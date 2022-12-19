<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_ComponenteVendido.aspx.cs" Inherits="Web_Inventario2021.Pagina_ComponenteVendido" %>
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
        <asp:Label ID="Label1" runat="server" Text="No. Serie: "></asp:Label>
        <asp:DropDownList ID="ddlNoSerie" runat="server" CssClass="EstiloBoton" OnSelectedIndexChanged="ddlNoSerie_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="EstiloBoton" OnClick="btnCargar_Click" />
        <asp:Button ID="btnCargar0" runat="server" Text="Mostrar" CssClass="EstiloBoton" OnClick="btnCargar0_Click" />
        <br />
        <br />
        <asp:GridView ID="gridDetalles" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowPaging="True" OnPageIndexChanging="gridDetalles_PageIndexChanging" PageSize="5">
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
    </div>
</asp:Content>
