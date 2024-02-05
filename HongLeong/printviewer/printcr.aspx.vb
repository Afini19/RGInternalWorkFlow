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
        End If

    End Sub

    Public Sub backpage2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lid As String = ViFeandi.General.GetValue(connectionstring, "workflowstatus", "wst_module", "wst_ucode", "'" & Session("uid") & "'", "", WebLib.MerchantID, "", WebLib.FilterCode)
        Dim lURL As String = ""

        lURL = Redirector.Redirect(lid, Session("uid")) & ""
        If lURL.Trim = "" Then
            Response.Redirect("~/main.aspx")
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
                                "cus_crtype as crtype,cus_businessReq as description, cus_devmandays as devmandays,cus_testingmandays as testingmandays, cus_priority as priority, " &
                                "cus_chargeable as chargeable,Convert(VARCHAR(10), getdate(), 103) As submitteddt from " & Session("tablename") & " where cus_ucode = '" & Session("uid") & "'"
            LogtheAudit(cmd.CommandText)
            ad.SelectCommand = cmd
            ad.Fill(ds, "root")

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

