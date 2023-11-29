Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class rebate_list_class
    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Private FORMCODE As String = "REBATE"  'Hardcoded for customised form

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "cus_company;Customer Name;S|cus_uno;Document Ref No.;S|usr_name;Submitted By;S|cus_createdt;Submission Date;D"

        listingpage = ""
        _FormsName = "Master Rebate"
        'columnscount = "10"
        TableName = "zcustom_rebate"
        DetailPage = ""
        IDPField = ""
        IDField = "cus_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "cus_filter"
        Orderby = ""
        '_pagesize = 20
        APPCode = "WORKFLOW" '"SMS"
        AddRights = "" '"SM0001"
        DelRights = "" ' "SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = "RM0005"
        NmSpace = "zcustom_rebate"

        pFieldNames = " workflowstatus.*," & TableName & ".*,usr_name,ApprovalLevelName = (" & clsWorkflow.getLevelNameSQL("wst_workflowid", "wst_level") & ") "
        pJoinFields = " inner join workflowstatus on cus_ucode = wst_ucode left outer join secuserinfo on cus_createby = usr_loginid "

        If Page.IsPostBack = False Then
            bid.value = Request("ba")

            wfid.value = WebLib.GetValue("Workflowlink", "wfl_wflowid", "wfl_subcode", "'" & FORMCODE & "'", "", "")
            _searchfilter = " wst_status='Pending' and (cus_createby='" & WebLib.LoginUser & "' or '" & WebLib.LoginUser & "' in (" & clsWorkflow.getUserCodebyWorkFlowSQL("wst_workflowid", "wst_level") & ")) "

        Else
            _searchfilter = ""

        End If
        bid.value = "zcustom_rebate"


        Call InitLoad()

        btnback.visible = False
        Redirector.PrevURL1 = "modules/custom/rebate_list.aspx"
        btnadd.Visible = True

        Call LoadFilterButtons()
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand


    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound


        Dim drv As DataRowView
        drv = e.Item.DataItem

        'Dim objdata As Literal = e.Item.FindControl("litData")
        'If Not objdata Is Nothing Then
        '    Dim llink As String

        '    Dim lCode As String
        '    Dim lstatus As String = ""
        '    If (drv.Row("wst_status").ToString.Trim) = "Pending" Then
        '        lstatus = "Pending <b>" & (drv.Row("ApprovalLevelName").ToString.Trim & "</b>")
        '    Else
        '        lstatus = (drv.Row("wst_status").ToString.Trim)
        '    End If
        '    llink = WebLib.ClientURL(Redirector.Redirect(drv.Row("wst_module").ToString.Trim, drv.Row("wst_ucode").ToString.Trim))

        '    lCode = "<table width=""100%"">"
        '    lCode = lCode & "<tr><td width=""10%"" class=""cssdetail"">Subject</td><td class=""cssdetail"" width=""2%"">:</td><td class=""cssdetail"" width=""88%"">" & drv.Row("cus_company").ToString.Trim & "</td></tr>"
        '    lCode = lCode & "<tr><td class=""cssdetail"">Created By</td><td class=""cssdetail"">:</td><td class=""cssdetail"">" & drv.Row("usr_name").ToString.Trim & " " & drv.Row("wst_createon").ToString.Trim & "</td></tr>"
        '    lCode = lCode & "<tr><td class=""cssdetail"">Status</td><td class=""cssdetail"">:</td><td class=""cssdetail""><b>" & lStatus & "</b></td></tr>"

        '    If drv.Row("wst_refno").ToString.Trim <> "" Then
        '        lCode = lCode & "<tr><td class=""cssdetail"">Ticket No.</td><td class=""cssdetail"">:</td><td class=""cssdetail""><b>" & drv.Row("wst_refno").ToString.Trim & "</b></td></tr>"
        '    End If


        '    lCode = lCode & "<tr><td class=""cssdetail""></td><td class=""cssdetail""></td><td class=""cssdetail""><a href=""" & llink & """>View Document</a></td></tr>"
        '    lcode = lcode & "</table>"

        '    objdata.Text = lcode

        'End If


        dim objdata as literal = e.Item.FindControl("litimage")
        If Not objdata Is Nothing Then
            'objdata.Text = "<img src=""" & WebLib.ClientURL("graphics/workflow/paper.png") & """ width=""48"">"
            objdata.Text = "<a href=""" & WebLib.ClientURL(Redirector.Redirect(drv.Row("wst_module").ToString.Trim, drv.Row("wst_ucode").ToString.Trim)) & """><img src=""" & WebLib.ClientURL("graphics/workflow/paper.png") & """ width=""48""></a>"

        End If

    End Sub
    Public Sub shortcut1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call loaddata(" wst_status='Pending' ")

    End Sub
    Private Sub LoadFilterButtons()
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lsql As String = ""

        Dim lwfid As String = wfid.value
        lsql = clsWorkflow.getLevelsbyWorkflowID(lwfid)

        Dim obj As Object
        obj = Page.FindControl("phFilters")

        If Not obj Is Nothing Then
            Try
                cn.Open()
                cmd.CommandText = lsql
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    counter = counter + 1
                    Dim obj1 As New Button
                    obj1.ID = "ID" & dr("recno")
                    obj1.Style.Add("width", "160px")
                    obj1.Text = dr("wui_name")
                    obj1.CssClass = "btn btn-secondary btn-sm w-100 m-1"
                    '                    obj1.Style.Add("height", "20")
                    'word-wrap:break-word;
                    obj1.Style.Add("display", "inline")
                    obj1.Style.Add("white-space", "normal")

                    obj1.Style.Add("word-wrap", "break-word")
                    obj1.Style.Add("text-align", "left")

                    AddHandler obj1.Click, AddressOf Me.filterclick
                    obj.Controls.Add(obj1)
                Next
                cn.Close()
                cmd.Dispose()
                cn.Dispose()

            Catch ex As Exception


            End Try

        End If


    End Sub
    Public Sub filterclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lLevel As String
        lLevel = sender.id.ToString.Replace("ID", "")

        If isnumeric(lLevel) = False Then
            lLevel = 0
        End If
        filterhead.text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Pending' and wst_level=" & lLevel)

    End Sub
    Public Sub shortcutmy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Pending' and ('" & WebLib.LoginUser & "' in (" & clsWorkflow.getUserCodebyWorkFlowSQL("wst_workflowid", "wst_level") & ")) ")
    End Sub

    Public Sub shortcut2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Approved' ")

    End Sub
    Public Sub AddEventAdd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("~/" & Redirector.Redirect(bid.value, "", True))
    End Sub
    Public Sub shortcut3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Cancelled' ")

    End Sub
    Public Sub shortcut4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Rejected' ")

    End Sub

End Class

