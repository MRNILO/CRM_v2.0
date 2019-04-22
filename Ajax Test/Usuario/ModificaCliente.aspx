<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="ModificaCliente.aspx.vb" Inherits="Ajax_Test.ModificaCliente" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <style>
        .ui-autocomplete-loading {
            background: white url("/assets/imagenes/load.gif") right center no-repeat;
        }
    </style>
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
    <h3 class="page-title">Nuevo <small>Prospecto</small>
    </h3>

    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Datos generales
            </div>
        </div>
        <div class="portlet-body">
            Ingrese el nombre de su prospecto
            <br />
            <asp:TextBox ID="tb_NombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            Ingrese el apellido Paterno 
            <br />
            <asp:TextBox ID="tb_ApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            Ingrese el apellido materno
            <br />
            <asp:TextBox ID="tb_ApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            Ingrese email (Debe ser valido)
            <br />
            <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            <br />
            Buscar ID empresa:
            <br />
            <div class="ui-widget">
                <label for="<%:tb_empresas.ClientID%>">Buscar: </label>
                <asp:TextBox ID="tb_empresas" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="portlet box blue-steel">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-square"></i>Teléfonos
            </div>
        </div>
        <div class="portlet-body">

            <dx:ASPxGridView ID="GV_telefonos" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" KeyFieldName="id_telefonoCliente">
                <Settings ShowGroupPanel="True" />
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Caption="Opciones" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Principal" FieldName="Principal" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telefono" FieldName="Telefono" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id_telefonoCliente" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>

        </div>
    </div>

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-arrows"></i>Datos de Producto
            </div>
        </div>
        <div class="portlet-body">
            Seleccione un producto:
            <br />
            <asp:DropDownList ID="cb_productos" runat="server" CssClass="form-control select2me">
            </asp:DropDownList>
            <br />
            Nivel de interes en el producto:
            <br />
            <asp:DropDownList ID="cb_nivelInteres" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-tencent-weibo"></i>Datos de campaña
            </div>
        </div>
        <div class="portlet-body">
            Seleccione un Campaña:
            <br />
            <asp:DropDownList ID="cb_campañas" runat="server" CssClass="form-control select2me">
            </asp:DropDownList>
        </div>
    </div>

    <div class="portlet box purple-plum">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-instagram"></i>Fotografías
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_fotocliente" runat="server"></asp:Literal>
            <br />
            Fotografía del cliente (solamente JPG):
            <br />
            <asp:FileUpload ID="Fupl_Foto_Cliente" runat="server" CssClass="form-control" />
            <asp:Literal ID="lbl_fotoTpres" runat="server"></asp:Literal>
            <br />
            Fotografía de tarjeta de presentación (solamente JPG):
            <br />
            <asp:FileUpload ID="Fupl_bCard" runat="server" CssClass="form-control" />
        </div>
    </div>

    <div class="portlet box yellow-saffron">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-square"></i>Adicionales
            </div>
            <div class="tools">
                <asp:Button ID="btn_verobservacion" runat="server" Text="Ver Observaciones" CssClass="btn btn-sm blue" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-12">
                    <label>Ultimo Comentario:</label><br />
                    <asp:Literal ID="lbl_Observaciones" runat="server"></asp:Literal>
                </div>
            </div>
            <br />
            Observaciones:
            <br />
            <asp:TextBox runat="server" ID="tb_observaciones" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" CssClass="btn btn-lg green" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>
    <script>
        $(function () {
            function log(message) {
                $("<div>").text(message).prependTo("#log");
                $("#log").scrollTop(0);
            }

            $("#<%:tb_empresas.ClientID%>").autocomplete({
                source: function (request, response) {
                    $.getJSON("/api/empresas?Query=" + request.term, function (data) {
                        response($.map(data, function (Empresa, id_empresa) {
                            return {
                                label: Empresa.Empresa,
                                value: Empresa.id_empresa
                            };
                        }));
                    });
                },
                minLength: 3,
            });
        });
    </script>
</asp:Content>
