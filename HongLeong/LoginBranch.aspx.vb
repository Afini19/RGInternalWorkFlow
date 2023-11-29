Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class loginbranch_class
    Inherits stdpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _searchkeystr = ""
        listingpage = "login.aspx"
        _FormsName = "Login : Branch Access"
        columnscount = "7"
        TableName = ""
        DetailPage = ""
        IDPField = ""
        IDField = ""
        APPIDField = ""
        MerchantIDField = ""
        FilterField = ""
        Orderby = ""
        _pagesize = 20

        Call initLoad()

        If Page.IsPostBack = False Then

            Call loaddata()
        End If

        lblmessage.text = ""

    End Sub
    Public Sub loaddata(Optional ByVal _p_searchkey As String = "")
        Dim cn As New OleDbConnection(connectionstring)

        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow


        If _p_searchkey.Trim <> "" Then
            _p_searchkey = " where " & _p_searchkey
        End If

        cn.Open()
        cmd.CommandText = "Select branch.* from branch inner join UserBranchRights on br_merchantid = ub_merchantid and br_filter = ub_filter and br_code = ub_brcode and ub_usrcode='" & weblib.loginuser & "'" & _p_searchkey & " order by br_name"

        cmd.Connection = cn
        ad.SelectCommand = cmd
        ad.Fill(ds, "datarecords")

        Dim dt As DataTable = ds.Tables("datarecords")
        Dim dv As New DataView(dt)

        Dim pgitems As New PagedDataSource()
        pgitems.DataSource = dv

        rep.DataSource = pgitems
        rep.DataBind()

        If dt.rows.count = 0 Then
            '            Weblib.BranchID = e.CommandArgument
            REsponse.redirect("posproxy.aspx")
        End If

    End Sub
    Public Sub backpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect(listingpage)
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Select" Then
            '           response.write(e.CommandArgument)
            '            response.end()
            Weblib.BranchID = e.CommandArgument
            'REsponse.redirect("TSLabourlist.aspx")
            REsponse.redirect("posproxy.aspx")

        End If
    End Sub
End Class

