Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class docdocmod_class
    Inherits detailspage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = "docrepo.aspx"
        _FormsName = "Document Repository : Document"
        TableName = "docdoc"
        IDPField = ""
        IDField = "doc_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = ""
        APPCode = ""
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = ""
        NmSpace = "docdoc"

        If Page.IsPostBack = False Then
            da.value = Request("da") & ""
        End If
        Call InitLoad()
    End Sub
    Private Function ValidateForm()
        lblmessage.text = ""
        If doc_subject.Text.Trim = "" Then
            lblMessage.Text = "Subject is Mandatory"
            Return False
            Exit Function
        End If

        If doc_attach1.Text.Trim = "" Then
            '            lblmessage.Text = "Please upload a file"
            '           Return False
            '          Exit Function
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
        If IsNumeric(rid.value) = False Then
            Exit Function
        End If

        Try
            cmd.CommandText = "Select * from docdoc where doc_id=" & rid.value
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                doc_subject.Text = dr("doc_subject") & ""
                doc_details.text = dr("doc_details") & ""
                doc_keywords.text = dr("doc_keywords") & ""
                doc_attach1.FileName = dr("doc_attach1")

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
        Dim ldocgroup As String = ""
        ldocgroup = "-1"

        Try
            If rid.value = "" Then
                insertfields = insertfields & "doc_filter"
                insertvalues = insertvalues & "'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_merchantid"
                insertvalues = insertvalues & ",'" & WebLib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_group"
                insertvalues = insertvalues & "," & ldocgroup & ""
                insertfields = insertfields & ",doc_subject"
                insertvalues = insertvalues & ",'" & doc_subject.text.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_details"
                insertvalues = insertvalues & ",'" & doc_details.text.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_keywords"
                insertvalues = insertvalues & ",'" & doc_keywords.text.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_createby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",doc_attach1"
                insertvalues = insertvalues & ",'" & doc_attach1.text.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_attach1path"
                insertvalues = insertvalues & ",'" & doc_attach1.FilePathHttp.replace("'", "''") & "'"
                insertfields = insertfields & ",doc_uniqueid"
                insertvalues = insertvalues & ",'" & bid.value.replace("'", "''") & "'"

            Else
                insertvalues = insertvalues & "doc_group=" & ldocgroup & ""
                insertvalues = insertvalues & ",doc_subject='" & doc_subject.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",doc_details='" & doc_details.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",doc_keywords='" & doc_keywords.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",doc_attach1='" & doc_attach1.text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",doc_attach1path='" & doc_attach1.FilePathHttp.Replace("'", "''") & "'"

            End If

            If savedata(insertfields, insertvalues) = True Then
                Call backbackback()
            End If
        Catch Err As Exception
            lblmessage.text = Err.Message
        Finally

        End Try
    End Sub
    Private Sub backbackback()
        Response.Redirect("postpage.aspx?NextPage=" & WebLib.ClientURL("modules/docrepo/docrepomod.aspx") & "&ba=" & bid.Value)

    End Sub
    Public Sub backback(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call backbackback()
    End Sub



End Class
