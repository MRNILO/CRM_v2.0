<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="NuevaCita.aspx.vb" Inherits="Ajax_Test.NuevaCita" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
    <ul class="nav navbar-nav pull-right">
        <!-- BEGIN USER LOGIN DROPDOWN -->
        <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
        <li class="dropdown dropdown-user">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                <%--<img alt="" class="img-circle" src="/assets/admin/layout/img/avatar3_small.jpg"/>--%>
                <span class="username username-hide-on-mobile">
                    <asp:Literal ID="lbl_nombre" runat="server"></asp:Literal>
                </span>
                <i class="fa fa-angle-down"></i>
            </a>

            <ul class="dropdown-menu dropdown-menu-default">
                <li>
                    <a href="/Usuario/MisDatos.aspx">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <%--	<li>
							<a href="page_calendar.html">
							<i class="icon-calendar"></i> Mi Calendario </a>
						</li>
						<li>
							<a href="inbox.html">
							<i class="icon-envelope-open"></i> Mis Mensajes <span class="badge badge-danger">
							3 </span>
							</a>
						</li>
						
						<li class="divider">
						</li>				--%>
                <li>
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
        <!-- END USER LOGIN DROPDOWN -->
        <!-- BEGIN QUICK SIDEBAR TOGGLER -->
        <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
        <!-- END QUICK SIDEBAR TOGGLER -->
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-search"></i>Nueva Cita
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-12">
                    Seleccione un cliente:
                    <br />
                    <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me"></asp:DropDownList>
                </div>
            </div>
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-2">
                    ¿Qué día?
                    <br />
                    <dx:ASPxDateEdit ID="dtp_fecha" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2">
                    Hora Inicial:
                    <br />
                    <dx:ASPxTimeEdit ID="tp_horaInicio" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxTimeEdit>
                </div>
                <div class="col-lg-2">
                    Hora Final:
                    <br />
                    <dx:ASPxTimeEdit ID="tp_horaFinal" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxTimeEdit>
                </div>
                <div class="col-lg-6">
                    Lugar (Dirección):
                    <br />
                    <asp:TextBox ID="tb_lugar" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-12">
                    Observaciones:
                    <br />
                    <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <br />

            <br />
            <asp:Button ID="btn_guardarCita" runat="server" CssClass="btn btn-sm blue" Text="Programar cita" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
