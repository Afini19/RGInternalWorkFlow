Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class wgrouprights_class
    Inherits stdpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _searchkeystr = ""
        listingpage = "wgrouplist.aspx"
        _FormsName = "Workflow : Approval Group : Assign Users"
        columnscount = "7"
        TableName = "secuserrights"
        DetailPage = ""
        IDPField = ""
        IDField = "wur_id"
        APPIDField = ""
        MerchantIDField = "wur_merchantid"
        FilterField = "wur_filter"
        Orderby = ""
        _pagesize = 100

        Call initLoad()

        If Page.IsPostBack = False Then
            bid.Value = Request("ba")
            rid.Value = Request("ga")

            '            Call WebLib.setListItemsTable(usr_profile, "app_name", "app_code", "sysApplication", "app_name", "", "", "", " app_code in (" & Weblib.GetAppsByMerchantIDforSearch(Weblib.merchantid) & "'xxxx')")
            Call WebLib.setListItemsTable(usr_profile, "pf_name", "pf_id", "secuserprofile", "pf_name", "", "", "", "")

            Call loaddata("")
        End If

        lblmessage.text = ""

    End Sub
    Protected Sub searchdata(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If usr_profile.selectedindex < 0 Then
            Call loaddata("")
        Else
            Call loaddata(" usr_profile=" & usr_profile.SelectedItem.Value & "")

        End If

    End Sub
    Public Sub loaddata(Optional ByVal _p_searchkey As String = "")


        If _p_searchkey.Trim = "" Then
            Exit Sub
        End If
        If IsNumeric(rid.Value) = False Then
            Response.Redirect("wgrouplist.aspx")
        End If

        Dim cn As New OleDbConnection(connectionstring)

        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow




        If _p_searchkey.Trim <> "" Then
            _p_searchkey = " and " & _p_searchkey
        End If

        cn.Open()
        cmd.CommandText = "Select secuserinfo.*,wgrouprights.* from secuserinfo left outer join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid=" & rid.Value &
                                " where rtrim(isnull(usr_code,'')) <> '' and usr_company like N'%" & WebLib.LoginUserCompanySelected & "%' " & _p_searchkey
        '" where rtrim(isnull(usr_merchantid,'')) = '' " & _p_searchkey
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
        Dim bcheck As Boolean = False

        Dim lsql As String = ""
        cn.Open()
        cmd.Connection = cn

        Dim item As RepeaterItem
        For Each item In rep.Items


            Dim lFull As String = ""
            Dim myCheckBox5 As CheckBox = item.FindControl("chkfull")
            If Not myCheckBox5 Is Nothing Then
                bcheck = myCheckBox5.Checked
            Else
                bcheck = False
            End If


            Dim lID As String = ""
            Dim mtTextBox2 As HiddenField = item.FindControl("txtid")
            If Not mtTextBox2 Is Nothing Then
                lID = mtTextBox2.Value
            End If

            If lID.Trim = "" Then
                GoTo NextItem
            End If

            lsql = "Delete from wgrouprights where wur_merchantid='" & "" & "' and wur_filtercode='" & WebLib.FilterCode & "' and wur_uid=" & lID & " and wur_wgroupid=" & rid.Value

            If bcheck = True Then
                lsql = lsql & ";Insert into [wgrouprights] (wur_uid,wur_wgroupid,wur_merchantid,wur_filtercode,wur_updateby,wur_updatedt) Values (" & _
                 lID & "," & rid.Value & ",'" & "" & "','" & WebLib.FilterCode & "','" & WebLib.LoginUser & "',getdate())"

            End If


            Try

                itrans = cn.BeginTransaction()
                cmd.Transaction = itrans
                cmd.CommandText = lSql
                cmd.ExecuteNonQuery()
                itrans.Commit()

            Catch Err As Exception
                Try
                    itrans.Rollback()

                Catch ex As Exception

                End Try
                lblmessage.text = Err.Message
            End Try

NextItem:
        Next
    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim drv As DataRowView
        drv = e.Item.DataItem


        Dim myCheckBox5 As CheckBox = e.Item.FindControl("chkfull")
        If Not myCheckBox5 Is Nothing Then
            If myCheckBox5.ToolTip.Trim = "" Then
                myCheckBox5.visible = False
            Else
                If drv.Row("wur_uid").ToString.Trim = drv.Row("usr_id").ToString.Trim Then
                    myCheckBox5.Checked = True
                Else
                    myCheckBox5.Checked = False
                End If
            End If
        End If




    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect(listingpage)
    End Sub

End Class

