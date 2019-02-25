<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="NuevaLlamada.aspx.vb" Inherits="Ajax_Test.NuevaLlamada" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
							<a href="/Usuario/MisDatos.aspx">
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
							<a href="/Account/Logoff.aspx">
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


      <div class="modal fade" id="ComentariosLlamada" tabindex="-1" role="basic" aria-hidden="true">
								<div class="modal-dialog">
									<div class="modal-content">
										<div class="modal-header">
											<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
											<h4 class="modal-title">Observaciones llamada</h4>
										</div>
										<div class="modal-body">
                                            <div id="BtnLlamada"></div>
                                            <br />
                                            ¿Como fue la llamada?
                                            <dx:ASPxRadioButtonList ID="rbg_Respuesta" runat="server" ValueType="System.String" Theme="MetropolisBlue">
                                                <Items>
                                                    <dx:ListEditItem Text="No contesta" Value="NO" Selected="true" />
                                                    <dx:ListEditItem Text="Llamada exitosa" Value="SI" />
                                                </Items>
                                            </dx:ASPxRadioButtonList>
                                            Observaciones
                                            <br />
                                            <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            <br />
                                            <asp:Button ID="btn_guardarLLamada" runat="server" Text="Guardar" CssClass="btn btn-lg green" />
                                            </div>
                                        </div>
                                    </div>
          </div>

    
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-phone"></i>Llamada
            </div>
            	
        </div>
        <div class="portlet-body">
            Seleccione un cliente:
            <br />
            <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me" onchange="EjecutaAjax()"></asp:DropDownList>
            <br />
            <div id="Telefonos">

            </div>
            <br />
            <a href="#"  class="btn green" onclick="btn_agregarLlamadaClick()"><i class="fa fa-phone"></i>Registrar Llamada</a>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript">   
        function btn_agregarLlamadaClick() {
            var telefono = document.getElementById("idTelefono").value;

            $("#BtnLlamada").html("<a href='tel:" + telefono + "' class='btn green' >Llamar</a>")
            $("#ComentariosLlamada").modal("show");
        }
     
        jQuery(document).ready(function () {
            EjecutaAjax();

        });
      function EjecutaAjax() {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("NuevaLlamada.aspx/PruebaAjax")%>",
                data: '{valor: "' + $("#<%=cb_clientes.ClientID%>")[0].value + '"}',
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
            $("#Telefonos").html("Seleccione un teléfono:<br />"+response.d);
        }
    </script>



    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
