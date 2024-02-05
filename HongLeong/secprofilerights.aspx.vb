Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class secprorights_list_class
    Inherits stdpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _searchkeystr = ""
        listingpage = "secprofilelist.aspx"
        _FormsName = "Security Center : User Profile : Rights Assignment"
        columnscount = "7"
        TableName = "secuserrights"
        DetailPage = ""
        IDPField = ""
        IDField = "pf_id"
        APPIDField = "pf_appid"
        MerchantIDField = "pf_merchantid"
        FilterField = "pf_filter"
        Orderby = ""
        _pagesize = 2000
        lblMessage.text = ""

        Call initLoad()
        If Page.IsPostBack = False Then
            bid.Value = Request("ba")
            rid.Value = Request("ga")

            Call WebLib.setListItemsTable(sys_app, "app_name", "app_code", "sysApplication", "app_name", "", "", "", "")

            Call loaddata("")
        End If

        lblmessage.text = ""

    End Sub
    Protected Sub searchdata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sys_app.selectedindex < 0 Then
            Call loaddata("")
        Else
            Call loaddata(" ssf_appid='" & sys_app.SelectedItem.Value & "'")

        End If

    End Sub
    Public Sub loaddata(Optional ByVal _p_searchkey As String = "")


        If _p_searchkey.Trim = "" Then
            Exit Sub
        End If
        Dim cn As New OleDbConnection(connectionstring)

        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow


        If _p_searchkey.Trim <> "" Then
            _p_searchkey = " where " & _p_searchkey
        End If

        cn.Open()
        cmd.CommandText = "Select secfunction.*,secaccessrights.* from secfunction left outer join secaccessrights on ssf_appid = ssa_appid and ssf_code = ssa_functioncode and ssa_profileid=" & rid.value & " " & _p_searchkey
        logtheaudit(cmd.CommandText)
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")

        Dim dt As DataTable = ds.Tables("datarecords")
        Dim dv As New DataView(dt)

        Dim pgitems As New PagedDataSource()
        pgitems.DataSource = dv

        rep.DataSource = pgitems
        rep.DataBind()

    End Sub

    Public Sub savepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New OleDbConnection(connectionstring)
        Dim itrans As OleDbTransaction

        Dim cmd As New OleDbCommand()
        Dim counter As Integer = 0
        Dim lSql As String = ""

        cn.Open()
        cmd.Connection = cn

        Dim item As RepeaterItem
        For Each item In rep.Items


            Dim lAdd As String = ""
            Dim myCheckBox As CheckBox = item.FindControl("chkadd")
            If Not myCheckBox Is Nothing And myCheckBox.Checked Then
                lAdd = myCheckBox.ToolTip
            End If

            Dim lMod As String = ""
            Dim myCheckBox2 As CheckBox = item.FindControl("chkmod")
            If Not myCheckBox2 Is Nothing And myCheckBox2.Checked Then
                lMod = myCheckBox2.ToolTip
            End If

            Dim lDel As String = ""
            Dim myCheckBox3 As CheckBox = item.FindControl("chkdel")
            If Not myCheckBox3 Is Nothing And myCheckBox3.Checked Then
                lDel = myCheckBox3.ToolTip
            End If

            Dim lView As String = ""
            Dim myCheckBox4 As CheckBox = item.FindControl("chkview")
            If Not myCheckBox4 Is Nothing And myCheckBox4.Checked Then
                lView = myCheckBox4.ToolTip
            End If

            Dim lFull As String = ""
            Dim myCheckBox5 As CheckBox = item.FindControl("chkfull")
            If Not myCheckBox5 Is Nothing And myCheckBox5.Checked Then
                lFull = myCheckBox5.ToolTip

            End If
            Dim lAppID As String = ""
            Dim mtTextBox1 As HiddenField = item.FindControl("txtappid")
            If Not mtTextBox1 Is Nothing Then
                lAppID = mtTextBox1.Value
            End If

            If lAppID.Trim = "" Then
                GoTo NextItem
            End If


            Dim lCode As String = ""
            Dim mtTextBox2 As HiddenField = item.FindControl("txtcode")
            If Not mtTextBox2 Is Nothing Then
                lCode = mtTextBox2.Value
            End If

            If lCode.Trim = "" Then
                GoTo NextItem
            End If

            '            If lAdd.Trim = "" And lMod.Trim = "" And lDel.Trim = "" And lView.Trim = "" And lFull.Trim = "" Then
            'GoTo NextItem
            'End If

            'lSql = "Delete from secaccessrights where ssa_merchantid='" & weblib.MerchantID & "' and ssa_filtercode='" & WebLib.FilterCode & "' and ssa_appid='" & lAppID & "' and ssa_functioncode='" & lCode & "' and ssa_profileid=" & rid.value & ";Insert into secaccessrights (ssa_profileid,ssa_merchantid,ssa_filtercode,ssa_appid,ssa_functioncode,ssa_add,ssa_mod,ssa_del,ssa_view,ssa_full,ssa_updateby,ssa_updatedt) Values (" & _
            '   rid.value & ",'" & Weblib.MerchantID & "','" & WebLib.FilterCode & "','" & lAppID & "','" & lCode & "','" & lAdd & "','" & lMod & "','" & lDel & "','" & lView & "','" & lFull & "','" & WebLib.LoginUser & "',getdate())"
            lSql = "Delete from secaccessrights where ssa_filtercode='" & WebLib.FilterCode & "' and ssa_appid='" & lAppID & "' and ssa_functioncode='" & lCode & "' and ssa_profileid=" & rid.value & ";Insert into secaccessrights (ssa_profileid,ssa_filtercode,ssa_appid,ssa_functioncode,ssa_add,ssa_mod,ssa_del,ssa_view,ssa_full,ssa_updateby,ssa_updatedt) Values (" & _
                rid.value & ",'" & WebLib.FilterCode & "','" & lAppID & "','" & lCode & "','" & lAdd & "','" & lMod & "','" & lDel & "','" & lView & "','" & lFull & "','" & WebLib.LoginUser & "',getdate())"

            Try

                itrans = cn.BeginTransaction()
                cmd.Transaction = itrans
                cmd.CommandText = lSql
                cmd.ExecuteNonQuery()
                itrans.Commit()

                lblMessage.Text = WebLib.getAlertMessageStyle("Records Saved")


            Catch Err As Exception
                Try
                    itrans.Rollback()

                Catch ex As Exception

                End Try
                lblMessage.Text = WebLib.getAlertMessageStyle(Err.Message)
            End Try

NextItem:
        Next
    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim myCheckBox As CheckBox = e.Item.FindControl("chkadd")
        If Not myCheckBox Is Nothing Then
            If myCheckBox.ToolTip.Trim = "" Then
                myCheckBox.Visible = False
            Else
                If drv.Row("ssa_add").ToString.Trim = drv.Row("ssf_add").ToString.Trim Then
                    myCheckBox.Checked = True
                Else
                    myCheckBox.Checked = False
                End If
            End If
        End If

        Dim myCheckBox2 As CheckBox = e.Item.FindControl("chkmod")
        If Not myCheckBox2 Is Nothing Then
            If myCheckBox2.ToolTip.Trim = "" Then
                myCheckBox2.Visible = False
            Else
                If drv.Row("ssa_mod").ToString.Trim = drv.Row("ssf_edit").ToString.Trim Then
                    myCheckBox2.Checked = True
                Else
                    myCheckBox2.Checked = False
                End If

            End If
        End If

        Dim myCheckBox3 As CheckBox = e.Item.FindControl("chkdel")
        If Not myCheckBox3 Is Nothing Then
            If myCheckBox3.ToolTip.Trim = "" Then
                myCheckBox3.visible = False
            Else
                If drv.Row("ssa_del").ToString.Trim = drv.Row("ssf_del").ToString.Trim Then
                    myCheckBox3.Checked = True
                Else
                    myCheckBox3.Checked = False
                End If
            End If

            '              response.write(myCheckBox3.ToolTip)
        End If
        Dim myCheckBox4 As CheckBox = e.Item.FindControl("chkview")
        If Not myCheckBox4 Is Nothing Then
            If myCheckBox4.ToolTip.Trim = "" Then
                myCheckBox4.visible = False
            Else
                If drv.Row("ssa_view").ToString.Trim = drv.Row("ssf_view").ToString.Trim Then
                    myCheckBox4.Checked = True
                Else
                    myCheckBox4.Checked = False
                End If
            End If
            '              response.write(myCheckBox3.ToolTip)
        End If

        Dim myCheckBox5 As CheckBox = e.Item.FindControl("chkfull")
        If Not myCheckBox5 Is Nothing Then
            If myCheckBox5.ToolTip.Trim = "" Then
                myCheckBox5.visible = False
            Else
                If drv.Row("ssa_full").ToString.Trim = drv.Row("ssf_gotrights").ToString.Trim And drv.Row("ssf_gotrights").ToString.Trim <> "" Then
                    myCheckBox5.Checked = True
                Else
                    myCheckBox5.Checked = False
                End If
            End If
            '              response.write(myCheckBox3.ToolTip)
        End If




    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect(listingpage)
    End Sub

    Public Sub LogtheAudit(ByVal theMessage As String)
        Dim strFile As String = "c:\officeonelog\ErrorLog3.txt"
        Dim fileExists As Boolean = File.Exists(strFile)

        Try

            Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                sw.WriteLine(DateTime.Now & " - " & theMessage)

            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class

