<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SupervisorMty/SupervisorMty.master" CodeBehind="DetalleObservaciones.aspx.vb" Inherits="Ajax_Test.DetalleObservacionesMty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <style>
        .ui-autocomplete-loading {
            background: white url("/assets/imagenes/load.gif") right center no-repeat;
        }
    </style>
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
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Observaciones del Cliente
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_Observaciones" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>

    <script>
        $(function () {
            function log(message) {
                $("<div>").text(message).prependTo("#log");
                $("#log").scrollTop(0);
            }
        });
    </script>
</asp:Content>
