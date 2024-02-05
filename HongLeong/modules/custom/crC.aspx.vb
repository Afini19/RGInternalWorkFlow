Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports System.Drawing
Imports AjaxControlToolkit
Imports NPOI.OpenXmlFormats.Dml.Diagram
Imports System.Windows.Forms
Imports System.Web.Services
Imports System.Diagnostics

Partial Public Class crC_class
    Inherits detailspage
    Private Shared connectionstring As String = System.Configuration.ConfigurationSettings.AppSettings("ConnStr")
    Private FORMCODE As String = "CRC"  'Hardcoded for customised form

    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = "crC_list.aspx"
        _FormsName = "Change Request Form"
        TableName = "[zcustom_crC]"
        IDPField = ""
        IDField = "cus_id"
        AppIDField = ""
        MerchantIDField = "cus_merchantid"
        FilterField = "cus_filter"
        APPCode = "WORKFLOW"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = "AA0005"
        NmSpace = "zcustom_crC"

        wfb_bar.workflownamespace = NmSpace
        wfb_bar.custommode = True
        wfb_bar.overridemode = True
        wfb_bar.attachmentbycreatoronly = True

        If Page.IsPostBack = False Then
            lblcrno.Text = "<b>Auto Generated</b>"
            'cus_date.Textdmy = WebLib.formatthedate(DateTime.Today)
            cus_refno.Text = Request("rc") & "" 'notsure

            'WebLib.SetListItems(cus_typeofsample, f_type)
            'WebLib.SetListItems(cus_business, f_business)
            'WebLib.SetListItems(cus_typeoftest, f_trial)

            If (Request("wp2") & "").Trim <> "" Then '2 always use for custcode
                Dim obj As New RuntimeCustomer
                Call obj.getInfo((Request("wp2") & "").Trim)
                ccode.Value = (Request("wp2") & "").Trim
                'cus_company.Text = obj.CustName & ""
                obj = Nothing

            Else
            End If

            cus_department.DataSource = backend.GetDepartmentList()
            cus_department.DataValueField = "de_id"
            cus_department.DataTextField = "de_name"
            cus_department.DataBind()
            cus_department.Items.Insert(0, New ListItem("Please Select", ""))

            cus_customer.DataSource = backend.GetCustomerList()
            cus_customer.DataValueField = "cu_code"
            cus_customer.DataTextField = "cu_name"
            cus_customer.DataBind()
            cus_customer.Items.Insert(0, New ListItem("Please Select", ""))

            cus_priority.DataSource = backend.GetPriorityList()
            cus_priority.DataValueField = "cm_description"
            cus_priority.DataTextField = "cm_description"
            cus_priority.DataBind()
            cus_priority.Items.Insert(0, New ListItem("Please Select", ""))

            cus_devname.DataSource = backend.GetDeveloperNameList()
            cus_devname.DataValueField = "usr_name"
            cus_devname.DataTextField = "usr_name"
            cus_devname.DataBind()
            cus_devname.Items.Insert(0, New ListItem("Please Select", ""))

            cus_testername.DataSource = backend.GetTesterNameList()
            cus_testername.DataValueField = "usr_name"
            cus_testername.DataTextField = "usr_name"
            cus_testername.DataBind()
            cus_testername.Items.Insert(0, New ListItem("Please Select", ""))

            cus_testingstatus.DataSource = backend.GetTestingStatusList()
            cus_testingstatus.DataValueField = "cm_description"
            cus_testingstatus.DataTextField = "cm_description"
            cus_testingstatus.DataBind()
            cus_testingstatus.Items.Insert(0, New ListItem("Please Select", ""))

            Call WebLib.setListItemsTable(cus_tags, "cm_description", "cm_description", "codemaster", "cm_id", "", "", "", " cm_fieldname = 'tags' ")

            'LoadCategories(cus_department.SelectedItem.Value)

            'LoadModules(cus_category.SelectedItem.Value)

        End If

        createdt.Value = DateTime.Now
        cus_date.Textdmy = WebLib.formatthedate(DateTime.Today)
        'cus_devduedate.Textdmy = WebLib.formatthedate(DateTime.Today)
        cus_refno.ReadOnly = True 'notsure

        Call InitLoad()
        Call enabledisablesubmitbutton()

        wfb_bar.parentobj = mp

        Call assigninitvalues()

        If (wfb_bar.canAction()) Then
            lvlvalid.Value = "True"
        Else
            lvlvalid.Value = "False"
        End If

        'If (WebLib.LoginIsFullAdmin = True And wfb_bar.Workflowended = False) Or (IsNumeric(rid.Value) = False And cus_accountholder.SelectedValue = "") Then
        '    cus_accountholder.Enabled = True
        'Else
        '    cus_accountholder.Enabled = False
        'End If

        cus_remarks.ValidationGroup = wfb_bar.wlevelAget().ToString.Trim & "-"

        loadpr()



    End Sub

    Private Sub enabledisablesubmitbutton()
        If wfb_bar.wlevelAPget().ToString.Trim = "7" And cus_testingstatus.SelectedValue <> "Closed" Then
            commentSubmit.Visible = False
        End If
    End Sub

    Private Function ValidateForm()
        lblMessage.Text = ""

        'If cus_duration.enabled = True Then
        '    If (cus_duration.textdmy) <> "" Then
        '        If cus_duration.datevalue = New DateTime(1991, 1, 1) Then
        '            lblMessage.Text = WebLib.getAlertMessageStyle("Date Sample Needed at Site")
        '            Return False
        '        End If
        '    End If
        'End If

        If cus_chargeable.Enabled = True And wfb_bar.wlevelAPget().ToString.Trim = "4" Then
            If cus_chargeable.SelectedIndex < 0 Then
                lblMessage.Text = WebLib.getAlertMessageStyle("Please Indicate CR is Chargeable or not")
                Return False
            Else

            End If
        End If

        If cus_devduedate.Enabled = True And wfb_bar.wlevelAPget().ToString.Trim = "5" Then
            If cus_devduedate.DateValue < DateTime.Today Then
                lblMessage.Text = WebLib.getAlertMessageStyle("Please Enter Valid Development Due Date")
                Return False
            End If
        End If

        If cus_devname.Enabled = True And wfb_bar.wlevelAPget().ToString.Trim = "5" Then
            If cus_devname.Text = "" Then
                lblMessage.Text = WebLib.getAlertMessageStyle("Please Enter Developer Name")
                Return False
            End If
        End If

        If cus_testername.Enabled = True And wfb_bar.wlevelAPget().ToString.Trim = "7" Then
            If cus_testername.Text = "" Then
                lblMessage.Text = WebLib.getAlertMessageStyle("Please Enter Tester Name")
                Return False
            End If
        End If

        If cus_testingstatus.Enabled = True And wfb_bar.wlevelAPget().ToString.Trim = "7" Then
            If cus_testingstatus.Text = "" Then
                lblMessage.Text = WebLib.getAlertMessageStyle("Please Enter Testing Status")
                Return False
            End If
        End If

        If cus_devmandays.Enabled = True Then
            If cus_devmandays.Text <> "" Then

                If Regex.IsMatch(cus_devmandays.Text, "^(?:0|[1-9]\d*)(?:\.[05]0?)?$") = False Then
                    lblMessage.Text = WebLib.getAlertMessageStyle("Development man-days: Either an integer or a decimal of 0.5 is allowed")
                    Return False
                End If

            End If
        End If

        If cus_testingmandays.Enabled = True Then
            If cus_testingmandays.Text <> "" Then

                If Regex.IsMatch(cus_testingmandays.Text, "^(?:0|[1-9]\d*)(?:\.[05]0?)?$") = False Then
                    lblMessage.Text = WebLib.getAlertMessageStyle("Internal testing man-days: Either an integer or a decimal of 0.5 is allowed")
                    Return False
                End If

            End If
        End If

        If cus_category.SelectedIndex < 0 Then
            LogtheAudit(cus_category.SelectedIndex)
            lblMessage.Text = WebLib.getAlertMessageStyle("Please Indicate Category")
            Return False
        End If

        Return True
    End Function

    Public Sub SetFieldRights()
        Call wfb_bar.EnableDisable(mp)
        Exit Sub
    End Sub

    Private Sub assigninitvalues()
        'If cus_duration.enabled = False And (cus_duration.value & "").trim = "" Then
        '    cus_duration.textdmy = ""
        'End If
    End Sub

    Public Sub backpagepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect(WebLib.ClientURL(Redirector.PrevURL1))
    End Sub

    Public Overrides Function LoadData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem

        If IsNumeric(rid.Value) = False Then

            wfb_bar.uid = ""
            Call SetFieldRights()
            'cus_accountholder.SelectedValue = backend.GetAccountHolder((Request("wp2") & "").Trim)
            Exit Function
        End If

        Try
            cmd.CommandText = "Select * from " & TableName & " where cus_id = " & rid.Value
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows

                counter = counter + 1

                'ccode.Value = dr("cus_custcode") & ""
                uid.Value = dr("cus_ucode") & ""
                cus_title.Text = dr("cus_title") & ""
                cus_requestTitle.Text = dr("cus_requestTitle") & ""
                cus_date.Textdmy = dr("cus_createdt").ToString.Trim
                cus_department.Text = dr("cus_department") & ""
                cus_category.Text = dr("cus_category") & ""
                cus_module.Text = dr("cus_module") & ""
                cus_crtype.Text = dr("cus_crtype") & ""
                cus_customer.SelectedValue = dr("cus_customer") & ""
                cus_initiator.Text = dr("cus_initiator") & ""
                cus_contactno.Text = dr("cus_contactno") & ""
                cus_priority.SelectedValue = dr("cus_priority") & ""

                'templi = cus_department.Items.FindByValue(dr("de_name") & "")
                'cus_department.SelectedIndex = cus_department.Items.IndexOf(templi)

                'templi = cus_category.Items.FindByValue(dr("cus_category") & "")
                'cus_category.SelectedIndex = cus_category.Items.IndexOf(templi)

                'templi = cus_module.Items.FindByValue(dr("mod_description") & "")
                'cus_module.SelectedIndex = cus_module.Items.IndexOf(templi)


                'cus_devmandays.Text = dr("cus_devmandays") & ""
                'cus_testingmandays.Text = dr("cus_testingmandays") & ""

                Try
                    cus_devmandays.Text = dr("cus_devmandays") & ""

                    If IsNumeric(cus_devmandays.Text) = False Then
                        cus_devmandays.Text = "0"
                    End If
                Catch ex As Exception
                End Try

                Try
                    cus_testingmandays.Text = dr("cus_testingmandays") & ""

                    If IsNumeric(cus_testingmandays.Text) = False Then
                        cus_testingmandays.Text = "0"
                    End If
                Catch ex As Exception
                End Try

                cus_technicalReq.Text = dr("cus_technicalReq") & ""
                cus_businessReq.Text = dr("cus_businessReq") & ""
                'cus_tags.Text = dr("cus_tags") & ""

                Dim cus_tagsstr As String = dr("cus_tags") & ""
                For Each item As ListItem In cus_tags.Items
                    If cus_tagsstr.Contains(item.Value) Then
                        item.Selected = True
                    End If
                Next

                Dim cus_chargeablestr As String = dr("cus_chargeable") & ""
                For Each item As ListItem In cus_chargeable.Items
                    If cus_chargeablestr.Contains(item.Value) Then
                        item.Selected = True
                        genreportbtn.Visible = True
                    End If
                Next

                If dr("cus_devduedate") & "" = "" Then
                    cus_devduedate.Textdmy = WebLib.formatthedate(DateTime.Today)
                Else
                    cus_devduedate.Textdmy = dr("cus_devduedate") & ""
                End If

                'cus_devduedate.Textdmy = dr("cus_devduedate") & ""
                cus_devname.Text = dr("cus_devname") & ""
                cus_testername.Text = dr("cus_testername") & ""
                cus_testingstatus.Text = dr("cus_testingstatus") & ""

                cus_refno.Text = dr("cus_refno") & ""
                lblcrno.Text = dr("cus_crno") & ""

                wfb_bar.uid = uid.Value
                createdt.Value = dr("cus_createdt").ToString.Trim

                loaddraft()

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            If wfb_bar.WorkflowEnded = True Then
                btnsave.enabled = False
            Else
                btnsave.enabled = True
            End If

            Call SetFieldRights()
            Call enabledisablesubmitbutton()

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try

    End Function

    Private Sub savedatadata(ByVal pWorkflowAction As Boolean, ByVal pType As String)
        Dim insertfields, insertvalues As String
        Dim lsrdesc As String = ""
        Dim lsql As String = ""
        Dim newform As Boolean = False
        Dim savedDraft As String = ""
        insertfields = ""
        insertvalues = ""

        If ValidateForm() = False Then
            Exit Sub
        End If

        Dim ldevduedate As String = "NULL"
        If cus_devduedate.Enabled = True Then
            If cus_devduedate.DateValue = New DateTime(1991, 1, 1) Then
                ldevduedate = "NULL"
            Else
                ldevduedate = "'" & WebLib.FormatDateFullFormatDDMMYYYYtoYYYYMMDD(cus_devduedate.DateValue) & "'"
            End If
        End If

        Dim lcus_tags As String = ""
        Dim cus_tagsList As List(Of String) = New List(Of String)()
        For Each item As ListItem In cus_tags.Items
            If item.Selected Then
                cus_tagsList.Add(item.Value)
            Else
            End If
        Next
        lcus_tags = String.Join(",", cus_tagsList.ToArray())

        Dim lcus_department As String = ""
        If cus_department.SelectedIndex < 0 Then
            lcus_department = ""
        Else
            lcus_department = cus_department.SelectedItem.Value
        End If

        Dim lcus_category As String = ""
        If cus_category.SelectedIndex < 0 Then
            lcus_category = ""
        Else
            lcus_category = cus_category.SelectedValue
        End If

        Dim lcus_module As String = ""
        If cus_module.SelectedIndex < 0 Then
            lcus_module = ""
        Else
            lcus_module = cus_module.SelectedItem.Value
        End If

        Try
            If rid.Value = "" Then
                savedDraft = "saved"
                newform = True
                uid.Value = WebLib.getUniqueKey

                Dim lID As String
                Dim lDocno As String = ""
                lDocno = WebLib.GetDocNo(NmSpace, "cus_crno", APPCode) & ""
                If lDocno.Trim = "" Then
                    lblMessage.Text = WebLib.getAlertMessageStyle("CR No. Not Set")
                    Exit Sub
                End If

                lID = WebLib.GetValue("Workflowlink", "wfl_wflowid", "wfl_subcode", "'" & FORMCODE & "'", "", "")
                If IsNumeric(lID) = False Or (lID & "").Trim = "0" Then
                    lblMessage.Text = WebLib.getAlertMessageStyle("No Workflow Assign for this form")
                    Exit Sub
                End If

                lsql = wfb_bar.GetWorkFlowSaveSQL(lID, uid.Value, True, cus_refno.Text, NmSpace, _FormsName, cus_title.Text, lDocno)

                insertfields = insertfields & "cus_merchantid"
                insertvalues = insertvalues & "'" & ccode.Value.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_filter"
                insertvalues = insertvalues & ",'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",cus_ucode"
                insertvalues = insertvalues & ",'" & uid.Value & "'"
                insertfields = insertfields & ",cus_crno"
                insertvalues = insertvalues & ",'" & lDocno & "'"
                insertfields = insertfields & ",cus_title"
                insertvalues = insertvalues & ",'" & cus_title.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_requestTitle"
                insertvalues = insertvalues & ",'" & cus_requestTitle.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_department"
                insertvalues = insertvalues & ",'" & lcus_department & "'"
                insertfields = insertfields & ",cus_category"
                insertvalues = insertvalues & ",'" & lcus_category & "'"
                insertfields = insertfields & ",cus_module"
                insertvalues = insertvalues & ",'" & lcus_module & "'"
                insertfields = insertfields & ",cus_crtype"
                insertvalues = insertvalues & ",'" & cus_crtype.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_customer"
                insertvalues = insertvalues & ",'" & cus_customer.SelectedValue & "'"
                insertfields = insertfields & ",cus_initiator"
                insertvalues = insertvalues & ",'" & cus_initiator.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_contactno"
                insertvalues = insertvalues & ",'" & cus_contactno.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_priority"
                insertvalues = insertvalues & ",'" & cus_priority.SelectedValue & "'"
                insertfields = insertfields & ",cus_devmandays"
                insertvalues = insertvalues & "," & cus_devmandays.Text.Replace("'", "''") & ""
                insertfields = insertfields & ",cus_testingmandays"
                insertvalues = insertvalues & "," & cus_testingmandays.Text.Replace("'", "''") & ""
                insertfields = insertfields & ",cus_technicalReq"
                insertvalues = insertvalues & ",'" & cus_technicalReq.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_businessReq"
                insertvalues = insertvalues & ",'" & cus_businessReq.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_tags"
                insertvalues = insertvalues & ",'" & lcus_tags.Replace("'", "''") & "'"

                insertfields = insertfields & ",cus_chargeable"
                insertvalues = insertvalues & ",'" & cus_chargeable.SelectedValue & "'"
                insertfields = insertfields & ",cus_devduedate"
                insertvalues = insertvalues & "," & ldevduedate & ""
                insertfields = insertfields & ",cus_devname"
                insertvalues = insertvalues & ",'" & cus_devname.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_testername"
                insertvalues = insertvalues & ",'" & cus_testername.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",cus_testingstatus"
                insertvalues = insertvalues & ",'" & cus_testingstatus.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",cus_createby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",cus_createdt"
                insertvalues = insertvalues & ",getdate()"

                insertfields = insertfields & ",cus_updateby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",cus_updatedt"
                insertvalues = insertvalues & ",getdate()"

            Else

                If pWorkflowAction = True Then
                    lsql = wfb_bar.getapprovesql(pType)
                Else
                    savedDraft = "saved"
                    newform = True
                End If

                insertvalues = insertvalues & "cus_updateby='" & WebLib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",cus_updatedt=getdate()"

                If cus_title.Enabled = True Then
                    insertvalues = insertvalues & ",cus_title='" & cus_title.Text.Replace("'", "''") & "'"
                End If
                If cus_requestTitle.Enabled = True Then
                    insertvalues = insertvalues & ",cus_requestTitle='" & cus_requestTitle.Text.Replace("'", "''") & "'"
                End If
                If cus_department.Enabled = True Then
                    insertvalues = insertvalues & ",cus_department='" & lcus_department & "'"
                End If
                If cus_category.Enabled = True Then
                    insertvalues = insertvalues & ",cus_category='" & lcus_category & "'"
                End If
                If cus_module.Enabled = True Then
                    insertvalues = insertvalues & ",cus_module='" & lcus_module & "'"
                End If
                If cus_crtype.Enabled = True Then
                    insertvalues = insertvalues & ",cus_crtype='" & cus_crtype.Text.Replace("'", "''") & "'"
                End If
                If cus_customer.Enabled = True Then
                    insertvalues = insertvalues & ",cus_customer='" & cus_customer.SelectedValue & "'"
                End If
                If cus_initiator.Enabled = True Then
                    insertvalues = insertvalues & ",cus_initiator='" & cus_initiator.Text.Replace("'", "''") & "'"
                End If
                If cus_contactno.Enabled = True Then
                    insertvalues = insertvalues & ",cus_contactno='" & cus_contactno.Text.Replace("'", "''") & "'"
                End If
                If cus_priority.Enabled = True Then
                    insertvalues = insertvalues & ",cus_priority='" & cus_priority.SelectedValue & "'"
                End If
                If cus_devmandays.Enabled = True Then
                    insertvalues = insertvalues & ",cus_devmandays=" & cus_devmandays.Text.Replace("'", "''") & ""
                End If
                If cus_testingmandays.Enabled = True Then
                    insertvalues = insertvalues & ",cus_testingmandays=" & cus_testingmandays.Text.Replace("'", "''") & ""
                End If
                If cus_technicalReq.Enabled = True Then
                    insertvalues = insertvalues & ",cus_technicalReq='" & cus_technicalReq.Text.Replace("'", "''") & "'"
                End If
                If cus_businessReq.Enabled = True Then
                    insertvalues = insertvalues & ",cus_businessReq='" & cus_businessReq.Text.Replace("'", "''") & "'"
                End If
                If cus_tags.Enabled = True Then
                    insertvalues = insertvalues & ",cus_tags='" & lcus_tags.Replace("'", "''") & "'"
                End If
                If wfb_bar.wlevelAPget().ToString.Trim = "4" Then
                    insertvalues = insertvalues & ",cus_chargeable='" & cus_chargeable.SelectedValue & "'"
                End If
                If wfb_bar.wlevelAPget().ToString.Trim = "5" Then
                    insertvalues = insertvalues & ",cus_devduedate=" & ldevduedate & ""
                    insertvalues = insertvalues & ",cus_devname='" & cus_devname.Text.Replace("'", "''") & "'"
                End If
                If wfb_bar.wlevelAPget().ToString.Trim = "7" Then
                    insertvalues = insertvalues & ",cus_testername='" & cus_testername.Text.Replace("'", "''") & "'"
                    insertvalues = insertvalues & ",cus_testingstatus='" & cus_testingstatus.Text.Replace("'", "''") & "'"
                End If

            End If

            Dim lsqlcom As String = ""
            lsqlcom = lsqlcom & "'" & WebLib.LoginUser.replace("'", "''") & "'"
            lsqlcom = lsqlcom & ",'" & IIf(cus_remarks.Text = "", "[Please refer to above section.]", cus_remarks.Text.Replace("'", "''")) & "'"
            lsqlcom = lsqlcom & ",getdate()"

            wfb_bar.postComments(lsqlcom, TableName, pWorkflowAction)

            If savedata(insertfields, insertvalues, True, lsql) = True Then

                If pType = "" Then
                    pType = "route"
                End If

                If pWorkflowAction = True Then
                    If wfb_bar.notifyusers(pType) = False Then


                    End If
                End If
                Response.Redirect("~/" & Redirector.Redirect(NmSpace, uid.Value, False))
                'Else
                '    lblMessage.Text = WebLib.getAlertMessageStyle("There is an error while saving. Please retry")

            End If


        Catch Err As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(Err.Message)
        Finally
        End Try
    End Sub

    Public Sub savepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call savedatadata(False, "")
    End Sub

    Protected Sub wfb_bar_OnApproveEvent(ByVal sender As Object, ByVal e As EventArgs) Handles wfb_bar.OnApproveEvent
        Call savedatadata(True, "Approve")
    End Sub

    Protected Sub wfb_bar_OnRejectEvent(ByVal sender As Object, ByVal e As EventArgs) Handles wfb_bar.OnRejectEvent
        Call savedatadata(True, "Reject")
    End Sub

    Protected Sub wfb_bar_OnCancelEvent(ByVal sender As Object, ByVal e As EventArgs) Handles wfb_bar.OnCancelEvent
        Call savedatadata(True, "Cancel")
    End Sub

    Public Sub loadpr()
        Try
            rep_comment.DataSource = wfb_bar.getComments2()
            rep_comment.DataBind()
            rep_audit.DataSource = wfb_bar.GetAuditLogsDs2()
            rep_audit.DataBind()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Sub

    Public Sub loaddraft()
        Try
            cus_remarks.Text = wfb_bar.getDraft2()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Sub

    Public Sub generatereport()

        If ValidateForm() = True Then

            Response.Redirect("postpage.aspx?NextPage=" & WebLib.ClientURL("printviewer/printcr.aspx") & "&ga=" & TableName & "&la=" & uid.Value & "&da=" & cus_chargeable.SelectedValue & "")
        End If


    End Sub

    Protected Sub cus_department_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        LoadCategories(cus_department.SelectedValue)
    End Sub

    <WebMethod>
    Public Shared Function LoadCategories(ByVal departmentId As String) As List(Of ListItem)

        Try

            Dim str As String = "select * from category where cat_deptid = '" & departmentId & "'"
            Dim cn As New OleDbConnection(connectionstring)
            Dim cmd As New OleDbCommand()
            Dim ad As New OleDb.OleDbDataAdapter()
            Dim ds As New DataSet()
            Dim counter As Integer = 0
            Dim dr As DataRow

            cn.Open()
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            Dim category As New List(Of ListItem)()

            category.Add(New ListItem() With {.Value = "", .Text = "Please Select"})

            For Each dr In ds.Tables("datarecords").Rows
                category.Add(New ListItem() With {
                    .Value = dr("cat_id"),
                    .Text = dr("cat_description").ToString.Trim})
            Next

            cn.Close()

            Return category

        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try

    End Function

    Protected Sub cus_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Call savedatadata(False, "")
    End Sub

    <WebMethod>
    Public Shared Function LoadModules(ByVal categoryId As String) As List(Of ListItem)

        Try

            Dim str As String = "select * from module where mod_catid = '" & categoryId & "'"
            Dim cn As New OleDbConnection(connectionstring)
            Dim cmd As New OleDbCommand()
            Dim ad As New OleDb.OleDbDataAdapter()
            Dim ds As New DataSet()
            Dim counter As Integer = 0
            Dim dr As DataRow

            cn.Open()
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            Dim moduleList As New List(Of ListItem)()

            moduleList.Add(New ListItem() With {.Value = "", .Text = "Please Select"})

            For Each dr In ds.Tables("datarecords").Rows
                moduleList.Add(New ListItem() With {
                    .Value = dr("mod_id").ToString.Trim,
                    .Text = dr("mod_description").ToString.Trim})
            Next

            cn.Close()

            Return moduleList

        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    'Protected Sub cus_chargeable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cus_chargeable.SelectedIndexChanged
    '    Call savedatadata(False, "")
    '    'If cus_chargeable.SelectedValue = "" Then
    '    '    genreportbtn.Visible = False

    '    'Else
    '    '    genreportbtn.Visible = True

    '    'End If



    'End Sub

    Protected Sub cus_testingstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cus_testingstatus.SelectedIndexChanged
        Call savedatadata(False, "")
    End Sub

    Public Shared Sub LogtheAudit(ByVal theMessage As String)
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

