Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class downloaddocs_list_class
    Inherits blankpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (WebLib.CustNum & "").trim = "" Then
            WebLib.ShowMessagePage(Response, "You are required to select a customer instance", "main.aspx")
        End If

        If Page.IsPostBack = False Then
            company.Value = Request("c")
            docno.Value = Request("d")
        End If

        Call loadfiles()
    End Sub

    Private Sub loadfiles()
        Dim conn As OdbcConnection
        Dim comm As OdbcCommand
        Dim dr As DataRow
        Dim counter As Integer = 0
        Dim ad As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet()
        Dim connectionString As String
        Dim sql As String

        Try
            connectionString = WebLib.ConnEpicor

            sql = "SELECT  a.xfilerefnum, b.Xfilename, SUBSTRING(b.XFileName, LEN(b.Xfilename) - CHARINDEX ('.',REVERSE(b.Xfilename)) + 1, LEN(b.Xfilename)) as XfileExtension " &
                    "FROM Ice.XFileAttch a " &
                    "inner join Ice.xfileref b on a.xfilerefnum = b.xfilerefnum " &
                    "where a.Company='" & company.Value & "' and relatedtofile = 'ShipHead' and Key1=" & docno.Value

            WebLib.ErrorTrap = sql
            conn = New OdbcConnection(connectionString)
            conn.Open()
            comm = New OdbcCommand(sql, conn)
            ad.SelectCommand = comm
            ad.Fill(ds, "datarecords")

            For Each dr In ds.Tables("datarecords").Rows
                If (dr("Xfilename") & "").trim <> "" Then
                    counter = counter + 1
                    Dim obj As New LinkButton
                    obj.ID = "ID" & counter & dr("XfileExtension") & ""
                    obj.Text = "File " & counter
                    obj.CommandArgument = dr("Xfilename") & ""
                    obj.CommandName = "Download"

                    AddHandler obj.Command, AddressOf download_click

                    phListFiles.Controls.Add(obj)
                    phListFiles.Controls.Add(New LiteralControl("<br>"))
                End If
            Next

            conn.Close()
            comm.Dispose()
            conn.Dispose()
        Catch ex As Exception
            '            Return False
        End Try
    End Sub

    Protected Sub download_click(ByVal sender As Object, ByVal e As CommandEventArgs)
        If e.CommandName = "Download" Then
            Dim filePath As String = ""
            Dim lcompany As String = company.Value
            Dim ldocumentno As String = docno.Value
            Dim temp
            Dim ldownloadname As String = ""

            ldownloadname = "DO" & ldocumentno & "-" & sender.Text.ToString.Replace(" ", "") & "." & sender.ID.ToString.Split(".")(1)
            filePath = e.CommandArgument

            Response.ContentType = "application/" & sender.ID.ToString.Split(".")(1)
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + ldownloadname))
            Response.WriteFile(filePath)
            Response.End()
        End If
    End Sub

End Class

