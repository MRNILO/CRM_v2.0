<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Prospectador/Prospectador.Master" CodeBehind="Clientes.aspx.vb" Inherits="Ajax_Test.Clientes_Prospectador" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-2">
            <a href="NuevoCliente.aspx" class="btn btn-lg btn-sm btn-block blue"><strong>NUEVO CLIENTE</strong></a>
        </div>
    </div>
    <div class="portlet box purple" style="margin-top: 15px">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-search"></i>Todos los clientes
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <dx:ASPxGridViewExporter ID="GE_Clientes" runat="server" GridViewID="GV_Clientes">
            </dx:ASPxGridViewExporter>
            <div class="row">
                <div class="col-lg-2">
                    <dx:ASPxButton ID="btn_exportar" runat="server" Text="Exportar a Excel" Width="100%" Theme="MaterialCompact">
                        <Image IconID="actions_loadfrom_16x16">
                        </Image>
                    </dx:ASPxButton>
                </div>
            </div>
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Clientes" runat="server" AutoGenerateColumns="False" DataSourceID="ClientesDS" KeyFieldName="id_cliente" Theme="MaterialCompact" ClientInstanceName="TablaClientes"
                    Font-Size="9pt">
                    <ClientSideEvents RowDblClick="function(s, e) {
	                                               TablaClientes.PerformCallback(s.GetFocusedRowIndex());
                                               }" />
                    <SettingsAdaptivity>
                        <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                    </SettingsAdaptivity>

                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsBehavior AllowFocusedRow="True" />
                    <SettingsSearchPanel Visible="True" />

                    <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_cliente" VisibleIndex="1" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApellidoPaterno" VisibleIndex="3">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApellidoMaterno" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NombreCorto" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NSS" VisibleIndex="7">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CURP" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="fechaNacimiento" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="ranking" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NPersona" VisibleIndex="11">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NContrato" VisibleIndex="12">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="RFC" VisibleIndex="13">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="NHijos" VisibleIndex="14">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="IngresosPersonales" VisibleIndex="15">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Fraccionamiento" VisibleIndex="16">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cita/Visita" FieldName="id_cliente" VisibleIndex="0">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;CitaCte.aspx?id={0}&quot; class=&quot;btn btn-sm green&quot;&gt;Cita&lt;/a&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
            <asp:SqlDataSource ID="ClientesDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="ObtenerClientesCC" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

