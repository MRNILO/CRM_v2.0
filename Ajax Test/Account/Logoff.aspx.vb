Public Class Logoff
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Clear()
        FormsAuthentication.SignOut()
        Response.Redirect("../Default.aspx")
    End Sub

End Class