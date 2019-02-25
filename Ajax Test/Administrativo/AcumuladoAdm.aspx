<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrativo/Administrativo.Master" CodeBehind="AcumuladoAdm.aspx.vb" Inherits="Ajax_Test.AcumuladoAdm" %>
<%@ Register Assembly="DevExpress.XtraCharts.v18.1.Web, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
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
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                    <legend maxhorizontalpercentage="30" visibility="False"></legend>
                    <seriestemplate argumentdatamember="Arguments" argumentscaletype="Qualitative" valuedatamembersserializable="Values">
                        <viewserializable>
                            <cc1:SideBySideBarSeriesView ColorEach="True">
                            </cc1:SideBySideBarSeriesView>
                        </viewserializable>
                    </seriestemplate>
                </dxchartsui:WebChartControl>
                </div>
            </div>
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
