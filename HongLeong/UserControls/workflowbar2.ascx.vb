Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class UserControls_workflowbar2
    Inherits System.Web.UI.UserControl

    Public Event OnApproveEvent As System.EventHandler
    Public Event OnRejectEvent As System.EventHandler
    Public Event OnCancelEvent As System.EventHandler

    Private connectionstring As String = ConfigurationManager.AppSettings("ConnStr")
    Public parentobj As Object
    ' Public wstatus, lblmessage, wlevel, wlevelA, wucode, btnwapprove, btnwreject, btnwcancel, actype, artype, aatype, wwid, cus_wrefno, btntracking, btnattachments, litstatus, litdetails, wr, wrm, litapprovalperson, litattachments, litAudit, wlevelamt, wlevelamtend, wlevelamtenabled, wversion, btnwresend As Object
    Public workflownamespace As String = ""
    Public custommode As Boolean = False
    Public overridemode As Boolean = False
    Public attachmentbycreatoronly As Boolean = False
    Public isapproved As Boolean = False
    Public canattach As Boolean = False
    Dim _l_currentamt As String = 0
    Public ErrorMsg As String = ""
    Public StrictValidationGroup As Boolean = False

    Public Property statusGet() As String
        Get
            Return wstatus.Value

        End Get
        Set(value As String)

        End Set
    End Property
    Public Property wlevelAPget() As String
        Get
            Return wlevelAP.Value

        End Get
        Set(value As String)

        End Set
    End Property
    Public Property wlevelAget() As String
        Get
            Return wlevelA.Value

        End Get
        Set(value As String)

        End Set
    End Property
    Public Property wlevelNameget() As String
        Get
            Return wlevelName.Value

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property uid() As String
        Get
            Return wucode.Value
        End Get
        Set(ByVal value As String)
            wucode.Value = value

            Try
                btnwResend.Visible = True
            Catch ex As Exception
                btnwResend.Visible = False
            End Try
            Call LoadData()
            loadResults()
        End Set
    End Property
    Public Property wfAppLimit() As String
        Get
            Return wlevelamt.Value

        End Get
        Set(value As String)
            wlevelamt.Value = value
        End Set
    End Property
    Public Property DocumentAmt() As String
        Get
            If IsNumeric(_l_currentamt) = False Then
                _l_currentamt = 0
            End If
            Return _l_currentamt
        End Get
        Set(ByVal value As String)
            If IsNumeric(value) = False Then
                _l_currentamt = 0
            Else
                _l_currentamt = value
            End If
        End Set
    End Property
    Public Property WorkflowEnded() As Boolean
        Get
            If wstatus.Value.ToLower = "pending" Or wstatus.Value.ToLower.Trim = "" Then
                Return False
            Else
                isapproved = True
                Return True
            End If

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public Sub assignReviewers(ByVal users As ArrayList)
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        lsql = "insert into [wgroup]( [wo_name], [wo_createdt], [wo_updateby],[wo_updatedt],wo_createby, wo_lvl)" & " values( '" & wucode.Value & "'," & "getDate()" & ", '" & WebLib.LoginUser & "'," & "getDate()" & ", '" & WebLib.LoginUser & "','" & Convert.ToInt32(wlevelA.Value) + 1 & "' )"
        '   Try
        cn.Open()
        cmd.CommandText = lsql
        cmd.Connection = cn
        cmd.ExecuteNonQuery()


        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        Dim wgroup As String = ""
        Dim whg As String = ""


        If customRightsCheck(Convert.ToInt32(wlevelA.Value) + 1 & "") Then
            Try
                cmd.CommandText = "Select wo_id from wgroup where wo_name = '" & wucode.Value & "' and wo_lvl = " & Convert.ToInt32(wlevelA.Value) + 1 & ""
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    wgroup = dr("wo_id") & ";;"


                Next

            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try
        Else
            Try
                cmd.CommandText = "Select wui_rights from workflowitems where wui_wid = " & wwid.Value & " and wui_no =  = '" & Convert.ToInt32(wlevelA.Value) + 1 & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    wgroup = dr("wui_rights")


                Next

            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try

        End If


        lsql = "update [wfhorizontalrights] set [hwg_wgid] ='" & wgroup & "', [hwg_rights]='" & wgroup & "',[hwg_updatedby]='" & WebLib.LoginUser & "',[hwg_updatedt]=getDate() from [wfhorizontalrights] where hwg_wuid = '" & wwid.Value & "' and hwg_level = '" & Convert.ToInt32(wlevelA.Value) + 1 & "' and hwg_ucode = '" & wucode.Value & "'"
        cmd.CommandText = lsql
        cmd.Connection = cn
        cmd.ExecuteNonQuery()

        Try
            cmd.CommandText = "Select [hwg_uid] from [wfhorizontalrights] where [hwg_ucode] = '" & wucode.Value & "' and hwg_level = '" & Convert.ToInt32(wlevelA.Value) + 1 & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords2")
            For Each dr In ds.Tables("datarecords2").Rows
                whg = dr("hwg_uid")


            Next

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try

        For Each usr As String In users
            '    lsql = "insert into wfhorizontalapproval ([wfha_uid],[wfha_wfrid],[wfha_approved]) values ('" & usr & "','" & whg & "', '') "
            lsql = "insert into [wgrouprights]( [wur_uid], [wur_wgroupid], [wur_updateby],[wur_updatedt], [wur_filtercode])" & " values( '" & usr & "','" & wgroup.Replace(";;", "") & "', '" & WebLib.LoginUser & "'," & "getDate()" & ",'Filter' )"
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Next


        cn.Close()
        cmd.Dispose()
        cn.Dispose()


    End Sub
    Public Sub postComments(ByVal insertvalues As String, ByVal refno As String, ByVal notdraft As Boolean)
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()

        lblMessage.Text = wlevelA.Value


        lsql = "insert into zcustom_comments( [wf_refno],[cus_uid], [comment], [createddate], [wf_level], [wf_notdraft])" & " values( '" & wucode.Value & "'," & insertvalues & ", '" & wlevelA.Value & "', '" & notdraft & "' )"
        '   Try
        cn.Open()
        cmd.CommandText = lsql
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Dispose()
        cn.Dispose()

        '       Catch ex As Exception
        '    lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        '        End Try

    End Sub


    Public Function getComments() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim comList As New ArrayList()
        Try
            'cmd.CommandText = "Select usr_name, comment, (CONVERT(VARCHAR(25), createddate, 103) + ' ' + CONVERT(VARCHAR(8), createddate, 108)) as createddate, wui_name from zcustom_comments left join [workflowitems] on wf_level = wui_no left join secuserinfo on cus_uid = usr_code where wf_refno = '" & wucode.Value & "' and wui_wid = '" & wwid.Value & "' and wf_notdraft = 1 order by wf_level "
            cmd.CommandText = "Select usr_name, comment, createddate, wui_name from zcustom_comments left join [workflowitems] on wf_level = wui_no and wui_wid = '" & wwid.Value & "' left join secuserinfo on cus_uid = usr_code where wf_refno = '" & wucode.Value & "' and wf_notdraft = 1 order by createddate "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                comList.Add(dr("comment"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Return ds

    End Function
    Public Function getComments2() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim comList As New ArrayList()
        Try
            ' table:  (t)     char(10)    ;;
            cmd.CommandText = "Select usr_name, IIF(comment like '%(t)%', SUBSTRING(REPLACE(comment, char(10), '<br>'), 0, CHARINDEX('(t)', REPLACE(comment, char(10), '<br>'))) + '<table><tr><td>' + REPLACE(REPLACE(REPLACE(REPLACE((SUBSTRING(comment, CHARINDEX('(t)', comment), len(comment)- len( SUBSTRING(comment, 0,CHARINDEX('(t)', comment))) - len(SUBSTRING(comment, CHARINDEX('(/t)', comment), len(comment))) +4)), char(10), '</td></tr><tr><td>'), ';;', '</td><td>'), '(/t)', '</td></tr></table></div>'), '(t)', '<div><table class=''none'' style=''border:solid''><tr><td>') + '</td></tr></table>' + iif(len(SUBSTRING(comment + '', CHARINDEX('(/t)', comment)+4 , len(comment))) <= 0 ,'', SUBSTRING(REPLACE(comment, char(10), '<br>'), CHARINDEX('(/t)', REPLACE(comment, char(10), '<br>')) + 4, len(comment))) , REPLACE(comment, char(10), '<br>')) as comment, createddate, wui_name, isnull( wui_no,c.wf_level) as wui_no from zcustom_comments C " &
                                " inner join (select wf_level , max(createddate ) as MaxDate from zcustom_comments  where wf_refno  ='" & wucode.Value & "' group by wf_level) t on c.wf_level = t.wf_level and c.createddate = t.MaxDate " &
                                " left join secuserinfo on cus_uid = usr_code " &
                                " left join workflowitems on c.wf_level = wui_no and wui_wid = '" & wwid.Value & "'  " &
                                " where wf_refno = '" & wucode.Value & "' and wf_notdraft = 1  " &
                                " order by wui_no, c.createddate "
            LogtheAudit(cmd.CommandText)
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                comList.Add(dr("comment"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Return ds

    End Function
    Public Function getCommentsMul() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        Dim wf As String = ""
        Dim wfStartDate As String = ""
        Dim wfEndDate As String = ""
        Dim query As String = ""
        Dim comList As New ArrayList()
        Dim cmd1 As New OleDbCommand()
        Dim ad1 As New OleDb.OleDbDataAdapter()
        Dim ds1 As New DataSet()
        Dim dr1 As DataRow

        Try
            cmd.CommandText = "select min(wfa_createon) as starttime1, max(wfa_createon) as endtime1, convert(varchar,min(wfa_createon),120) as starttime, convert(varchar,max(wfa_createon),120) as endtime, " &
                                " case wfa_description when '' then (select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "') else wfa_description end as wfa_description " &
                                " from workflowaudit where wfa_ucode ='" & wucode.Value & "' group by wfa_description order by starttime "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            'For Each dr In ds.Tables("datarecords").Rows
            '    If query <> "" Then
            '        query = query & " union "
            '    End If
            '    query = query & "Select usr_name, comment, createddate, wui_name, isnull( wui_no,c.wf_level) as wui_no,wui_wid,com_id from zcustom_comments C " &
            '                        " inner join (select wf_level , max(createddate) as MaxDate from zcustom_comments  where wf_refno  ='" & wucode.Value & "' and createddate between '" & dr("starttime") & "' and dateadd(s,1,'" & dr("endtime") & "') group by wf_level) t on c.wf_level = t.wf_level and c.createddate = t.MaxDate " &
            '                        " left join secuserinfo on cus_uid = usr_code " &
            '                        " left join workflowitems on c.wf_level = wui_no and wui_wid = '" & dr("wfa_description").ToString.Replace("prev workflow ", "") & "'  " &
            '                        " where wf_refno = '" & wucode.Value & "' and wf_notdraft = 1  "
            'Next

            cn.Close()

            For Each dr In ds.Tables("datarecords").Rows

                'Dim stime As String = " (select min(wfa_createon) from workflowaudit where wfa_ucode ='" & wucode.Value & "' and IIF(wfa_description='',(select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "'),wfa_description) =  '" & dr("wfa_description") & "') "
                'Dim etime As String = " (select max(wfa_createon) from workflowaudit where wfa_ucode ='" & wucode.Value & "' and IIF(wfa_description='',(select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "'),wfa_description) =  '" & dr("wfa_description") & "') "

                Dim stime As String = " '" & dr("starttime") & "'"
                Dim etime As String = " '" & dr("endtime") & "'"

                'query = "Select usr_name, comment, createddate, wui_name, isnull( wui_no,c.wf_level) as wui_no,wui_wid,com_id from zcustom_comments C " &
                '        " inner join (select wf_level , max(createddate) as MaxDate from zcustom_comments  where wf_refno  ='" & wucode.Value & "' and createddate between " & stime & " and dateadd(s,1," & etime & ") group by wf_level) t on c.wf_level = t.wf_level and c.createddate = t.MaxDate " &
                '        " left join secuserinfo on cus_uid = usr_code " &
                '        " left join workflowitems on c.wf_level = wui_no and wui_wid = '" & dr("wfa_description").ToString.Replace("prev workflow ", "") & "'  " &
                '        " where wf_refno = '" & wucode.Value & "' and wf_notdraft = 1  "


                ' *** between dateadd(s,-1," & stime & ") > because insert into workflowaudit after zcustom_comment, to get zcustom_comment, get 1 second before
                ' *** between and dateadd(s,1," & etime & ") > because 2020-06-24 09:48:12.853 only can get 2020-06-24 09:48:12, get 1 second extra 
                query = "Select usr_name, REPLACE(comment, CHAR(10), '<br>') as comment, createddate, wui_name, isnull( wui_no,c.wf_level) as wui_no,wui_wid,com_id from zcustom_comments C " &
                        " inner join (select wf_level , max(createddate) as MaxDate from zcustom_comments  where wf_refno  ='" & wucode.Value & "' and createddate between dateadd(s,-1," & stime & ") and dateadd(s,1," & etime & ") group by wf_level) t on c.wf_level = t.wf_level and c.createddate = t.MaxDate " &
                        " left join secuserinfo on cus_uid = usr_code " &
                        " left join workflowitems on c.wf_level = wui_no and wui_wid = '" & dr("wfa_description").ToString.Replace("prev workflow ", "") & "'  " &
                        " where wf_refno = '" & wucode.Value & "' and wf_notdraft = 1  "

                Try
                    cmd1.CommandText = "select * from ( " & query & " ) t order by wui_no, createddate"
                    cmd1.Connection = cn
                    ad1.SelectCommand = cmd1
                    ad1.Fill(ds1, "datarecords")

                    For Each dr1 In ds1.Tables("datarecords").Rows
                        comList.Add(dr1("comment"))
                    Next
                Catch ex As Exception
                    Dim derew As String = ex.Message
                End Try
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Return ds1
    End Function
    Public Function validateUpload(ByVal dtype As String) As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim drows As Integer = 0
        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from docdoc where doc_uniqueid = '" & wucode.Value & "' and doc_keywords like  '" & dtype & "%'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            drows = ds.Tables("datarecords").Rows.Count




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        If drows > 0 Then
            Return True
        Else Return False
        End If

    End Function
    Public Function getDepartments(ByVal lplant As String) As ArrayList
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from department where de_plant = '" & lplant & "' "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            depList.Add("- Select Department -")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                depList.Add(dr("de_name"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Return depList

    End Function

    Public Function getPlants() As ArrayList
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim plantList As New ArrayList()
        plantList.Add(" - Select Plant - ")
        Try
            cmd.CommandText = "Select * from branch where br_createdt >" & "'20190101'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                plantList.Add(dr("br_code"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Return plantList

    End Function
    Public Sub loadResults()
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""
        Dim lsql As String = ""
        Dim results As String = ""
        Try
            lsql = lsql & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL  "
            lsql = lsql & "BEGIN "
            lsql = lsql & "DROP TABLE #tempAlltable  "
            lsql = lsql & "END  "
            lsql = lsql & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant, cus_remarks2 from zcustom_oq union  "
            lsql = lsql & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant,cus_remarks2 from zcustom_pq union  "
            lsql = lsql & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant,cus_remarks2 from zcustom_iq union  "
            lsql = lsql & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_createby, cus_createdt, cus_prono,cus_department,cus_plant,cus_remarks2 from zcustom_vr) x  "
            lsql = lsql & " "
            lsql = lsql & "Select cus_remarks2 "
            lsql = lsql & "from #tempAlltable where cus_ucode = '" & wucode.Value & "'"
            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                results = dr("cus_remarks2") & ""
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception

        End Try


        If results <> "" Then
            resultsCard.Attributes.CssStyle.Remove("Display")
            resultsCard.Attributes.CssStyle.Add("Display", "block")
            Select Case results
                Case "1"

                    litresults.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/pass.png") & """ width=""100%"">"

                Case "0"
                    litresults.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/fail.png") & """ width=""100%"">"

            End Select
        End If

    End Sub
    Public Function LoadData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem



        litdetails.Text = "<font color=""red"">Pending Document Creation<font>"


        If wucode.Value.Trim = "" Then

            Call setstatus("")
            Exit Function
        End If

        If (wr.Value & "").Trim = "" Then
            Call GetRights()
        End If


        Try
            cmd.CommandText = "Select wst_workflowid,wst_level,wst_refno,wst_status,(CONVERT(VARCHAR(25), wst_lastupdateon, 103) + ' ' + CONVERT(VARCHAR(8), wst_lastupdateon, 108)) as wst_lastupdateon from workflowstatus where wst_ucode='" & wucode.Value & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                wwid.Value = dr("wst_workflowid") & ""
                wlevel.Value = dr("wst_level") & ""

                cus_wrefno.Value = dr("wst_refno") & ""
                wstatus.Value = dr("wst_status") & ""


                getLevelA()
                getLevelName()
                getLevelAP()
                getTableNameByUcode()


                If (dr("wst_lastupdateon") & "").trim <> "" Then
                    litdetails.Text = "Current Approval Level : <b>" & dr("wst_level") & "</b><br>Last Action On :-<br>" & dr("wst_lastupdateon") & ""
                Else
                    litdetails.Text = "Current Approval Level : <b>" & dr("wst_level") & "</b>"
                End If

                Call setstatus(dr("wst_status") & "")

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


            If StrictValidationGroup = True Then
                EnableDisable2(Page)
            Else
                EnableDisable(Page)
            End If


            LoadAudit()

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Function
    Private Function getLevelA()
        Dim ooWorkflow As New clsWorkflow
        wlevelA.Value = ooWorkflow.GetLevelNobySequence(wwid.Value, wlevel.Value)
        ooWorkflow = Nothing
    End Function
    Private Function getTableNameByUcode()
        Dim getmodule As String = WebLib.GetValue("workflowstatus", "wst_module", "wst_ucode", "'" & wucode.Value & "'", "", "")
        Dim gettablename As String = ""
        If getmodule = "zcustom_dn" Or getmodule = "zcustom_dn2" Or getmodule = "zcustom_dn3" Or getmodule = "zcustom_cn" Or getmodule = "zcustom_cn2" Or getmodule = "zcustom_cn3" Then
            gettablename = "zcustom_dncn"
        ElseIf getmodule = "zcustom_ccr" Or getmodule = "zcustom_ccrp" Or getmodule = "zcustom_ccrs" Or getmodule = "zcustom_ccrc" Then
            gettablename = "zcustom_ccr"
        ElseIf getmodule = "zcustom_clexceed" Then
            gettablename = "zcustom_climit"
        Else
            gettablename = getmodule
        End If
        wtablename.Value = gettablename
    End Function
    Private Function getLevelAP()
        Dim ooWorkflow As New clsWorkflow

        Dim str As String = "Select top 1 ROW_NUMBER() OVER(ORDER BY wui_no asc) AS wui_no, wui_pno from workflowitems where wui_wid=" + wwid.Value + " and isnull(wui_no,0)<=" + wlevel.Value + " order by wui_no desc"
        ooWorkflow = Nothing

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                wlevelAP.Value = dr("wui_pno") & ""

            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try


    End Function
    Private Function getLevelName()
        Dim ooWorkflow As New clsWorkflow

        Dim str As String = ooWorkflow.getLevelNameSQL(wwid.Value, wlevel.Value)
        ooWorkflow = Nothing

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                wlevelName.Value = dr("wui_name") & ""

            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try


    End Function
    Private Function getAuditSQL(ByVal pType As String, ByVal pRefNo As String, ByVal pDescription As String, ByVal pucode As String) As String

        Dim ooWorkFlow As New clsWorkflow
        Return ooWorkFlow.getAuditSQL(wlevel.Value, pType, pRefNo, pDescription, pucode)
        ooWorkFlow = Nothing
        Exit Function

        '        Dim pLevel As String
        '       pLevel = wlevel.Value

        '        If IsNumeric(pLevel) = False Then
        'pLevel = "NULL"
        ' End If

        '        Return "Insert into workflowaudit (wfa_code,wfa_refno,wfa_description,wfa_ucode,wfa_createon,wfa_createby,wfa_merchantid,wfa_filtercode,wfa_level) Values " & _
        '                       "('" & pType & "','" & pRefNo & "','" & pDescription & "','" & pucode & "',getdate(),'" & WebLib.LoginUser & "','" & WebLib.MerchantID & "','" & WebLib.FilterCode & "'," & pLevel & ")"

    End Function
    Public Function GetWorkFlowSaveSQL(ByVal WorkflowID As String, ByVal UniqueCode As String, ByVal isCreate As Boolean, ByVal RefNo As String, ByVal Modulecode As String, ByVal DocumentTitle As String, Optional ByVal Param1 As String = "", Optional ByVal Param2 As String = "", Optional ByVal Param3 As String = "", Optional ByVal Param4 As String = "") As String
        Dim ltempsql As String
        If isCreate = True Then
            If IsNumeric(WorkflowID) = False Then
                Return ""
                Exit Function
            End If
            If Modulecode.Trim = "" Then
                Return ""
                Exit Function
            End If
            If UniqueCode.Trim = "" Then
                Return ""
                Exit Function
            End If

            'ltempsql = "Insert into workflowstatus (wst_workflowid,wst_ucode,wst_refno,wst_module,wst_status,wst_level,wst_merchantid,wst_filtercode,wst_createon,wst_createby,wst_subject) Values " & _
            '           "(" & WorkflowID & ",'" & UniqueCode & "','" & RefNo.Replace("'", "''") & "','" & Modulecode & "','Pending',1,'" & WebLib.MerchantID & "','" & WebLib.FilterCode & "',getdate(),'" & WebLib.LoginUser & "','" & DocumentTitle.ToString.Replace("'", "''") & "')"

            'Change to SAVE Level 2, Level 1 is always creator


            'ltempsql = "Insert into workflowstatus (wst_workflowid,wst_ucode,wst_refno,wst_module,wst_status,wst_level,wst_merchantid,wst_filtercode,wst_createon,wst_createby,wst_subject) Values " & _
            '"(" & WorkflowID & ",'" & UniqueCode & "','" & RefNo.Replace("'", "''") & "','" & Modulecode & "','Pending',2,'" & WebLib.MerchantID & "','" & WebLib.FilterCode & "',getdate(),'" & WebLib.LoginUser & "','" & DocumentTitle.ToString.Replace("'", "''") & "')"


            'Will only run 1 time, which is the first time
            Dim lnextlevel As String
            Dim ooLevel As New clsWorkflow
            lnextlevel = ooLevel.GetNextLevel(WorkflowID, "1")
            ooLevel = Nothing
            If IsNumeric(lnextlevel) = False Then
                lnextlevel = 1
            End If

            'Hardcode to 1 after save...need to submit - 20151130
            lnextlevel = 1

            'ltempsql = "Insert into workflowstatus (wst_workflowid,wst_ucode,wst_refno,wst_module,wst_status,wst_level,wst_merchantid,wst_filtercode,wst_createon,wst_createby,wst_subject) Values " & _
            '"(" & WorkflowID & ",'" & UniqueCode & "','" & RefNo.Replace("'", "''") & "','" & Modulecode & "','Pending'," & lnextlevel & ",'" & WebLib.MerchantID & "','" & WebLib.FilterCode & "',getdate(),'" & WebLib.LoginUser & "','" & DocumentTitle.ToString.Replace("'", "''") & "')"
            'EUVERN 290419 Added draft status instead of pending
            ltempsql = "Insert into workflowstatus (wst_workflowid,wst_ucode,wst_refno,wst_module,wst_status,wst_level,wst_merchantid,wst_filtercode,wst_createon,wst_createby,wst_subject,wst_param1,wst_param2,wst_param3,wst_param4) Values " &
            "(" & WorkflowID & ",'" & UniqueCode & "','" & RefNo.Replace("'", "''") & "','" & Modulecode & "','Pending'," & lnextlevel & ",'" & WebLib.MerchantID & "','" & WebLib.FilterCode & "',getdate(),'" & WebLib.LoginUser & "','" & DocumentTitle.ToString.Replace("'", "''") & "','" & Utils.checktext(Param1) & "','" & Utils.checktext(Param2) & "','" & Utils.checktext(Param3) & "','" & Utils.checktext(Param4) & "')"

            wwid.Value = WorkflowID
            wucode.Value = UniqueCode
            ltempsql = ltempsql & ";" & getAuditSQL("CREATE", RefNo, "", UniqueCode)



        Else
            ltempsql = ""

        End If

        Return ltempsql
    End Function
    Private Function isrework() As Boolean

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        '    Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()

        ltemp = "select wst_ucode,wst_rework from workflowstatus where wst_ucode='" & wucode.Value & "' and wst_rework = 'True' "

        Try
            'cn.Open()
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds2, "datarecords2")
            'For Each dr In ds2.Tables("datarecords2").Rows

            'Next


            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception

        End Try
        If ds2.Tables("datarecords2").Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub setstatus(ByVal paStatus As String)
        btnwApprove.Enabled = False
        btnwReject.Enabled = False
        btnwCancel.Enabled = False
        btnAttachments.Enabled = True
        btnTracking.Enabled = True
        btnwResend.Visible = False

        If custommode = True Then
            btnwApprove.Visible = False
            btnwReject.Visible = False
            btnwCancel.Visible = False

        Else
            btnwApprove.Visible = True
            btnwReject.Visible = True
            btnwCancel.Visible = True

        End If


        Try
            If WebLib.LoginIsFullAdmin = True Or WebLib.hasrights("workflow_resend", "WORKFLOW", "WR0005") Then
                btnwResend.Visible = True
            End If
        Catch ex As Exception

        End Try


        If attachmentbycreatoronly = True Then

            If IsNumeric(wlevelA.Value) = True Then
                If CLng(wlevelA.Value) > 1 Then
                    btnAttachments.Visible = False
                Else
                    btnAttachments.Visible = True

                End If
            End If


        Else
            btnAttachments.Visible = True


        End If



        If (workflownamespace & "").Trim = "" Then

            btnAttachments.Enabled = False
            btnTracking.Enabled = False
            litdetails.Text = "<font color=""red"">WORKFLOW NAMESPACE NOT DEFINED<font>"
            Exit Sub
        End If

        Select Case paStatus.ToLower

            Case "pending"
                litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/pending300.png") & """ width=""100%"">"
                If isrework() Then
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/rework300.png") & """ width=""100%"">"
                End If

            Case "approved"
                If WebLib.isStaff = True Then
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/approve300.png") & """ width=""100%"">"
                Else
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/closed300.jpg") & """ width=""100%"">"
                End If

            Case "rejected"
                If WebLib.isStaff = True Then
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/rejected300.png") & """ width=""100%"">"
                Else
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/closed300.jpg") & """ width=""100%"">"
                End If
            Case "cancelled"
                If WebLib.isStaff = True Then
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/cancelled300.jpg") & """ width=""100%"">"
                Else
                    litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/closed300.jpg") & """ width=""100%"">"
                End If
            Case Else
                litstatus.Text = "<img src=""" & WebLib.ClientURL("graphics/chops/pending300.png") & """ width=""100%"">"
                btnAttachments.Enabled = False
                btnTracking.Enabled = False

        End Select
        If paStatus.ToLower <> "pending" Then

            Call GetAttachments()
            Call GetAuditLogs()
            btnAttachments.Visible = False

            Exit Sub


        Else

            Call loadActions(wlevel.Value)
            Call GetApprovalPerson()
            Call GetAttachments()
            Call GetAuditLogs()

        End If

    End Sub
    Private Function horizontalPersonApprovalCheck() As Boolean
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        Dim hashori As Boolean = False
        Dim isApproved As Boolean = False
        Dim hasapproved As String = ""
        Dim depList As New ArrayList()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""
        Try
            cmd.CommandText = "Select * from [wfhorizontalrights] left join [workflowitems] on [hwg_wuid] = [wui_wid] and [hwg_level] = [wui_no] where wui_wid = '" & wwid.Value & "' and wui_no = '" & wlevel.Value & "' and [wui_horizontal] = 'True' and hwg_ucode = '" & wucode.Value & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                hasapproved = dr("hwg_approved").ToString.Trim
            Next

        Catch e As Exception

        End Try

        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        ad.Dispose()

        If (luserid & "").Trim = "" Then
            Return False
            Exit Function
        End If
        luserid = luserid & ";;"
        Dim lrightstring As String = "|" & luserid.Replace(";;", ";;|")

        If Right(lrightstring, 1) = "|" Then
            lrightstring = Left(lrightstring, lrightstring.Length - 1)
        End If

        Dim temp
        Dim lvalue As String = ""
        temp = Microsoft.VisualBasic.Split(hasapproved.Replace(" ", ""), ";;")

        If UBound(temp) = 0 Then
            lvalue = hasapproved.Replace(" ", "")
            If InStr(1, lrightstring, "|" & lvalue & ";;") < 1 Then
                isApproved = False
            End If


        Else
            Dim counter As Integer
            For counter = 0 To UBound(temp)
                lvalue = temp(counter)
                If InStr(1, lrightstring, "|" & lvalue & ";;") >= 1 Then
                    isApproved = True

                    Exit For
                End If

            Next
        End If



        Return isApproved

    End Function
    Private Function horizontalApprovalCheck() As Boolean
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        Dim hashori As Boolean = False
        Dim isApproved As Boolean = False
        Dim hasapproved As String = ""
        Dim hasrights As String = ""
        Dim depList As New ArrayList()
        hasrights = (wrm.Value & "").Replace(";;", ",")
        Dim userlst As New ArrayList()

        If hasrights.Trim <> "" Then
            hasrights = hasrights & "-1"
        End If




        Try
            cmd.CommandText = "Select * from [wfhorizontalrights] left join [workflowitems] on [hwg_wuid] = [wui_wid] and [hwg_level] = [wui_no] where wui_wid = '" & wwid.Value & "' and wui_no = '" & wlevel.Value & "' and [wui_horizontal] = 'True' and hwg_ucode = '" & wucode.Value & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                hasapproved = dr("hwg_approved").ToString.Trim

            Next
            cmd.CommandText = "Select distinct usr_name, usr_id from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & hasrights & ") "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords2")
            hasrights = ""
            For Each dr In ds.Tables("datarecords2").Rows
                hasrights = hasrights & dr("usr_id") & ";;"
            Next


        Catch e As Exception

        End Try

        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        ad.Dispose()
        If (hasapproved & "").Trim = "" Then
            Return False
            Exit Function
        End If

        If (hasrights & "").Trim = "" Then
            Return False
            Exit Function
        End If

        Dim lvalue As String = ""
        Dim hasapprovedlist As String() = Microsoft.VisualBasic.Split(hasapproved.Replace(" ", ""), ";;")
        Dim rightslist As String() = Microsoft.VisualBasic.Split(hasrights.Replace(" ", ""), ";;")
        Dim approvalcount As Integer = 0
        Dim hasapprovedcheck As String = ""
        For x As Integer = 0 To hasapprovedlist.Length - 1

            For y As Integer = 0 To rightslist.Length - 1
                If hasapprovedlist(x) = rightslist(y) Then
                    approvalcount = approvalcount + 1
                    hasapprovedcheck = hasapprovedcheck & "," & rightslist(y)
                End If
            Next
        Next
        If approvalcount = rightslist.Length Then
            isApproved = True
        End If

        Return isApproved

    End Function
    Private Sub horizontalApprove()
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""
        '  Dim ad As New OleDb.OleDbDataAdapter()
        '    Dim ds As New DataSet()
        '   Dim dr As DataRow

        lsql = "UPDATE [wfhorizontalrights] SET [hwg_approved] = (isnull(hwg_approved,'') + '" & luserid & ";;') from [wfhorizontalrights] left join [workflowitems] on [hwg_wuid] = [wui_wid] where wui_wid = '" & wwid.Value & "' and wui_no = '" & wlevel.Value & "' and [wui_horizontal] = 'True' and hwg_ucode = '" & wucode.Value & "'"
        '   Try 
        cn.Open()
        cmd.CommandText = lsql
        cmd.Connection = cn
        cmd.ExecuteNonQuery()

        cn.Close()
        cmd.Dispose()
        cn.Dispose()


    End Sub
    Private Function depAprvCheck(Optional ByVal lvl As String = "") As Boolean
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow

        If wwid.Value = "" Then
            Try
                cmd.CommandText = "Select * from workflowstatus where wst_ucode='" & wucode.Value & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows

                    wwid.Value = dr("wst_workflowid") & ""
                    wlevel.Value = dr("wst_level") & ""

                    Exit For
                Next
            Catch
            End Try


        End If
        If lvl = "" Then
            lvl = wlevel.Value
        End If
        Dim isApproved As Boolean = False

        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from [workflowitems] where wui_wid = '" & wwid.Value & "' and wui_no = '" & lvl & "' and [wui_departmentrights] = 'True'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords2")
            For Each dr In ds.Tables("datarecords2").Rows
                isApproved = True
            Next

        Catch e As Exception

        End Try

        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        ad.Dispose()

        Return isApproved

    End Function
    Private Function customRightsCheck(Optional ByVal lvl As String = "") As Boolean
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        If lvl = "" Then
            lvl = wlevel.Value
        End If

        Dim isApproved As Boolean = False

        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from [workflowitems] where wui_wid = '" & wwid.Value & "' and wui_no = '" & lvl & "' and [wui_customrights] = 'True'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                isApproved = True
            Next

        Catch e As Exception

        End Try

        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        ad.Dispose()

        Return isApproved

    End Function
    Private Function horizontalCheck() As Boolean
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow

        Dim isApproved As Boolean = False

        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from [workflowitems] where wui_wid = '" & wwid.Value & "' and wui_no = '" & wlevel.Value & "' and [wui_horizontal] = 'True'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                isApproved = True
            Next

        Catch e As Exception

        End Try

        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        ad.Dispose()
        backend.createHorizontal(wucode.Value, Convert.ToInt32(wlevel.Value) + 1 & "", wwid.Value)
        Return isApproved

    End Function
    Private Function getActionActionSQL(ByVal pActionValue As String, ByVal pActionStatus As String) As String
        Dim lLevel As String = ""
        Dim lSQL As String = ""
        lLevel = wlevel.Value

        If IsNumeric(lLevel) = False Then
            lLevel = 0
        End If


        '**** Added for Amount Control ********
        '21082016
        Try

            If pActionStatus.ToLower = "approved" Then
                If (wlevelamtenabled.Value & "").ToLower.Trim = "true" Then
                    If IsNumeric(wlevelamt.Value) = False Then
                        wlevelamt.Value = 0
                    End If

                    If CDbl(DocumentAmt) > CDbl(wlevelamt.Value) Then
                        ' pActionValue = 2 'Force Proceed next level (cant approve this amount)
                        'No need do anything
                    Else
                        If (wlevelamtend.Value & "").ToLower.Trim = "true" Then
                            pActionValue = 1 'Force End workflow cause amount met
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        '**************************************


        Select Case pActionValue.ToLower

            Case "1"  'End Workflow
                'Remove merchant ID, if not cant update status sometimes
                '                lSQL = "Update WorkflowStatus set wst_lastupdateon=getdate(),wst_status='" & pActionStatus & "' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_merchantid='" & WebLib.MerchantID & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                lSQL = "Update WorkflowStatus set wst_lastupdateby='" & WebLib.LoginUser & "',wst_lastupdateon=getdate(),wst_status='" & pActionStatus & "',wst_rework = 'False' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                If pActionStatus.ToLower = "approved" Then
                    isapproved = True
                End If


            Case "2"  'Proceed Next Approval
                Dim lnextlevel As String
                Dim ooLevel As New clsWorkflow
                If horizontalCheck() Then
                    horizontalApprove()
                    If horizontalApprovalCheck() Then
                        lnextlevel = ooLevel.GetNextLevel(wwid.Value, lLevel)
                    Else
                        lnextlevel = lLevel
                    End If
                Else
                    lnextlevel = ooLevel.GetNextLevel(wwid.Value, lLevel)
                    ooLevel = Nothing
                End If
                If IsNumeric(lnextlevel) = False Then
                    lSQL = ""
                Else
                    'Remove merchant ID, if not cant update status sometimes
                    'lSQL = "Update WorkflowStatus set wst_lastupdateon=getdate(), wst_level = " & lnextlevel & " where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_merchantid='" & WebLib.MerchantID & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                    lSQL = "Update WorkflowStatus set wst_lastupdateby='" & WebLib.LoginUser & "',wst_lastupdateon=getdate(), wst_level = " & lnextlevel & ",wst_rework = 'False' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                End If

            Case "3"  'Back to Creator
                'Remove merchant ID, if not cant update status sometimes
                'lSQL = "Update WorkflowStatus set wst_lastupdateon=getdate(), wst_level = 1,wst_status='Pending' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_merchantid='" & WebLib.MerchantID & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                'EUVERN 290419 ADDED REWORK STATUS FOR REJECTED ITEMS
                lSQL = "Update WorkflowStatus set wst_lastupdateby='" & WebLib.LoginUser & "',wst_lastupdateon=getdate(), wst_level = 1,wst_status='Pending', wst_rework = 'True' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_filtercode='" & WebLib.FilterCode & "'"

            Case "4"  'Back to Previous Step
                If CLng(lLevel) > 1 Then
                    Dim lprevlevel As String
                    Dim ooLevel As New clsWorkflow
                    lprevlevel = ooLevel.GetPreviousLevel(wwid.Value, lLevel)
                    ooLevel = Nothing
                    If IsNumeric(lprevlevel) = False Then
                        lSQL = ""
                    Else
                        'Remove merchant ID, if not cant update status sometimes
                        'lSQL = "Update WorkflowStatus set wst_lastupdateon=getdate(), wst_level =" & lprevlevel & " where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_merchantid='" & WebLib.MerchantID & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                        lSQL = "Update WorkflowStatus set wst_lastupdateby='" & WebLib.LoginUser & "',wst_lastupdateon=getdate(), wst_level =" & lprevlevel & ",wst_rework = 'True' where wst_level=" & lLevel & " and wst_ucode='" & wucode.Value & "' and wst_filtercode='" & WebLib.FilterCode & "'"
                    End If

                End If
        End Select

        Return lSQL

    End Function
    Private Sub getDocs()



    End Sub
    Public Function getapprovesql(Optional ByVal pType As String = "") As String

        Dim lsql As String = ""
        Dim lAction As String = ""


        Select Case pType.ToLower

            Case "reject"
                lsql = getActionActionSQL(aRType.Value, "Rejected")
                lAction = btnwReject.Text
                If (lAction & "").Trim = "" Then
                    lAction = "Reject"
                End If
                'lsql = lsql & ";" & getAuditSQL("Reject", cus_wrefno.Value, "", wucode.Value)
                lsql = lsql & ";" & getAuditSQL(lAction, cus_wrefno.Value, "", wucode.Value)

            Case "cancel"
                lsql = getActionActionSQL(aCType.Value, "Cancelled")
                lAction = btnwCancel.Text
                If (lAction & "").Trim = "" Then
                    lAction = "Cancel"
                End If

                'lsql = lsql & ";" & getAuditSQL("Cancel", cus_wrefno.Value, "", wucode.Value)
                lsql = lsql & ";" & getAuditSQL(lAction, cus_wrefno.Value, "", wucode.Value)

            Case "approve"
                lsql = getActionActionSQL(aAType.Value, "Approved")
                lAction = btnwApprove.Text
                If (lAction & "").Trim = "" Then
                    lAction = "Approve"
                End If


                'lsql = lsql & ";" & getAuditSQL("Approve", cus_wrefno.Value, "", wucode.Value)
                lsql = lsql & ";" & getAuditSQL(lAction, cus_wrefno.Value, "", wucode.Value)

            Case Else

        End Select


        Return lsql
    End Function
    Private Sub ApproveMod()
        RaiseEvent OnApproveEvent(Me, New EventArgs())

    End Sub
    Public Function notifyusers(ByVal pAction As String, Optional ByVal adhocSendToCust As String = "", Optional ByVal adhocSendToEmail As String = "") As Boolean
        Dim emailLevel As String = (Convert.ToInt32(wlevelA.Value) + 1 & "")
        If customRightsCheck(Convert.ToInt32(wlevelA.Value) & "") Then
            If horizontalApprovalCheck() Then

            Else
                Return True
                Exit Function
            End If
        End If

        If customRightsCheck(emailLevel) Then
            pAction = "H"
        ElseIf depAprvCheck(emailLevel) Then
            pAction = "D"
        Else

            Select Case pAction.ToLower
                Case "approve"
                    If isapproved = True Then
                        pAction = "A"
                    Else
                        pAction = "U"
                    End If
                Case "route"
                    pAction = "U"
                Case "reject"
                    pAction = "R"
                Case "cancel"
                    pAction = "C"
                Case "close"
                    pAction = "L"
                Case "submit"
                    pAction = "S"
                Case Else
                    ErrorMsg = "Action not defined"
                    Return False
                    Exit Function

            End Select
        End If

        If pAction.Trim = "" Then
            ErrorMsg = "Action not defined"
            Return False
            Exit Function
        End If
        Dim ooemail As New clsWorkflowEmail

        Dim pLevel As String
        pLevel = wlevel.Value

        If IsNumeric(pLevel) = False Then
            pLevel = 1
        End If
        If IsNumeric(wwid.Value) = False Then
            ErrorMsg = "Workflow not defined"
            Return False
            Exit Function
        End If


        Dim lversion2 As Boolean = False
        If (wversion.Value & "").Trim = "2" Then
            lversion2 = True
        End If

        If ooemail.NotifyUsers(wwid.Value, pLevel, pAction, workflownamespace, wucode.Value, lversion2, adhocSendToCust, adhocSendToEmail) = False Then


            ErrorMsg = ooemail.ErrorMsg
            Return False

            lblMessage.Text = WebLib.getAlertMessageStyle(ooemail.ErrorMsg)
            Exit Function
        End If

        Try


            If pAction = "U" Or pAction = "D" Then  '****** Added on 2016/10/20 to stop sending notification if is not route to top
                If ooemail.NotifyUsers(wwid.Value, pLevel, "N", workflownamespace, wucode.Value) = False Then
                    ErrorMsg = ooemail.ErrorMsg
                    Return False

                    lblMessage.Text = WebLib.getAlertMessageStyle(ooemail.ErrorMsg)
                    Exit Function

                End If
            End If  '**** End of Add

        Catch ex As Exception

        End Try

        ooemail = Nothing
        Return True
    End Function
    Public Sub resend(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lversion2 As Boolean = False
        Dim pLevel As String

        Dim ooLevel As New clsWorkflow
        pLevel = ooLevel.GetPreviousLevel(wwid.Value, wlevel.Value)
        ooLevel = Nothing

        If IsNumeric(pLevel) = False Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Invalid Level")
            Exit Sub
        End If
        If IsNumeric(wwid.Value) = False Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Wrokflow not defined")
            Exit Sub
        End If


        Try
            cmd.CommandText = "Select top 1 wui_emailSf from workflowitems where wui_wid=" & wwid.Value & " and isnull(wui_no,0)=" & pLevel & " order by wui_no asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                Try
                    If WebLib.BitToBoolean(dr("wui_emailSf") & "") = True Then
                        lversion2 = True
                    Else
                        lversion2 = False
                    End If
                Catch ex As Exception
                    lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                    Exit Sub
                End Try


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Exit Sub
        End Try


        Dim ooemail As New clsWorkflowEmail



        If ooemail.NotifyUsers(wwid.Value, pLevel, "U", workflownamespace, wucode.Value, lversion2) = False Then
            ErrorMsg = ooemail.ErrorMsg
            lblMessage.Text = WebLib.getAlertMessageStyle(ooemail.ErrorMsg)
        Else
            lblMessage.Text = WebLib.getAlertMessageStyle("Email Resent Successful")
        End If

        ooemail = Nothing

    End Sub
    Public Sub approve(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If overridemode = True Then
            Call ApproveMod()
            Exit Sub
        End If


        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim counter As Integer = 0

        If IsNumeric(wwid.Value) = False Then
            Exit Sub
        End If
        Dim lsql As String
        '        lsql = getActionActionSQL(aAType.Value, "Approved")
        '       lsql = lsql & ";" & getAuditSQL("Approve", cus_wrefno.Value, "", wucode.Value)
        lsql = getapprovesql("approve")
        Try
            cn.Open()
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            'Call LoadData()
            '            response.redirect(redirector.
            Call notifyusers("approve")

            Response.Redirect("~/" & Redirector.Redirect(workflownamespace, wucode.Value, False))


        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Sub
    Private Sub rejectMod()

        RaiseEvent OnRejectEvent(Me, New EventArgs())

    End Sub
    Public Sub reject(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If overridemode = True Then
            Call rejectMod()
            Exit Sub
        End If

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim counter As Integer = 0

        If IsNumeric(wwid.Value) = False Then
            Exit Sub
        End If
        Dim lsql As String
        '        lsql = getActionActionSQL(aRType.Value, "Rejected")
        '       lsql = lsql & ";" & getAuditSQL("Reject", cus_wrefno.Value, "", wucode.Value)
        lsql = getapprovesql("reject")
        Try
            cn.Open()
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            '            Call LoadData()
            Call notifyusers("reject")

            Response.Redirect("~/" & Redirector.Redirect(workflownamespace, wucode.Value, False))

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try

    End Sub
    Private Sub CancelMod()
        RaiseEvent OnCancelEvent(Me, New EventArgs())

    End Sub
    Public Sub cancel(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If overridemode = True Then

            Call CancelMod()
            Exit Sub
        End If


        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim counter As Integer = 0

        If IsNumeric(wwid.Value) = False Then
            Exit Sub
        End If
        Dim lsql As String
        '        lsql = getActionActionSQL(aCType.Value, "Cancelled")
        '       lsql = lsql & ";" & getAuditSQL("Cancel", cus_wrefno.Value, "", wucode.Value)
        lsql = getapprovesql("cancel")
        Try
            cn.Open()
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Call notifyusers("cancel")

            '            Call LoadData()
            Response.Redirect("~/" & Redirector.Redirect(workflownamespace, wucode.Value, False))

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Sub
    Public Sub viewattach(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        If wucode.Value.Trim = "" Then
        'lblMessage.Text = " Inconsistency Detected. This action is not allowed"
        'Exit Sub
        'End If
        If IsNumeric(wwid.Value) = False Or wucode.Value.Trim = "" Then
            lblMessage.Text = " Inconsistency Detected. This action is not allowed"
            Exit Sub
        End If


        Response.Redirect("postpage.aspx?NextPage=" & WebLib.ClientURL("modules/docrepo/docrepomod.aspx") & "&ba=" & wucode.Value)
    End Sub
    Public Sub viewworkflow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsNumeric(wwid.Value) = False Or wucode.Value.Trim = "" Then
            lblMessage.Text = " Inconsistency Detected. This action is not allowed"
            Exit Sub
        End If

        Response.Redirect("postpage.aspx?NextPage=" & WebLib.ClientURL("modules/workflow/wbuilderpreview.aspx") & "&ga=" & wwid.Value & " &ba=" & wucode.Value)
    End Sub
    Public Function canAction() As Boolean
        If (wr.Value & "").Trim = "" Then
            Return False
            Exit Function
        End If

        If (wrm.Value & "").Trim = "" Then
            Return False
            Exit Function
        End If
        Dim lrightstring As String = "|" & wrm.Value.Replace(";;", ";;|")

        If Right(lrightstring, 1) = "|" Then
            lrightstring = Left(lrightstring, lrightstring.Length - 1)
        End If

        Dim temp
        Dim lvalue As String = ""
        temp = Microsoft.VisualBasic.Split(wr.Value.Replace(" ", ""), ";;")

        If UBound(temp) = 0 Then
            lvalue = wr.Value.Replace(" ", "")
            If InStr(1, lrightstring, "|" & lvalue & ";;") < 1 Then
                Return False
                Exit Function
            End If
        Else
            Dim counter As Integer
            Dim hasrights As Boolean = False
            For counter = 0 To UBound(temp)
                lvalue = temp(counter)
                'If InStr(1, lrightstring, "|" & lvalue & ";;") >= 1 Then

                '    hasrights = True
                '    Exit For
                'End If
                If InStr(1, lrightstring, "|" & lvalue & ";;") >= 1 Then
                    If lvalue = "49" Then ' account holder, control only cus_accountholder can action
                        If WebLib.LoginUser = WebLib.GetValue(wtablename.Value, "cus_accountholder", "cus_ucode", "'" & wucode.Value & "'", "", "").ToUpper Then
                            hasrights = True
                            Exit For
                        End If
                    Else
                        hasrights = True
                        Exit For
                    End If
                End If
            Next
            If hasrights Then
                If horizontalCheck() Then
                    If horizontalPersonApprovalCheck() Then
                        Return False
                        Exit Function
                    Else
                        Return True

                        Exit Function
                    End If
                Else
                    Return True

                End If
            End If
        End If

    End Function

    Private Sub GetRights()

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim ltemp As String = ""

        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""

        If IsNumeric(luserid) = False Then
            luserid = 0
        End If


        If depAprvCheck() Then
            ltemp = "SELECT CAST((select ltrim(convert(varchar(max),wur_wgroupid) + ';;') as 'data()' from wgrouprights left join secuserinfo on wur_uid = usr_id left join secuserdeplink on secuserinfo.usr_id = secuserdeplink.usr_id left join " & workflownamespace & " on cus_department = secuserdeplink.de_id Where wur_uid=" & luserid & " and cus_ucode = '" & wucode.Value & "' for xml path('')) AS VARCHAR(MAX)) AS RtnData"
        Else
            ltemp = "SELECT CAST((select ltrim(convert(varchar(max),wur_wgroupid) + ';;') as 'data()' from wgrouprights Where wur_uid=" & luserid & " for xml path('')) AS VARCHAR(MAX)) AS RtnData"


        End If

        cn.Open()
        cmd.CommandText = ltemp
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")
        For Each dr In ds.Tables("datarecords").Rows
            counter = counter + 1
            wr.Value = dr("RtnData") & ""
        Next

        cn.Close()
        cmd.Dispose()
        cn.Dispose()

    End Sub
    Public Function GetActionUserHorizontal(Optional ByVal lrights As String = "") As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""




        Try
            '   lrights = getActionRights(Convert.ToInt32(wlevelA.Value) + 1).Replace(";;", ",")



            cmd.CommandText = "Select distinct usr_name, secuserinfo.usr_id from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & lrights & ") " '"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords3")

        Catch ex As Exception
            ds = Nothing
        End Try


        cn.Close()
        cmd.Dispose()
        cn.Dispose()

        Return ds

    End Function
    Private Function GetApprovalPerson() As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""
        Dim lrights As String = ""
        lrights = (wrm.Value & "").Replace(";;", ",")
        Dim userlst As New ArrayList()

        If lrights.Trim <> "" Then
            lrights = lrights & "-1"
        End If

        litapprovalperson.Text = ""

        If lrights.Trim = "" Then
            Return ""
            Exit Function
        End If

        Dim apprights As String = ""
        If horizontalCheck() Then
            Try
                cmd.CommandText = "Select * from [wfhorizontalrights] left join [workflowitems] on [hwg_wuid] = [wui_wid] and [hwg_level] = [wui_no] where wui_wid = '" & wwid.Value & "' and wui_no = '" & wlevel.Value & "' and [wui_horizontal] = 'True' and hwg_ucode = '" & wucode.Value & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    apprights = dr("hwg_approved") & ""

                Next

                If apprights.Trim <> "" Then
                    apprights = apprights & "0"
                End If

            Catch ex As Exception
                lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                Return ""

            End Try
            Try
                cmd.CommandText = "Select distinct usr_name, usr_id from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & lrights & ") and wur_wgroupid <>'48' "
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords2")
                For Each dr In ds.Tables("datarecords2").Rows
                    lstring = lstring & dr("usr_name")
                    If InStr(1, apprights, dr("usr_id") & ";;") >= 1 Then
                        lstring = lstring & "&nbsp;&nbsp;<span style=""color:green"" class=""fas fa-check""></span> <br>"
                    Else
                        lstring = lstring & "&nbsp;&nbsp;<span style=""color:red"" class=""fas fa-minus""></span> <br>"
                    End If
                Next
                LogtheAudit(cmd.CommandText)
                cn.Close()
                cmd.Dispose()
                cn.Dispose()
                litapprovalperson.Text = "<b>Authorised Approval by : </b><br>" & lstring & "</br>"
            Catch ex As Exception
                lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                Return ""

            End Try
        ElseIf depAprvCheck() Then
            Try
                cmd.CommandText = "Select distinct usr_name from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & lrights & ") and wur_wgroupid <>'48' left join secuserdeplink on secuserinfo.usr_id = secuserdeplink.usr_id left join " & workflownamespace & " on cus_department = secuserdeplink.de_id where cus_ucode = '" & wucode.Value & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords3")
                For Each dr In ds.Tables("datarecords3").Rows
                    lstring = lstring & dr("usr_name") & "<br>"
                Next
                LogtheAudit(cmd.CommandText)
                If lstring.Trim <> "" Then
                    lstring = "<font color=""blue"">" & lstring & "</font><br><br>"
                End If

                litapprovalperson.Text = "<b>Authorised Approval by : </b><br>" & lstring & "</br>"
                Return lstring
            Catch ex As Exception
                lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                Return ""

            End Try

        Else


            Try
                'cmd.CommandText = "Select distinct usr_name from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & lrights & ")  and wur_wgroupid <>'48' "
                ' exclude user in approval group (account holder) but not in cus_accountholder 
                cmd.CommandText = "select distinct usr_name from (Select distinct usr_name,wur_wgroupid from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (" & lrights & ")  and wur_wgroupid <>'48' except Select distinct usr_name,wur_wgroupid  from secuserinfo inner join wgrouprights on secuserinfo.usr_id = wur_uid and wur_wgroupid in (49) and secuserinfo.usr_code not in (select cus_Accountholder from " & wtablename.Value & " where cus_ucode ='" & wucode.Value & "')) x"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    lstring = lstring & dr("usr_name") & "<br>"
                Next
                LogtheAudit(cmd.CommandText)
                cn.Close()
                cmd.Dispose()
                cn.Dispose()

                If lstring.Trim <> "" Then
                    lstring = "<font color=""blue"">" & lstring & "</font><br><br>"
                End If

                litapprovalperson.Text = "<b>Authorised Approval by : </b><br>" & lstring & "</br>"
                Return lstring
            Catch ex As Exception
                lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                Return ""

            End Try

        End If

    End Function
    Public Function GetAuditLogsDs() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""

        litAudit.Text = ""

        Try
            'cmd.CommandText = "Select wui_name,wfa_code,usr_name,(CONVERT(VARCHAR(25), wfa_createon, 103) + ' ' + CONVERT(VARCHAR(8), wfa_createon, 108)) as wfa_createon from workflowaudit left join secuserinfo on wfa_createby = usr_code left join workflowitems on wui_no = wfa_level where wfa_ucode='" & wucode.Value & "' and wui_wid = '" & wwid.Value & "' order by wfa_createon asc"
            cmd.CommandText = "Select wui_name,wfa_code,usr_name,wfa_createon from workflowaudit left join secuserinfo on wfa_createby = usr_code left join workflowitems on wui_no = wfa_level and wui_wid = '" & wwid.Value & "' where wfa_ucode='" & wucode.Value & "' order by wfa_createon asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For x As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(x).Item("wfa_code").ToString.ToLower = "reject" Then

                    ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "ed"
                Else
                    If ds.Tables(0).Rows(x).Item("wfa_code").ToString(ds.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "t" Then

                        ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "ted"
                    End If
                End If

                If ds.Tables(0).Rows(x).Item("wfa_code").ToString(ds.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "e" Then

                    ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "d"

                End If
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            '      litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ds
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds

        End Try



    End Function
    Public Function GetAuditLogsDs2() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""

        litAudit.Text = ""

        Try
            cmd.CommandText = "Select wui_name,wfa_code,usr_name,wfa_createon " &
                                " from workflowaudit a" &
                                " inner join (select wfa_level, max(wfa_createon) as MaxDate from workflowaudit where wfa_ucode='" & wucode.Value & "' group by wfa_level) t on isnull(a.wfa_level,0)=isnull(t.wfa_level,0) and a.wfa_createon = t.MaxDate " &
                                " left join secuserinfo on wfa_createby = usr_code " &
                                " left join workflowitems on wui_no = a.wfa_level and wui_wid = '" & wwid.Value & "' " &
                                " where wfa_ucode='" & wucode.Value & "' " &
                                " order by a.wfa_level, wfa_createon asc "

            LogtheAudit(cmd.CommandText)

            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For x As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(x).Item("wfa_code").ToString.ToLower = "reject" Then

                    ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "ed"
                Else
                    If ds.Tables(0).Rows(x).Item("wfa_code").ToString(ds.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "t" Then

                        ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "ted"
                    End If
                End If

                If ds.Tables(0).Rows(x).Item("wfa_code").ToString(ds.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "e" Then

                    ds.Tables(0).Rows(x).Item("wfa_code") = ds.Tables(0).Rows(x).Item("wfa_code").ToString & "d"

                End If
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            '      litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds

        End Try
        Return ds


    End Function
    Public Function GetAuditLogsDsMul() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim wf As String = ""
        Dim wfStartDate As String = ""
        Dim wfEndDate As String = ""
        Dim lstring As String = ""
        Dim query As String = ""
        Dim cmd1 As New OleDbCommand()
        Dim ad1 As New OleDb.OleDbDataAdapter()
        Dim ds1 As New DataSet()
        Dim dr1 As DataRow

        Try
            cmd.CommandText = "select min(wfa_createon) as starttime1, max(wfa_createon) as endtime1, convert(varchar,min(wfa_createon),120) as starttime, convert(varchar,max(wfa_createon),120) as endtime," &
                                " case wfa_description when '' then (select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "') else wfa_description end as wfa_description " &
                                " from workflowaudit where wfa_ucode ='" & wucode.Value & "' group by wfa_description order by starttime "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            'For Each dr In ds.Tables("datarecords").Rows
            '    If query <> "" Then
            '        query = query & " union "
            '    End If 
            '    query = query & "Select wui_name,wfa_code,usr_name,wfa_createon,a.wfa_level,wui_wid,wfa_id from workflowaudit a " &
            '                        " inner join (select wfa_level , max(wfa_createon) as MaxDate from workflowaudit where wfa_ucode  ='" & wucode.Value & "' and wfa_createon between '" & dr("starttime") & "' and dateadd(s,1,'" & dr("endtime") & "') group by wfa_level) t on isnull(a.wfa_level,0)=isnull(t.wfa_level,0) and a.wfa_createon = t.MaxDate " &
            '                        " left join secuserinfo on wfa_createby = usr_code " &
            '                        " left join workflowitems on wui_no = a.wfa_level and wui_wid = '" & dr("wfa_description").ToString.Replace("prev workflow ", "") & "'  " &
            '                        " where wfa_ucode = '" & wucode.Value & "'  "
            'Next

            'cn.Close()
            'ds.Clear()

            'cmd.CommandText = "select * from ( " & query & " ) t order by wfa_id "
            'cmd.Connection = cn
            'ad.SelectCommand = cmd
            'ad.Fill(ds, "datarecords")

            cn.Close()

            For Each dr In ds.Tables("datarecords").Rows

                'Dim stime As String = " (select min(wfa_createon) from workflowaudit where wfa_ucode ='" & wucode.Value & "' and IIF(wfa_description='',(select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "'),wfa_description) =  '" & dr("wfa_description") & "') "
                'Dim etime As String = " (select max(wfa_createon) from workflowaudit where wfa_ucode ='" & wucode.Value & "' and IIF(wfa_description='',(select convert(varchar,wst_workflowid) from workflowstatus where wst_ucode ='" & wucode.Value & "'),wfa_description) =  '" & dr("wfa_description") & "') "

                Dim stime As String = " '" & dr("starttime") & "'"
                Dim etime As String = " '" & dr("endtime") & "'"

                query = "Select wui_name,wfa_code,usr_name,wfa_createon,a.wfa_level,wui_wid,wfa_id from workflowaudit a " &
                        " inner join (select wfa_level , max(wfa_createon) as MaxDate from workflowaudit where wfa_ucode  ='" & wucode.Value & "' and wfa_createon between " & stime & " and dateadd(s,1," & etime & ") group by wfa_level) t on isnull(a.wfa_level,0)=isnull(t.wfa_level,0) and a.wfa_createon = t.MaxDate " &
                        " left join secuserinfo on wfa_createby = usr_code " &
                        " left join workflowitems on wui_no = a.wfa_level and wui_wid = '" & dr("wfa_description").ToString.Replace("prev workflow ", "") & "'  " &
                        " where wfa_ucode = '" & wucode.Value & "'  "
                Try
                    cmd1.CommandText = "select * from ( " & query & " ) t order by wfa_level, wfa_createon asc "
                    cmd1.Connection = cn
                    ad1.SelectCommand = cmd1
                    ad1.Fill(ds1, "datarecords")

                    For x As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        If ds1.Tables(0).Rows(x).Item("wfa_code").ToString.ToLower = "reject" Then
                            ds1.Tables(0).Rows(x).Item("wfa_code") = ds1.Tables(0).Rows(x).Item("wfa_code").ToString & "ed"
                        Else
                            If ds1.Tables(0).Rows(x).Item("wfa_code").ToString(ds1.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "t" Then
                                ds1.Tables(0).Rows(x).Item("wfa_code") = ds1.Tables(0).Rows(x).Item("wfa_code").ToString & "ted"
                            End If
                        End If
                        If ds1.Tables(0).Rows(x).Item("wfa_code").ToString(ds1.Tables(0).Rows(x).Item("wfa_code").ToString.Length() - 1) = "e" Then
                            ds1.Tables(0).Rows(x).Item("wfa_code") = ds1.Tables(0).Rows(x).Item("wfa_code").ToString & "d"
                        End If
                    Next
                Catch ex As Exception
                    Dim derew As String = ex.Message
                End Try
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds1
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds1
        End Try
    End Function
    Private Function GetAuditLogs() As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""

        litAudit.Text = ""

        Try
            cmd.CommandText = "Select * from workflowaudit where wfa_ucode='" & wucode.Value & "' order by wfa_createon asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                lstring = lstring & dr("wfa_createon").ToString.ToUpper & " : <b><br>" & dr("wfa_code").ToString.ToUpper & "</b> by " & dr("wfa_createby") & "<br>"
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If lstring.Trim <> "" Then
                lstring = "<font color=""black"">" & lstring & "</font><br><br>"
            End If

            'litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ""
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ""

        End Try



    End Function

    Public Function GetBaseUrl() As String
        ' Get the current request
        Dim request = HttpContext.Current.Request

        ' Build the base URL with scheme and host
        Dim baseUrl As String = request.Url.Scheme & "://" & request.Url.Host

        ' Add the port if it's not the default for the scheme
        If request.Url.Port <> 80 AndAlso request.Url.Port <> 443 Then
            baseUrl &= ":" & request.Url.Port
        End If

        ' Include the application's virtual path (ensuring it has a trailing slash)
        Dim virtualPath = HttpRuntime.AppDomainAppVirtualPath
        If Not virtualPath.EndsWith("/") Then
            virtualPath &= "/"
        End If

        baseUrl &= virtualPath

        Return baseUrl
    End Function


    Private Sub GetAttachments()
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim lstring As String = ""
        litattachments.Text = ""

        If (wucode.Value & "").Trim = "" Then
            Exit Sub
        End If


        Try
            Dim obj As New clsFileTypes
            Dim objWebLib As New WebLib
            Dim wfdocpath As String = ""
            Dim webRootPath As String = ""
            Dim lsql As String = ""

            lsql = "Select docdoc.* from docdoc left outer join docgroup on doc_group = dg_id where isnull(doc_group,0) = -1 and doc_uniqueid='" & wucode.Value & "' "
            If WebLib.isStaff = False Then
                lsql = lsql & " and doc_createby = '" & WebLib.LoginUser & "' "
            End If
            lsql = lsql & " order by doc_subject "

            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                obj.InitFile(dr("doc_attach1") & "")
                LogtheAudit(GetBaseUrl())
                webRootPath = GetBaseUrl() & ConfigurationManager.AppSettings("filespathhttpiissub")
                wfdocpath = Path.Combine(webRootPath, dr("doc_attach1path").ToString.Trim & dr("doc_attach1").ToString.Trim)

                lstring = lstring & "<table width=""100%""><tr><td width=""20%"" valign=""top""><img src=""" & WebLib.ClientURL(obj.FileImageFile) & """ width=""100%""></td><td width=""80%"" valign=""top"" class=""cssdetail""><b><a href=""#"" onClick=""$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: '" & wfdocpath & "',width:'90%',height:'90%'})"">" & dr("doc_subject") & "</a></b><br><font color=""gray"">" & obj.FileType & "</font></td></tr></table>"
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            obj = Nothing
            If lstring.Trim <> "" Then
                litattachments.Text = lstring & "<br><br>"

            Else
                litattachments.Text = "<font color=""red"">No Attachments</font>"

            End If
            '            Return lstring
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)

        End Try



    End Sub
    Private Function getHorizontalRights(ByVal level As String) As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim rights As String = ""
        cmd.CommandText = "Select top 1 * from wfhorizontalrights where hwg_ucode= '" & wucode.Value & "' and hwg_level='" & level & "'"
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")
        For Each dr In ds.Tables("datarecords").Rows
            rights = dr("hwg_rights")
        Next
        Return rights
    End Function
    Private Function getActionRights(plevel As String) As String

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim bcan As Boolean = True
        Dim arights As String = ""

        Try
            cmd.CommandText = "Select top 1 * from workflowitems where wui_wid=" & wwid.Value & " and isnull(wui_no,0)=" & plevel & " order by wui_no asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                arights = dr("wui_rights") & ""





                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()



        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
        Return arights
    End Function

    Private Sub loadActions(ByVal pLevel As String)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim bcan As Boolean = True
        If IsNumeric(pLevel) = False Then
            Exit Sub

        End If
        If IsNumeric(wwid.Value) = False Then
            Exit Sub
        End If

        Try
            cmd.CommandText = "Select top 1 * from workflowitems where wui_wid=" & wwid.Value & " and isnull(wui_no,0)=" & pLevel & " order by wui_no asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                If WebLib.BitToBoolean(dr("wui_approve") & "") = True Then
                    btnwApprove.Enabled = True
                End If
                If WebLib.BitToBoolean(dr("wui_cancel") & "") = True Then
                    btnwCancel.Enabled = True
                End If
                If WebLib.BitToBoolean(dr("wui_reject") & "") = True Then
                    btnwReject.Enabled = True
                End If

                If WebLib.BitToBoolean(dr("wui_allowattach") & "") = True Then
                    btnAttachments.Visible = True
                    btnAttachments.Enabled = True
                End If


                'Added for customise approve button
                If (dr("wui_approvename") & "").trim <> "" Then
                    btnwApprove.Text = (dr("wui_approvename") & "").trim
                End If

                If (dr("wui_cancelname") & "").trim <> "" Then
                    btnwCancel.Text = (dr("wui_cancelname") & "").trim
                End If

                If (dr("wui_rejectname") & "").trim <> "" Then
                    btnwReject.Text = (dr("wui_rejectname") & "").trim
                End If


                If dr("wui_horizontal").ToString.Trim = "True" And dr("wui_customrights").ToString.Trim = "True" Then
                    wrm.Value = getHorizontalRights(dr("wui_no"))

                Else
                    wrm.Value = dr("wui_rights") & ""
                End If



                aCType.Value = dr("wui_cancelstep") & ""
                aRType.Value = dr("wui_rejectstep") & ""
                aAType.Value = dr("wui_approvestep") & ""



                Try
                    wlevelamtenabled.Value = WebLib.BitToBoolean(dr("wui_approveval") & "")
                    wlevelamt.Value = dr("wui_approvevalamt") & ""
                    wlevelamtend.Value = WebLib.BitToBoolean(dr("wui_approvalvalend") & "")
                Catch ex As Exception

                End Try


                Try
                    If WebLib.BitToBoolean(dr("wui_emailSf") & "") = True Then
                        wversion.Value = 2
                    Else
                        wversion.Value = ""
                    End If
                Catch ex As Exception

                End Try


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


            If canAction() = False Then
                btnwApprove.Enabled = False
                btnwCancel.Enabled = False
                btnwReject.Enabled = False
            End If


        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Sub
    Private Function LoadAreaButton()

        Dim obj, obj9 As Object
        'obj = Page.FindControl("phlevel" & wlevel.Value)
        obj = Page.FindControl("commentSubmit")
        obj9 = Page.FindControl("contoh")

        If Not obj Is Nothing Then

            Dim objlit As New Literal
            'objlit.ID = "litID" & wlevel.Value
            objlit.ID = "litID" & wlevelA.Value

            'objlit.Text = "&nbsp;&nbsp;"
            obj.Controls.Add(objlit)


            If btnwApprove.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "A"
                obj1.ID = "dobj" & wlevelA.Value & "A"

                obj1.Attributes.Add("class", "btn-submit btn")
                obj1.Attributes.CssStyle.Add("margin-right", "2em")
                '   obj1.Style.Add("width", "100")
                obj1.Text = btnwApprove.Text
                '        obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.ApproveMod
                obj.Controls.Add(obj1)


                objlit = New Literal
                'objlit.ID = "litID" & wlevel.Value & "1"
                objlit.ID = "litID" & wlevelA.Value & "1"

                objlit.Text = "<br/>"
                obj.Controls.Add(objlit)


            End If

            If btnwReject.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "R"
                obj1.ID = "dobj" & wlevelA.Value & "R"

                '         obj1.Style.Add("width", "100")
                obj1.Attributes.Add("class", "btn-reject btn")
                obj1.Text = btnwReject.Text
                '     obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.rejectMod
                obj.Controls.Add(obj1)

                objlit = New Literal
                'objlit.ID = "litID" & wlevel.Value & "2"
                objlit.ID = "litID" & wlevelA.Value & "2"

                objlit.Text = "<br/>"
                obj.Controls.Add(objlit)


            End If
            If btnwCancel.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "C"
                objlit.ID = "litID" & wlevelA.Value & "2"
                obj1.Attributes.Add("class", "btn-info btn")
                '      obj1.Style.Add("width", "100")
                obj1.Text = btnwCancel.Text
                '     obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.CancelMod
                obj.Controls.Add(obj1)
                obj.Controls.Add(objlit)

            End If
        End If

    End Function
    Private Function LoadAreaButtonOld()

        Dim obj As Object
        'obj = Page.FindControl("phlevel" & wlevel.Value)
        obj = Page.FindControl("phlevel" & wlevelA.Value)

        If Not obj Is Nothing Then

            Dim objlit As New Literal
            'objlit.ID = "litID" & wlevel.Value
            objlit.ID = "litID" & wlevelA.Value

            objlit.Text = "&nbsp;&nbsp;"
            obj.Controls.Add(objlit)


            If btnwApprove.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "A"
                obj1.ID = "dobj" & wlevelA.Value & "A"

                obj1.Attributes.Add("class", "btn")
                obj1.Attributes.Add("class", "btn-info")
                obj1.Style.Add("width", "100")
                obj1.Text = btnwApprove.Text
                obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.ApproveMod
                obj.Controls.Add(obj1)


                objlit = New Literal
                'objlit.ID = "litID" & wlevel.Value & "1"
                objlit.ID = "litID" & wlevelA.Value & "1"

                objlit.Text = "&nbsp;"
                obj.Controls.Add(objlit)


            End If

            If btnwReject.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "R"
                obj1.ID = "dobj" & wlevelA.Value & "R"

                obj1.Style.Add("width", "100")
                obj1.Text = btnwReject.Text
                obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.rejectMod
                obj.Controls.Add(obj1)

                objlit = New Literal
                'objlit.ID = "litID" & wlevel.Value & "2"
                objlit.ID = "litID" & wlevelA.Value & "2"

                objlit.Text = "&nbsp;"
                obj.Controls.Add(objlit)


            End If
            If btnwCancel.Enabled = True Then
                Dim obj1 As New Button
                'obj1.ID = "dobj" & wlevel.Value & "C"
                objlit.ID = "litID" & wlevelA.Value & "2"

                obj1.Style.Add("width", "100")
                obj1.Text = btnwCancel.Text
                obj1.Style.Add("height", "25")
                AddHandler obj1.Click, AddressOf Me.CancelMod
                obj.Controls.Add(obj1)
                obj.Controls.Add(objlit)

            End If

        End If

    End Function
    Private Function LoadAudit() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem
        Dim obj As Object
        Try
            cmd.CommandText = "Select wfa_code,wfa_createon,wfa_createby,wfa_level from workflowaudit where wfa_ucode='" & wucode.Value & "' order by wfa_id asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                obj = Page.FindControl("lbllevel" & (dr("wfa_level") & "").trim)
                If Not obj Is Nothing Then
                    obj.text = "&nbsp;&nbsp;<font color=""blue"" class=""cssdetail"">" & (dr("wfa_code") & "").ToString.ToUpper & " by " & (dr("wfa_createby") & "").ToString.ToUpper & " " & (dr("wfa_createon") & "").ToString.ToUpper & "</font>"
                End If
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try

    End Function
    Public Function LoadDataApproval2() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem

        Try
            cmd.CommandText = "Select top 1 * from workflowtrack where ws_ucode='" & wucode.Value & "' and isnull(ws_ok,0) = 0 order by ws_wno asc"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Function
    Public Sub EnableDisable(ByRef pParent As Object)

        '**** Added ****
        If StrictValidationGroup = True Then
            Call EnableDisable2(pParent)
            Exit Sub
        End If
        '****


        Dim obj As Object
        Dim llevel As String = ""
        Dim bcan As Boolean = True
        If IsNumeric(wlevelA.Value) = False Then
            'llevel = "0"
            llevel = "1"

        Else
            llevel = wlevelA.Value

            If canAction() = True Then
                bcan = True
            Else
                bcan = False
            End If


        End If



        For Each obj In pParent.Controls

            If TypeOf obj Is TextBox Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    '  If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True Then
                    If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then

                    Else
                        obj.style.add("background-color", "#EEEEEE")
                        obj.enabled = False
                    End If
                End If
            End If


            If (obj.GetType()).ToString.ToLower = "asp.usercontrols_datepicker_ascx" Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                        'If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True Then

                    Else
                        Try

                            obj.TextBox1.style.add("background-color", "#EEEEEE")
                        Catch ex As Exception

                        End Try

                        obj.enabled = False
                    End If
                End If
            End If

            If TypeOf obj Is CheckBox Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    '  If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True Then
                    If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then

                    Else
                        obj.enabled = False
                    End If
                End If
            End If


            If TypeOf obj Is RadioButtonList Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    'If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True Then
                    If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then

                    Else
                        obj.enabled = False
                    End If
                End If
            End If


            If TypeOf obj Is DropDownList Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    ' If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True Then
                    If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then

                    Else
                        obj.enabled = False
                    End If
                End If
            End If


        Next
        Exit Sub

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadAreaButton()
    End Sub


    Public Sub EnableDisable2(ByRef pParent As Object)

        '**** Added ****
        If StrictValidationGroup = False Then
            Call EnableDisable(pParent)
            Exit Sub
        End If
        '****


        Dim obj As Object
        Dim llevel As String = ""
        Dim bcan As Boolean = True
        If IsNumeric(wlevelA.Value) = False Then
            llevel = "1"

        Else
            llevel = wlevelA.Value

            If canAction() = True Then
                bcan = True
            Else
                bcan = False
            End If


        End If



        For Each obj In pParent.Controls

            If TypeOf obj Is TextBox Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True And obj.validationgroup.ToString.Length = (llevel & "-").Trim.Length Then
                        'If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                        obj.style.remove("background-color")
                        obj.enabled = True
                    Else
                        obj.style.add("background-color", "#EEEEEE")
                        obj.enabled = False
                    End If
                End If
            End If


            If (obj.GetType()).ToString.ToLower = "asp.usercontrols_datepicker_ascx" Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    ' If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                    If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True And obj.validationgroup.ToString.Length = (llevel & "-").Trim.Length Then
                        obj.enabled = True
                    Else
                        obj.TextBox1.style.add("background-color", "#EEEEEE")
                        obj.enabled = False
                    End If
                End If
            End If

            If TypeOf obj Is CheckBox Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True And obj.validationgroup.ToString.Length = (llevel & "-").Trim.Length Then
                        ' If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                        obj.enabled = True
                    Else
                        obj.enabled = False
                    End If
                End If
            End If


            If TypeOf obj Is RadioButtonList Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True And obj.validationgroup.ToString.Length = (llevel & "-").Trim.Length Then
                        ' If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                        obj.enabled = True
                    Else
                        obj.enabled = False
                    End If
                End If
            End If


            If TypeOf obj Is DropDownList Then
                If obj.validationgroup.ToString.Trim <> "" Then
                    If obj.validationgroup.ToString.Trim = llevel & "-" And WorkflowEnded = False And bcan = True And obj.validationgroup.ToString.Length = (llevel & "-").Trim.Length Then
                        '  If InStr(1, obj.validationgroup.ToString.Trim, llevel & "-") >= 1 And WorkflowEnded = False And bcan = True Then
                        obj.enabled = True
                    Else
                        obj.enabled = False
                    End If
                End If
            End If


        Next
        Exit Sub

    End Sub

    Public Function getDraft() As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim str As String = Nothing

        'Dim comList As New ArrayList()
        Try
            cmd.CommandText = "Select top 1 comment from zcustom_comments where wf_refno = '" & wucode.Value & "' and wf_notdraft = 0 and cus_uid = '" & WebLib.LoginUser & "' and wf_level = '" & wlevelAget.ToString.Trim & "' order by createddate desc "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                str = dr("comment")
                'comList.Add(dr("comment"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            lblMessage.Text = ex.Message
            str = ""
        End Try
        Return str

    End Function


    Public Function getDraft2() As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim str As String = Nothing

        'Dim comList As New ArrayList()
        Try
            cmd.CommandText = "Select top 1 comment from zcustom_comments where wf_refno = '" & wucode.Value & "' and wf_level = '" & wlevelAget.ToString.Trim & "' order by createddate desc "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                str = dr("comment")
                'comList.Add(dr("comment"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            lblMessage.Text = ex.Message
            str = ""
        End Try
        Return str

    End Function

    Public Shared Sub LogtheAudit(ByVal theMessage As String)
        Dim strFile As String = "c:\officeonelog\ErrorLogWF.txt"
        Dim fileExists As Boolean = File.Exists(strFile)

        Try

            Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                sw.WriteLine(DateTime.Now & " - " & theMessage)
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class


