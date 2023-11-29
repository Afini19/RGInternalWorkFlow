Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class posproxy_class
    Inherits stdpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = ""
        listingpage = ""
        _FormsName = ""
        columnscount = "0"
        TableName = ""
        DetailPage = ""
        IDPField = ""
        IDField = ""
        APPIDField = ""
        MerchantIDField = ""
        FilterField = ""
        Orderby = ""
        _pagesize = 20


        If (Weblib.ProfileID & "").trim = "" Then
            Weblib.ShowMessagePage(response, "Login profile not set", "Login.aspx")
        End If
        If (Weblib.BranchID & "").trim = "" Then
            Weblib.ShowMessagePage(response, "Login branch not set", "Login.aspx")
        End If

        response.redirect("home.aspx")


        Call initLoad()

        If Page.IsPostBack = False Then

        End If


    End Sub


End Class

