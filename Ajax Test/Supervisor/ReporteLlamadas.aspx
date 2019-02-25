<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="ReporteLlamadas.aspx.vb" Inherits="Ajax_Test.ReporteLlamadas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte de llamadas</h2>
    Fecha Inicio:
    <br />
    <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="MaterialCompact"></dx:ASPxDateEdit>
     Fecha Final:
    <br />
    <dx:ASPxDateEdit ID="dtp_final" runat="server" Theme="MaterialCompact"></dx:ASPxDateEdit>
    <br />
    <dx:ASPxButton ID="btn_generar" runat="server" Text="Generar" Theme="Material">
        <Image IconID="arrows_next_16x16">
        </Image>
    </dx:ASPxButton>

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Reporte de llamadas
            </div>
            	<div class="tools">
                    
    <dx:ASPxButton ID="btn_excel" runat="server" Text="Exportar a Excel" Theme="Material">
        <Image IconID="export_exporttoxls_16x16">
        </Image>
    </dx:ASPxButton>
            	</div>
        </div>
         
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxPivotGrid ID="PV_llamadas" runat="server" Theme="Material" ClientIDMode="AutoID" DataSourceID="LlamadasDS" Width="100%">
                    <Fields>
                        <dx:PivotGridField ID="fieldCantidad" Area="DataArea" AreaIndex="0" FieldName="Cantidad" Name="fieldCantidad">
                        </dx:PivotGridField>
                        <dx:PivotGridField ID="fieldEmpresa" AreaIndex="0" FieldName="Empresa" Name="fieldEmpresa">
                        </dx:PivotGridField>
                        <dx:PivotGridField ID="fieldNombreCliente" AreaIndex="1" FieldName="NombreCliente" Name="fieldNombreCliente">
                        </dx:PivotGridField>
                        <dx:PivotGridField ID="fieldrealizada" Area="ColumnArea" AreaIndex="0" FieldName="realizada" Name="fieldrealizada">
                        </dx:PivotGridField>
                        <dx:PivotGridField ID="fieldusuario" Area="RowArea" AreaIndex="0" FieldName="usuario" Name="fieldusuario">
                        </dx:PivotGridField>
                    </Fields>
        <optionsdata dataprocessingengine="LegacyOptimized" />
    </dx:ASPxPivotGrid>
                <asp:SqlDataSource ID="LlamadasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT
1 as Cantidad,
dbo.empresas.Empresa,
CONCAT(dbo.clientes.Nombre,' ',
dbo.clientes.ApellidoPaterno) AS NombreCliente,
IIF(dbo.llamadas.realizada=1,'SI','NO') as realizada,
dbo.usuarios.usuario

FROM
dbo.llamadas
INNER JOIN dbo.clientes ON dbo.llamadas.id_cliente = dbo.clientes.id_cliente
INNER JOIN dbo.empresas ON dbo.clientes.id_empresa = dbo.empresas.id_empresa
INNER JOIN dbo.usuarios ON dbo.llamadas.id_usuario = dbo.usuarios.id_usuario AND dbo.clientes.id_usuarioOriginal = dbo.usuarios.id_usuario
WHERE 
Fecha BETWEEN @finicio AND @ffinal
">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dtp_inicio" DefaultValue="0" Name="finicio" PropertyName="Value" />
                        <asp:ControlParameter ControlID="dtp_final" DefaultValue="0" Name="ffinal" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <dx:ASPxPivotGridExporter ID="PE_exporter" runat="server" ASPxPivotGridID="PV_llamadas">
                </dx:ASPxPivotGridExporter>
                </div>
            </div>
    </div>

    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
