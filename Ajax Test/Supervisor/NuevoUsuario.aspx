<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="NuevoUsuario.aspx.vb" Inherits="Ajax_Test.NuevoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDeActividades" runat="server">
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
                    <a href="#">
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
                  <a href="../Account/Logoff.aspx">
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

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Datos Nuevo usuario 
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-4">
                    <label>Nombre:</label>
                    <asp:TextBox ID="tb_NombreUsuario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label>Apellido Paterno:</label>
                    <asp:TextBox ID="tb_ap1Usuario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label>Apellido Materno:</label>
                    <asp:TextBox ID="tb_ap2Usuario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="col-lg-4">
                    <label>Nombre de usuario:</label>
                    <asp:TextBox ID="tb_usuarioSistema" runat="server" CssClass="form-control" onchange="verificaUsuario();" required="required"></asp:TextBox>
                    <br />
                    <div id="msjUsuario"></div>
                </div>
                <div class="col-lg-4">
                    <label>Contraseña:</label>
                    <asp:TextBox ID="tb_contrasenia" runat="server" CssClass="form-control" required="required" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label>Confirma Contraseña:</label>
                    <asp:TextBox ID="tb_contrasenia2" runat="server" CssClass="form-control" onchange="verificaContrasenia();" required="required" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <label>e-mail:</label>
                    <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <label>Tipo de Usuario:</label>
                    <asp:DropDownList ID="cb_tipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row" style="margin-top: 20px">
                <div class="col-lg-2">
                    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-sm btn-block blue" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">

        function verificaUsuario() {
            var Puser = document.getElementById('<%:tb_usuarioSistema.ClientID%>').value;

            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Supervisor/NuevoUsuario.aspx/VerificaUsuario")%>",
                data: '{usuario: "' + Puser + '"}',
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
            if (response.d == 'SI') {
                //Usuario ya existe
                $("#msjUsuario").html('<div class="alert alert-danger display-none" style="display: block;"><button class="close" data-dismiss="alert"></button>Usuario ya en uso dentro del sistema, intente con otro</div>');
            } else {
                //Usuario no existe
                $("#msjUsuario").html('<div class="alert alert-info display-none" style="display: block;"><button class="close" data-dismiss="alert"></button>Usuario disponible</div>');
            }
        }

        function verificaContrasenia() {
            var Con1 = document.getElementById('<%:tb_contrasenia.ClientID%>').value;
            var Con2 = document.getElementById('<%:tb_contrasenia2.ClientID%>').value;

            if (Con1 == Con2) {

            } else {
                alert('Las contraseñas no coinciden.')
            }
        }
    </script>

    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
