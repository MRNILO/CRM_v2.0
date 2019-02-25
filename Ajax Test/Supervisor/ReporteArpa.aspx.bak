<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="ReporteArpa.aspx.vb" Inherits="Ajax_Test.ReporteArpa" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
                    <a href="#">
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
                <i class="fa fa-file"></i>Fechas de Reporte
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-2">
                    <label>Fecha Inicial:</label>
                    <dx:ASPxDateEdit ID="deFechaInicial" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2">
                    <label>Fecha Final:</label>
                    <dx:ASPxDateEdit ID="deFechaFinal" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2" style="margin-top: 25px">
                    <dx:ASPxButton ID="btnBuscar" runat="server" Text="Buscar" Width="100%" Theme="MetropolisBlue">
                        <Image IconID="zoom_zoom_16x16office2013">
                        </Image>
                    </dx:ASPxButton>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Tabla de Datos ARPA
            </div>
            <div class="tools">
                <asp:Button ID="btnExcel" runat="server" Text="A Excel" CssClass="btn btn-sm green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_ArpaData" runat="server" Width="100%" Theme="MaterialCompact">
                    <SettingsAdaptivity>
                        <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                    </SettingsAdaptivity>

                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" />

                    <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                </dx:ASPxGridView>
            </div>
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
