<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="cambiaProducto.aspx.vb" Inherits="Ajax_Test.cambiaProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

      <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Cambiar Producto
            </div>
            	<div class="tools">
                  
            	</div>
        </div>
        <div class="portlet-body">
            Nombre Corto:
            <br />
            <asp:TextBox ID="tb_NombreCorto" runat="server" required="required" CssClass="form-control"></asp:TextBox>
              Nombre Completo:
            <br />
            <asp:TextBox ID="tb_NombreCompleto" runat="server" required="required" CssClass="form-control"></asp:TextBox>
              Descripción:
            <br />
            <asp:TextBox ID="tb_descripcion" runat="server" required="required" CssClass="form-control"></asp:TextBox>
              Precio Lista:
            <br />
            <asp:TextBox ID="PNormal" runat="server" required="required" CssClass="form-control"></asp:TextBox>
             Precio descuento:
            <br />
            <asp:TextBox ID="PDesc" runat="server" required="required" CssClass="form-control"></asp:TextBox>
           Categoria Producto:
            <br />
            <asp:DropDownList ID="cb_categorias" runat="server" CssClass="form-control"></asp:DropDownList>
             Observaciones:
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar Información" CssClass="btn btn-lg green" />
            </div>
            </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

        <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
