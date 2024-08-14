Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class message_class
    Inherits blankpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _FormsName = "Message"

        Call InitLoad()

        If Page.IsPostBack = False Then
            bid.Value = Request("ba")
            If bid.Value = "-" Then
                SubmitButton.Visible = False
            Else
                SubmitButton.Visible = True
            End If
            lblMessage.Text = Request("ga")
        End If
    End Sub

    Public Sub gonextpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("Home.aspx")
    End Sub

End Class

