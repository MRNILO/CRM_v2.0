<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SupervisorMty/SupervisorMty.master" CodeBehind="Consultas.aspx.vb" Inherits="Ajax_Test.ConsultasMty" %>

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
                <div class="col-lg-5" style="margin-top: 20px">
                    <label>Archivo de Consulta</label>
                    <dx:ASPxComboBox ID="cmBoxArchivos" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" TabIndex="1"></dx:ASPxComboBox>
                </div>
                <div class="col-lg-1" style="margin-top: 45px">
                    <asp:Button ID="btnAbrirArchivo" runat="server" Text="Abrir" Width="100%" Height="30px" CssClass="btn btn-sm btn-block green" TabIndex="2" />
                </div>
            </div>
            <div class="row" id="Mensaje" runat="server">
                <div class="col-lg-12" style="margin-top: 20px">
                    <div class="col-lg" style="margin-top: 20px">
                        <asp:Label ID="lbl_ConsultaAbierta" runat="server" BackColor="#99ff99"></asp:Label>
                    </div>
                    <div class="col-lg-2 col-lg-offset-5">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block blue" TabIndex="5" />
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100%" Height="30px" CssClass="btn btn-sm btn-block yellow" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="RangoFechas" runat="server" style="margin-top: 10px">
                <div class="col-lg-12">
                    <div>
                        <i class="fa fa-calendar"></i>Rango Fechas 
                    </div>
                    <div class="col-lg-2">
                        <label>Fecha Inicio:</label>
                        <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="Mulberry" Width="100%" required="required" TabIndex="3"></dx:ASPxDateEdit>
                    </div>
                    <div class="col-lg-2">
                        <label>Fecha Final:</label>
                        <dx:ASPxDateEdit ID="dtp_Fin" runat="server" Theme="Mulberry" Width="100%" required="required" TabIndex="4"></dx:ASPxDateEdit>
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
            <dx:ASPxGridView ID="grdViewConsulta" Width="100%" runat="server" Theme="Moderno"
                Font-Size="9pt" Font-Names="Microsoft Sans Serif">
                <Settings VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
