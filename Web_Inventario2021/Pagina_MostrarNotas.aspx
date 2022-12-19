<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_MostrarNotas.aspx.cs" Inherits="Web_Inventario2021.Pagina_MostrarNotas" %>
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
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Consultar Notas de Venta"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="ID Nota: "></asp:Label>
        <asp:DropDownList ID="ddlIDNotas" runat="server" CssClass="EstiloBoton">
        </asp:DropDownList>
        <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="EstiloBoton" OnClick="btnCargar_Click" />
        <asp:Button ID="btnCargar0" runat="server" Text="Mostrar" CssClass="EstiloBoton" OnClick="btnCargar0_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID_NOTA" HeaderText="ID NOTA" />
                <asp:BoundField DataField="FECHA" HeaderText="FECHA" />
                <asp:BoundField DataField="FOLIO" HeaderText="FOLIO" />
                <asp:BoundField DataField="PRECIOVENTA" DataFormatString="{0:N}" HeaderText="PRECIO DE VENTA" />
                <asp:BoundField DataField="PRECIOCOMPRA" DataFormatString="{0:N}" HeaderText="PRECIO DE COMPRA" />
                <asp:BoundField DataField="F_CONTFACTURA" HeaderText="ID CONT. FACTURA" />
                <asp:BoundField DataField="TOTAL" DataFormatString="{0:N}" HeaderText="TOTAL" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
</asp:Content>
