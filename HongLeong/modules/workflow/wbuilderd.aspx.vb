Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class wbuilderd_class
    Inherits detailspage

    Private f_approve As String = String.Empty & "|-Please Select-;;1|End Workflow;;2|Proceed Next Approval"
    Private f_reject As String = String.Empty & "|-Please Select-;;1|End Workflow;;3|Back to Creator;;4|Back to Previous Step"
    Private f_cancel As String = String.Empty & "|-Please Select-;;1|End Workflow;;3|Back to Creator;;4|Back to Previous Step"

    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = "wbuilder.aspx"
        _FormsName = "Define Action"
        TableName = "[workflowitems]"
        IDPField = ""
        IDField = "wui_id"
        AppIDField = ""
        MerchantIDField = "wui_merchantid"
        FilterField = "wui_filter"
        APPCode = ""
        AddRights = "" '"SM0001"
        DelRights = "" '"SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "wbuilderd"
        If Page.IsPostBack = False Then
            Call WebLib.SetListItems(wui_approvestep, f_approve)
            Call WebLib.SetListItems(wui_cancelstep, f_cancel)

            Call WebLib.SetListItems(wui_rejectstep, f_reject)
            Call loaddatarights()
        End If
        Call InitLoad()

    End Sub
    Private Sub recheck(ByVal pString As String, ByVal pEmailN As String, ByVal pEmailA As String, ByVal pEmailR As String, ByVal pEmailC As String, ByVal pEmailS As String)


        Dim item As RepeaterItem
        For Each item In rep.Items

            Dim lID As String = ""
            Dim mtTextBox2 As HiddenField = item.FindControl("txtid")
            If Not mtTextBox2 Is Nothing Then
                lID = mtTextBox2.Value
            End If

            If lID.Trim = "" Then

            Else
                If Microsoft.VisualBasic.InStr(";;" & pString, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBox5 As CheckBox = item.FindControl("chkfull")
                    If Not myCheckBox5 Is Nothing Then
                        myCheckBox5.Checked = True
                    End If
                End If

                If Microsoft.VisualBasic.InStr(";;" & pEmailN, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBox9 As CheckBox = item.FindControl("chkonnotify")
                    If Not myCheckBox9 Is Nothing Then
                        myCheckBox9.Checked = True
                    End If
                End If


                If Microsoft.VisualBasic.InStr(";;" & pEmailA, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBox6 As CheckBox = item.FindControl("chkonapprove")
                    If Not myCheckBox6 Is Nothing Then
                        myCheckBox6.Checked = True
                    End If
                End If

                If Microsoft.VisualBasic.InStr(";;" & pEmailS, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBoxS As CheckBox = item.FindControl("chkonapproves")
                    If Not myCheckBoxS Is Nothing Then
                        myCheckBoxS.Checked = True
                    End If
                End If


                If Microsoft.VisualBasic.InStr(";;" & pEmailR, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBox7 As CheckBox = item.FindControl("chkonreject")
                    If Not myCheckBox7 Is Nothing Then
                        myCheckBox7.Checked = True
                    End If
                End If

                If Microsoft.VisualBasic.InStr(";;" & pEmailC, ";;" & lID & ";;") > 0 Then
                    Dim myCheckBox8 As CheckBox = item.FindControl("chkoncancel")
                    If Not myCheckBox8 Is Nothing Then
                        myCheckBox8.Checked = True
                    End If
                End If


            End If


        Next


    End Sub

    Private Function ValidateForm()
        lblmessage.Text = ""
        If IsNumeric(bid.Value) = False Then
            lblMessage.Text = WebLib.getAlertMessageStyle("No workflow is selected. Please select a workflow")
            Return False
            Exit Function
        End If
        If IsNumeric(wui_no.Text) = False Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Seq No. is mandatory")
            Return False
            Exit Function
        End If

        If wui_name.Text.Trim = "" Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Action Name is mandatory")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Public Overrides Function LoadData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem
        If IsNumeric(rid.Value) = False Then

            Exit Function
        End If

        Try
            cmd.CommandText = "Select * from [workflowitems] where wui_id=" & rid.Value
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                wui_name.Text = dr("wui_name") & ""
                wui_no.Text = dr("wui_no") & ""
                templi = wui_approvestep.Items.FindByValue(dr("wui_approvestep") & "")
                wui_approvestep.SelectedIndex = wui_approvestep.Items.IndexOf(templi)
                templi = wui_rejectstep.Items.FindByValue(dr("wui_rejectstep") & "")
                wui_rejectstep.SelectedIndex = wui_rejectstep.Items.IndexOf(templi)
                templi = wui_cancelstep.Items.FindByValue(dr("wui_cancelstep") & "")
                wui_cancelstep.SelectedIndex = wui_cancelstep.Items.IndexOf(templi)
                wui_reject.Checked = WebLib.BitToBoolean(dr("wui_reject") & "")
                wui_cancel.Checked = WebLib.BitToBoolean(dr("wui_cancel") & "")
                wui_approve.Checked = WebLib.BitToBoolean(dr("wui_approve") & "")
                ucode.Value = dr("wui_ucode") & ""

                Try
                    wui_emailsf.Checked = WebLib.BitToBoolean(dr("wui_emailsf") & "")

                Catch ex As Exception

                End Try

                Try
                    wui_approvename.Text = dr("wui_approvename") & ""

                Catch ex As Exception

                End Try
                Try
                    wui_rejectname.Text = dr("wui_rejectname") & ""

                Catch ex As Exception

                End Try
                Try
                    wui_cancelname.Text = dr("wui_cancelname") & ""

                Catch ex As Exception

                End Try


                Try
                    wui_allowattach.Checked = WebLib.BitToBoolean(dr("wui_allowattach") & "")
                Catch ex As Exception

                End Try

                Try
                    wui_approveval.Checked = WebLib.BitToBoolean(dr("wui_approveval") & "")
                Catch ex As Exception

                End Try

                Try
                    wui_approvevalamt.text = dr("wui_approvevalamt") & ""
                Catch ex As Exception

                End Try

                Try
                    wui_approvalvalend.Checked = WebLib.BitToBoolean(dr("wui_approvalvalend") & "")
                Catch ex As Exception

                End Try



                Call recheck(dr("wui_rights") & "", dr("wui_emailN") & "", dr("wui_emailA") & "", dr("wui_emailR") & "", dr("wui_emailC") & "", dr("wui_emailS") & "")




                If WebLib.CodeExists(dr("wui_wid").ToString, "wfl_wflowid", "workflowlink", "wfl_id", "", "", "", "", "", "") Then
                    delbutton.Visible = False
                    Button3.Visible = False
                End If


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Function
    Public Sub savepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim insertfields, insertvalues As String
        Dim lType As String = ""
        Dim lsrdesc As String = ""
        Dim lQuestion As String = ""
        Dim lFooter As String = ""

        insertfields = ""
        insertvalues = ""
        If ValidateForm() = False Then
            Exit Sub
        End If

        Dim lapprovestep As String = ""
        If wui_approvestep.SelectedIndex < 0 Then
            lapprovestep = ""
        Else
            lapprovestep = wui_approvestep.SelectedItem.Value
        End If

        Dim lrejectstep As String = ""
        If wui_rejectstep.SelectedIndex < 0 Then
            lrejectstep = ""
        Else
            lrejectstep = wui_rejectstep.SelectedItem.Value
        End If


        Dim lcancelstep As String = ""
        If wui_cancelstep.SelectedIndex < 0 Then
            lcancelstep = ""
        Else
            lcancelstep = wui_cancelstep.SelectedItem.Value
        End If


        If isnumeric(wui_approvevalamt.text) = False Then
            wui_approvevalamt.text = "0.00"
        End If


        Dim lstring As String = ""
        Dim lemailA As String = ""
        Dim lemailR As String = ""
        Dim lemailC As String = ""
        Dim lemailN As String = ""
        Dim lemailS As String = ""

        Dim item As RepeaterItem
        Dim bCheck As Boolean
        For Each item In rep.Items

            Dim lID As String = ""
            Dim mtTextBox2 As HiddenField = item.FindControl("txtid")
            If Not mtTextBox2 Is Nothing Then
                lID = mtTextBox2.Value
            End If



            Dim lFull As String = ""
            Dim myCheckBox5 As CheckBox = item.FindControl("chkfull")
            If Not myCheckBox5 Is Nothing Then
                bcheck = myCheckBox5.Checked
            Else
                bcheck = False
            End If

            If lID.Trim = "" Then

            Else
                If bCheck = True Then
                    lstring = lstring & lID & ";;"
                End If


                myCheckBox5 = item.FindControl("chkonapprove")
                If Not myCheckBox5 Is Nothing Then
                    If myCheckBox5.Checked = True Then
                        lemailA = lemailA & lID & ";;"
                    End If
                End If


                myCheckBox5 = item.FindControl("chkonapproves")
                If Not myCheckBox5 Is Nothing Then
                    If myCheckBox5.Checked = True Then
                        lemailS = lemailS & lID & ";;"
                    End If
                End If

                myCheckBox5 = item.FindControl("chkonreject")
                If Not myCheckBox5 Is Nothing Then
                    If myCheckBox5.Checked = True Then
                        lemailR = lemailR & lID & ";;"
                    End If
                End If

                myCheckBox5 = item.FindControl("chkoncancel")
                If Not myCheckBox5 Is Nothing Then
                    If myCheckBox5.Checked = True Then
                        lemailC = lemailC & lID & ";;"
                    End If
                End If

                myCheckBox5 = item.FindControl("chkonnotify")
                If Not myCheckBox5 Is Nothing Then
                    If myCheckBox5.Checked = True Then
                        lemailN = lemailN & lID & ";;"
                    End If
                End If


            End If


        Next

        Try
            If rid.Value = "" Then
                ucode.Value = WebLib.getUniqueKey
                insertfields = insertfields & "wui_merchantid"
                insertvalues = insertvalues & "'" & WebLib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",wui_filter"
                insertvalues = insertvalues & ",'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",wui_name"
                insertvalues = insertvalues & ",'" & wui_name.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",wui_approvename"
                insertvalues = insertvalues & ",'" & wui_approvename.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",wui_rejectname"
                insertvalues = insertvalues & ",'" & wui_rejectname.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",wui_cancelname"
                insertvalues = insertvalues & ",'" & wui_cancelname.Text.Replace("'", "''") & "'"

                insertfields = insertfields & ",wui_ucode"
                insertvalues = insertvalues & ",'" & ucode.Value & "'"
                insertfields = insertfields & ",wui_approve"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_approve.Checked) & ""
                insertfields = insertfields & ",wui_approvestep"
                insertvalues = insertvalues & ",'" & lapprovestep & "'"
                insertfields = insertfields & ",wui_reject"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_reject.Checked) & ""
                insertfields = insertfields & ",wui_rejectstep"
                insertvalues = insertvalues & ",'" & lrejectstep & "'"


                insertfields = insertfields & ",wui_approveval"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_approveval.Checked) & ""
                insertfields = insertfields & ",wui_approvevalamt"
                insertvalues = insertvalues & "," & wui_approvevalamt.text & ""
                insertfields = insertfields & ",wui_approvalvalend"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_approvalvalend.Checked) & ""

                insertfields = insertfields & ",wui_allowattach"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_allowattach.Checked) & ""


                insertfields = insertfields & ",wui_emailsf"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_emailsf.Checked) & ""


                insertfields = insertfields & ",wui_cancel"
                insertvalues = insertvalues & "," & WebLib.BooleanToBit(wui_cancel.Checked) & ""
                insertfields = insertfields & ",wui_cancelstep"
                insertvalues = insertvalues & ",'" & lcancelstep & "'"
                insertfields = insertfields & ",wui_rights"
                insertvalues = insertvalues & ",'" & lstring & "'"

                insertfields = insertfields & ",wui_emailA"
                insertvalues = insertvalues & ",'" & lemailA & "'"


                insertfields = insertfields & ",wui_emailS"
                insertvalues = insertvalues & ",'" & lemailS & "'"

                insertfields = insertfields & ",wui_emailR"
                insertvalues = insertvalues & ",'" & lemailR & "'"
                insertfields = insertfields & ",wui_emailC"
                insertvalues = insertvalues & ",'" & lemailC & "'"
                insertfields = insertfields & ",wui_emailN"
                insertvalues = insertvalues & ",'" & lemailN & "'"


                insertfields = insertfields & ",wui_wid"
                insertvalues = insertvalues & "," & bid.Value & ""
                insertfields = insertfields & ",wui_no"
                insertvalues = insertvalues & "," & wui_no.Text & ""
                insertfields = insertfields & ",wui_createby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",wui_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",wui_updateby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",wui_updatedt"
                insertvalues = insertvalues & ",getdate()"
            Else
                insertvalues = insertvalues & "wui_name='" & wui_name.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",wui_approvename='" & wui_approvename.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",wui_rejectname='" & wui_rejectname.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",wui_cancelname='" & wui_cancelname.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",wui_allowattach=" & WebLib.BooleanToBit(wui_allowattach.Checked) & ""

                insertvalues = insertvalues & ",wui_approvestep='" & lapprovestep & "'"
                insertvalues = insertvalues & ",wui_approve=" & WebLib.BooleanToBit(wui_approve.Checked) & ""
                insertvalues = insertvalues & ",wui_rejectstep='" & lrejectstep & "'"
                insertvalues = insertvalues & ",wui_reject=" & WebLib.BooleanToBit(wui_reject.Checked) & ""
                insertvalues = insertvalues & ",wui_cancelstep='" & lcancelstep & "'"
                insertvalues = insertvalues & ",wui_cancel=" & WebLib.BooleanToBit(wui_cancel.Checked) & ""

                insertvalues = insertvalues & ",wui_emailsf=" & WebLib.BooleanToBit(wui_emailsf.Checked) & ""

                insertvalues = insertvalues & ",wui_rights='" & lstring & "'"

                insertvalues = insertvalues & ",wui_emailA='" & lemailA & "'"

                insertvalues = insertvalues & ",wui_emails='" & lemailS & "'"

                insertvalues = insertvalues & ",wui_emailR='" & lemailR & "'"
                insertvalues = insertvalues & ",wui_emailC='" & lemailC & "'"
                insertvalues = insertvalues & ",wui_emailN='" & lemailN & "'"

                insertvalues = insertvalues & ",wui_approveval=" & WebLib.BooleanToBit(wui_approveval.Checked) & ""
                insertvalues = insertvalues & ",wui_approvalvalend=" & WebLib.BooleanToBit(wui_approvalvalend.Checked) & ""
                insertvalues = insertvalues & ",wui_approvevalamt=" & wui_approvevalamt.text & ""

                insertvalues = insertvalues & ",wui_no=" & wui_no.Text & ""
                insertvalues = insertvalues & ",wui_updateby='" & WebLib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",wui_updatedt=getdate()"

            End If

            If savedata(insertfields, insertvalues, True) = True Then
                Call gotoback22()
            End If
        Catch Err As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(Err.Message)
        Finally

        End Try
    End Sub
    Public Sub gotoback2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call gotoback22()
    End Sub
    Private Sub gotoback22()
        Response.Redirect("postpage.aspx?NextPage=wbuilder.aspx&ga=" & bid.Value & "&ba=" & bid.Value & "&rc=")
    End Sub
    Public Sub loaddatarights(Optional ByVal _p_searchkey As String = "")

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
        cmd.CommandText = "Select wgroup.wo_name,wgroup.wo_id,workflowitemsrights.* from wgroup left outer join workflowitemsrights on wgroup.wo_id = wfi_gid and wfi_ucode='" & ucode.Value & "' " & _p_searchkey
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
    public Sub deleterec()
        Try
            Dim conn As New OleDbConnection(connectionstring)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim sql As String = "DELETE FROM " & TableName & " WHERE " & IDField & " = '" & rid.Value & "'"
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            cmd.Dispose()
            conn.Dispose()
            Call gotoback22()

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

End Class

