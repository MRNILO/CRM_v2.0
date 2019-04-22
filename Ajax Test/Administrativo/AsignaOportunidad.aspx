<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrativo/Administrativo.Master" CodeBehind="AsignaOportunidad.aspx.vb" Inherits="Ajax_Test.AsignaOportunidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
   <link rel="stylesheet" type="text/css" href="/assets/global/plugins/select2/select2.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
     <ul class="nav navbar-nav pull-right">				
				<!-- BEGIN USER LOGIN DROPDOWN -->
				<!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
				<li class="dropdown dropdown-user">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
					<%--<img alt="" class="img-circle" src="/assets/admin/layout/img/avatar3_small.jpg"/>--%>
					<span class="username username-hide-on-mobile">
					<asp:Literal ID="lbl_nombre" runat="server"></asp:Literal> </span>
					<i class="fa fa-angle-down"></i>
					</a>
                    
					<ul class="dropdown-menu dropdown-menu-default">
						<li>
							<a href="../Usuario/MisDatos.aspx">
							<i class="icon-user"></i> Mis Datos </a>
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
							<i class="icon-key"></i> Salir </a>
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
    
     <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Cambiar de usuario a un cliente
            </div>
            	
        </div>
        <div class="portlet-body">
            Seleccione un Cliente
            <br />
            <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me"></asp:DropDownList>
            <br />
            Seleccione un usuario a asignar este cliente:
            <br />
            <asp:DropDownList ID="cb_usuarios" runat="server" CssClass="form-control select2me"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn green" />
            </div>
        </div> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
