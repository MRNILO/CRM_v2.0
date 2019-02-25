﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="BIAdmin.aspx.vb" Inherits="Ajax_Test.BIAdmin" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Fechas para reporte
            </div>
            	<div class="tools">
                    
                    
            	</div>
        </div>
        <div class="portlet-body">
             Fecha inicio:
            <br />
            <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="MetropolisBlue"></dx:ASPxDateEdit>
             Fecha Final:
            <br />
            <dx:ASPxDateEdit ID="dtp_final" runat="server" Theme="MetropolisBlue"></dx:ASPxDateEdit>
            <br />
            <asp:Button ID="btn_Generar" runat="server" Text="Generar" CssClass="btn green" />
            <br />
            </div>
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
