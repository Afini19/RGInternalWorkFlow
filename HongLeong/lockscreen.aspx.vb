Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class lockscreen_class
    Inherits blankpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Call initLoad()

        If Page.IsPostBack = False Then
            WebLib.LoginUser = ""
            bid.value = WebLib.BranchID
        End If

        lblmessage.text = ""

    End Sub
    Public Sub loginpage(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cmd.CommandText = "Select usr_code,usr_profile,usr_branch,usr_name,usr_firstscreen from secuserinfo where usr_loginid='" & usr_loginid.text.replace("'", "''") & "' and usr_password='" & usr_password.text.replace("'", "''") & "' and usr_merchantid='" & weblib.MerchantID & "' and usr_filter='" & Weblib.FilterCode & "' and isnull(usr_disable,0) = 0 "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                WebLib.LoginUser = dr("usr_code").ToString.ToUpper
                WebLib.LoginUserName = dr("usr_name").ToString.ToUpper
                WebLib.StartupApp = dr("usr_firstscreen") & ""

                WebLib.BranchID = dr("usr_branch").ToString.ToUpper
                WebLib.ProfileID = dr("usr_profile").ToString.ToUpper
                '                WebLib.BranchID = bid.value
                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If counter = 0 Then
                lblmessage.text = "Login Failed"

            Else

                response.redirect("LoginBranch.aspx")

            End If

        Catch ex As Exception
            lblmessage.text = ex.Message
        End Try
    End Sub


    Public Sub loginpage2(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cmd.CommandText = "Select usr_code,usr_profile,usr_branch,usr_name,usr_firstscreen from secuserinfo where usr_pin=" & uc_login.text.replace("'", "''") & " and usr_merchantid='" & weblib.MerchantID & "' and usr_filter='" & Weblib.FilterCode & "' and isnull(usr_disable,0) = 0 "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                WebLib.LoginUser = dr("usr_code").ToString.ToUpper
                WebLib.ProfileID = dr("usr_profile").ToString.ToUpper
                WebLib.LoginUserName = dr("usr_name").ToString.ToUpper
                WebLib.StartupApp = dr("usr_firstscreen") & ""

                'WebLib.BranchID = bid.value
                WebLib.BranchID = dr("usr_branch").ToString.ToUpper


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If counter = 0 Then
                lblmessage.text = "Login Failed"

            Else

                response.redirect("LoginBranch.aspx")

            End If

        Catch ex As Exception
            lblmessage.text = ex.Message
        End Try
    End Sub


End Class

