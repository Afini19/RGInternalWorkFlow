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
  

        Call initLoad()

        If Page.IsPostBack = False Then
            bid.value = Request("ba")
            lblmessage.text = Request("ga")
        End If


    End Sub
    Public Sub gonextpage(ByVal sender As System.Object, ByVal e As System.EventArgs)


        response.redirect(bid.value)

    End Sub

End Class

