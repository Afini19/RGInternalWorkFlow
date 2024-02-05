Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class wlist_list_class
    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "wf_name;Workflow Name;S|"""
        listingpage = "wlist.aspx"
        _FormsName = "Workflow Designer"
        'columnscount = "10"
        TableName = "workflow"
        DetailPage = "w.aspx"
        IDPField = ""
        IDField = "wf_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "wf_filter"
        Dim sqlgroupby As String = " group by wf_id,wf_filter,wf_name,wf_code,wf_classification,wfl_wflowid "
        Orderby = sqlgroupby & " order by wf_name "
        '_pagesize = 20
        APPCode = "" '"SMS"
        AddRights = "" '"SM0001"
        DelRights = "" ' "SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "forms"
        pFieldNames = " wf_id,wf_name,wf_code,wf_classification,wfl_wflowid,wf_filter "
        pJoinFields = " left join workflowlink on " & TableName & ".wf_id=workflowlink.wfl_wflowid "
        btnback.Visible = False
        Call InitLoad()
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Edit" Then
            Response.Redirect("postpage.aspx?NextPage=" & DetailPage & "&ga=" & e.CommandArgument & "&ba=" & bid.Value)
        End If
        If e.CommandName = "Del" Then
            Call DeleteRec(e.CommandArgument)
        End If
        If e.CommandName = "Def" Then
            Response.Redirect("postpage.aspx?NextPage=wbuilder.aspx&ga=" & e.CommandArgument & "&ba=" & e.CommandArgument)
        End If
        If e.CommandName = "New" Then
            Call newwf(e.CommandArgument)
        End If

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim objEdit As Object = e.Item.FindControl("lnkEdit")
        If Not objEdit Is Nothing Then
            If WebLib.hasrights(NmSpace, APPCode, ModRights) = False Then
                Try
                    objEdit.Visible = False
                Catch ex As Exception
                End Try
            End If
        End If

        Dim objDel As Object = e.Item.FindControl("lnkDelete")
        If Not objDel Is Nothing Then
            If WebLib.hasrights(NmSpace, APPCode, DelRights) = False Then
                Try
                    objDel.Visible = False
                Catch ex As Exception
                End Try
            End If
        End If

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litData")
        If Not objdata Is Nothing Then
            objdata.Text = "<b>" & drv.Row("wf_code").ToString.Trim & "</b> : <br class=""btn2""/>" & drv.Row("wf_name").ToString.Trim
        End If

        objdata = e.Item.FindControl("litimage")
        If Not objdata Is Nothing Then
            objdata.Text = "<img src=""" & WebLib.getclassificationImage((drv.Row("wf_classification").ToString & "").Trim) & """ class=""imggrid"">"
        End If

        objdata = e.Item.FindControl("litimage2")
        If Not objdata Is Nothing Then
            If drv.Row("wfl_wflowid").ToString <> "" Then
                objdata.Text = "<img src=""" & WebLib.ClientURL("graphics/classification/linked.png") & """ class=""imggrid"">"
            End If
        End If
    End Sub

    Private Sub newwf(ByVal wfid As String)

        Dim id As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0

        Try
            cmd.CommandText = " declare @wui_id int; " &
                            " insert into workflow (wf_merchantid, wf_filter, wf_code, wf_name, wf_createby, wf_createdt, wf_classification) " &
                            " select top 1 wf_merchantid, wf_filter, " &
                            " case when charindex('_V',trim(wf_code)) > 0  then " &
                            " convert(varchar(20),left(trim(wf_code), len(trim(wf_code))-1) + convert(varchar(1),cast(right(trim(wf_code),1) as int) + 1)) " &
                            " else trim(wf_code) + '_V1' end as wf_code, " &
                            " case when charindex('_V',trim(wf_name)) > 0  then " &
                            " convert(varchar(100),left(trim(wf_name),len(trim(wf_name))-1) + convert(varchar(1),cast(right(wf_name,1) as int) + 1)) " &
                            " else trim(wf_name) + '_V1' end as wf_name " &
                            " , '" & WebLib.LoginUser.replace("'", "''") & "', getdate(), wf_classification from workflow w where wf_code like '%' + trim((select wf_code from workflow where wf_id = '" & wfid & "')) + '%' order by wf_id desc " &
                            " set @wui_id = (select SCOPE_IDENTITY()) " &
                            " insert into workflowitems (wui_filter, wui_wid, wui_no, wui_pno, wui_name, wui_approve, wui_approvestep, wui_reject, wui_rejectstep, " &
                            " wui_cancel, wui_cancelstep, wui_createby, wui_createdt, wui_ucode, wui_rights, wui_approveval, wui_approvevalamt, wui_approvalvalend, " &
                            " wui_approvename, wui_rejectname, wui_cancelname, wui_emailA, wui_emailR, wui_emailC, wui_allowattach, wui_emailN, wui_emailS, wui_emailSf ) " &
                            " select wui_filter, @wui_id, wui_no, wui_pno, wui_name, wui_approve, wui_approvestep, wui_reject, wui_rejectstep, " &
                            " wui_cancel, wui_cancelstep, wui_createby, wui_createdt, '" & WebLib.getUniqueKey & "', wui_rights, wui_approveval, wui_approvevalamt, wui_approvalvalend, " &
                            " wui_approvename, wui_rejectname, wui_cancelname, wui_emailA, wui_emailR, wui_emailC, wui_allowattach, wui_emailN, wui_emailS, wui_emailSf " &
                            " from workflowitems where wui_wid = '" & wfid & "'" &
                            " select @wui_id as id "

            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr As datarow In ds.Tables("datarecords").Rows
                id = dr("id")
                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try

        Response.Redirect("postpage.aspx?NextPage=wbuilder.aspx&ga=" & id & "&ba=" & id)

    End Sub

End Class

