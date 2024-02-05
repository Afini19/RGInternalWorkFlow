Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports Microsoft.VisualBasic

Public Class backend

    Private Shared connectionstring As String = System.Configuration.ConfigurationSettings.AppSettings("ConnStr")


    Public Shared Function dateformat(ByVal indate As String) As String

        Dim myDate As DateTime = DateTime.Parse(indate)
        Return myDate.ToString("dd/MM/yyyy HH:mm:ss") & ""
    End Function
    Public Shared Function genActivityButtons() As DataSet

        Dim lsql As String = "select  wui_name from workflowitems where wui_wid in ('27','28','29','30') order by wui_no"
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim dr As DataRow
        Dim item As New List(Of String)

        ds2.Tables.Add(New DataTable)
        ds2.Tables(0).Columns.Add("wui_name")

        cmd.CommandText = lsql
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")

        For Each dr In ds.Tables("datarecords").Rows
            Dim hasitem As Boolean = False
            For Each dr2 As DataRow In ds2.Tables(0).Rows
                If dr("wui_name") = dr2("wui_name") Then
                    hasitem = True
                End If
            Next
            If Not hasitem Then
                ds2.Tables(0).Rows.Add(dr("wui_name"))
            End If

        Next
        Return ds2

    End Function
    Public Shared Function getDraft() As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        '    Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()


        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #tempAlltable "
        ltemp = ltemp & "END "
        ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_oq union "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_pq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_iq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_createby from zcustom_vr) x "
        ltemp = ltemp & "Select cus_id,cus_custype, cus_ucode, cus_title, cus_uno, cus_createby, [wst_level], datediff( DAY,wst_createon, GETDATE()) as daysago, "
        ltemp = ltemp & " (case datediff( DAY,wst_createon, GETDATE()) "
        ltemp = ltemp & "When '1' then 'day' "
        ltemp = ltemp & "Else 'days' "
        ltemp = ltemp & "End) As kword, "
        ltemp = ltemp & "ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode where wst_status='Pending' and cus_createby =  '" & WebLib.LoginUser & "' and wst_level = '1' and wst_lastupdateon is null order by wst_lastupdateon"

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
            Return Nothing
        End Try
        Return ds2
    End Function
    Public Shared Function getRework() As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        '    Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()


        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #tempAlltable "
        ltemp = ltemp & "END "
        ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_oq union "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_pq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_iq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_createby from zcustom_vr) x "
        ltemp = ltemp & "Select cus_id,cus_custype, cus_ucode, cus_title, cus_uno, cus_createby, [wst_level], datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) as daysago, "
        ltemp = ltemp & " (case datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) "
        ltemp = ltemp & "When '1' then 'day' "
        ltemp = ltemp & "Else 'days' "
        ltemp = ltemp & "End) As kword, "
        ltemp = ltemp & "ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode where wst_status='Pending' and cus_createby =  '" & WebLib.LoginUser & "' and wst_rework = 'True' order by wst_lastupdateon"

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
            Return Nothing
        End Try
        Return ds2
    End Function
    Public Shared Function getNotificationsOther(Optional ByVal notfilter As String = "0") As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""

        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable')  "
        ltemp = ltemp & "IS NOT NULL BEGIN DROP TABLE #tempAlltable END  "
        ltemp = ltemp & "Select * into #tempAlltable  "
        ltemp = ltemp & "from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby  "
        ltemp = ltemp & "from zcustom_oq union  "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno,cus_createby "
        ltemp = ltemp & " from zcustom_pq union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby  "
        ltemp = ltemp & " from zcustom_iq union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_vr) x "
        ltemp = ltemp & " "
        ltemp = ltemp & " "
        ltemp = ltemp & " Select cus_id,cus_custype, cus_ucode, cus_title, cus_uno, [wst_level], cus_createby, "
        ltemp = ltemp & " datediff( DAY,ISNULL(wst_createon, wst_lastupdateon),  "
        ltemp = ltemp & " GETDATE()) as daysago,  (case datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE())  "
        ltemp = ltemp & " When '1' then 'day' Else 'days' End)  "
        ltemp = ltemp & " As kword, ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon, wui_rights, WST_STATUS  "
        ltemp = ltemp & " from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode  "
        ltemp = ltemp & " left join workflowitems On wst_workflowid = wui_wid  "
        ltemp = ltemp & " And wst_level = wui_no where wui_no >= 4 and "
        ltemp = ltemp & " cus_createby = '" & WebLib.LoginUser & "' and wst_lastupdateon is not null  "
        If notfilter <> "0" Then
            ltemp = ltemp & "and datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) < '" & notfilter & "'"
        End If

        ltemp = ltemp & "  order by wst_lastupdateon desc "

        Try
            cn.Open()
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds2, "datarecords2")
            ds2.Tables("datarecords2").Columns.Add("span")
            Dim appcount As Integer = 0
            Dim cancount As Integer = 0
            Dim count As Integer = 0
            For Each dr In ds2.Tables("datarecords2").Rows
                Select Case dr("wst_status").ToString
                    Case "Approved" : dr("span") = "<span class="" fas fa-check"" style="" color:green;padding-right:1em;padding-right:.7em;""></span>"
                        appcount = appcount + 1

                    Case "Pending" : dr("span") = "<span class="" fas fa-minus"" style="" color:red;padding-right:1em;padding-right:1em;""></span>"
                        cancount = cancount + 1

                    Case "Cancelled" : dr.Delete()


                End Select
                count = count + 1
            Next
            ds2.Tables("datarecords2").Columns.Add("count")
            ds2.Tables("datarecords2").Rows(0).Item("count") = count
            ds2.Tables("datarecords2").Columns.Add("appcount")
            ds2.Tables("datarecords2").Rows(0).Item("appcount") = appcount
            ds2.Tables("datarecords2").Columns.Add("cancount")
            ds2.Tables("datarecords2").Rows(0).Item("cancount") = cancount
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds2
        Catch ex As Exception
            Return Nothing
        End Try


    End Function
    Public Shared Function getNotifications(Optional ByVal notfilter As String = "0") As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim ds3 As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""
        Dim count As Integer = 0
        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable')  "
        ltemp = ltemp & "IS NOT NULL BEGIN DROP TABLE #tempAlltable END  "
        ltemp = ltemp & "Select * into #tempAlltable  "
        ltemp = ltemp & "from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby  "
        ltemp = ltemp & "from zcustom_oq union  "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno,cus_createby "
        ltemp = ltemp & " from zcustom_pq union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby  "
        ltemp = ltemp & " from zcustom_iq union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby from zcustom_vr) x "
        ltemp = ltemp & " "
        ltemp = ltemp & " "
        ltemp = ltemp & " Select cus_id,cus_custype, cus_ucode, cus_title, cus_uno, [wst_level], cus_createby, "
        ltemp = ltemp & " datediff( DAY,ISNULL(wst_createon, wst_lastupdateon),  "
        ltemp = ltemp & " GETDATE()) as daysago,  (case datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE())  "
        ltemp = ltemp & " When '1' then 'day' Else 'days' End)  "
        ltemp = ltemp & " As kword, ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon, wui_rights, WST_STATUS  "
        ltemp = ltemp & " from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode  "
        ltemp = ltemp & " left join workflowitems On wst_workflowid = wui_wid  "
        ltemp = ltemp & " And wst_level = wui_no where wui_no < 4 and "
        ltemp = ltemp & " cus_createby = '" & WebLib.LoginUser & "' and wst_lastupdateon is not null  "
        If notfilter <> "0" Then
            ltemp = ltemp & "and datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) < '" & notfilter & "'"
        End If

        ltemp = ltemp & "  order by wst_lastupdateon desc "

        Try
            cn.Open()
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds2, "datarecords2")
            ds2.Tables("datarecords2").Columns.Add("span")
            Dim appcount As Integer = 0
            Dim cancount As Integer = 0

            For Each dr In ds2.Tables("datarecords2").Rows
                Select Case dr("wst_status").ToString
                    Case "Approved" : dr("span") = "<span class="" fas fa-check"" style="" color:green;padding-right:1em;padding-right:.7em;""></span>"
                        appcount = appcount + 1

                    Case "Pending" : dr("span") = "<span class="" fas fa-minus"" style="" color:red;padding-right:1em;padding-right:1em;""></span>"
                        cancount = cancount + 1

                    Case "Cancelled" : dr.Delete()


                End Select
                count = count + 1
            Next
            If ds2.Tables("datarecords2").Rows.Count = 0 Then
                ds2.Tables("datarecords2").Rows.Add()
            End If
            ds2.Tables("datarecords2").Columns.Add("count")
            ds2.Tables("datarecords2").Rows(0).Item("count") = count
            ds2.Tables("datarecords2").Columns.Add("appcount")
            ds2.Tables("datarecords2").Rows(0).Item("appcount") = appcount
            ds2.Tables("datarecords2").Columns.Add("cancount")
            ds2.Tables("datarecords2").Rows(0).Item("cancount") = cancount
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds2
        Catch ex As Exception
            Try
                ds3.Tables.Add("datarecords2")
                ds3.Tables("datarecords2").Columns.Add("count")
                ds3.Tables("datarecords2").Rows.Add()
                ds3.Tables("datarecords2").Rows(0).Item("count") = count
                Return ds3
            Catch ex2 As Exception
            End Try

        End Try


    End Function
    Public Shared Function getPending() As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""


        If IsNumeric(luserid) = False Then
            luserid = 0
        End If
        Dim lsql As String = " SELECT wur_wgroupid from wgrouprights Where wur_uid='" & luserid & "'"
        cn.Open()
        cmd.CommandText = lsql
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")
        For Each dr In ds.Tables("datarecords").Rows
            gwlist.Add(dr("wur_wgroupid"))
        Next


        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #tempAlltable "
        ltemp = ltemp & "END "
        ltemp = ltemp & "IF OBJECT_ID('tempdb..#temp2') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #temp2 "
        ltemp = ltemp & "END "
        ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_oq union "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_pq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_iq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_vr) x "
        ltemp = ltemp & "Select cus_department , isnull(wui_departmentrights,'0') as wui_departmentrights,wui_name, wui_no, wui_customrights, wui_rights = "
        ltemp = ltemp & "Case wui_customrights "
        ltemp = ltemp & "when 'True' then (select hwg_rights from wfhorizontalrights where hwg_ucode = cus_ucode) "
        ltemp = ltemp & "Else wui_rights "
        ltemp = ltemp & "End,  cus_id,cus_custype, cus_ucode, cus_title, cus_uno, [wst_level], datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) As daysago, "
        ltemp = ltemp & "(Case datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) "
        ltemp = ltemp & "When '1' then 'day' "
        ltemp = ltemp & "Else 'days' "
        ltemp = ltemp & "End) As kword, "
        ltemp = ltemp & "ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon,wst_workflowid into #temp2 from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode left join workflowitems On wst_workflowid = wui_wid And wst_level = wui_no where wst_status='Pending' and wst_level <> '1' "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, daysago, kword, wst_lastupdateon, wui_name, wui_no from secuserdeplink left join #temp2 on de_id = cus_department where wui_no <> '2' and wui_no <> '3' and  wui_departmentrights = 'true' and usr_id = " & luserid & " and ("
        For wg As Integer = 0 To gwlist.Count - 1
            If wg <> gwlist.Count - 1 Then
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') or "
            Else
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') "
            End If


        Next
        ltemp = ltemp & " ) "
        ltemp = ltemp & " union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, daysago, kword, wst_lastupdateon,wui_name, wui_no  from #temp2 where wui_no <> '2' and wui_no <> '3' and wui_departmentrights <> 'true' and ("

        For wg As Integer = 0 To gwlist.Count - 1
            If wg <> gwlist.Count - 1 Then
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') or "
            Else
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') "
            End If



        Next
        ltemp = ltemp & " ) "
        ltemp = ltemp & " and	 "
        ltemp = ltemp & "('" & WebLib.LoginUser & "' not in (Select distinct usr_code  "
        ltemp = ltemp & "from secuserinfo inner join wgrouprights  "
        ltemp = ltemp & "on secuserinfo.usr_id = wur_uid  "
        ltemp = ltemp & " and Charindex('''' + convert(varchar(max),usr_id) + '''', "
        ltemp = ltemp & "	 (Select top 1  '''' + replace(isnull(hwg_approved,''),';;',''',''') + '0'''  from workflowitems "
        ltemp = ltemp & " Left Join wfhorizontalrights on wui_wid = hwg_wuid And wui_no = hwg_level where wui_wid= wst_workflowid "
        ltemp = ltemp & "	 And  hwg_ucode = cus_ucode and isnull(wui_no,0)=wst_level)) <> 0 and wst_level > 1 ) ) "
        ltemp = ltemp & "  "
        ltemp = ltemp & "order by wst_lastupdateon asc"
        'cn.Open()
        Try
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds2, "datarecords2")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            Return Nothing
        End Try


        Return ds2
    End Function
    Public Shared Function getPendingReq() As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim ds2 As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim ltemp As String = ""
        Dim gwlist As New ArrayList()
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "") & ""


        If IsNumeric(luserid) = False Then
            luserid = 0
        End If
        Dim lsql As String = " SELECT wur_wgroupid from wgrouprights Where wur_uid='" & luserid & "'"
        cn.Open()
        cmd.CommandText = lsql
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")
        For Each dr In ds.Tables("datarecords").Rows
            gwlist.Add(dr("wur_wgroupid"))
        Next


        ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #tempAlltable "
        ltemp = ltemp & "END "
        ltemp = ltemp & "IF OBJECT_ID('tempdb..#temp2') IS NOT NULL "
        ltemp = ltemp & "BEGIN "
        ltemp = ltemp & "DROP TABLE #temp2 "
        ltemp = ltemp & "END "
        ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_oq union "
        ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_pq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_iq union "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_department from zcustom_vr) x "
        ltemp = ltemp & "Select cus_department , isnull(wui_departmentrights,'0') as wui_departmentrights,wui_name, wui_no, wui_customrights, wui_rights = "
        ltemp = ltemp & "Case wui_customrights "
        ltemp = ltemp & "when 'True' then (select hwg_rights from wfhorizontalrights where hwg_ucode = cus_ucode) "
        ltemp = ltemp & "Else wui_rights "
        ltemp = ltemp & "End,  cus_id,cus_custype, cus_ucode, cus_title, cus_uno, [wst_level], datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) As daysago, "
        ltemp = ltemp & "(Case datediff( DAY,ISNULL(wst_createon, wst_lastupdateon), GETDATE()) "
        ltemp = ltemp & "When '1' then 'day' "
        ltemp = ltemp & "Else 'days' "
        ltemp = ltemp & "End) As kword, "
        ltemp = ltemp & "ISNULL( wst_createon, wst_lastupdateon)wst_lastupdateon,wst_workflowid into #temp2 from #tempAlltable left join workflowstatus On cus_ucode = wst_ucode left join workflowitems On wst_workflowid = wui_wid And wst_level = wui_no where wst_status='Pending' and wst_level <> '1' "
        ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, daysago, kword, wst_lastupdateon, wui_name, wui_no from secuserdeplink left join #temp2 on de_id = cus_department where (wui_no='2' or  wui_no = '3') and wui_departmentrights = 'true' and usr_id = " & luserid & " and ("
        For wg As Integer = 0 To gwlist.Count - 1
            If wg <> gwlist.Count - 1 Then
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') or "
            Else
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') "
            End If


        Next
        ltemp = ltemp & " ) "
        ltemp = ltemp & " union select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, daysago, kword, wst_lastupdateon,wui_name, wui_no  from #temp2 where (wui_no = '2' or  wui_no = '3') and wui_departmentrights <> 'true' and ("

        For wg As Integer = 0 To gwlist.Count - 1
            If wg <> gwlist.Count - 1 Then
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') or "
            Else
                ltemp = ltemp & "wui_rights like ('" & gwlist(wg) & ";;%') or wui_rights like ('%;;" & gwlist(wg) & ";;%') "
            End If



        Next
        ltemp = ltemp & " ) "
        ltemp = ltemp & " and	 "
        ltemp = ltemp & "('" & WebLib.LoginUser & "' not in (Select distinct usr_code  "
        ltemp = ltemp & "from secuserinfo inner join wgrouprights  "
        ltemp = ltemp & "on secuserinfo.usr_id = wur_uid  "
        ltemp = ltemp & " and Charindex('''' + convert(varchar(max),usr_id) + '''', "
        ltemp = ltemp & "	 (Select top 1  '''' + replace(isnull(hwg_approved,''),';;',''',''') + '0'''  from workflowitems "
        ltemp = ltemp & " Left Join wfhorizontalrights on wui_wid = hwg_wuid And wui_no = hwg_level where wui_wid= wst_workflowid "
        ltemp = ltemp & "	 And  hwg_ucode = cus_ucode and isnull(wui_no,0)=wst_level)) <> 0 and wst_level > 1 ) ) "
        ltemp = ltemp & "  "
        ltemp = ltemp & "order by wst_lastupdateon asc"
        'cn.Open()
        Try
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds2, "datarecords2")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            Return Nothing
        End Try


        Return ds2
    End Function
    Public Shared Function getDepartmentsDs(ByVal lplant As String) As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        'Dim dr As DataRow
        'Dim dt As New DataTable("table")

        Dim depList As New ArrayList()
        Try
            cmd.CommandText = "Select * from department where de_plant = '" & lplant & "' "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            'For Each dr In ds.Tables("datarecords").Rows
            '    Dim drnew As DataRow = dt.NewRow()
            '    drnew("id") = dr("dep_ip")
            'Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            ' lblMessage.Text = ex.Message
        End Try
        Return ds
    End Function

    Public Shared Function getDepartments(ByVal lplant As String) As ArrayList
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
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                depList.Add(dr("de_name"))


            Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            ' lblMessage.Text = ex.Message
        End Try
        Return depList

    End Function
    Public Shared Function getPlants() As ArrayList
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Dim plantList As New ArrayList()
        '   plantList.Add(" - All Plants - ")
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
            'lblMessage.Text = ex.Message
        End Try
        Return plantList

    End Function
    Public Shared Function getPlantsDs() As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0


        Try
            cmd.CommandText = "Select * from branch where br_createdt >" & "'20190101'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")


            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            'lblMessage.Text = ex.Message
        End Try
        Return ds

    End Function
    Public Shared Sub saveUserPlant(ByVal plant As ArrayList, ByVal usr As String)
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()

        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & usr & "'", "", "", "", "") & ""
        cn.Open()
        cmd.CommandText = "delete from secuserplantlink where usr_id = '" & luserid & "'"
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        For Each br As String In plant
            lsql = lsql & "insert into [secuserplantlink] ([usr_id],[br_id]) values ('" & luserid & "','" & br & "');"
        Next
        Try

            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception

        End Try

    End Sub



    Public Shared Sub saveUserDep(ByVal deps As ArrayList, ByVal usr As String)
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()

        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & usr & "'", "", "", "", "") & ""
        cn.Open()
        cmd.CommandText = "delete from secuserdeplink where usr_id = '" & luserid & "'"
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        For Each dep As String In deps
            lsql = lsql & "insert into [secuserdeplink] ([usr_id],[de_id]) values ('" & luserid & "','" & dep & "');"
        Next
        Try

            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function loadDepartment(ByVal usrid As String) As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & usrid & "'", "", "", "", "") & ""

        ' Try
        cmd.CommandText = "Select distinct de_name from secuserdeplink left join department On secuserdeplink.de_id = department.de_id where usr_id = '" & luserid & "'"
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")


        cn.Close()
        cmd.Dispose()
        cn.Dispose()


        '   Catch ex As Exception
        '   Console.WriteLine(ex.Message)
        '   End Try
        Return ds
    End Function
    Public Shared Function loadPlant(ByVal usrid As String) As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & usrid & "'", "", "", "", "") & ""

        ' Try
        cmd.CommandText = "Select distinct br_name, br_code from secuserplantlink left join branch On secuserplantlink.br_id = branch.br_code where usr_id = '" & luserid & "'"
        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")


        cn.Close()
        cmd.Dispose()
        cn.Dispose()


        '   Catch ex As Exception
        '   Console.WriteLine(ex.Message)
        '   End Try
        Return ds
    End Function
    Public Shared Function loadWfGrid(ByVal table As String, ByVal table2 As String, ByVal table3 As String, ByVal table4 As String, Optional lsearch As String = "") As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lsql As String = ""
        If lsearch = "all" Then
            lsearch = ""
        ElseIf lsearch.Trim <> "" Then
            lsearch = "where " & lsearch

        Else
            lsearch = lsearch & "where  wst_status='Pending' and ( "
            lsearch = lsearch & "('" & WebLib.LoginUser & "' in (Select distinct usr_code  "
            lsearch = lsearch & "from secuserinfo inner join wgrouprights  "
            lsearch = lsearch & "on secuserinfo.usr_id = wur_uid  "
            lsearch = lsearch & "and (isnull(wui_customrights,'0') <> 'True' and isnull(wui_departmentrights,'0') <> 'True' and Charindex('''' + convert(varchar(max),wur_wgroupid) + '''', "
            lsearch = lsearch & "(Select top 1  '''' + replace(isnull(wui_rights,''),';;',''',''') + '0'''  "
            lsearch = lsearch & "from workflowitems where wui_wid=wst_workflowid and isnull(wui_no,0)=wst_level)) <> 0)  "
            lsearch = lsearch & "and wst_level > 1))  "
            lsearch = lsearch & "or "
            lsearch = lsearch & "('" & WebLib.LoginUser & "' in (Select distinct usr_code  "
            lsearch = lsearch & "from secuserinfo inner join wgrouprights  "
            lsearch = lsearch & "on secuserinfo.usr_id = wur_uid  "
            lsearch = lsearch & "and (isnull(wui_departmentrights,'0') = 'True' and Charindex('''' + convert(varchar(max),wur_wgroupid) + '''', "
            lsearch = lsearch & "(Select top 1  '''' + replace(isnull(wui_rights,''),';;',''',''') + '0'''  "
            lsearch = lsearch & "from workflowitems where wui_wid=wst_workflowid and isnull(wui_no,0)=wst_level)) <> 0)  "
            lsearch = lsearch & "and wst_level > 1 left join secuserdeplink on secuserinfo.usr_id = secuserdeplink.usr_id where de_id = cus_department) ) "
            lsearch = lsearch & " or	 "
            lsearch = lsearch & "('" & WebLib.LoginUser & "' in (Select distinct usr_code  "
            lsearch = lsearch & "from secuserinfo inner join wgrouprights  "
            lsearch = lsearch & "on secuserinfo.usr_id = wur_uid  "
            lsearch = lsearch & "and (isnull(wui_customrights,'0') = 'True' and Charindex('''' + convert(varchar(max),wur_wgroupid) + '''', "
            lsearch = lsearch & "(Select top 1  '''' + replace(isnull(hwg_wgid,''),';;',''',''') + '0'''  "
            lsearch = lsearch & "from workflowitems  left join wfhorizontalrights on wui_wid = hwg_wuid and wui_no = hwg_level where wui_wid= wst_workflowid and  hwg_ucode = cus_ucode and isnull(wui_no,0)=wst_level)) <> 0)  "
            lsearch = lsearch & " and Charindex('''' + convert(varchar(max),usr_id) + '''', "
            lsearch = lsearch & "	 (Select top 1  '''' + replace(isnull(hwg_approved,''),';;',''',''') + '0'''  from workflowitems "
            lsearch = lsearch & " Left Join wfhorizontalrights on wui_wid = hwg_wuid And wui_no = hwg_level where wui_wid= wst_workflowid "
            lsearch = lsearch & "	 And  hwg_ucode = cus_ucode and isnull(wui_no,0)=wst_level)) = 0 and wst_level > 1 ) ) "
            lsearch = lsearch & ")  "
            lsearch = lsearch & " "

        End If

        Try
            lsql = lsql & "IF OBJECT_ID('tempdb..#temp1')  "
            lsql = lsql & "IS NOT NULL BEGIN DROP TABLE #temp1 END  "
            lsql = lsql & "Select cus_id, cus_title, cus_createby, cus_createdt, cus_updatedt, cus_uno, cus_lotno, cus_priority, cus_custype, cus_plant, cus_department, cus_prono,cus_ucode,cus_remarks2 "
            lsql = lsql & " into #temp1"
            lsql = lsql & " from " & table & " "
            lsql = lsql & " union  "
            lsql = lsql & "Select cus_id, cus_title, cus_createby, cus_createdt, cus_updatedt, cus_uno, cus_lotno, cus_priority, cus_custype, cus_plant, cus_department, cus_prono, cus_ucode,cus_remarks2 "
            lsql = lsql & "from " & table2 & "  "
            lsql = lsql & " union  "
            lsql = lsql & "Select cus_id, cus_title, cus_createby, cus_createdt, cus_updatedt, cus_uno, cus_lotno, cus_priority, cus_custype, cus_plant, cus_department, cus_prono, cus_ucode,cus_remarks2 "
            lsql = lsql & "from " & table3 & " "
            lsql = lsql & " union  "
            lsql = lsql & "Select cus_id, cus_title, cus_createby, cus_createdt, cus_updatedt, cus_uno, cus_lotno, cus_priority, cus_custype, cus_plant, cus_department, cus_prono, cus_ucode,cus_remarks2 "
            lsql = lsql & "from " & table4 & " "
            lsql = lsql & "select cus_id, cus_title, cus_createby, cus_createdt, (CONVERT(VARCHAR(25), cus_updatedt, 103) + ' ' + CONVERT(VARCHAR(8), cus_updatedt, 108)) as cus_updatedt, cus_uno, cus_lotno, cus_priority, cus_custype, cus_plant, cus_department, cus_prono, wui_name, cus_ucode, wst_status, wst_workflowid, wst_level, de_name, "
            lsql = lsql & " (case datediff( DAY,ISNULL(wst_lastupdateon, wst_createon), GETDATE()) "
            lsql = lsql & "When '0' then 'low' "
            lsql = lsql & "When '1' then 'low' "
            lsql = lsql & "When '2' then 'med' "
            lsql = lsql & "When '3' then 'low' "
            lsql = lsql & "Else 'high' "
            lsql = lsql & "End) As kword, (case cus_remarks2 When '0' then '<span class="" fas fa-times"" style="" color:red""></span>&nbsp;Failed' When '1' then '<span class="" fas fa-check"" style="" color:green""></span>&nbsp;Passed  ' Else '' END) AS cus_remarks2 "
            lsql = lsql & "from #temp1 left join [workflowstatus] on cus_ucode = wst_ucode left join [workflowitems] On wst_workflowid = wui_wid And wst_level = wui_no left join department on cus_department = de_id " & lsearch & " order by cus_createdt desc "
            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                If dr("wst_status").ToString <> "Approved" Then
                    Select Case dr("kword").ToString
                        Case "low" : dr("kword") = "<span class="" fas fa-circle"" style="" color:green""></span>&nbsp;Low"
                        Case "med" : dr("kword") = "<span class="" fas fa-circle"" style="" color:orange""></span>&nbsp;Med"
                        Case "high" : dr("kword") = "<span class="" fas fa-circle"" style="" color:red""></span>&nbsp;High"
                    End Select
                Else
                    dr("kword") = ""
                End If
            Next


            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return ds

    End Function
    Public Shared Function getUser(Optional lsearch As String = "") As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow


        Try
            cmd.CommandText = "Select distinct(secuserdeplink.usr_id), secuserinfo.usr_name from secuserdeplink left join secuserinfo On secuserdeplink.usr_id = secuserinfo.usr_id " + lsearch
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return ds

    End Function
    Public Shared Function getSuggestedUser(ByVal lsearch As String, ByVal dep As String) As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow


        Try
            '  cmd.CommandText = "select distinct  usr_name, usr_id from (select distinct  usr_name, usr_id from workflowaudit left join secuserinfo on wfa_createby = usr_loginid where wfa_ucode = '" & lsearch & "' union all select secuserinfo.usr_name, secuserinfo.usr_id from secuserdeplink left join secuserinfo on secuserinfo.usr_id = secuserdeplink.usr_id where secuserdeplink.de_id = '" & dep & "') a"
            cmd.CommandText = "select distinct  usr_name, usr_id from workflowaudit left join secuserinfo on wfa_createby = usr_loginid where wfa_ucode = '" & lsearch & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return ds

    End Function
    Public Shared Function getUserInfo(Optional lsearch As String = "") As DataSet

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim dr3 As DataRow

        Try
            cmd.CommandText = "Select usr_id, usr_name, br_name, de_name from secuserinfo left join branch On usr_branch = br_id left join department On usr_department = de_id " + lsearch + "order by usr_name"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                Dim ds2 As New DataSet()
                cmd.CommandText = "Select distinct de_name from secuserdeplink left join department On secuserdeplink.de_id = department.de_id where usr_id = '" & dr("usr_id") & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds2, "datarecords2")
                For Each dr2 In ds2.Tables("datarecords2").Rows
                    If dr("de_name").ToString.Trim = "" Then
                        dr("de_name") = dr2("de_name")
                    Else
                        dr("de_name") = dr("de_name") & ", " & dr2("de_name")
                    End If

                Next
                Dim ds3 As New DataSet()
                cmd.CommandText = "select distinct br_name from secuserplantlink left join branch on secuserplantlink.br_id = branch.br_code where usr_id = '" & dr("usr_id") & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds3, "datarecords2")
                For Each dr3 In ds3.Tables("datarecords2").Rows
                    If dr("br_name").ToString.Trim = "" Then
                        dr("br_name") = dr3("br_name")
                    Else
                        dr("br_name") = dr("br_name") & ", " & dr3("br_name")
                    End If

                Next
            Next



            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return ds
        ds.Dispose()

    End Function
    Public Shared Function validateUserTest(ByVal lvl As String, ByVal uid As String, ByVal formid As String, Optional ByVal formname As String = "") As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim wgrplist As New ArrayList()
        Dim aprgrplist As New ArrayList()
        Dim index As Integer = 0


        Try
            cmd.CommandText = "Select (WUI_RIGHTS) FROM workflowitems left join workflowstatus On wui_wid = wst_workflowid  where wst_ucode = '" & formid & "' and wui_no = '" & lvl & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                Dim x As Integer = dr("WUI_RIGHTS").ToString().Length
                Dim aprgrp As String = ""
                For i As Integer = 0 To dr("WUI_RIGHTS").ToString().Length - 1
                    If dr("WUI_RIGHTS").ToString(i) <> ";" Then
                        aprgrp = aprgrp + dr("WUI_RIGHTS").ToString(i)
                    End If
                    If dr("WUI_RIGHTS").ToString(i) = ";" And dr("WUI_RIGHTS").ToString(i + 1) = ";" Then
                        i = i + 1
                        aprgrplist.Add(aprgrp)
                        aprgrp = ""
                    End If
                Next

            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Dim test As String = ""

        For Each s As String In aprgrplist
            test = s & "+" & test

        Next
        Return test
    End Function
    Public Shared Function closed(ByVal ucode As String) As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim wgrplist As New ArrayList()
        Dim aprgrplist As New ArrayList()
        Dim status As String = ""


        Try
            cmd.CommandText = "SELECT wst_status from workflowstatus where wst_ucode = '" & ucode & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                status = dr("wst_status")

            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        If status = "Approved" Or status = "Cancelled" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Sub createHorizontal(ByVal ucode As String, ByVal lvl As String, ByVal wid As String)

        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim hasitem As Boolean = False
        Dim hashorizontal As Boolean = False
        Try
            cmd.CommandText = "Select * from workflowitems where  wui_wid = '" & wid & "' and wui_no = '" & lvl & "' and wui_horizontal = 'True'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr As DataRow In ds.Tables("datarecords").Rows
                hasitem = True
            Next

        Catch e As Exception

        End Try
        If hasitem Then


            Try
                cmd.CommandText = "Select * from wfhorizontalrights where hwg_wuid = '" & wid & "' and hwg_level = '" & lvl & "' and hwg_ucode = '" & ucode & "'"
                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords2")
                For Each dr As DataRow In ds.Tables("datarecords2").Rows
                    hashorizontal = True
                Next
                If Not hashorizontal Then
                    lsql = "insert into [wfhorizontalrights] ([hwg_wuid],[hwg_level], [hwg_ucode],[hwg_createdt],[hwg_createdby]) values( '" & wid & "','" & lvl & "','" & ucode & "'," & "getDate()" & ",'" & WebLib.LoginUser & "')"
                    cn.Open()
                    cmd.CommandText = lsql
                    cmd.Connection = cn
                    cmd.ExecuteNonQuery()
                End If
            Catch e As Exception

            End Try
        End If

        cn.Close()
        cmd.Dispose()
        cn.Dispose()


    End Sub
    Public Shared Sub resend(ByVal wwid As String, ByVal wlevel As String, ByVal wucode As String, ByVal workflownamespace As String)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lversion2 As Boolean = False
        Dim pLevel As String
        Dim rout As String = "U"

        If WebLib.LoginIsFullAdmin = False Then
            '  lblmessage.Text = WebLib.getAlertMessageStyle("Invalid User Rights")
            Exit Sub
        End If


        Dim ooLevel As New clsWorkflow

        pLevel = ooLevel.GetPreviousLevel(wwid, wlevel)
        pLevel = wlevel
        ooLevel = Nothing

        If IsNumeric(pLevel) = False Then

            Exit Sub
        End If
        If IsNumeric(wwid) = False Then

            Exit Sub
        End If


        Try
            cmd.CommandText = "Select * from workflowitems where wui_wid=" & wwid & " and isnull(wui_no,0)=" & pLevel & " order by wui_no asc"
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
                    If (dr("wui_horizontal") & "") Then
                        rout = "H"
                        pLevel = Convert.ToInt32(pLevel) - 1 & ""
                    End If
                Catch ex As Exception
                    '  lblmessage.Text = WebLib.getAlertMessageStyle(ex.Message)
                    Exit Sub
                End Try


                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            '    lblmessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Exit Sub
        End Try


        Dim ooemail As New clsWorkflowEmail



        If ooemail.NotifyUsers(wwid, pLevel, rout, workflownamespace, wucode, lversion2) = False Then
            '   ErrorMsg = ooemail.ErrorMsg
            ' lblmessage.Text = WebLib.getAlertMessageStyle(ooemail.ErrorMsg)
        Else
            '   lblmessage.Text = WebLib.getAlertMessageStyle("Email Resent Successful")
        End If

        ooemail = Nothing

    End Sub
    Public Shared Sub cancel(ByVal wwid As String, ByVal wlevel As String, ByVal wucode As String, ByVal workflownamespace As String)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim lsql As String

        If WebLib.LoginIsFullAdmin = False Then
            '  lblmessage.Text = WebLib.getAlertMessageStyle("Invalid User Rights")
            Exit Sub
        End If

        Dim ooWorkFlow As New clsWorkflow
        lsql = "Update WorkflowStatus set wst_lastupdateon=getdate(),wst_status='Cancelled',wst_rework = 'False' where wst_level=" & wlevel & " and wst_ucode='" & wucode & "' and wst_filtercode='" & WebLib.FilterCode & "';" & ooWorkFlow.getAuditSQL(wlevel, "cance;", "", "", wucode)

        Try
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = lsql
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            '    lblmessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Exit Sub
        End Try
        ooWorkFlow = Nothing

    End Sub
    Public Shared Function uploadRights(ByVal wlevel As String, ByVal rights As String, ByVal uploadlvl As Integer, Optional ByVal uploadlvl2 As Integer = 0, Optional ByVal uploadlvl3 As Integer = 0) As Boolean
        Dim wlvlint As Integer = 0
        If wlevel <> "" Then
            wlvlint = Convert.ToInt32(wlevel)
        End If
        If (wlvlint = uploadlvl Or (uploadlvl2 <> 0 And uploadlvl2 = wlvlint) Or (uploadlvl3 <> 0 And uploadlvl3 = wlvlint)) And rights = "True" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function viewRights(ByVal wlevel As String, ByVal viewlvl As Integer) As Boolean
        Dim wlvlint As Integer = 1
        If wlevel <> "" Then
            wlvlint = Convert.ToInt32(wlevel)
        End If
        If wlvlint >= viewlvl Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function viewRights2(ByVal wlevel As String, ByVal APlevel As Integer, ByVal ucode As String, ByVal formnamespace As String) As Boolean
        Dim wlvlint As Integer = 1
        Dim wclvint As Integer = 0
        If ucode = "" Then
            Exit Function
        Else
            wclvint = getLevelPC(APlevel, ucode, formnamespace)
        End If
        If wlevel <> "" Then
            wlvlint = Convert.ToInt32(wlevel) ' current level
            wlvlint = getMaxLevel(ucode, formnamespace) ' get workflowaudit max, show field if return 
        End If
        If wlvlint >= wclvint Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function getLevelPC(ByVal plevel As Integer, ByVal ucode As String, ByVal formnamespace As String) As Integer

        Dim str As String = "Select wui_no from " + formnamespace + " z inner join workflowstatus w on z.cus_ucode = w.wst_ucode inner join workflowitems i on i.wui_wid = w.wst_workflowid where z.cus_id = '" + ucode + "' and wui_pno = '" + plevel.ToString + "'"

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr As DataRow In ds.Tables("datarecords").Rows

                Return dr("wui_no") & ""

            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            ' lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return 0
        End Try


    End Function

    Public Shared Function getMaxLevel(ByVal uid As String, ByVal formnamespace As String) As Integer
        Dim str As String = ""

        str = "Select max(isnull(wfa_level,0)) as maxlevel from " + formnamespace + "  z inner join workflowaudit a on z.cus_ucode = a.wfa_ucode where z.cus_id = '" + uid + "' "

        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr As DataRow In ds.Tables("datarecords").Rows
                Return dr("maxlevel") & ""
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

        Catch ex As Exception
            ' lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Sub delRecord(ByVal id As String, ByVal value As String, ByVal tablename As String)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim filename As String = ""

        Try
            cn.Open()
            cmd.CommandText = "Delete from " & tablename & " where " & id & " = '" & value & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            'lblMessage.Text = ex.Message
        End Try



    End Sub

    Public Shared Sub DeleteOldDraft(ByVal tablename As String)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim filename As String = ""

        Try
            cn.Open()
            cmd.CommandText = "delete " & tablename & " from " & tablename & " inner join workflowstatus on cus_ucode = wst_ucode where cus_updatedt < DATEADD(MONTH, -1, GETDATE()) and wst_level = 1 and wst_status = 'Pending'; " &
                              "delete workflowstatus from " & tablename & " inner join workflowstatus on cus_ucode = wst_ucode where cus_updatedt < DATEADD(MONTH, -1, GETDATE()) and wst_level = 1 and wst_status = 'Pending'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            'lblMessage.Text = ex.Message
        End Try
    End Sub

    Public Shared Function validateUser(ByVal lvl As String, ByVal formid As String, ByVal status As String) As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim wgrplist As New ArrayList()
        Dim aprgrplist As New ArrayList()
        Dim index As Integer = 0
        Dim valid As Boolean = False
        Dim luserid As String = ViFeandi.General.GetValue(connectionstring, "secuserinfo", "usr_id", "usr_code", "'" & WebLib.LoginUser & "'", "", "", "", "")
        If status = "Approved" Or status = "Cancelled" Then
            Return False
        End If
        Try
            cmd.CommandText = "select wur_uid, wur_wgroupid from wgrouprights where wur_uid =  '" & luserid & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                wgrplist.Add(dr("wur_wgroupid"))
            Next

            '  cn.Close()
            ' cmd.Dispose()
            '   cn.Dispose()
            ad.Dispose()
            ds.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Try
            cmd.CommandText = "SELECT (WUI_RIGHTS) FROM workflowitems where wui_wid = '" & formid & "' and wui_no = '" & lvl & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                Dim x As Integer = dr("WUI_RIGHTS").ToString().Length
                Dim aprgrp As String = ""
                For i As Integer = 0 To dr("WUI_RIGHTS").ToString().Length - 1
                    If dr("WUI_RIGHTS").ToString(i) <> ";" Then
                        aprgrp = aprgrp + dr("WUI_RIGHTS").ToString(i)
                    End If
                    If dr("WUI_RIGHTS").ToString(i) = ";" And dr("WUI_RIGHTS").ToString(i + 1) = ";" Then
                        i = i + 1
                        aprgrplist.Add(aprgrp)
                        aprgrp = ""
                    End If
                Next

            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        For Each wgrp As String In wgrplist
            For Each apgrp As String In aprgrplist
                If wgrp = apgrp Then
                    valid = True
                    Exit For

                End If
            Next
            If valid Then
                Exit For
            End If
        Next
        Return valid
    End Function
    Public Shared Function getAllAnnouncment(Optional ByVal lsearch As String = "") As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""
        Dim lsql As String = ""
        If lsearch <> "" Then
            lsearch = "and " & lsearch
        End If
        Try
            lsql = lsql & "Select * from Announcement left join docdoc on ann_file = doc_attach1 order by ann_createddt desc"
            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            '      litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ds
        Catch ex As Exception
            '    lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds

        End Try



    End Function
    Public Shared Function getAnnouncment(Optional ByVal lsearch As String = "") As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""
        Dim lsql As String = ""
        If lsearch <> "" Then
            lsearch = "and " & lsearch
        End If
        Try
            lsql = lsql & "Select top 5 * from Announcement left join docdoc on ann_file = doc_attach1 where ann_status = 'True' and datepart(DAYOFYEAR,CONVERT(DATETIME,ann_startdt)) <= datepart(dayofyear,getdate()) and  datepart(DAYOFYEAR,CONVERT(DATETIME,ann_enddt)) >= datepart(dayofyear,getdate()) order by CONVERT(DATETIME,ann_createddt) DESC"
            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            '      litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ds
        Catch ex As Exception
            '    lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds

        End Try



    End Function
    Public Shared Sub postAnnouncement(ByVal title As String, ByVal ann As String, Optional annfile As String = "", Optional dateto As String = "", Optional datefrom As String = "", Optional active As String = "")
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()

        If dateto = "" Then
            dateto = "getDate()"
        End If
        If datefrom = "" Then
            datefrom = "getDate()"
        End If

        lsql = lsql & "insert into Announcement ([ann_title],[ann_text],[ann_createdby],[ann_createddt], [ann_file], [ann_startdt], [ann_enddt],[ann_status]) values ('" & title & "','" & ann & "','" & WebLib.LoginUser & "',getdate(),'" & annfile & "'," & datefrom & "," & dateto & ",'" & active & "')"

        Try
            cn.Open()
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function GetAuditLogsDs(Optional ByVal lsearch As String = "") As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lstring As String = ""
        Dim lsql As String = ""
        If lsearch <> "" Then
            lsearch = "and " & lsearch
        End If
        Try
            lsql = lsql & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL  "
            lsql = lsql & "BEGIN "
            lsql = lsql & "DROP TABLE #tempAlltable  "
            lsql = lsql & "END  "
            lsql = lsql & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant from zcustom_oq union  "
            lsql = lsql & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant from zcustom_pq union  "
            lsql = lsql & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_createby, cus_createdt, cus_prono,cus_department,cus_plant from zcustom_iq union  "
            lsql = lsql & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_createby, cus_createdt, cus_prono,cus_department,cus_plant from zcustom_vr) x  "
            lsql = lsql & " "
            lsql = lsql & "Select cus_uno, cus_createby, cus_createdt, cus_custype, cus_title, cus_prono,cus_plant, (CONVERT(VARCHAR(25), wfa_createon, 103) + ' ' + CONVERT(VARCHAR(8), wfa_createon, 108)) as wfa_createon , wfa_level, isnull(wui_name,'Created') as wui_name, wfa_createby,  wfa_code, de_name "
            lsql = lsql & "from  workflowaudit  left join #tempAlltable on wfa_ucode = cus_ucode left join workflowstatus on cus_ucode = wst_ucode  "
            lsql = lsql & "left join workflowitems on wst_workflowid = wui_wid and wfa_level = wui_no left join department on de_id = cus_department "
            lsql = lsql & "where wfa_createon > '20190417' " & lsearch
            lsql = lsql & " order by cus_uno asc, wfa_createon, wfa_level asc "
            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            '      litAudit.Text = "<b>Audit Logs</b><br>" & lstring
            Return ds
        Catch ex As Exception
            '    lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return ds

        End Try



    End Function
    Public Shared Function getAllDocsDs(Optional ByVal lsearch As String = "") As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ad2 As New OleDb.OleDbDataAdapter()
        Dim ds2 As New DataSet()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim ltemp As String = ""
        If lsearch = "" Then
            lsearch = "where wst_status = 'Approved'"
        Else
            lsearch = lsearch & " and wst_status = 'Approved'"
        End If


        Try

            ltemp = ltemp & "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
            ltemp = ltemp & "BEGIN "
            ltemp = ltemp & "DROP TABLE #tempAlltable "
            ltemp = ltemp & "END "
            ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono, cus_department, cus_plant, cus_createby from zcustom_oq union "
            ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_pq union "
            ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_iq union "
            ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_vr) x "
            ltemp = ltemp & "Select cus_uno, cus_prono, cus_ucode, cus_lotno, de_name, cus_plant, (CONVERT(VARCHAR(25), wst_lastupdateon, 103) ) as wst_lastupdateon,doc_subject, doc_keywords, doc_attach1path, doc_attach1, doc_ext, doc_module from docdoc left join #tempAlltable on doc_uniqueid = cus_ucode left join workflowstatus on cus_ucode = wst_ucode left join department on de_id = cus_department " & lsearch & " and  doc_module  <> 'Announcment' order by cus_uno DESC, doc_keywords"
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords2")




            ltemp = "IF OBJECT_ID('tempdb..#tempAlltable') IS NOT NULL "
            ltemp = ltemp & "BEGIN "
            ltemp = ltemp & "DROP TABLE #tempAlltable "
            ltemp = ltemp & "END "
            ltemp = ltemp & "Select * into #tempAlltable from (Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono, cus_department, cus_plant, cus_createby from zcustom_oq union "
            ltemp = ltemp & "Select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_pq union "
            ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno, cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_iq union "
            ltemp = ltemp & "select cus_id, cus_title, cus_ucode, cus_custype, cus_uno ,cus_lotno, cus_prono,cus_department, cus_plant,cus_createby from zcustom_vr) x "
            ltemp = ltemp & "Select cus_uno,cus_title, cus_custype, cus_prono, cus_ucode, cus_lotno, de_name, cus_plant,(CONVERT(VARCHAR(25), wst_lastupdateon, 103) ) as wst_lastupdateon, [Production Report]='', [QA Testing Report]='', [Final Report]='' from #tempAlltable left join workflowstatus on cus_ucode = wst_ucode left join department on de_id = cus_department where wst_status = 'Approved' order by cus_uno DESC "
            cmd.CommandText = ltemp
            cmd.Connection = cn
            ad2.SelectCommand = cmd
            Dim x As Integer = 0
            Dim ended As Boolean = False
            ad2.Fill(ds2, "datarecords")
            For Each dr As DataRow In ds2.Tables("datarecords").Rows
                Dim present As Boolean = False
                If ended = False Then


                    While dr("cus_ucode") = ds.Tables("datarecords2").Rows(x)("cus_ucode")
                        present = present Or True
                        Select Case ds.Tables("datarecords2").Rows(x)("doc_keywords")
                            Case "PR" : dr("Production Report") = dr("Production Report") & "<span style=""margin-left:1em;"" class=""fas fa-file-invoice""></span> <a href=""" & ds.Tables("datarecords2").Rows(x)("doc_attach1path") & ds.Tables("datarecords2").Rows(x)("doc_attach1") & """ download=""" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & """>" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & " </a> "

                            Case "TR" : dr("QA Testing Report") = dr("QA Testing Report") & "<span  style=""margin-left:1em;"" class=""fas fa-file-invoice""></span> <a href=""" & ds.Tables("datarecords2").Rows(x)("doc_attach1path") & ds.Tables("datarecords2").Rows(x)("doc_attach1") & """ download=""" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & """>" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & " </a> "

                            Case "C" : dr("Final Report") = dr("Final Report") & "<span  style=""margin-left:1em;"" class=""fas fa-file-invoice""></span> <a href=""" & ds.Tables("datarecords2").Rows(x)("doc_attach1path") & ds.Tables("datarecords2").Rows(x)("doc_attach1") & """ download=""" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & """>" & ds.Tables("datarecords2").Rows(x)("doc_subject") & ds.Tables("datarecords2").Rows(x)("doc_ext") & " </a>"


                        End Select


                        x = x + 1
                        If x >= ds.Tables("datarecords2").Rows.Count Then
                            ended = True
                            Exit While

                        End If

                    End While
                End If
                If present = False Then
                    dr.Delete()
                End If


            Next





            'For Each dr As DataRow In ds.Tables("datarecords").Rows
            '    If dr("doc_keywords").ToString.Trim Like "PR*" Then
            '        dr("doc_keywords") = "Production "
            '    ElseIf dr("doc_keywords").ToString.Trim Like "TR*" Then
            '        dr("doc_keywords") = "QA Inspection Report "
            '    ElseIf dr("doc_keywords").ToString.Trim Like "C*" Then
            '        dr("doc_keywords") = "Compilation Report "
            '    End If


            'Next




            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            'lblMessage.Text = ex.Message
            Return Nothing
        End Try
        Return ds2

    End Function

    Public Shared Function getTerritoryIDfromLoginUser() As String
        Return " select tl_territorycode from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "mstrterritorylist where tl_regioncode IN " &
                                " ('" & HttpContext.Current.Session("LoginUserRegion").ToString.Replace(",", "','") & "')"
    End Function

    Public Shared Function getEvents(ByVal usercode As Object, ByVal status As String, ByVal phSearchStr As String) As List(Of CalendarEvent)
        Dim events As List(Of CalendarEvent) = New List(Of CalendarEvent)()
        'Dim cn As New OleDbConnection(connectionstring)
        'Dim cmd As New OleDbCommand()
        'Dim ad As New OleDb.OleDbDataAdapter()
        Dim cn As New OdbcConnection(WebLib.ConnEpicor)
        Dim cmd As New OdbcCommand()
        Dim ad As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim lsql As String = ""

        Try
            'lsql = "select usr_name,ffm.* from fieldforcemgmt ffm inner join secuserinfo on ffm.ffm_usrcode = secuserinfo.usr_code where ffm_usrcode in ('" & IIf(usercode = "", WebLib.LoginUser, usercode) & "') "
            'lsql = "select usr_name,ffm.* from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "fieldforcemgmt ffm " &
            lsql = "select usr_name,ffm_id,ffm_subject,ffm_usrcode,ffm_category,ffm_usrcode,ffm_startdate,ffm_enddate from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "fieldforcemgmt ffm " &
                    " inner join " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "secuserinfo on ffm.ffm_usrcode = secuserinfo.usr_code " &
                    " left join (select custid as merchantid, name as merchantname from customer union select cust_code, cust_name from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "customer ) x on ffm.ffm_merchantid = x.merchantid " &
                    " where ffm_usrcode in ('" & IIf(usercode = "", WebLib.LoginUser, usercode) & "') "

            If status <> "" Then
                lsql = lsql & " and ffm_status in ('" & status & "') "
            End If
            If phSearchStr <> "" Then
                lsql = lsql & " and " & phSearchStr.Replace("/", "%") & " "
            End If

            cmd.CommandText = lsql
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                Dim cevent As CalendarEvent = New CalendarEvent()
                cevent.id = dr("ffm_id")
                cevent.title = dr("ffm_subject") & IIf(usercode.ToString.Contains(","), " (" & IIf(dr("ffm_usrcode") = WebLib.LoginUser, "Me", dr("usr_name")) & ")", "")
                cevent.description = dr("ffm_category")
                cevent.usrid = dr("ffm_usrcode")
                cevent.start = dr("ffm_startdate")
                cevent.[end] = dr("ffm_enddate")
                events.Add(cevent)
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()

        Catch ex As Exception
            Dim msg As String = ex.Message
        End Try

        Return events
    End Function

    Public Shared Function getSalesmanListByLoginUser(ByVal loginuser As String) As String
        Dim lsql As String = ""
        lsql = " select ROW_NUMBER() OVER(ORDER BY usr_code asc) AS Recno, usr_code as sdgu_usrcode, 'Me Only' as usr_name from secuserinfo where usr_code = '" & loginuser & "' union select ROW_NUMBER() OVER(ORDER BY sdgu_usrcode asc) AS Recno, sdgu_usrcode, usr_name from secdatagroupusers inner join secuserinfo on secdatagroupusers.sdgu_usrcode = secuserinfo.usr_code where sdgu_supervisorcode = '" & loginuser & "' group by sdgu_usrcode,usr_name  "
        Return lsql
    End Function

    Public Shared Function getDocsDs(ByVal uid As String, ByVal fmodule As String) As DataSet
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim objWebLib As New WebLib

        Try
            cmd.CommandText = "Select doc_id,doc_attach1path,doc_attach1,doc_subject,doc_createby " &
                                ",(CONVERT(VARCHAR(25), doc_createdt, 103) + ' ' + CONVERT(VARCHAR(8), doc_createdt, 108)) as doc_createdt " &
                                ", '" & objWebLib.AbsoluteWebPath & ConfigurationManager.AppSettings("filespathhttpiissub") & "' + doc_attach1path + doc_attach1 as fullpath " &
                                "from docdoc where doc_uniqueid ='" & uid & "' and doc_module = '" & fmodule & "' "
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()
        Catch ex As Exception
            'lblMessage.Text = ex.Message
        End Try
        Return ds

    End Function

    Public Shared Sub saveUploaded(ByVal path As String, ByVal newname As String, ByVal oldname As String, ByVal formucode As String, ByVal moduleName As String, ByVal keyword As String, ByVal ext As String, Optional ByVal wfalevel As String = "")
        Dim lsql As String = ""
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ldocgroup As String = "-1"
        Dim insertfields As String = ""
        Dim insertvalues As String = ""
        Dim posted As Boolean
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        cn.Open()

        insertfields = insertfields & "doc_filter"
        insertvalues = insertvalues & "'" & WebLib.FilterCode.replace("'", "''") & "'"
        insertfields = insertfields & ",doc_merchantid"
        insertvalues = insertvalues & ",'" & WebLib.MerchantID.replace("'", "''") & "'"
        insertfields = insertfields & ",doc_group"
        insertvalues = insertvalues & "," & ldocgroup & ""
        insertfields = insertfields & ",doc_subject"
        insertvalues = insertvalues & ",'" & oldname.Replace("'", "''") & "'"
        insertfields = insertfields & ",doc_module"
        insertvalues = insertvalues & ",'" & moduleName.Replace("'", "''") & "'"
        insertfields = insertfields & ",doc_keywords"
        insertvalues = insertvalues & ",'" & keyword.Replace("'", "''") & "'"
        insertfields = insertfields & ",doc_createby"
        insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
        insertfields = insertfields & ",doc_createdt"
        insertvalues = insertvalues & ",getdate()"
        insertfields = insertfields & ",doc_attach1"
        insertvalues = insertvalues & ",'" & newname.Replace("'", "''") & "'"
        insertfields = insertfields & ",doc_attach1path"
        insertvalues = insertvalues & ",'" & path.Replace("'", "''") & "'"
        insertfields = insertfields & ",doc_uniqueid"
        insertvalues = insertvalues & ",'" & formucode.Replace("'", "''") & "'"

        Try
            lsql = "Insert into docdoc (" & insertfields & ") values (" & insertvalues & ")"
            cmd.CommandText = lsql
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            posted = True
        Catch e As Exception
        Finally
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Public Shared Function deleteFile(ByVal rid As String, Optional ByVal formucode As String = "") As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim filename As String = ""
        Dim posted As Boolean
        Dim lsql As String = ""

        Try
            cmd.CommandText = "Select * from docdoc where doc_id = '" & rid & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                filename = dr("doc_attach1")
            Next

            cn.Open()
            cmd.CommandText = "Delete from docdoc where doc_id = '" & rid & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            posted = True
        Catch ex As Exception
            'lblMessage.Text = ex.Message
        Finally
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            ad.Dispose()
        End Try

        Return filename
    End Function

    Public Shared Function getMatrixValidation(ByVal matrixlvl As String, ByVal matrixkey As String) As String
        Dim lsql As String = ""

        lsql = WebLib.GetValue("mstrmatrixlevel", "ml_validation", "ml_code", "'" & matrixlvl & "'", "", "", " ml_key = '" & matrixkey & "' ")

        lsql = lsql.Replace("@ConnDB", ConfigurationManager.AppSettings("ConnStrDB"))
        lsql = lsql.Replace("@LoginUserRegion", WebLib.LoginUserRegion)
        lsql = lsql.Replace("@LoginUserState", WebLib.LoginUserState)
        lsql = lsql.Replace("@LoginUser", WebLib.LoginUser)

        Return lsql
    End Function

    Public Shared Function GetAccountHolders(Optional ByVal company As String = "") As DataSet
        Dim str As String = "select salesrepcode,usr_name from customer inner join " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.secuserinfo on salesrepcode=usr_code "
        str = str & " where salesrepcode not in ('', 'Default') "
        If company.Trim <> "" Then
            str = str & " and company = '" & company & "' "
        End If
        str = str & " group by salesrepcode,usr_name order by usr_name "

        Dim cn As New Odbc.OdbcConnection(WebLib.ConnEpicor)
        Dim cmd As New Odbc.OdbcCommand()
        Dim ad As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function GetDepartmentList() As DataSet
        Dim str As String = "select * from department"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetCategoryListAS() As DataSet
        Dim str As String = "select * from category"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetModuleListAS() As DataSet
        Dim str As String = "select * from module"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function
    Public Shared Function GetCategoryList(ByVal DeptID As String) As DataSet
        Dim str As String = "select * from category where cat_deptid = '" & DeptID & "'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            LogtheAudit(cmd.CommandText)
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetModuleList(ByVal CatID As String) As DataSet
        Dim str As String = "select * from module where mod_catid = '" & CatID & "'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            LogtheAudit(cmd.CommandText)
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetCRTypeList() As DataSet
        Dim str As String = "select cm_description from codemaster where cm_fieldname = 'crtype'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetCustomerList() As DataSet
        Dim str As String = "select cu_name, cu_code from customer"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetPriorityList() As DataSet
        Dim str As String = "select cm_description from codemaster where cm_fieldname = 'priority'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetLevelList(ByVal WID As String) As DataSet
        Dim str As String = "select wui_name from workflowitems where wui_wid = " & WID & ""

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetUserList() As DataSet
        Dim str As String = "select * from secuserinfo where usr_branch = 'RGTECH' except select * from secuserinfo where usr_sysadmin = 1"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetTestingStatusList() As DataSet
        Dim str As String = "select cm_description from codemaster where cm_fieldname = 'testingstatus'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetTagList() As DataSet
        Dim str As String = "select cm_description from codemaster where cm_fieldname = 'tags'"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetDeveloperNameList() As DataSet
        Dim str As String = "select usr_name from wgrouprights inner join secuserinfo on usr_id = wur_uid where wur_wgroupid = 53"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetTesterNameList() As DataSet
        Dim str As String = "select usr_name from wgrouprights inner join secuserinfo on usr_id = wur_uid where wur_wgroupid = 51"

        Dim cn As New OleDb.OleDbConnection(connectionstring)
        Dim cmd As New OleDb.OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Return ds
        Catch ex As Exception
            LogtheAudit(ex.Message)
        End Try
    End Function

    Public Shared Function GetAccountHolder(Optional ByVal custid As String = "") As String
        Dim str As String = "select salesrepcode,usr_name from customer inner join " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.secuserinfo on salesrepcode=usr_code  "
        str = str & " where salesrepcode not in ('', 'Default') "
        'If custid <> "" Then
        str = str & " and custid = '" & custid & "' "
        'End If
        str = str & " group by salesrepcode,usr_name "

        Dim cn As New Odbc.OdbcConnection(WebLib.ConnEpicor)
        Dim cmd As New Odbc.OdbcCommand()
        Dim ad As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim dr As DataRow
        Dim AccHolder As String = ""

        Try
            cmd.CommandText = str
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                AccHolder = dr("salesrepcode") & ""
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return AccHolder

        Catch ex As Exception
        End Try
    End Function

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

