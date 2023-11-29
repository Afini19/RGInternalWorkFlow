Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class message1_class
    Inherits blankpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _FormsName = "Message"

        Call InitLoad()

        If Page.IsPostBack = False Then
            bid.Value = Request("ba")

            If bid.Value = "" Then
                SubmitButton.Visible = False
            End If

            If Request("ga") = "B" Then
                lblMessage.Text = "<div class='center' style='color:black'><h2>Supported Browsers</h2><p>We recommend downloading the newest version of your preferred browser for the best experience. Our Net Promoter Score Survey & Portal supports the following browsers:</p><ul><li>Chrome 18 and later</li><li>Firefox 24 and later</li><li>Safari 7 or later</li><li>Microsoft Edge</li><li>Internet Explorer 11</li></ul></div>" ' Request("ga").Replace(".",".<br>")
				SubmitButton.Visible = False 
			else
                lblMessage.Text = Request("ga")
            End If
        End If
    End Sub

    Public Sub gonextpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect(bid.Value)
    End Sub

End Class

