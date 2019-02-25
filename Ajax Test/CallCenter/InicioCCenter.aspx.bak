<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="InicioCCenter.aspx.vb" Inherits="Ajax_Test.InicioCCenter" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:DropDownList ID="cb_clientes" runat="server" CssClass="form-control select2me" AutoPostBack="True" DataSourceID="ClientesDS" DataTextField="Column1" DataValueField="id_cliente"></asp:DropDownList>
             <asp:SqlDataSource ID="ClientesDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT
dbo.clientes.id_cliente,
CONCAT(dbo.clientes.Nombre,' ',
dbo.clientes.ApellidoPaterno,' ',
dbo.clientes.ApellidoMaterno,' (',
dbo.clientes.Email,'|',
dbo.clientes.NSS,'|',
dbo.clientes.CURP,')')

FROM
dbo.clientes
"></asp:SqlDataSource>
            <br />     
            </div>
           </div>
  <%--  <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-search"></i>Buscar cliente
            </div>
            	<div class="tools">
                    
                    
            	</div>
        </div>
         
        <div class="portlet-body">
             <h2>Buscar Cliente:</h2>
            <br />
            <table>
                <tr>
                    <td>
                        Nombre(s):
                        <asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Paterno,Materno
                        <asp:TextBox ID="tb_paterno" runat="server"></asp:TextBox><asp:TextBox ID="tb_materno" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <h2>Datos cliente:</h2>
            <br />
            <table>
                <tr>
                    <td>Nro. Persona: <asp:TextBox ID="tb_npersona" runat="server"></asp:TextBox></td>
                    <td>Nro. Cliente: <asp:TextBox ID="tb_ncliente" runat="server"></asp:TextBox></td>
                    <td>Nro. Contrato <asp:TextBox ID="tb_contrato" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                     <td>R.F.C.: <asp:TextBox ID="tb_rfc" runat="server"></asp:TextBox></td>
                    <td>N.S.S.: <asp:TextBox ID="tb_nss" runat="server"></asp:TextBox></td>
                    <td>Fecha de nacimiento <dx:ASPxDateEdit ID="dtp_fecNac" runat="server"></dx:ASPxDateEdit>
                    </td>
                </tr>
            </table>
            
             <h2>Telefonos:</h2>
            <br />
            <table>
                <tr>
                    <td>Teléfono: <asp:TextBox ID="tb_lada" runat="server"></asp:TextBox></td>
                    <td>Nro.: <asp:TextBox ID="tb_numero" runat="server"></asp:TextBox></td>
                    </tr>
            </table>

            </div>
           </div>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
     <script src="/assets/global/plugins/select2/select2.min.js"></script>
</asp:Content>
