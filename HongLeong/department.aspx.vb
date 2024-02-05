Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class department_class

    Inherits detailspage

    Private f_size As String
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = "deptlist.aspx"
        _FormsName = "Department Details"
        TableName = "department"
        IDPField = ""
        IDField = "de_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "de_filter"
        APPCode = ""
        AddRights = "" '"SM0001"
        DelRights = "" '"SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "mstrcategory"

        Dim obj As New ViFeandi.General
        f_size = obj.GetPageSizeString(True, "")
        obj = Nothing

        If Page.IsPostBack = False Then
            'Call WebLib.SetListItems(wf_classification, WebLib.ClassificationString)
        End If

        Call InitLoad()

    End Sub
    Private Function ValidateForm()
        lblMessage.Text = ""
        If de_code.Text.Trim = "" Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Department Code is Mandatory")
            Return False
            Exit Function
        End If

        If de_name.Text.Trim = "" Then
            lblMessage.Text = WebLib.getAlertMessageStyle("Department Name is Mandatory")
            Return False
            Exit Function
        End If

        If WebLib.CodeExists(de_code.Text, "de_code", TableName, IDField, rid.Value, IDPField, bid.Value, AppIDField, MerchantIDField, FilterField) = True Then
            lblMessage.Text = "This Department Code Already Exist"
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
            cmd.CommandText = "Select * from department where de_id=" & rid.Value
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                counter = counter + 1

                de_code.Text = dr("de_code") & ""
                de_name.Text = dr("de_name") & ""

                'templi = wf_classification.Items.FindByValue(dr("wf_classification") & "")
                'wf_classification.SelectedIndex = wf_classification.Items.IndexOf(templi)

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            Return True

        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
            Return False
        End Try
    End Function

    Public Sub savepage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim insertfields, insertvalues As String
        Dim lsrdesc As String = ""
        insertfields = ""
        insertvalues = ""
        If ValidateForm() = False Then
            Exit Sub
        End If

        Dim lwf_class As String = ""
        'If wf_classification.SelectedIndex < 0 Then
        '    lwf_class = ""
        'Else
        '    lwf_class = wf_classification.SelectedItem.Value
        'End If

        Try
            If rid.Value = "" Then
                uid.Value = WebLib.getUniqueKey

                insertfields = insertfields & "de_merchantid"
                insertvalues = insertvalues & "'" & WebLib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",de_filter"
                insertvalues = insertvalues & ",'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",de_uid"
                insertvalues = insertvalues & ",'" & uid.Value & "'"
                insertfields = insertfields & ",de_code"
                insertvalues = insertvalues & ",'" & de_code.Text.Replace("'", "''") & "'"
                insertfields = insertfields & ",de_name"
                insertvalues = insertvalues & ",'" & de_name.Text.Replace("'", "''") & "'"
                'insertfields = insertfields & ",wf_classification"
                'insertvalues = insertvalues & ",'" & lwf_class.Replace("'", "''") & "'"
                insertfields = insertfields & ",de_createby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",de_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",de_updateby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",de_updatedt"
                insertvalues = insertvalues & ",getdate()"

            Else
                insertvalues = insertvalues & "de_name='" & de_name.Text.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",de_code='" & de_code.Text.Replace("'", "''") & "'"
                'insertvalues = insertvalues & ",wf_classification='" & lwf_class.Replace("'", "''") & "'"
                insertvalues = insertvalues & ",de_updateby='" & WebLib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",de_updatedt=getdate()"

            End If

            If savedata(insertfields, insertvalues) = True Then
                Call gotoback()
            End If
        Catch Err As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(Err.Message)
        Finally

        End Try
    End Sub

End Class

