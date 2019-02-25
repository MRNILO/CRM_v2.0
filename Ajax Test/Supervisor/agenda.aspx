<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="agenda.aspx.vb" Inherits="Ajax_Test.agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
      <link href="/assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id='calendar'></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/assets/global/plugins/moment.min.js" type="text/javascript"></script>
        <script src="/assets/global/plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
        <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
      <%--<script src="/assets/apps/scripts/calendar.min.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {

            // page is now ready, initialize the calendar...

            $('#calendar').fullCalendar({
                // put your options and callbacks here
                lang: 'es',
                events: [{
                    title: 'Click for Google',
                    start: '2016-05-09T12:30:00',
                    end: '2016-05-09T18:30:00',
                    backgroundColor: App.getBrandColor('yellow'),
                    url: 'http://google.com/',
                }]
            })

        });
    </script>
</asp:Content>
