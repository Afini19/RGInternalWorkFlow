Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic

Partial Public Class cusCCRC_list_class
    Inherits listpage
    Private FORMCODE As String = "CCR"  'Hardcoded for customised form

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If WebLib.isStaff = True Then
            _searchkeystr = "cus_distributor;Distributor Name;S|cus_customer;Customer Name;S|cus_uno;Document Ref No.;S|usr_name;Submitted By;S|cus_createdt;Submission Date;D"
        Else
            _searchkeystr = "cus_distributor;Distributor Name;S|cus_customer;Customer Name;S|cus_ccrcno;Document Ref No.;S|usr_name;Submitted By;S|cus_createdt;Submission Date;D"
        End If

        listingpage = ""
        _FormsName = "Customer Complaint Report"
        TableName = "zcustom_ccr"
        DetailPage = ""
        IDPField = ""
        IDField = "cus_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "cus_filter"
        Orderby = " order by cus_createdt desc "
        APPCode = "WORKFLOW"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = ""
        NmSpace = "zcustom_ccrc"

        pFieldNames = " workflowstatus.*,zcustom_ccr.*,usr_name,ApprovalLevelName = (" & clsWorkflow.getLevelNameSQL("wst_workflowid", "wst_level") & ") "
        pJoinFields = " inner join workflowstatus on cus_ucode = wst_ucode left outer join secuserinfo on cus_createby = usr_loginid "

        If Page.IsPostBack = False Then
            bid.Value = Request("ba")

            wfid.Value = WebLib.GetValue("Workflowlink", "wfl_wflowid", "wfl_subcode", "'" & FORMCODE & "'", "", "")
            _searchfilter = " isnull(cus_ccrcno,'') <>'' and wst_status='Pending' and (cus_createby='" & WebLib.LoginUser & "' or '" & WebLib.LoginUser & "' in (" & clsWorkflow.getUserCodebyWorkFlowSQL("wst_workflowid", "wst_level") & ")) "

        Else
            _searchfilter = " isnull(cus_ccrcno,'') <>'' "
        End If
        bid.Value = "zcustom_ccrc"

        If WebLib.CustNum <> "" Then
            If _searchfilter <> "" Then
                _searchfilter = _searchfilter & " and "
            End If
            _searchfilter = _searchfilter & " cus_distributor = '" & WebLib.CustName & "' and isnull(cus_ccrcno,'') <>'' "
        End If

        Call InitLoad()

        btnback.Visible = False
        Redirector.PrevURL1 = "modules/custom/cusccr_listC.aspx"
        btnadd.Visible = True
    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
    End Sub

    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound
        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litimage")
        If Not objdata Is Nothing Then
            If WebLib.isStaff = True Then
                redirecttoformcode.Value = drv.Row("wst_module").ToString.Trim.Split("_")(1)
                objdata.Text = "<a href=""" & WebLib.ClientURL(Redirector.Redirect(drv.Row("wst_module").ToString.Trim, drv.Row("wst_ucode").ToString.Trim, False, redirecttoformcode.Value)) & """><img src=""" & WebLib.ClientURL("graphics/workflow/paper.png") & """ width=""48""></a>"

            Else
                objdata.Text = "<a href=""" & WebLib.ClientURL(Redirector.Redirect(NmSpace, drv.Row("wst_ucode").ToString.Trim)) & """><img src=""" & WebLib.ClientURL("graphics/workflow/paper.png") & """ width=""48""></a>"

            End If
        End If


        Dim objdata2 As Literal = e.Item.FindControl("litView")
        If Not objdata2 Is Nothing Then
            If WebLib.isStaff = True Then
                redirecttoformcode.Value = drv.Row("wst_module").ToString.Trim.Split("_")(1)
                objdata2.Text = "<a href=""" & WebLib.ClientURL(Redirector.Redirect(drv.Row("wst_module").ToString.Trim, drv.Row("wst_ucode").ToString.Trim, False, redirecttoformcode.Value)) & """>View Document</a>"
            Else
                objdata2.Text = "<a href=""" & WebLib.ClientURL(Redirector.Redirect(NmSpace, drv.Row("wst_ucode").ToString.Trim)) & """>View Document</a>"
            End If
        End If
    End Sub

    Public Sub shortcutmy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Pending' and ('" & WebLib.LoginUser & "' in (" & clsWorkflow.getUserCodebyWorkFlowSQL("wst_workflowid", "wst_level") & ")) ")
    End Sub

    Public Sub shortcut1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Pending' ")
    End Sub

    Public Sub shortcut2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Approved' ")
    End Sub
    Public Sub shortcut3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Cancelled' ")
    End Sub

    Public Sub shortcut4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status='Rejected' ")
    End Sub

    Public Sub shortcut5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        filterhead.Text = "Filter : <b>" & sender.Text & "</b>"
        Call loaddata(" wst_status<>'Pending' ")
    End Sub

    Public Sub AddEventAdd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If WebLib.isStaff = True Then
            Response.Redirect("~/" & Redirector.Redirect(bid.Value, "", True))
        Else
            'Response.Redirect("~/wiz-postpage.aspx?NextPage=wiz-selectcustomer.aspx&wp1=modules/custom/cusccr.aspx&wp2=" & WebLib.MerchantID)
            Response.Redirect("~/wiz-postpage.aspx?NextPage=modules/custom/cusccrc.aspx&events=C&wp2=" & WebLib.MerchantID & "")
        End If
    End Sub

    Public Sub SearchStr2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lworkflowstatus As String = ""
        Dim workflowstatusList As List(Of String) = New List(Of String)()
        For Each item As ListItem In workflowstatus.Items
            If item.Selected Then
                workflowstatusList.Add(item.Value)
            End If
        Next
        lworkflowstatus = String.Join("','", workflowstatusList.ToArray())
        If lworkflowstatus <> "" Then
            If _searchfilter <> "" Then
                _searchfilter = _searchfilter & " and "
            End If
            _searchfilter = _searchfilter & " wst_status in ('" & lworkflowstatus & "') "
        End If

        Call SearchStr(Me, EventArgs.Empty)
    End Sub

    Public Sub exportrange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _l_EpicorDateFormat As String = "MM/dd/yyyy"
        Dim lstring As String = ""
        Dim lFieldNames As String = " cus_type as 'Type',cus_uno as 'Doc Ref',cus_ccrcno as 'Customer Ref',cus_distributor as 'Distributor' " &
                                        ", cus_distributorcontname As 'Distributor Contact Name',cus_distributorcontnum as 'Distributor Contact Number' " &
                                        ",cus_distributorcontemail as 'Distributor Contact Email',cus_customer as 'Customer',cus_location as 'Location',cus_person as 'Person to Contact On Site' " &
                                        ", cus_telno As 'Site Contact Number',cus_dateofcomplaint as 'Date of Complaint',cus_hp as 'H/P',cus_dono as 'D/O Number' " &
                                        ", cus_transporter As 'Transporter',cus_product as 'Product',cus_qty as 'Quantity',cus_description as 'Description of Complaint' " &
                                        ", cus_classification As 'Classification',cus_complaint as 'Complaint',cus_accountholder as 'Account Holder',cus_dncnno as 'CN Number' " &
                                        ", cus_investigatordate As 'Date Of Visit',cus_valid as 'Valid ?',cus_rootcause as 'RCA ?',cus_immediateaction as 'Immediate Action' " &
                                        ", cus_immediatedate As 'Date of Action',cus_cusaccept as 'Case Accepted by Customer ?' " &
                                        ",wst_status as 'Status',usr_name as 'Created by',cus_createdt as 'Created Date',cus_updateby as 'Updated by',cus_updatedt as 'Updated Date' "

        lblMessage.Text = ""


        Dim lworkflowstatus As String = ""
        Dim workflowstatusList As List(Of String) = New List(Of String)()
        For Each item As ListItem In workflowstatus.Items
            If item.Selected Then
                workflowstatusList.Add(item.Value)
            End If
        Next
        lworkflowstatus = String.Join("','", workflowstatusList.ToArray())
        If lworkflowstatus <> "" Then
            If lstring <> "" Then
                lstring = lstring & " and "
            End If
            lstring = lstring & " wst_status in ('" & lworkflowstatus & "') "
        End If

        If search_key1.Text <> "" Then
            If lstring <> "" Then
                lstring = lstring & " and "
            End If
            lstring = lstring & " (cus_distributor like '%" & search_key1.Text.Trim & "%' or cus_customer like '%" & search_key1.Text.Trim & "%' or cus_uno like '%" & search_key1.Text.Trim & "%' " &
                            "or usr_name like '%" & search_key1.Text.Trim & "%') "
        End If

        Dim struc_to As DateTime
        If uc_to.Value.ToString.Trim = "" Then
            struc_to = DateTime.Now
        Else
            struc_to = uc_to.DateValue
        End If

        If lstring <> "" Then
            lstring = lstring & " And "
        End If
        lstring = lstring & " (cus_createdt >= '" & Microsoft.VisualBasic.Format(uc_from.DateValue, _l_EpicorDateFormat) & "' and cus_createdt <= '" & Microsoft.VisualBasic.Format(struc_to, _l_EpicorDateFormat) & "') "

        Dim _l_sql As String = "Select " & lFieldNames & " from " & TableName & " " & pJoinFields & " where " & _searchfilter & "  " & lstring & " " & Orderby
        Try
            WebLib.ExportExcel(Response, _l_sql, "Customer Complaint Report")
        Catch ex As Exception
            lblMessage.Text = "Failed to generate excel"
        End Try
    End Sub

End Class

