<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Prospectador/Prospectador.Master" CodeBehind="NuevoCliente.aspx.vb" Inherits="Ajax_Test.NuevoCliente_Prospectador" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <!-- BEGIN PAGE LEVEL STYLES -->
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
        </div>
    </div>

    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-search"></i>Datos cliente
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <label>Nombre:</label><br />
            <asp:TextBox ID="tb_nombre" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Apellido Paterno:</label><br />
            <asp:TextBox ID="tb_paterno" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Apellido Materno:</label><br />
            <asp:TextBox ID="tb_materno" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Email:</label><br />
            <asp:TextBox ID="tb_email" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>NSS:</label><br />
            <asp:TextBox ID="tb_nss" runat="server" CssClass="form-control" onChange="validaNSS()"></asp:TextBox><br />
            <label>CURP:</label><br />
            <asp:TextBox ID="tb_curp" runat="server" CssClass="form-control" onChange="validaCurp()"></asp:TextBox><br />
            <label>RFC:</label><br />
            <asp:TextBox ID="tb_rfc" runat="server" CssClass="form-control"></asp:TextBox><br />
            <div class="row">
                <div class="col-lg-2">
                    <label>Fecha de nacimiento:</label><br />
                    <dx:ASPxDateEdit ID="dtp_fecnac" runat="server" Date="2000-01-01" CssClass="form-control"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2">
                    <label>Edo Civil:</label><br />
                    <asp:DropDownList ID="cb_edoCivil" runat="server" CssClass="form-control">
                        <asp:ListItem>SOLTERO</asp:ListItem>
                        <asp:ListItem>CASADO</asp:ListItem>
                        <asp:ListItem>DIVORCIADO</asp:ListItem>
                        <asp:ListItem>UNION LIBRE</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-2">
                    <label>No. Hijos</label><br />
                    <asp:TextBox ID="tb_nHijos" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label>Ingresos Personales:</label><br />
                    <asp:TextBox ID="tb_ingresosPersonales" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <div class="row">
                        <div class="col-lg-6">
                            <label>Lada:</label><br />
                            <asp:TextBox ID="tb_lada" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">

                            <label>Telefono:</label><br />
                            <asp:TextBox ID="tb_tel" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="col-lg-3">
                    <label>Fraccionamiento:</label><br />
                    <asp:DropDownList ID="cb_fracc" runat="server" DataSourceID="fraccDS7" DataTextField="Fraccionamiento" DataValueField="Fraccionamiento" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                    <asp:SqlDataSource ID="fraccDS7" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT DISTINCT productos.Fraccionamiento FROM productos"></asp:SqlDataSource>
                </div>
                <div class="col-lg-3">
                    <label>Modelo:</label><br />
                    <asp:DropDownList ID="cb_producto" runat="server" DataSourceID="ProductosDS" DataTextField="NombreCorto" DataValueField="id_producto" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ProductosDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT productos.id_producto,productos.NombreCorto FROM productos WHERE Fraccionamiento=@Fracc">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cb_fracc" Name="Fracc" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-lg-3">
                    <label>Esquema Financiamiento:</label><br />
                    <asp:DropDownList ID="CB_TIPOcREDITO" runat="server" CssClass="form-control">
                        <asp:ListItem>COFINAVIT</asp:ListItem>
                        <asp:ListItem>INFONAVIT</asp:ListItem>
                        <asp:ListItem>INFONAVIT TOTAL</asp:ListItem>
                        <asp:ListItem>INFONAVIT 2DO CREDITO</asp:ListItem>
                        <asp:ListItem>SHF</asp:ListItem>
                        <asp:ListItem>CAJA POPULAR</asp:ListItem>
                        <asp:ListItem>ISSEG</asp:ListItem>
                        <asp:ListItem>FOVISSSTE</asp:ListItem>
                        <asp:ListItem>BANCARIO</asp:ListItem>
                        <asp:ListItem>CONTADO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <label>Origen:</label><br />
                    <asp:DropDownList ID="cb_campañas" runat="server" DataSourceID="CampañasDS" DataTextField="campañaNombre" DataValueField="id_campaña" CssClass="form-control"></asp:DropDownList>
                    <asp:SqlDataSource ID="CampañasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT dbo.[campañas].[id_campaña], dbo.[campañas].[campañaNombre]
                                                                                                                                                            FROM dbo.[campañas]"></asp:SqlDataSource>
                </div>
            </div>

            <%--<td>Nro.Persona: <asp:TextBox ID="tb_nPersona" runat="server"></asp:TextBox></td>--%>
            <div id="DivBtnGuarda" class="row" style="margin-top: 15px">
                <div class="col-lg-2">
                    <asp:Button ID="btn_Guardar" runat="server" Text="Guardar Prospecto" OnClientClick="QuitaBoton()" CssClass="btn btn-lg green" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
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
    </script>

    <script type="text/javascript">
        function QuitaBoton() {
            $('#DivBtnGuarda').hide();
            $('#Validando').modal('show');
        }

        function ValidaCliente() {
            $('#Validando').modal('show');

            var nombreCliente = document.getElementById("<%:tb_nombre.ClientID%>").value;
            var apellidoCliente = document.getElementById("<%:tb_paterno.ClientID%>").value;
            var apellido2Cliente = document.getElementById("<%:tb_materno.ClientID%>").value;

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
            $('#DivBtnGuarda').show();
        }
    </script>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
