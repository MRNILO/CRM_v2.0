<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="nuevaEmpresa.aspx.vb" Inherits="Ajax_Test.nuevaEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-building"></i>Datos Empresa
            </div>

        </div>
        <div class="portlet-body">
            Nombre comercial:
            <br />
            <asp:TextBox ID="tb_nombreEmpresa" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            <br />
            Razon Social:
            <br />
            <asp:TextBox ID="tb_razonSocial" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            <br />
            Dirección Fisica:
            <br />
            <asp:TextBox ID="tb_Direccion" runat="server" required="required" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
            <asp:TextBox ID="tb_paginaweb" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            <br />
            Seleccione rubro:
            <br />
            <asp:DropDownList ID="cb_rubros" runat="server" CssClass="form-control"></asp:DropDownList>
            <br />
            Horario:
            <br />
            <asp:TextBox ID="tb_Horario" runat="server" required="required" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <br />
            Email:
            <br />
            <asp:TextBox ID="tb_email" runat="server" required="required" CssClass="form-control" TextMode="email"></asp:TextBox>
            <br />
            Logotipo:
            <br />
            <asp:FileUpload ID="fup_logotipo" runat="server" CssClass="form-control" />
            <br />
            Observaciones:
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" required="required" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <br />

        </div>
    </div>

    <asp:Button ID="btn_guardarEmpresa" runat="server" Text="Guardar Empresa" CssClass="btn btn-lg green" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">   
      function EjecutaAjax() {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("nuevaEmpresa.aspx/PruebaAjax")%>",
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
            $("#Ciudades").html("Seleccione una ciudad:<br />"+response.d);
        }
    </script>



    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
