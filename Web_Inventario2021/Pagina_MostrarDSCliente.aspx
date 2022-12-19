<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_MostrarDSCliente.aspx.cs" Inherits="Web_Inventario2021.Pagina_MostrarDSCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido">
        <section id="submenu">
                <nav>
                    <ul>
                        <li><a href="Pagina_ClienteRegistro.aspx">Registro</a></li>
                        <li><a href="Pagina_ClienteModificar.aspx">Actualizar</a></li>
                        <li><a href="Pagina_MostrarDSCliente.aspx">Tabla</a></li>
                    </ul>
                </nav>
            </section>
        <%--------------------------------------------------------%>
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Lista de clientes"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
</asp:Content>
