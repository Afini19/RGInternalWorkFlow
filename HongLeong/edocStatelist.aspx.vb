Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic

Partial Public Class edocstate_list_class
    Inherits listpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = ""
        listingpage = "edocStatelist.aspx"
        'columnscount = "7"
        TableName = "edocstate"
        DetailPage = "edocstate.aspx"
        IDPField = ""
        IDField = "edoc_id"
        AppIDField = ""
        MerchantIDField = "edoc_merchantid"
        FilterField = "sy_filter"
        Orderby = ""
        '_pagesize = 20
        btnback.Visible = False

        If (WebLib.CustNum & "").trim = "" Then
            WebLib.ShowMessagePage(Response, "You are required to select a customer instance", "main.aspx")
        End If
        If SOSettings.InitRuntimeObject = False Then
            WebLib.ShowMessagePage(Response, "Error in Sales Order Initialization", "main.aspx")
        End If

        If Not IsPostBack Then
            Call populateyear()
        End If

        Call InitLoad()
        Call loadfiles()

    End Sub

    Private Sub populateyear()
        Dim item As ListItem
        Dim lyear As Integer = System.DateTime.Today.Year

        item = New ListItem("Year", "")
        ddYear.Items.Add(item)

        For counter As Integer = 0 To 7
            item = New ListItem(lyear - counter, lyear - counter)
            ddYear.Items.Add(item)
        Next
    End Sub

    Private Sub loadfiles()
        Dim lPath As String = ""
        Dim lFormat As String = ""

        If rid.Value = "S" Then
            _FormsName = "eDocument : Statement"

            If (SOSettings.DocPath1 & "").trim = "" Then
                WebLib.ShowMessagePage(Response, "Statement Download Settings Not Set", "main.aspx")
            End If
            lPath = SOSettings.DocPath1 & WebLib.MerchantID

            If WebLib.isStaff = True And WebLib.CustUnderLoginUserMatrixLevel <> "" Then
                If WebLib.CustUnderLoginUserMatrixLevel <> "L2" Then
                    WebLib.ShowMessagePage(Response, "You are not authorized to access Customer Statement.", "-")
                End If
            End If

            'July2015 Branch Filtering
            If (WebLib.CustBranchID & "").trim <> "" Then
                lFormat = lFormat & "-" & (WebLib.CustBranchName & "").trim & "*"
            Else
                If search_key1.Text.Trim <> "" Then
                    lFormat = lFormat & "-*" & search_key1.Text.Trim & "*"
                End If
            End If

            If ddYear.SelectedIndex > 0 Then
                lFormat = lFormat & "-*" & ddYear.SelectedItem.Value & "*"
            End If

            If ddMonth.SelectedIndex > 0 Then
                lFormat = lFormat & "-*" & ddMonth.SelectedItem.Value & ""
            End If

            lFormat = "*" & lFormat & ".*"
        End If

        If rid.Value = "P" Then
            _FormsName = "eDocument : Payment Listing"

            If (SOSettings.DocPath2 & "").trim = "" Then
                WebLib.ShowMessagePage(Response, "Payment Listing Download Settings Not Set", "main.aspx")
            End If
            lPath = SOSettings.DocPath2 & WebLib.MerchantID

            If WebLib.isStaff = True And WebLib.CustUnderLoginUserMatrixLevel <> "" Then
                If WebLib.CustUnderLoginUserMatrixLevel <> "L2" Then
                    WebLib.ShowMessagePage(Response, "You are not authorized to access Payment Listing.", "-")
                End If
            End If

            'July2015 Branch Filtering
            If (WebLib.CustBranchID & "").trim <> "" Then
                lFormat = lFormat & "-" & (WebLib.CustBranchName & "").trim & "*"
            Else
                If search_key1.Text.Trim <> "" Then
                    lFormat = lFormat & "-*" & search_key1.Text.Trim & "*"
                End If
            End If

            If ddYear.SelectedIndex > 0 Then
                lFormat = lFormat & "-*" & ddYear.SelectedItem.Value & "*"
            End If

            If ddMonth.SelectedIndex > 0 Then
                lFormat = lFormat & "-*" & ddMonth.SelectedItem.Value & ""
            End If

            lFormat = "*" & lFormat & ".*"
        End If


        If Directory.Exists(lPath) = False Then
            Directory.CreateDirectory(lPath)
        End If

        Dim filePaths() As String = Directory.GetFiles(lPath, WebLib.MerchantID & lFormat)

        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next

        rep.DataSource = files
        rep.DataBind()

    End Sub

    Public Sub SearchStrM(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call loadfiles()
    End Sub

    Protected Sub cmdPrevM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call loadfiles()
    End Sub

    Protected Sub cmdNextM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call loadfiles()
    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Download" Then
            Dim filePath As String

            If rid.Value = "S" Then
                If (SOSettings.DocPath1 & "").trim = "" Then
                    WebLib.ShowMessagePage(Response, "Statement Download Settings Not Set", "main.aspx")
                End If
                filePath = SOSettings.DocPath1 & WebLib.MerchantID & "/" & e.CommandArgument
            Else
                If (SOSettings.DocPath2 & "").trim = "" Then
                    WebLib.ShowMessagePage(Response, "Payment Listing Download Settings Not Set", "main.aspx")
                End If
                filePath = SOSettings.DocPath2 & WebLib.MerchantID & "/" & e.CommandArgument
            End If

            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
            Response.WriteFile(filePath)
            Response.End()
        End If
    End Sub

    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound
        Dim mytext As Literal = e.Item.FindControl("litfilename")
        Dim lFileName As String = ""
        Dim lFileName2 As String = ""
        If Not mytext Is Nothing Then
            lFileName = mytext.Text
        End If
        mytext.Visible = False
        If lFileName.Trim = "" Then
            Exit Sub
        End If

        lFileName2 = System.IO.Path.GetExtension(mytext.Text)
        Dim obj As New clsFileTypes
        Call obj.InitFile(lFileName)
        mytext = e.Item.FindControl("litimage")
        If Not mytext Is Nothing Then
            mytext.Text = "<img src=""" & obj.FileImageFile & """ width=""48px"" />"
        End If

        mytext = e.Item.FindControl("littype")
        If Not mytext Is Nothing Then
            mytext.Text = obj.FileType
        End If


        Dim temp
        temp = Microsoft.VisualBasic.Split(lFileName.Replace(lFileName2, ""), "-")

        If Microsoft.VisualBasic.UBound(temp) = 3 Then
            mytext = e.Item.FindControl("litmonth")
            If Not mytext Is Nothing Then
                mytext.Text = temp(3)
            End If

            mytext = e.Item.FindControl("lityear")
            If Not mytext Is Nothing Then
                mytext.Text = temp(2)
            End If


            mytext = e.Item.FindControl("litbranch")
            If Not mytext Is Nothing Then
                mytext.Text = temp(1)
            End If
        End If
    End Sub

End Class

