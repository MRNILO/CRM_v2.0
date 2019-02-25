<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="Citas.aspx.vb" Inherits="Ajax_Test.Citas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <div class="portlet-body">
           
            <div class="table-responsive">
                <br />
                <dx:ASPxGridViewExporter ID="GE_Citas" runat="server">
                </dx:ASPxGridViewExporter>
                <dx:ASPxButton ID="btn_exportar" runat="server" Text="Exportar a excel" Theme="Material">
                    <Image IconID="actions_loadfrom_16x16">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxGridView ID="GV_Citas" runat="server" Theme="MaterialCompact" AutoGenerateColumns="False" DataSourceID="CitasDS" Width="100%">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApellidoPaterno" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApellidoMaterno" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaCita" VisibleIndex="4">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Etapa" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NSS" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CURP" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ranking" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NPersona" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NContrato" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="RFC" VisibleIndex="11">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NHijos" VisibleIndex="12">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="IngresosPersonales" VisibleIndex="13">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NombreUsuario" VisibleIndex="14">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApUsuario" VisibleIndex="15">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApMUsuario" VisibleIndex="16">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="CitasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT
dbo.clientes.Nombre,
dbo.clientes.ApellidoPaterno,
dbo.clientes.ApellidoMaterno,
dbo.clientes.Email,
dbo.CitasCall.FechaCita,
dbo.etapasCliente.Descripcion AS Etapa,
dbo.clientes.NSS,
dbo.clientes.CURP,
dbo.clientes.ranking,
dbo.clientes.NPersona,
dbo.clientes.NContrato,
dbo.clientes.RFC,
dbo.clientes.NHijos,
dbo.clientes.IngresosPersonales,
dbo.usuarios.nombre As NombreUsuario,
dbo.usuarios.apellidoPaterno as ApUsuario,
dbo.usuarios.apellidoMaterno as ApMUsuario

FROM
dbo.CitasCall
INNER JOIN dbo.clientes ON dbo.CitasCall.id_cliente = dbo.clientes.id_cliente
INNER JOIN dbo.etapasCliente ON dbo.clientes.id_etapaActual = dbo.etapasCliente.id_etapa
INNER JOIN dbo.usuarios ON dbo.CitasCall.id_usuarioCC = dbo.usuarios.id_usuario
ORDER BY
Etapa ASC"></asp:SqlDataSource>
                </div>
           </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
