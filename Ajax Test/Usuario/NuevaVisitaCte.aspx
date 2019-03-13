﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="NuevaVisitaCte.aspx.vb" Inherits="Ajax_Test.NuevaVisitaCte" %>

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

            <ul class="dropdown-menu dropdown-menu-dranefault">
                <li>
                    <a href="/Usuario/MisDatos.aspx">
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
    <div class="portlet box blue-hoki">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Cita
            </div>
        </div>
        <div class="portlet-body">
            <div class="row" style="margin-top: 5px">
                <div class="col-lg-2">
                    <label><strong>Origen:</strong></label><br />
                    <asp:TextBox ID="tb_origen" runat="server" CssClass="form-control">AGENTE MOVIL</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-4">
                        <label><strong>Asesor Asignado:</strong></label><br />
                        <asp:TextBox ID="txBox_AsesorAsignado" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Vigencia De:</strong></label><br />
                        <dx:ASPxDateEdit ID="dtp_finicio" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>A:</strong></label><br />
                        <dx:ASPxDateEdit ID="dtp_ffinal" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Fecha Cita:</strong></label><br />
                        <dx:ASPxDateEdit ID="dtp_fechaCita" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-2">
                        <label><strong>Medio:</strong></label><br />
                        <dx:ASPxComboBox ID="cmBoxMedio" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True"></dx:ASPxComboBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Lugar Contacto:</strong></label><br />
                        <dx:ASPxComboBox ID="cmBoxCampana" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True"></dx:ASPxComboBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Medio 2:</strong></label>
                        <asp:TextBox ID="tb_TipoCampana" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-4">
                        <label><strong>Proyacto que visitará:</strong></label><br />
                        <asp:DropDownList ID="cb_fraccinamientos" runat="server" CssClass="form-control" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Modelo:</strong></label><br />
                        <asp:DropDownList ID="cb_modelos" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 20px">
                <div class="col-lg-2 pull-right">
                    <dx:ASPxButton ID="btn_asignaCita" runat="server" Text="Asigna Cita" Theme="Moderno" Width="100%">
                        <Image IconID="actions_save_16x16devav">
                        </Image>
                    </dx:ASPxButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>