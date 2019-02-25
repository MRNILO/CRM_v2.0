<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="NuevoCliente.aspx.vb" Inherits="Ajax_Test.NuevoCliente" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ContentPlaceHolderID="CSSContent" runat="server">
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="/assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <style>
        .ui-autocomplete-loading {
            background: white url("/assets/imagenes/load.gif") right center no-repeat;
        }
    </style>
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

    <%--<div class="btn btn-lg blue" onclick="ValidaCliente()">Validar Cliente</div>--%>
    <div class="modal fade" id="NuevaEmpresa" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Empresa Nueva</h4>
                </div>
                <div class="modal-body">

                    <div class="portlet box red">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-building"></i>Datos Empresa
                            </div>

                        </div>
                        <div class="portlet-body">
                            Nombre comercial:
            <br />
                            <asp:TextBox ID="tb_nombreEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            Razon Social:
            <br />
                            <asp:TextBox ID="tb_razonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            Dirección Fisica:
            <br />
                            <asp:TextBox ID="tb_Direccion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            Seleccione un estado:
            <br />
                            <asp:DropDownList ID="cb_estados" runat="server" CssClass="form-control" onchange="EjecutaAjax()"></asp:DropDownList>
                            <br />
                            <div id="Ciudades">
                            </div>
                            <br />
                            Página Web:
            <br />
                            <asp:TextBox ID="tb_paginaweb" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            Seleccione rubro:
            <br />
                            <asp:DropDownList ID="cb_rubros" runat="server" CssClass="form-control"></asp:DropDownList>
                            <br />
                            Horario:
            <br />
                            <asp:TextBox ID="tb_Horario" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            Email:
            <br />
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="email"></asp:TextBox>
                            <br />
                            Logotipo:
            <br />
                            <asp:FileUpload ID="fup_logotipo" runat="server" CssClass="form-control" />
                            <br />
                            Observaciones:
            <br />
                            <asp:TextBox ID="tb_EmpObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <br />

                        </div>
                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_guardarEmpresa" runat="server" Text="Guardar Empresa" CssClass="btn btn-lg green" UseSubmitBehavior="false" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%--<input id="birds" name="empresa">--%><%--<div id="btnGuardar" style="display:none">--%>
    <div class="modal fade" id="Validando" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">Validando información...</h4>
                </div>
                <div class="modal-body">

                    <img src="/assets/imagenes/load.gif" class="img-responsive" />

                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%--<div class="btn btn-lg blue" onclick="ValidaCliente()">Validar Cliente</div>--%>

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
            NSS (Número de seguro social)
            <br />
            <asp:TextBox ID="tb_nss" runat="server" CssClass="form-control" onChange="validaNSS()"></asp:TextBox>
            <br />
            CURP
            <br />
            <asp:TextBox ID="tb_curp" runat="server" CssClass="form-control" onChange="validaCurp()"></asp:TextBox>
            <br />
            Fecha de nacimiento
            (dd/mm/aaaa)<br />
            <dx:ASPxDateEdit ID="dtp_fechaNacimiento" runat="server" Theme="MaterialCompact"></dx:ASPxDateEdit>
            <br />
            Seleccione empresa:
            <br />

            <div class="ui-widget">
                <br />
                <asp:DropDownList ID="cb_empresas" runat="server" CssClass="form-control" DataSourceID="EmpresasDS" DataTextField="Empresa" DataValueField="id_empresa">
                </asp:DropDownList>
                <asp:SqlDataSource ID="EmpresasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT 
id_empresa,
Empresa
FROM
empresas"></asp:SqlDataSource>
            </div>


            <br />
            <a data-toggle="modal" href="#NuevaEmpresa" class="btn btn-sm green" id="btn_agregaEmpresa">Agregar empresa</a>

        </div>
    </div>

    <div class="portlet box blue-steel">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-square"></i>Teléfonos
            </div>

        </div>
        <div class="portlet-body">

            <asp:Literal ID="lbl_telefonos" runat="server"></asp:Literal>
            <br />
            Ingrese el teléfono del cliente:
            <asp:TextBox ID="tb_telefono" runat="server" CssClass="form-control"></asp:TextBox>
            <div style="display: none">
                <asp:CheckBox ID="chB_telPrincipal" runat="server" CssClass="form-control" />¿Télefono principal?
            <br />
                <br />
                <asp:Button ID="btn_agregar" runat="server" Text="Agregar teléfono" CssClass="btn btn-sm green" UseSubmitBehavior="false" />
                <asp:Button ID="btn_borrarTel" runat="server" Text="Borrar ultimo teléfono" CssClass="btn btn-sm red" UseSubmitBehavior="false" />
            </div>

        </div>
    </div>

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-arrows"></i>Datos de Producto
            </div>

        </div>
        <div class="portlet-body">
            Fraccionamiento:
            <br />
            <asp:DropDownList ID="cb_fracc" runat="server" AutoPostBack="True" CssClass="form-control" DataSourceID="FraccDs" DataTextField="Fraccionamiento" DataValueField="Fraccionamiento">
            </asp:DropDownList>
            <asp:SqlDataSource ID="FraccDs" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT DISTINCT productos.Fraccionamiento FROM productos"></asp:SqlDataSource>
            <br />
            Seleccione un producto:
            <br />
            <asp:DropDownList ID="cb_productos" runat="server" CssClass="form-control" DataSourceID="ProductosDS" DataTextField="NombreCorto" DataValueField="id_producto">
            </asp:DropDownList>
            <asp:SqlDataSource ID="ProductosDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT productos.id_producto,productos.NombreCorto FROM productos WHERE Fraccionamiento=@Fracc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cb_fracc" Name="Fracc" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
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


    <div class="portlet box purple-plum" style="display: none">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-instagram"></i>Fotografías
            </div>

        </div>
        <div class="portlet-body">
            Fotografía del cliente (solamente JPG):
            <br />
            <asp:FileUpload ID="Fupl_Foto_Cliente" runat="server" CssClass="form-control" />

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

        </div>
        <div class="portlet-body">
            Observaciones:
            <br />
            <asp:TextBox runat="server" ID="tb_observaciones" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>

    <%--<div id="btnGuardar" style="display:none">--%>
    <asp:Button ID="btn_validarCliente" class="btn btn-lg blue" runat="server" Text="Validar Cliente" UseSubmitBehavior="false" Visible="False" />

    <div id="DivBtnGuarda">
        <asp:Button ID="btn_Guardar" runat="server" Text="Guardar Prospecto" OnClientClick="QuitaBoton()" CssClass="btn btn-lg green" UseSubmitBehavior="false" />
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="JSContent" runat="server">
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>

    <script>
        $(function () {
            function log(message) {
                $("<div>").text(message).prependTo("#log");
                $("#log").scrollTop(0);
            }

           <%-- $("#<%:tb_empresas.ClientID%>").autocomplete({
                source: function (request, response) {
                    $.getJSON("/api/empresas?Query=" + request.term, function (data) {
                        response($.map(data, function (Empresa, id_empresa) {
                            //alert(Empresa.Empresa);
                            return {
                                label: Empresa.Empresa,
                                value: Empresa.id_empresa
                            };
                        }));

                        


                    });
                },
                minLength: 3,
              
            });--%>
        });
    </script>


    <script type="text/javascript">

        function validaNSS() {
            var NSS = $("#<%:tb_nss.ClientID%>").val();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("NuevoCliente.aspx/ValidaNSS")%>",
                data: '{nss: "' + NSS + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == 'duplicado') {
                        sweetAlert('Cliente duplicado', 'No puede continuar con la carga', "error");
                        $("#DivBtnGuarda").hide();

                    } else {
                        if (response.d == 'si') {
                            $("#DivBtnGuarda").show();
                        }
                    }
                },
                failure: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                },
                error: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                }
            });

        }
        function validaCurp() {
            var Curp = $("#<%:tb_curp.ClientID%>").val();
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("NuevoCliente.aspx/ValidaCURP")%>",
                data: '{curp: "' + Curp + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == 'duplicado') {
                        sweetAlert('Cliente duplicado', 'No puede continuar con la carga', "error");
                        $("#DivBtnGuarda").hide();

                    } else {
                        if (response.d == 'si') {
                            $("#DivBtnGuarda").show();
                        }
                    }
                },
                failure: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                },
                error: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                }
            });

        }

        function ValidaCliente() {

            $('#Validando').modal('show');


            var nombreCliente = document.getElementById("<%:tb_NombreCliente.ClientID%>").value;
            var apellidoCliente = document.getElementById("<%:tb_ApellidoPaterno.ClientID%>").value;
            var apellido2Cliente = document.getElementById("<%:tb_ApellidoMaterno.ClientID%>").value;
            //var email = document.getElementById("<%:tb_email.ClientID%>").value



            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("NuevoCliente.aspx/ValidaCliente")%>",
                data: '{nombre: "' + nombreCliente + '", app1: "' + apellidoCliente + '",app2:"' + apellido2Cliente + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: TerminaValidacion,
                failure: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                },
                error: function (response) {
                    sweetAlert("¡Algo salio mal!", response.d, "error");
                }
            });


        }
        function TerminaValidacion(response) {

            $('#Validando').modal('hide');

            //if (response.d == 'duplicado') {
            //    sweetAlert("¡Cliente ya capturado!", "Cliente duplicado", "error");
            //    $('#btnGuardar').hide();

            //}else{
            //    sweetAlert("¡Cliente disponible!", "Puede continuar la captura", "success");
            $('#btnGuardar').show();


            //}            
        }
    </script>
    <script type="text/javascript">
        function QuitaBoton() {
            $('#btnGuardar').hide();
            $('#Validando').modal('show');
        }
    </script>
    <script type="text/javascript">   
        function EjecutaAjax() {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("NuevoCliente.aspx/PruebaAjax")%>",
                data: '{valor: "' + $("#<%=cb_estados.ClientID%>")[0].value + '"}',
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
            //alert("Si se pudo " + response.d);
            $("#Ciudades").html("Seleccione una ciudad:<br />" + response.d);
        }
    </script>



    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
