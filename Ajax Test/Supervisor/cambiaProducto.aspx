<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="cambiaProducto.aspx.vb" Inherits="Ajax_Test.cambiaProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="ActivityContent" ContentPlaceHolderID="MenuDeActividades" runat="server">
    <ul class="nav navbar-nav pull-right">
        <li class="dropdown dropdown-user">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                <span class="username username-hide-on-mobile">
                    <asp:Literal ID="lbl_nombre" runat="server"></asp:Literal>
                </span>
                <i class="fa fa-angle-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-menu-default">
                <li>
                    <a href="/Supervisor/MisDatos.aspx">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <li>
                  <a href="../Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Cambiar Producto
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            Nombre Corto:
            <br />
            <asp:TextBox ID="tb_NombreCorto" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            Nombre Completo:
            <br />
            <asp:TextBox ID="tb_NombreCompleto" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            Descripción:
            <br />
            <asp:TextBox ID="tb_descripcion" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            Precio Lista:
            <br />
            <asp:TextBox ID="PNormal" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            Precio descuento:
            <br />
            <asp:TextBox ID="PDesc" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            Categoria Producto:
            <br />
            <asp:DropDownList ID="cb_categorias" runat="server" CssClass="form-control"></asp:DropDownList>
            Observaciones:
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar Información" CssClass="btn btn-lg green" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
