Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class emailtemplace_class
Inherits detailspage
'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = ""
_FormsName = "Email Template"
TableName = "EmailTemplate"
IDPField = ""
IDField = "email_id"
APPIDField = ""
MerchantIDField = "email_merchantid"
FilterField = "email_filter"
APPCODE = "GENERAL"
AddRights = "ET0001"
DelRights = "ET0003"
ModRights = "ET0002"
ViewRights = "ET0004"
FullRights = ""
        NMSpace = "emailtemplace"
        Call InitLoad()

        BackButton.visible = False
End Sub
Private Function ValidateForm()
lblmessage.text = ""
If weblib.MerchantID.trim = "" Then
            'lblmessage.text = Weblib.getAlertMessageStyle("Merchant ID is Mandatory")
            'Return False
            'Exit Function
End If
If email_subject.text.trim = "" Then
            'lblmessage.text = Weblib.getAlertMessageStyle("Email Subject is Mandatory")
            'Return False
            'Exit Function
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


        Try
            cmd.CommandText = "Select * from EmailTemplate where email_type='" & bid.value & "'"
            ' and email_merchantid='" & weblib.Merchantid & "' and email_filter='" & Weblib.FilterCode & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                email_subject.text = dr("email_subject") & ""
                email_body.text = dr("email_body") & ""
                litcreateby.text = dr("email_createby") & ""
                litcreateon.text = dr("email_createdt") & ""
                litupdateby.text = dr("email_updateby") & ""
                litupdateon.text = dr("email_updatedt") & ""
                rid.value = dr("email_id") & ""
                Exit For
            Next

            If isnumeric(rid.value) = False Then
                Call GetDefault()
                Exit Function

            End If


            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblmessage.text = Weblib.getAlertMessageStyle(ex.Message)
        End Try
    End Function
    Public Function GetDefault() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Dim templi As ListItem

        Try
            cmd.CommandText = "Select * from EmailTemplateDefault where email_type='" & bid.value & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                email_subject.text = dr("email_subject") & ""
                email_body.text = dr("email_body") & ""
                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblmessage.text = Weblib.getAlertMessageStyle(ex.Message)
        End Try
    End Function

    Public Sub savepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim insertfields, insertvalues As String
        insertfields = ""
        insertvalues = ""
        If ValidateForm() = False Then
            Exit Sub
        End If

        Try
            If rid.value = "" Then
                insertfields = insertfields & "email_merchantid"
                insertvalues = insertvalues & "''"
                insertfields = insertfields & ",email_filter"
                insertvalues = insertvalues & ",''"
                insertfields = insertfields & ",email_subject"
                insertvalues = insertvalues & ",'" & email_subject.text.replace("'", "''") & "'"
                insertfields = insertfields & ",email_body"
                insertvalues = insertvalues & ",'" & email_body.text.replace("'", "''") & "'"
                insertfields = insertfields & ",email_type"
                insertvalues = insertvalues & ",'" & bid.value & "'"
                insertfields = insertfields & ",email_createby"
                insertvalues = insertvalues & ",'" & weblib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",email_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",email_updateby"
                insertvalues = insertvalues & ",'" & weblib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",email_updatedt"
                insertvalues = insertvalues & ",getdate()"

            Else
                insertvalues = insertvalues & "email_subject='" & email_subject.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_body='" & email_body.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_updateby='" & weblib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_updatedt=getdate()"

            End If

            If savedata(insertfields, insertvalues) = True Then
                lblmessage.text = Weblib.getAlertMessageStyle("Record Saved")

            End If
        Catch Err As Exception
            lblmessage.text = Weblib.getAlertMessageStyle(Err.message)
        Finally

        End Try
    End Sub
 End Class
