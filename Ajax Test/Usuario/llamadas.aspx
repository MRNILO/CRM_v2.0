<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="llamadas.aspx.vb" Inherits="Ajax_Test.llamadas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Reporte de llamadas 
            </div>
        </div>
        <div class="portlet-body">
            Seleccione una fecha inicial:
            <br />
            <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="Moderno"></dx:ASPxDateEdit>
            <br />
            Seleccione una fecha final:
            <br />
            <dx:ASPxDateEdit ID="dtp_final" runat="server" Theme="Moderno"></dx:ASPxDateEdit>
            <br />
            <asp:Button ID="btn_generar" runat="server" Text="Buscar llamadas" CssClass="btn btn-lg red" />
        </div>
    </div>
    <div class="portlet box green-haze" id="LlamadasDiv">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Llamadas
            </div>

        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Llamadas" runat="server" Width="100%" Theme="Moderno" AutoGenerateColumns="False" EnableCallBacks="False">
                    <SettingsPager PageSize="500">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_llamada" Name="Opciones" VisibleIndex="0">
                            <PropertiesTextEdit DisplayFormatString="&lt;div id=&quot;div{0}&quot;&gt;&lt;a href=&quot;javascript:void(0)&quot; id=&quot;{0}&quot; onclick=&quot;cambiarLlamada({0})&quot; class=&quot;btn btn-sm green&quot;&gt;Realizada&lt;/a&gt;&lt;/div&gt;">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cliente" FieldName="Cliente" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="HoraProgramacion" FieldName="HoraProgramacion" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="realizada" FieldName="realizada" VisibleIndex="5" Name="realizada">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Observación" FieldName="ObservacionUsuario" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha" FieldName="Fecha" VisibleIndex="2">
                        </dx:GridViewDataDateColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        $(window).on('beforeunload', function () {
            $("#LlamadasDiv").hide();
        });
        function cambiarLlamada(idLlamada) {
            $("#" + idLlamada).hide();
            $("#div" + idLlamada).html("<strong>Espere...</strong>");
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/cliente.aspx/PruebaAjax")%>",
                data: '{valor: "' + idLlamada + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == 'Exito') {
                        $("#div" + idLlamada).html("Ya realizada");
                    } else {
                        alert('No se cambio el estatus');
                    }
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
</asp:Content>
