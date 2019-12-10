<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Ajax_Test.Usuarios" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-bottom: 15px">
        <div class="col-lg-2">
            <a href="/Supervisor/NuevoUsuario.aspx" class="btn btn-sm btn-block purple">Nuevo Usuario</a>
        </div>
    </div>

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Usuarios 
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GV_exporter" runat="server" GridViewID="GV_Usuarios">
                </dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_Usuarios" runat="server" Width="100%" Theme="MaterialCompact" AutoGenerateColumns="False" KeyFieldName="id_usuario" EnableCallBacks="False" Font-Size="9pt" EnableTheming="True">
                    <SettingsAdaptivity>
                        <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                    </SettingsAdaptivity>

                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsBehavior AutoFilterRowInputDelay="600" />
                    <SettingsSearchPanel Visible="True" Delay="600" />

                    <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_usuario" VisibleIndex="1">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="3">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="e-mail" FieldName="Email" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Usuario" FieldName="Usuario" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Contraseña" FieldName="Contrasena" VisibleIndex="7">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <PropertiesTextEdit Password="True">
                                <MaskSettings PromptChar="*" />
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Registrado" FieldName="Registrado" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Perfil" FieldName="PerfilDes" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Perfil" FieldName="Perfil" Name="Perfil" VisibleIndex="9" Visible="false">
                            <PropertiesComboBox TextField="Tipo" ValueField="id_tipoUsuario" ValueType="System.Int32">
                            </PropertiesComboBox>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <EditFormSettings Visible="true" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Supervisor" FieldName="SupervisorDes" VisibleIndex="12">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Supervisor" FieldName="idsupervisor" Name="supervisor" VisibleIndex="11" Visible="false">
                            <PropertiesComboBox TextField="NombreCompleto" ValueField="id_supervisor" ValueType="System.Int32" DropDownStyle="DropDownList">
                            </PropertiesComboBox>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <EditFormSettings Visible="true" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataCheckColumn Caption="Activo" FieldName="activo" VisibleIndex="13">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">

        function cambiarLlamada(idLlamada) {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/cliente.aspx/PruebaAjax")%>",
                data: '{valor: "' + idLlamada + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            if (response.d == 'Exito') {
                location.reload();
            } else {
                alert('No se cambio el estatus');
            }
        }
    </script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="CSSContent" runat="server"></asp:Content>

