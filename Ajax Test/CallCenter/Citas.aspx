<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="Citas.aspx.vb" Inherits="Ajax_Test.Citas" %>

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
            <asp:SqlDataSource ID="CitasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>"
                SelectCommand="SELECT
                                  clientes.Nombre,
                                  clientes.ApellidoPaterno,
                                  clientes.ApellidoMaterno,
                                  clientes.Email,
                                  CitasClientes.FechaCita,
                                  etapasCliente.Descripcion AS Etapa,
                                  clientes.NSS,
                                  clientes.CURP,
                                  clientes.ranking,
                                  clientes.NPersona,
                                  clientes.NContrato,
                                  clientes.RFC,
                                  clientes.NHijos,
                                  clientes.IngresosPersonales,
                                  usuarios.nombre As NombreUsuario,
                                  usuarios.apellidoPaterno as ApUsuario,
                                  usuarios.apellidoMaterno as ApMUsuario
                               FROM
                                  CitasClientes 
                               INNER JOIN clientes ON CitasClientes.Id_Cliente = clientes.id_cliente
                               INNER JOIN etapasCliente ON clientes.id_etapaActual = etapasCliente.id_etapa
                               INNER JOIN usuarios ON CitasClientes.Id_Usuario = usuarios.id_usuario
                               WHERE CitasClientes.Origen = 'CALL CENTER'
                               ORDER BY
                               Etapa ASC"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
