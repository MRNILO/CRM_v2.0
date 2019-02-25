<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="ObservacionesCita.aspx.vb" Inherits="Ajax_Test.ObservacionesCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      
      <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-phone"></i>Cita
            </div>
            	
        </div>
        <div class="portlet-body">
            ¿Ya fue realizada la cita?
            <br />
            <asp:RadioButtonList ID="rb_realizada" runat="server">
                <asp:ListItem Value="Si">Realizada</asp:ListItem>
                <asp:ListItem Value="No">Sin realizar</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            Observaciones:
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar Cita" CssClass="btn btn-lg blue" />
            <br />
            <br />
            </div>
          </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">


    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
