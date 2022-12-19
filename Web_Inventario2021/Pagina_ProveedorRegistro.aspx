<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_ProveedorRegistro.aspx.cs" Inherits="Web_Inventario2021.Pagina_Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido">
        <section id="submenu">
                <nav>
                    <ul>
                        <li><a href="Pagina_ProveedorRegistro.aspx">Registro</a></li>
                        <li><a href="Pagina_ProveedorModificar.aspx">Actualizar</a></li>
                        <li><a href="Pagina_MostrarDSProveedor.aspx">Tabla</a></li>
                    </ul>
                </nav>
            </section>
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Registro de proveedores"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nombre proveedor: "></asp:Label>
        <asp:TextBox ID="txtNomProv" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Contacto: "></asp:Label>
        <asp:TextBox ID="txtContacto" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Dirección: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Teléfono: "></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Página Web: "></asp:Label>
        <asp:TextBox ID="txtPagWeb" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="RFC: "></asp:Label>
        <asp:TextBox ID="txtRFC" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Código postal: "></asp:Label>
        <asp:TextBox ID="txtCPostal" runat="server" CssClass="cajaCrear"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnInsertar" runat="server" Text="Registrar proveedor" CssClass="EstiloBoton" OnClick="btnInsertar_Click" />
        <br />
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
    </div>
</asp:Content>
