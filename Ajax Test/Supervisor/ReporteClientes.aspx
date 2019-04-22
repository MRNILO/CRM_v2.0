<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="ReporteClientes.aspx.vb" Inherits="Ajax_Test.ReporteClientes" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Reporte de clientes 
            </div>

        </div>
        <div class="portlet-body">
            Seleccione una fecha inicial:
            <br />
            <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="Moderno"></dx:ASPxDateEdit>
            <br />
            Seleccione una fecha final:
            <br />
            <dx:ASPxDateEdit ID="dtp_final" runat="server" Theme="Moderno"></dx:ASPxDateEdit>
            <br />
            <asp:Button ID="btn_generar" runat="server" Text="Buscar clientes" CssClass="btn btn-lg red" />
        </div>
    </div>
    <div class="portlet box blue-hoki">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Reporte de clientes 
            </div>
            <div class="tools">
                <asp:Button ID="btn_excel" runat="server" Text="Excel" CssClass="btn btn-sm green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GV_exporter" runat="server" GridViewID="GV_Clientes"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_Clientes" runat="server" Width="100%" Theme="Moderno"></dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
