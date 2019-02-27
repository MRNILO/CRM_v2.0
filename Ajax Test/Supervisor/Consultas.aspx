﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="Consultas.aspx.vb" Inherits="Ajax_Test.Consultas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Consultas 
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-3">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block blue" />
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block yellow" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:Button ID="btnExcel" runat="server" Text="Excel" Width="100%" Height="30px" CssClass="btn btn-sm btn-block green" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5" style="margin-top: 20px">
                    <label>Archivo de Consulta</label>
                    <dx:ASPxUploadControl ID="uplControlDAT" runat="server" UploadMode="Auto" Width="100%"
                        Theme="MaterialCompact" Font-Names="Microsoft Sans Serif" Font-Size="8pt" NullText="Archivo de Consulta"
                        ShowProgressPanel="True" ClientInstanceName="uploaderADD">
                        <ValidationSettings MaxFileCount="10" MaxFileCountErrorText="Has exedido el limite de archivos a subir">
                        </ValidationSettings>
                        <ClientSideEvents FilesUploadComplete="function(s, e) {
                                                                    PanelCarga.PerformCallback();	
                                                               }" />
                        <AdvancedModeSettings EnableMultiSelect="True">
                        </AdvancedModeSettings>
                    </dx:ASPxUploadControl>
                </div>
                <div class="col-lg-1" style="margin-top: 45px">
                    <dx:ASPxButton ID="btnCargar" runat="server" CssClass="btn btn-xs btn-default btn-block"
                        Width="100%" Height="30px" ToolTip="Cargar" AutoPostBack="False">
                        <ClientSideEvents Click="function(s, e) {
	                                                 uploaderADD.Upload();
                                                 }" />
                        <Image IconID="actions_up2_16x16">
                        </Image>
                    </dx:ASPxButton>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <label>
                        Consulta de Datos</label>
                    <dx:ASPxCallbackPanel ID="CallbackPanelCarga" runat="server" Width="100%" ClientInstanceName="PanelCarga"
                        Theme="MaterialCompact">
                        <PanelCollection>
                            <dx:PanelContent>
                                <asp:TextBox ID="txtBoxConsulta" runat="server" Width="100%" Height="200px" CssClass="form-control"
                                    TextMode="MultiLine"></asp:TextBox>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Resultados 
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <dx:ASPxGridView ID="grdViewConsulta" Width="100%" runat="server" Theme="Moderno"
                Font-Size="9pt" Font-Names="Microsoft Sans Serif">
                <Settings VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
