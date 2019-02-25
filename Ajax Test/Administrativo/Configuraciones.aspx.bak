<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrativo/Administrativo.Master" CodeBehind="Configuraciones.aspx.vb" Inherits="Ajax_Test.Configuraciones" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GV_Opciones" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="id_configuracion" Theme="Moderno" Width="100%">
        <Columns>
            <dx:GridViewCommandColumn Caption="#" ShowEditButton="True" VisibleIndex="8">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Días de Gracia" FieldName="diasDeGracias" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="id_configuracion" FieldName="id_configuracion" ReadOnly="True" Visible="False" VisibleIndex="0">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Email Del Sistema" FieldName="emailSistema" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Contraseña Email" FieldName="contraseñaEmail" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Servidor SMTP" FieldName="smtpServer" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Puerto SMTP" FieldName="puertoEmail" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Usar SSL (0=No,1=SÍ)" FieldName="SSL" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="¿Enviar Emails? (0=NO, 1= SÍ)" FieldName="EnviarEmails" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
