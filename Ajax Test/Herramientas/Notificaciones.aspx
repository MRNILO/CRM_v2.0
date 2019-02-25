<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Notificaciones.aspx.vb" Inherits="Ajax_Test.Notificaciones" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
         Titulo:<dx:ASPxTextBox ID="tb_titulo" runat="server" Theme="Material" Width="170px">
                    </dx:ASPxTextBox>
                    Mensaje:<dx:ASPxTextBox ID="tb_Mensaje" runat="server" Theme="Material" Width="170px">
                    </dx:ASPxTextBox>
                        <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <div>
            Seleccione a los asesores, solo se muestran los con aplicación instalada.
            <br />
            <dx:ASPxGridView ID="GV_Usuarios" runat="server" AutoGenerateColumns="False" DataSourceID="UsuariosDS" EnableTheming="True" KeyFieldName="id_usuario" Theme="Material" Width="435px">
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="id_usuario" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nombre" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoPaterno" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoMaterno" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="usuario" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="UsuariosDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT DISTINCT
dbo.usuarios.id_usuario,
dbo.usuarios.nombre,
dbo.usuarios.apellidoPaterno,
dbo.usuarios.apellidoMaterno,
dbo.usuarios.usuario

FROM
dbo.usuarios
INNER JOIN dbo.dispositivos ON dbo.dispositivos.id_usuario = dbo.usuarios.id_usuario
"></asp:SqlDataSource>
            <dx:ASPxButton ID="btn_enviar" runat="server" Text="Enviar notificación." Theme="Material">
            </dx:ASPxButton>
        </div>
               

                  


    
    </form>
</body>
</html>
