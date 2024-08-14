Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary
Imports Stimulsoft.Report.Web
Imports Stimulsoft.Base
Imports Newtonsoft.Json
Imports Stimulsoft.Base.Json.Linq
Imports Newtonsoft.Base.Json.Linq
Imports System.Text

Partial Public Class printcr_class

    Inherits detailspage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            'tablename.Value = Request("ga") & ""
            'uid.Value = Request("la") & ""

            Session("tablename") = Request("ga")
            Session("uid") = Request("la")
            Session("chargeable") = Request("da")

            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHk6iA0sbdKqrIQO6GCvEq/DMsbBwpE1dMzIA3oFWIwNp6W4pq" +
                "viQgfCsZrWDncNxPFxnPvR87ya2q3/83z0of5cbqMGLxdiCgSLKK+pQKLM7U3Fs5EwGOxazDlUi2GaCCxhxowiqUBw" +
                "p+df5VPoJ9XTbwT2yd/+eAnlaJzd7a8eGuImRAnY0fryGAnW2toroYawf/rUPhle6xtyvgaeXB+NpU5HR767cGBDos" +
                "X0ypNnFZL8eVVDbOjF5BSuqPQx8sxea2CY1GRjXA/arOQwDhlNxz0RIaLRvjXxvjDrSoNDOF/WsKX//swyMvDlNRlK" +
                "+zZjgH2dapvtHbMdm5sEqkE8s/KvzXOrf66H3ZTYYsbZvIIS0l5aE+E4SQXQdLcxhD1RrDwK/SuEhMOKhyT7BjXeFa" +
                "T569ibfXpC7rpby1au0bJ06ojJ0QDlIRzWBaHf99L+A0laOsi+0SC1Po+tUa0YVqZuW4q9Y5BeooBzmeYDYvWyAbfa" +
                "c7PD/EOPyOmHuPDA+EEd7yZWS96+fdiOfwPq"

            Dim dtsettest As DataSet = GetDataSetData()
            If dtsettest IsNot Nothing AndAlso dtsettest.Tables("root").Rows.Count > 0 Then
                Dim deltaJson As String = dtsettest.Tables("root").Rows(0)("description").ToString()
                ' Debugging: Log Delta JSON content

                LiteralDelta.Text = Server.HtmlEncode(deltaJson)
                'LogtheAudit("Delta JSON: ld" & LiteralDelta.Text)
            End If

        End If

    End Sub

    Public Sub backpage2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lid As String = ViFeandi.General.GetValue(connectionstring, "workflowstatus", "wst_module", "wst_ucode", "'" & Session("uid") & "'", "", WebLib.MerchantID, "", WebLib.FilterCode)
        Dim lURL As String = ""

        lURL = Redirector.Redirect(lid, Session("uid")) & ""
        If lURL.Trim = "" Then
            Response.Redirect("~/Home.aspx")
        Else
            Response.Redirect("~/" & lURL)
        End If
    End Sub

    Protected Function doValidation() As Boolean
        Return True
    End Function

    Protected Sub StiWebViewer1_GetReport(ByVal sender As Object, ByVal e As StiReportDataEventArgs)

        Dim report = StiReport.CreateNewReport()
        Dim path = Server.MapPath("reports/cr.mrt")

        report.Load(path)

        Dim dtsettest As DataSet = GetDataSetData()

        report.Dictionary.Databases.Clear()
        report.RegData(dtsettest)

        report.Dictionary.Synchronize()

        e.Report = report
    End Sub

    Public Function SanitizeBase64String(base64String As String) As String
        Return base64String.Replace(" ", "").Replace(vbCrLf, "").Replace(vbLf, "")
    End Function

    Public Function ConvertDeltaToHtml(deltaJson As String) As String
        Dim delta As JObject = JObject.Parse(deltaJson)
        Dim html As New StringBuilder()

        For Each op As JObject In delta("ops")
            If op.Property("insert") IsNot Nothing Then
                Dim insertValue As JToken = op("insert")
                Dim attributes As JObject = If(op("attributes"), Nothing)
                Dim formattedValue As String = ""

                If TypeOf insertValue Is JObject AndAlso insertValue("image") IsNot Nothing Then
                    ' Handle image insertion
                    Dim imageData As String = insertValue("image").ToString()
                    imageData = SanitizeBase64String(imageData)
                    formattedValue = "<img src='" & imageData & "' alt='Embedded Image' />"
                Else
                    ' Handle text insertion
                    formattedValue = insertValue.ToString()

                    ' Check for formatting attributes
                    If attributes IsNot Nothing Then
                        If attributes.Property("bold") IsNot Nothing Then
                            formattedValue = "<strong>" & formattedValue & "</strong>"
                        End If
                        If attributes.Property("italic") IsNot Nothing Then
                            formattedValue = "<em>" & formattedValue & "</em>"
                        End If
                        If attributes.Property("underline") IsNot Nothing Then
                            formattedValue = "<u>" & formattedValue & "</u>"
                        End If
                        If attributes.Property("header") IsNot Nothing Then
                            Dim headerLevel As Integer = Integer.Parse(attributes("header").ToString())
                            formattedValue = "<h" & headerLevel.ToString() & ">" & formattedValue & "</h" & headerLevel.ToString() & ">"
                        End If
                    End If
                End If

                html.Append(formattedValue)
            End If
        Next

        ' Replace newlines with <br/> for HTML, ensure we handle both \n and \r\n
        Return html.ToString().Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>")
    End Function


    Public Function ConvertDeltaToJson(deltaJson As String) As String
        Dim delta As JObject = JObject.Parse(deltaJson)
        Dim jsonOutput As New JObject()
        Dim imageData As String = ""

        For Each op As JObject In delta("ops")
            If op.Property("insert") IsNot Nothing Then
                Dim insertValue As JToken = op("insert")

                If TypeOf insertValue Is JObject AndAlso insertValue("image") IsNot Nothing Then
                    ' Extract image data
                    imageData = insertValue("image").ToString()
                    Exit For
                End If
            End If
        Next

        jsonOutput("image") = imageData
        Return jsonOutput.ToString()
    End Function

    Public Function GetDataSetData() As DataSet
        Dim cn As New OleDb.OleDbConnection()
        Dim cmd As New OleDb.OleDbCommand
        Dim ad As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim counter As Integer = 0
        Dim luid As String = ""
        Dim lsql As String = ""

        Try
            cn = New OleDb.OleDbConnection(connectionstring)
            cn.Open()
            cmd.Connection = cn

            lsql = "Update " & Session("tablename") & " set cus_chargeable = '" & Session("chargeable") & "' where cus_ucode = '" & Session("uid") & "' ; "
            cmd.CommandText = lsql & "Select cus_crno as crno, cus_customer as customer, cus_initiator as initiator, cus_contactno as contactno,Convert(VARCHAR(10), cus_createdt, 103) As createdt, cus_requestTitle as requestTitle, " &
                                "cus_crtype as crtype, cus_businessReq as description, cus_devmandays as devmandays,cus_testingmandays as testingmandays, cus_priority as priority, " &
                                "cus_chargeable as chargeable,Convert(VARCHAR(10), getdate(), 103) As submitteddt from " & Session("tablename") & " where cus_ucode = '" & Session("uid") & "'"
            LogtheAudit(cmd.CommandText)
            ad.SelectCommand = cmd
            ad.Fill(ds, "root")

            'For Each row As DataRow In ds.Tables("root").Rows
            '    Dim deltaData As String = row("description").ToString()
            '    If Not String.IsNullOrEmpty(deltaData) Then
            '        ' Convert delta JSON to plain JSON with base64 image data
            '        Dim jsonData As String = ConvertDeltaToJson(deltaData)
            '        Dim jsonObj As JObject = JObject.Parse(jsonData)
            '        If jsonObj("image") IsNot Nothing Then
            '            row("description") = jsonObj("image").ToString()
            '        End If
            '    End If
            'Next

            For Each row As DataRow In ds.Tables("root").Rows
                Dim deltaData As String = row("description").ToString()
                If Not String.IsNullOrEmpty(deltaData) Then
                    Dim htmlData As String = ConvertDeltaToHtml(deltaData)
                    row("description") = htmlData
                End If
            Next

            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return ds

        Catch ex As Exception
            LogtheAudit(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub LogtheAudit(ByVal theMessage As String)
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

