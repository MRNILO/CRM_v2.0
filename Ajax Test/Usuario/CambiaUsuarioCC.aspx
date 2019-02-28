<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="CambiaUsuarioCC.aspx.vb" Inherits="Ajax_Test.CambiaUsuarioCC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">

    <link href="/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
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
                    <a href="/Usuario/MisDatos.aspx">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <li>
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Cambiar de usuario a un cliente
            </div>

        </div>
        <div class="portlet-body">
            Seleccione un Cliente
            <br />
            <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me"></asp:DropDownList>
            <br />
            Seleccione un usuario a asignar este cliente:
            <br />
            <asp:DropDownList ID="cb_usuarios" runat="server" CssClass="form-control select2me"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn green" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>

    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
