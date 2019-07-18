<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="Estatus.aspx.vb" Inherits="Ajax_Test.Estatus" %>

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
                    <a href="#">
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
    <div>
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-file"></i>Citas
                </div>
                <div class="tools">
                </div>
            </div>
            <div class="portlet-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-4">
                            <label>Actualiza El estatus de las citas</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-2">
                            <dx:ASPxButton ID="btn_ActualizarCitas" runat="server" Text="Actualizar" Width="100%" Height="32px" Font-Size="8pt"
                                AutoPostBack="false" Theme="Material">
                                <ClientSideEvents Click="function(s, e) {
                                                                                actualizarCitas();                                                                            
                                                                         }" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="portlet box purple-plum">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-file"></i>Visitas
                </div>
                <div class="tools">
                </div>
            </div>
            <div class="portlet-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-4">
                            <label>Actualiza el estatus de las visitas</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-2">
                            <dx:ASPxButton ID="btn_ActualizarVisitas" runat="server" Text="Actualizar" Width="100%" Height="32px" Font-Size="8pt"
                                AutoPostBack="false" Theme="Material">
                                <ClientSideEvents Click="function(s, e) {
                                                                                actualizarVisitas();                                                                            
                                                                         }" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="ModalProcesando" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="row text-center">
                            <div class="col-lg-12">
                                <img src="../assets/imagenes/load.gif" alt="Procesando" />
                            </div>
                        </div>
                        <div class="row text-center">
                            <div class="col-lg-12">
                                <h4 class="modal-info">Procesando información . . .</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        function actualizarCitas() {
            $("#ModalProcesando").modal({ backdrop: 'static', keyboard: false });
            $.ajax({
                type: "POST",
                url: "<%=ResolveUrl("Estatus.aspx/ActualizarCitas")%>",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == 'OK') {
                        $("#ModalProcesando").modal('hide');
                        sweetAlert('¡CORRECTO!', '¡El estatus de las visitas se actualizo  de forma correcta!', 'success');
                    } else {
                        $("#ModalProcesando").modal('hide');
                        sweetAlert('¡UPS!', response.d, 'warning');
                    }
                },
                failure: function (response) {
                    $("#ModalProcesando").modal('hide');
                    sweetAlert('¡ERROR!', response.d, 'error');
                },
                error: function (response) {
                    $("#ModalProcesando").modal('hide');
                    sweetAlert('¡ERROR!', response.d, 'error');
                }
            });
        }

        function actualizarVisitas() {
            $("#ModalProcesando").modal({ backdrop: 'static', keyboard: false });
            $.ajax({
                type: "POST",
                url: "<%=ResolveUrl("Estatus.aspx/ActualizarVisitas")%>",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == 'OK') {
                        $("#ModalProcesando").modal('hide');
                        sweetAlert('¡CORRECTO!', '¡El estatus de las visitas se actualizo  de forma correcta!', 'success');
                    } else {
                        $("#ModalProcesando").modal('hide');
                        sweetAlert('¡UPS!', response.d, 'warning');
                    }
                },
                failure: function (response) {
                    $("#ModalProcesando").modal('hide');
                    sweetAlert('¡ERROR!', response.d, 'error');
                },
                error: function (response) {
                    $("#ModalProcesando").modal('hide');
                    sweetAlert('¡ERROR!', response.d, 'error');
                }
            });
        }
    </script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
