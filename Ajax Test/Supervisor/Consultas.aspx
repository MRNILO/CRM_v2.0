﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="Consultas.aspx.vb" Inherits="Ajax_Test.Consultas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
                    <a href="../Account/Logoff.aspx">
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
                <div class="col-lg-5">
                    <label><strong>Consulta:</strong></label>
                    <dx:ASPxComboBox ID="cmBoxArchivos" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" TabIndex="1"></dx:ASPxComboBox>
                    <br />
                    <asp:Label ID="lbl_ConsultaAbierta" runat="server" BackColor="#99ff99"></asp:Label>
                </div>
                <div class="col-lg-1" style="margin-top: 25px">
                    <asp:Button ID="btnAbrirArchivo" runat="server" Text="Abrir" Width="100%" Height="30px" CssClass="btn btn-sm btn-block green" TabIndex="2" />
                </div>
                <div class="col-lg-2" style="margin-top: 25px">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block blue" TabIndex="5" />
                </div>
                <div class="col-lg-2" style="margin-top: 25px">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block yellow" />
                </div>
            </div>
            <div class="row" id="Mensaje" runat="server" style="margin-top: 10px">
                <div class="col-lg-5" id="RangoFechas" runat="server">
                    <div class="row" style="margin-top: 10px">
                        <div class="col-lg-6">
                            <label><strong>Fecha Inicio:</strong></label>
                            <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="Mulberry" Width="100%" required="required" TabIndex="3"></dx:ASPxDateEdit>
                        </div>
                        <div class="col-lg-6">
                            <label><strong>Fecha Final:</strong></label>
                            <dx:ASPxDateEdit ID="dtp_Fin" runat="server" Theme="Mulberry" Width="100%" required="required" TabIndex="4"></dx:ASPxDateEdit>
                        </div>
                    </div>
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
                <asp:Button ID="btnExcel" runat="server" Text="Excel" Width="100%" Height="30px" CssClass="btn btn-sm btn-block green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="col-lg-5" style="margin-top: 10px">
                <asp:Label ID="lbl_Total" CssClass="font-dark " runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>
            <dx:ASPxGridView ID="grdViewConsulta" Width="100%" runat="server" Theme="MaterialCompact"
                Font-Size="9pt" Font-Names="Microsoft Sans Serif">
                <SettingsPager Mode="ShowAllRecords" Visible="False">
                </SettingsPager>
                <Settings VerticalScrollableHeight="350" VerticalScrollBarMode="Visible" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
