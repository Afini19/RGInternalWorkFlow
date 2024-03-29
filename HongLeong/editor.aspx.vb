Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class editor_class
    Inherits detailspage
    'Generated by VI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = ""
        _FormsName = "Masterfile : Editor"
        TableName = "Editor"
        IDPField = ""
        IDField = "editor_id"
        APPIDField = ""
        MerchantIDField = "editor_merchantid"
        FilterField = "editor_filter"

        APPCODE = "GENERAL"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = "ED0005"
        NMSpace = "webcms"

        BackButton.visible = False
        Call initLoad()
    End Sub
    Private Function ValidateForm()
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
            'cmd.CommandText = "Select * from Editor where editor_type='" & bid.value & "' and editor_merchantid='" & Weblib.Merchantid & "' and editor_filter='" & Weblib.filtercode & "'"
            cmd.CommandText = "Select * from Editor where editor_type='" & bid.value & "' and editor_merchantid='' and editor_filter='" & Weblib.filtercode & "'"

            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                counter = counter + 1
                rid.value = dr("editor_id")
                editor_body.text = dr("editor_body") & ""
                litcreateby.text = dr("editor_createby") & ""
                litcreateon.text = dr("editor_createdt") & ""
                litupdateby.text = dr("editor_updateby") & ""
                litupdateon.text = dr("editor_updatedt") & ""

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        Catch ex As Exception
            lblmessage.text = ex.Message
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
                insertfields = insertfields & "editor_merchantid"
                insertvalues = insertvalues & "'" & weblib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_filter"
                insertvalues = insertvalues & ",'" & weblib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_body"
                insertvalues = insertvalues & ",'" & editor_body.text.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_type"
                insertvalues = insertvalues & ",'" & bid.value.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_createby"
                insertvalues = insertvalues & ",'" & weblib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",editor_updateby"
                insertvalues = insertvalues & ",'" & weblib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",editor_updatedt"
                insertvalues = insertvalues & ",getdate()"

            Else
                insertvalues = insertvalues & "editor_body='" & editor_body.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",editor_updateby='" & weblib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",editor_updatedt=getdate()"

            End If

            If savedata(insertfields, insertvalues) = True Then
                '                Call gotoback()
                lblmessage.text = "Data saved"
            End If
        Catch Err As Exception
            lblmessage.text = Err.message
        Finally

        End Try
    End Sub
End Class

