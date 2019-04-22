<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="Ayuda.aspx.vb" Inherits="Ajax_Test.Ayuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
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
                    <a href="/Usuario/MisDatos.aspx">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <li>
                  <a href="../Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ayuda
    </h1>
    <br />
    <h2>¿Como capturar un nuevo prospecto?
    </h2>
    <br />
    Si tienes dudas de como ingresar un nuevo cliente al sistema te recomendamos leer este manual.
        <ul>
            <li>Error: No capturo ID de la empresa</li>
            <li>Error: debe capturar al menos un teléfono</li>
            <li>¡Algo salio mal!</li>
        </ul>
    <a href="/Ayuda/Capturar%20un%20nuevo%20prospecto.pdf" class="btn btn-lg green">Ver ¿Como capturar un nuevo prospecto?</a>
    <br />
    <h2>¿Como programo una cita con mi cliente?
    </h2>
    <br />
    Quieres programar una cita con tu cliente para que el sistema te recuerde, ve este documento
        <ul>
            <li>Que hacer despues de una cita con tu cliente</li>
            <li>¿Vas a tener una cita con tu cliente?, no olvides registrarla</li>
        </ul>
    <a href="/Ayuda/Como%20capturar%20una%20cita.pdf" class="btn btn-lg green">Ver ¿Como registrar una cita con mi cliente?</a>
    <h2>¿Como cambiar la etapa de mis clientes?
    </h2>
    <br />
    Actualiza su etapa YA, te decimos como hacerlo.
        <ul>
            <li>¿Uno de tus clientes te entrego su correcta documentación?</li>
            <li>¿Tuviste una cita con alguno de tus clientes?</li>
            <li>¿Un cliente no va a continuar con su trámite?</li>
        </ul>
    <a href="/Ayuda/Cambiar%20etapa%20de%20un%20cliente.pdf" class="btn btn-lg green">Ver ¿Como cambiar la etapa de mi cliente?</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
