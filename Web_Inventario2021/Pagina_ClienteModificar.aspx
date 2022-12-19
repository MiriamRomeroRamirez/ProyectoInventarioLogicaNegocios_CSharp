<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pagina_ClienteModificar.aspx.cs" Inherits="Web_Inventario2021.Pagina_ClienteModificar" %>
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
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Modificaciones para registros de clientes"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblListaClientes" runat="server" Text="Lista clientes: "></asp:Label>
        <asp:DropDownList ID="ddlListaClientes" runat="server" CssClass="EstiloBoton">
        </asp:DropDownList>
        <asp:Button ID="btnCargarClientes" runat="server" Text="Cargar" OnClick="btnCargarClientes_Click" CssClass="EstiloBoton" />
        <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" CssClass="EstiloBoton" />
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
        <asp:Label ID="lblRespuesta" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnModificar" runat="server" Text="Guardar cambios" OnClick="btnModificar_Click" CssClass="EstiloBoton" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar registro" OnClick="btnEliminar_Click" CssClass="EstiloBoton" />
    </div>
</asp:Content>
