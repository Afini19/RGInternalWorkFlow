Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports NPOI.HSSF.Record.PageBreakRecord
Imports NPOI.SS.Formula.Functions
Imports NPOI.Util

Public Class DefaultVB
    Public Shared ErrorMsg As String = ""
    Public Shared ConnectionString As String = ""
    Public Shared MerchantMerchantID As String = ""
    Public MerchantFilter As String = ""
    Public DBPrefix As String = ""
    Public MerchantID As String = ""
    Public MerchantPwd As String = ""
    Public gAPPCode As String = "SO"
    Private Shared Function ValidateEnvironment() As Boolean


        If ConnectionString.Trim = "" Then
            ErrorMsg = "Connection String Is Mandatory"
            Return False
        End If

        If MerchantMerchantID.Trim = "" Then
            ErrorMsg = "Merchant ID Is Mandatory"
            Return False
        End If



        Return True
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