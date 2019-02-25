<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="InicioUsuario.aspx.vb" Inherits="Ajax_Test.InicioUsuario" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ActivityContent" ContentPlaceHolderID="MenuDeActividades" runat="server">

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="modal fade" id="basic" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Nuevas características</h4>
                </div>
                <div class="modal-body">
                    <strong>¡Hola!</strong>
                    <br />
                    <br />
                    Antes de que empieces a utilizar su sistema CRM, te invitamos a conocer la nueva característica que está disponible para ti en HERRAMIENTAS>Llamadas entre fechas
                </div>
                <div class="modal-footer">
                    <div class="btn dark btn-outline" data-dismiss="modal">Salir</div>
                    <a class="btn green" href="llamadas.aspx">Conocer</a>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    Bienvenido Usuario
    <br />
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-search"></i>Buscar cliente
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            Seleccione un cliente:
            <br />
            <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me" AutoPostBack="True"></asp:DropDownList>
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat blue">
                <div class="visual">
                    <i class="fa fa-check-circle"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span class="counter">
                            <asp:Literal ID="lbl_ClientesActivos" runat="server"></asp:Literal>

                        </span>

                    </div>
                    <div class="desc">Clientes Activos </div>
                </div>
                <%--  <a class="more" href="/Reportes/VisitasEntreFechas.aspx"> Ver más
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>--%>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat green">
                <div class="visual">
                    <i class="fa fa-bar-chart-o"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup">
                            <asp:Literal ID="lbl_ProspectosSemana" runat="server"></asp:Literal>

                        </span>

                    </div>
                    <div class="desc">Prospectos por semana </div>
                </div>
                <%--  <a class="more" href="/Reportes/VisitasEntreFechas.aspx"> Ver más
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>--%>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat red">
                <div class="visual">
                    <i class="fa fa-ban"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup">
                            <asp:Literal ID="lbl_ClientesCancelados" runat="server"></asp:Literal>

                        </span>
                    </div>
                    <div class="desc">Clientes Cancelados </div>
                </div>
                <%--   <a class="more" href="/Reportes/VisitasEntreFechas.aspx"> Ver más
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>--%>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat purple">
                <div class="visual">
                    <i class="fa fa-globe"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup">
                            <asp:Literal ID="lbl_clientesTotal" runat="server"></asp:Literal>

                        </span>
                    </div>
                    <div class="desc">Clientes totales </div>
                </div>
                <%--  <a class="more" href="/Reportes/Incidencias.aspx"> Ver más
                                    <i class="m-icon-swapright m-icon-white"></i>
                                </a>--%>
            </div>
        </div>
    </div>

    <a href="/Usuario/ProgramarTarea.aspx" class="btn btn-lg green">Nueva Tarea</a>
    <br />
    <br />
    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Tareas Pendientes
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">

                <dx:ASPxGridView ID="GV_TareasPendientes" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" EnableCallBacks="False">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID Tarea" FieldName="id_tarea" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Prioridad" FieldName="Prioridad" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Avisado" FieldName="Avisado" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Creada" FieldName="fechaCreacion" VisibleIndex="4">
                            <PropertiesDateEdit DisplayFormatString="D">
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Programada" FieldName="fechaProgramada" VisibleIndex="5">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Hora Programada" FieldName="HoraProgramada" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_tarea" VisibleIndex="7">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;javascript:void(0)&quot; onclick=&quot;cambiarTarea({0})&quot; class=&quot;btn btn-sm green&quot;&gt;Terminar&lt;/a&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-phone"></i>Llamadas para hoy
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_llamadas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Nombre Cliente" FieldName="Nombre" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Producto" FieldName="Producto" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha" FieldName="Fecha" VisibleIndex="6">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="HORA" FieldName="HORA" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="JSContent" runat="server">
    <script src="//cdnjs.cloudflare.com/ajax/libs/waypoints/2.0.3/waypoints.min.js"></script>
    <script src="/assets/global/plugins/select2/select2.min.js"></script>
    <script src="/assets/global/plugins/counterup/jquery.counterup.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            // Handler for .ready() called.
            //$('#basic').modal('show');
        });



        function cambiarTarea(idLlamada) {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/InicioUsuario.aspx/PruebaAjax")%>",
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

    <script>
        jQuery(document).ready(function ($) {
            $('.counter').counterUp({
                delay: 10,
                time: 1000
            });
        });
    </script>

</asp:Content>
