Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices

Partial Public Class login_class
    Inherits blankpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = ""
        listingpage = ""
        _FormsName = "Login"
        columnscount = "0"
        TableName = "secuserinfo"
        DetailPage = ""
        IDPField = ""
        IDField = "usr_id"
        AppIDField = ""
        MerchantIDField = "usr_merchantid"
        FilterField = "usr_filter"
        Orderby = ""
        _pagesize = 20

        If Request.Browser.Type.ToLower.Contains("internetexplorer") OrElse Request.Browser.Browser = "IE" Then
            Dim ieversion As String = Request.Browser.Type.ToLower.Replace("internetexplorer", "")
            If Request.Browser.MajorVersion < 11 Then 'CInt(ieversion) < 11 OrElse
                Dim str As String = System.Net.WebUtility.UrlEncode("We recommend downloading the newest version of your preferred browser for the best experience. Our Net Promoter Score Survey & Portal supports the following browsers: <br/><ol><li>Chrome 18 and later</li><li>Firefox 24 and later</li><li>Safari 7 or later</li><li>Microsoft Edge</li><li>Internet Explorer 11</li></ol>")
                'Response.Redirect("postpage.aspx?NextPage=message1.aspx?ga=B&ba=" & "login.aspx")
                Response.Redirect("postpage.aspx?NextPage=message1.aspx?ga=B&ba=" & "loginstaff.aspx")
            End If
        End If

        Call InitLoad()

        If Page.IsPostBack = False Then
            WebLib.LoginUser = ""
            WebLib.BranchID = ""
            WebLib.CustBranchID = ""
            WebLib.CustBranchNum = ""

            WebLib.CustBranchName = ""
            WebLib.isStaff = False
            WebLib.CustNum = ""
            POSSettings.Branchid = ""
            SOSettings.NeedDateMinDays = ""
        End If

        lblMessage.Text = ""
        Call LoadData()

    End Sub

    Public Sub loginpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim loginStatus As String = ""
        Dim ADconnection As String = ""
        WebLib.LoginUserCompanySelected = "RGTECH"

        Try
            cmd.CommandText = "Select usr_email,usr_sysadmin,usr_code,usr_profile,usr_branch,usr_name,usr_firstscreen,usr_merchantid,isnull(usr_custbranchid,'') as usr_custbranchid,isnull(usr_custbranchnum,0) as usr_custbranchnum, usr_matrixlevel, usr_region, usr_isad, usr_password, usr_state from secuserinfo " &
                           " where (usr_loginid='" & usr_loginid.Text.Replace("'", "''") & "' or usr_adlogin='" & usr_loginid.Text.Replace("'", "''") & "') " &
                           " And usr_filter='" & WebLib.FilterCode & "' and rtrim(isnull(usr_merchantid,'')) = '' and isnull(usr_disable,0) = 0 and usr_company like '%" & WebLib.LoginUserCompanySelected & "%' "

            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                WebLib.LoginUser = dr("usr_code").ToString.ToUpper
                WebLib.LoginUserName = dr("usr_name").ToString.ToUpper
                WebLib.StartupApp = dr("usr_firstscreen") & ""
                WebLib.ProfileID = dr("usr_profile").ToString.ToUpper
                WebLib.BranchID = dr("usr_branch").ToString.ToUpper

                WebLib.MerchantID = ""

                WebLib.LoginIsFullAdmin = WebLib.BitToBoolean(dr("usr_sysadmin") & "")

                WebLib.isStaff = True
                WebLib.CustBranchID = dr("usr_custbranchid").ToString.ToUpper
                WebLib.CustBranchNum = dr("usr_custbranchnum").ToString.ToUpper

                WebLib.LoginUserMatrixLevel = dr("usr_matrixlevel") & ""
                WebLib.LoginUserRegion = dr("usr_region") & ""
                WebLib.LoginUserState = dr("usr_state") & ""

                WebLib.isAD = IIf(IsDBNull(dr("usr_isad")) Or WebLib.BitToBoolean(dr("usr_isad") & "") = False, False, True)
                WebLib.CustUnderLoginUserMatrixLevel = ""

                Try
                    WebLib.LoginUserEmail = dr("usr_email") & ""
                Catch ex As Exception
                End Try

                If IsDBNull(dr("usr_isad")) = False And WebLib.BitToBoolean(dr("usr_isad") & "") = True Then
                    If ADUserAuthentication(loginStatus, ADconnection) = True Then
                        Exit For
                    Else
                        lblMessage.Text = "Login Failed due to: <br>" & Chr(149) & " Incorrect username or password<br>" & Chr(149) & " Expired AD Password"
                        WebStats.trackstats("L", loginStatus, ADconnection)
                        Exit Sub
                    End If
                End If

                'If dr("usr_password") & "" <> usr_password.Text.Replace("'", "''") Then
                '    lblMessage.Text = "Login Failed."
                '    Exit Sub
                'End If

                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If counter = 0 Then
                lblMessage.Text = "Login Failed"
            Else
                'Call WebLib.GetAppsByMerchantID(WebLib.MerchantID)
                Call WebLib.GetRightsByProfileID(WebLib.ProfileID)

                'WebStats.trackstats("L", loginStatus, ADconnection)

                If (WebLib.CustBranchID & "").trim <> "" Then
                    Dim objbranch As New RuntimeCustomerBranch
                    objbranch.getInfo(WebLib.CustBranchNum, WebLib.CustNum)
                    WebLib.CustBranchName = objbranch.Description
                    objbranch = Nothing
                End If

                Response.Redirect("Home.aspx")
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
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
            cmd.CommandText = "Select usr_email,usr_merchantid,usr_code,usr_profile,usr_branch,usr_name,isnull(usr_custbranchid,'') as usr_custbranchid,isnull(usr_custbranchnum,0) as usr_custbranchnum from secuserinfo where usr_loginid='" & usr_loginid2.Text.Replace("'", "''") & "' and usr_password='" & usr_password2.Text.Replace("'", "''") & "' and rtrim(isnull(usr_merchantid,'')) <> ''  and isnull(usr_disable,0) = 0 "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                WebLib.LoginUser = dr("usr_code").ToString.ToUpper
                WebLib.ProfileID = dr("usr_profile").ToString.ToUpper
                WebLib.BranchID = dr("usr_branch").ToString.ToUpper
                WebLib.LoginUserName = dr("usr_name").ToString.ToUpper

                Try
                    WebLib.LoginUserEmail = dr("usr_email") & ""
                Catch ex As Exception
                End Try

                WebLib.CustCode = dr("usr_merchantid") & ""
                WebLib.MerchantID = dr("usr_merchantid") & ""
                WebLib.isStaff = False
                WebLib.CustBranchID = dr("usr_custbranchid").ToString.ToUpper
                WebLib.CustBranchNum = dr("usr_custbranchnum").ToString.ToUpper
                WebLib.LoginUserMatrixLevel = ""
                WebLib.LoginUserRegion = ""
                WebLib.LoginUserState = ""
                WebLib.isAD = False
                WebLib.CustUnderLoginUserMatrixLevel = ""
                WebLib.LoginUserCompanySelected = "RGTECH"

                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If counter = 0 Then
                lblMessage.Text = "Login Failed"
            Else
                Call initLogin()
                Call WebLib.GetRightsByProfileID(WebLib.ProfileID)

                WebStats.trackstats("L")

                If (WebLib.CustBranchID & "").trim <> "" Then
                    Dim objbranch As New RuntimeCustomerBranch
                    objbranch.getInfo(WebLib.CustBranchNum, WebLib.CustNum)
                    WebLib.CustBranchName = objbranch.Description
                    objbranch = Nothing
                End If

                Response.Redirect("Home.aspx")
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub

    Private Sub initLogin()
        If SOSettings.InitRuntimeObject = False Then
            WebLib.ShowMessagePage(Response, "Error in Sales Order Initialization", "main.aspx")
        End If

        'WebLib.ProfileID = SOSettings.CustomerProfile
        WebLib.BranchID = SOSettings.CustomerBranch

        Dim obj As New RuntimeCustomer
        Call obj.getInfo(WebLib.MerchantID)
        WebLib.CustNum = obj.CustNum
        WebLib.CustName = obj.CustName
        obj = Nothing
    End Sub

    Public Function LoadData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem

        Try
            cmd.CommandText = "Select * from Editor where editor_type='L'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                lithtml.Text = dr("editor_body") & ""
                Exit For
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            'lblMessage.Text = ex.Message
        End Try
    End Function

    Public Sub recoverpasswordC(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("recoverpassword.aspx?param1=C")
    End Sub

    Public Sub recoverpasswordS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("recoverpassword.aspx?param1=S")
    End Sub

    Public Function ADUserAuthentication(ByRef LoginStatus As String, ByRef ADConnection As String) As Boolean
        Dim connectionAD As String = String.Empty
        Try
            Dim adContext As PrincipalContext

            For i As Integer = 1 To 4

                connectionAD = IIf(i = 1, WebLib.ConnAD1, (IIf(i = 2, WebLib.ConnAD3, (IIf(i = 3, WebLib.ConnAD2, (IIf(i = 4, WebLib.ConnAD4, "")))))))

                adContext = New PrincipalContext(ContextType.Domain, connectionAD)

                If adContext.ValidateCredentials(usr_loginid.Text.Replace("'", "''"), usr_password.Text.Replace("'", "''")) Then
                    LoginStatus = ""
                    ADConnection = adContext.ConnectedServer
                    Return True
                Else
                    LoginStatus = "F"
                    ADConnection = adContext.ConnectedServer
                End If
            Next
            If LoginStatus <> "" Then
                Return False
            End If
        Catch ex As Exception
            lblMessage.Text = "Failed to Connect to AD. - " & ex.Message
            Return False
        End Try
    End Function

End Class

