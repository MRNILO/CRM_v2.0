<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrativo/Administrativo.Master" CodeBehind="AcumuladoAdm.aspx.vb" Inherits="Ajax_Test.AcumuladoAdm" %>

<%@ Register Assembly="DevExpress.XtraCharts.v18.2.Web, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
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
                    <a href="../Account/Logoff.aspx">
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
                <i class="fa fa-globe"></i>Fechas para reporte
            </div>
            <div class="tools">
            </div>
        </div>
        <dx:ASPxPivotGridExporter ID="PG_exporter" runat="server" ASPxPivotGridID="PG_AcumuladosClientes"></dx:ASPxPivotGridExporter>
        <div class="portlet-body">
            Fecha inicio:
            <br />
            <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="MetropolisBlue"></dx:ASPxDateEdit>
            Fecha Final:
            <br />
            <dx:ASPxDateEdit ID="dtp_final" runat="server" Theme="MetropolisBlue"></dx:ASPxDateEdit>
            <br />
            <asp:Button ID="btn_Generar" runat="server" Text="Generar" CssClass="btn green" />
            <br />
        </div>
    </div>


    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Acumulados 
            </div>
            <div class="tools">
                <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn btn-sm green" />

            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxPivotGrid ID="PG_AcumuladosClientes" runat="server" Theme="MetropolisBlue" Width="100%" EnableCallBacks="False"></dx:ASPxPivotGrid>
            </div>
        </div>
    </div>
    <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Grafico 
            </div>
            <div class="tools">
                <asp:Button ID="btn_actualiza" runat="server" Text="Actualiza Grafico" CssClass="btn btn-sm green" />


            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">
                <dxchartsui:WebChartControl ID="Wcc_grafico" runat="server" CssClass="img-responsive" CrosshairEnabled="True" DataSourceID="PG_AcumuladosClientes" Height="499px" SeriesDataMember="Series" Width="851px">
                    <DiagramSerializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                            </axisy>
                        </cc1:XYDiagram>
                    </DiagramSerializable>
                    <Legend MaxHorizontalPercentage="30" Visibility="False"></Legend>
                    <SeriesTemplate ArgumentDataMember="Arguments" ArgumentScaleType="Qualitative" ValueDataMembersSerializable="Values">
                        <viewserializable>
                            <cc1:SideBySideBarSeriesView ColorEach="True">
                            </cc1:SideBySideBarSeriesView>
                        </viewserializable>
                    </SeriesTemplate>
                </dxchartsui:WebChartControl>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
