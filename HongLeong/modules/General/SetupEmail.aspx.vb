Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Partial Class setupemail_aspx_class
    Inherits detailspage

    Dim TemplateCode As String = ""
    Private connectionstring As String = System.Configuration.ConfigurationSettings.AppSettings("ConnStr")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = ""
        _FormsName = "Email : Editor"
        TableName = "EmailTemplate"
        IDPField = ""
        IDField = "email_id"
        APPIDField = ""
        MerchantIDField = "email_merchantid"
        FilterField = "email_filter"

        APPCODE = "GENERAL"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = "ED0005"
        NMSpace = "webcms"

        BackButton.visible = False
        Call initLoad()

        If Page.IsPostBack = False Then
            Dim ooVifeandiEmail As New clsEmailNoti

            '            litcustom.text = ooVifeandiEmail.GetEmailCustomFiels("workflow").replace("|", "<br>")
            ooVifeandiEmail = Nothing
        End If
    End Sub
    Public Overrides Function LoadData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow

        Try
            cn.Open()
            cmd.CommandText = "Select * from EmailTemplate where email_type='" & bid.value & "'"

            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarec")
            For Each dr In ds.Tables("datarec").Rows
                counter = counter + 1
                emailcontent.text = dr("email_body") & ""
                txttitle.text = dr("email_subject") & ""
                rid.value = dr("email_id")
                litcreateby.text = dr("email_createby") & ""
                litcreateon.text = dr("email_createdt") & ""
                litupdateby.text = dr("email_updateby") & ""
                litupdateon.text = dr("email_updatedt") & ""

                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If counter = 0 Then
                initValues()
            End If


        Catch ex As Exception
            lblmessage.text = ex.message

        Finally
            cn.Close()
        End Try

        cn.Close()
    End Function

    Private Function ValidateForm()
        Return True
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
                insertvalues = insertvalues & "'" & WebLib.MerchantID.replace("'", "''") & "'"
                insertfields = insertfields & ",email_filter"
                insertvalues = insertvalues & ",'" & WebLib.FilterCode.replace("'", "''") & "'"
                insertfields = insertfields & ",email_body"
                insertvalues = insertvalues & ",'" & emailcontent.text.replace("'", "''") & "'"
                insertfields = insertfields & ",email_subject"
                insertvalues = insertvalues & ",'" & txttitle.text.replace("'", "''") & "'"
                insertfields = insertfields & ",email_type"
                insertvalues = insertvalues & ",'" & bid.value.replace("'", "''") & "'"
                insertfields = insertfields & ",email_createby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",email_createdt"
                insertvalues = insertvalues & ",getdate()"
                insertfields = insertfields & ",email_updateby"
                insertvalues = insertvalues & ",'" & WebLib.LoginUser.replace("'", "''") & "'"
                insertfields = insertfields & ",email_updatedt"
                insertvalues = insertvalues & ",getdate()"

            Else
                insertvalues = insertvalues & "email_body='" & emailcontent.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_subject='" & txttitle.text.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_updateby='" & WebLib.LoginUser.replace("'", "''") & "'"
                insertvalues = insertvalues & ",email_updatedt=getdate()"

            End If

            If savedata(insertfields, insertvalues) = True Then
                lblmessage.text = "Data saved"
            End If
        Catch Err As Exception
            lblmessage.text = Err.message
        Finally

        End Try


    End Sub
    Public Sub resetpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim lDate As Date = now
        Try
            cn.Open()
            cmd.CommandText = "Delete from " & TableName & " where email_type='" & bid.value & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            lblmessage.text = ""
            Response.Redirect("SetupEmail.aspx")
        Catch Err As Exception
            lblmessage.text = Err.message
        Finally
            cn.Close()
        End Try

    End Sub
    Public Sub initValues()


    End Sub

End Class