Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web.UI
Partial Class Redirect_page
    Inherits System.Web.UI.Page
    Public connectionstring As String = System.Configuration.ConfigurationSettings.AppSettings("ConnStr")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Request("c") & "").Trim = "" Then
            Response.Redirect("RedirectError.aspx")
        End If


        Call RedirectNOW(Request("c"))

    End Sub

    Private Sub RedirectNOW(ByVal pCode As String)

        Dim strConnection As String = connectionstring
        Dim cnHQ As New OleDb.OleDbConnection()
        Dim cmdHQ As New OleDb.OleDbCommand
        Dim adHQ As New OleDb.OleDbDataAdapter
        Dim dsHQ As New DataSet()
        Dim drHQ As DataRow
        Dim sql As String = ""
        Dim lURL As String = ""
        Dim lRefID As String = ""
        Dim lRefID2 As String = ""
        Dim lRefID3 As String = ""
        Dim lUserID As String = ""

        Dim lID As String = ""

        Try
            cnHQ = New OleDb.OleDbConnection(strConnection)

            cnHQ.Open()
            cmdHQ.Connection = cnHQ
            cmdHQ.CommandText = "Select top 1 * from Redirect where red_code='" & pCode & "' and datediff(d,isnull(red_expiry,getdate()),getdate()) < 0 and isnull(red_time,isnull(red_timeclick,0) + 1) > isnull(red_timeclick,0)"
            adHQ.SelectCommand = cmdHQ
            adHQ.Fill(dsHQ, "_data")
            If dsHQ.Tables(0).Rows.Count > 0 Then
                For Each drHQ In dsHQ.Tables("_data").Rows
                    lURL = drHQ("red_redirectto") & ""
                    lUserID = drHQ("red_user") & ""
                    lRefID = drHQ("red_refID") & ""
                    'lRefID2 = drHQ("red_refID2") & ""
                    If drHQ("red_refID2") = "zcustom_ccrc" Then
                        lRefID2 = WebLib.GetValue("workflowstatus", "wst_module", "wst_ucode", "'" & drHQ("red_refID3") & "'", "", "")
                    Else
                        lRefID2 = drHQ("red_refID2") & ""
                    End If
                    lRefID3 = drHQ("red_refID3") & ""
                    lID = drHQ("red_id")
                    Exit For
                Next
                cmdHQ.CommandText = "Update Redirect set red_timeclick = isnull(red_timeclick,0) + 1,red_lastclickdt=getdate() where red_code='" & pCode & "' and red_id=" & lID
                cmdHQ.ExecuteNonQuery()
            Else
                Response.Redirect("RedirectError.aspx")

            End If
            cmdHQ.Dispose()
            cnHQ.Close()
            cnHQ.Dispose()


        Catch ex As Exception

            lURL = ""

        Finally
            If lURL.Trim <> "" Then

                If (lUserID & "").Trim <> "" Then
                    Dim oouser As New clslogins
                    If oouser.autologinstaff((lUserID & "").Trim) = False Then
                        Response.Redirect("RedirectError.aspx")
                    End If
                End If

                If lURL.Trim.ToLower = "workflow" Then
                    If lRefID2.Contains("ccr") = True Then
                        lURL = Redirector.Redirect(lRefID2, lRefID3,, lRefID2.Replace("zcustom_", ""))
                    Else
                        lURL = Redirector.Redirect(lRefID2, lRefID3)
                    End If
                End If

                If lURL.Trim <> "" Then
                    Response.Redirect(WebLib.ClientURL(lURL))

                Else
                    Response.Redirect("RedirectError.aspx")

                End If
            Else
                Response.Redirect("RedirectError.aspx")
            End If


        End Try


    End Sub
End Class
