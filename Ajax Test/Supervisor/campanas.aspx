<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="campanas.aspx.vb" Inherits="Ajax_Test.campanas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Opciones
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <a href="/Supervisor/NuevaCampana.aspx" class="btn btn-lg blue">Nueva Campaña</a>
        </div>
    </div>
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Campañas
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_campañas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_campaña" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre campaña" FieldName="campañaNombre" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="tipo Campaña" FieldName="tipoCampaña" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="fechaCreacion" FieldName="fechaCreacion" VisibleIndex="3">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn Caption="fechaInicio" FieldName="fechaInicio" VisibleIndex="4">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn Caption="fechaFinal" FieldName="fechaFinal" VisibleIndex="5">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="Observaciones" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
