<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_ClienteRegistro.aspx.cs" Inherits="Web_Inventario2021.Pagina_Cliente" %>
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
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Registro de clientes"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Razón social: "></asp:Label>
        <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Dirección: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Teléfono: "></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Código postal: "></asp:Label>
        <asp:TextBox ID="txtCPostal" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Correo: "></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnInsertar" runat="server" Text="Registrar cliente nuevo" OnClick="btnInsertar_Click" CssClass="EstiloBoton" />
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    

</asp:Content>
