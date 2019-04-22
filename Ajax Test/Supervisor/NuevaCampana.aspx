<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="NuevaCampana.aspx.vb" Inherits="Ajax_Test.NuevaCampana" %>

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

    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Nueva Campaña
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-4">
                        <label>Nombre Campaña</label>
                        <asp:TextBox ID="tb_NombreCampaña" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <label>Tipo Campaña</label>
                        <br />
                        <asp:DropDownList ID="cb_tiposCampañas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4">
                        <label>Medio Campaña</label>
                        <br />
                        <asp:DropDownList ID="cb_MedioCampañas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <label>Fecha Inicio:</label>
                        <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                    <div class="col-lg-2">
                        <label>Fecha final:</label>
                        <dx:ASPxDateEdit ID="dtp_final" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-12">
                        <label>Observaciones</label>
                        <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-sm btn-block blue" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
