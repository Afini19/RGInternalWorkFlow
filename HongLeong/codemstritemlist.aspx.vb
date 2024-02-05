Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class codemstritemlist_class

    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "cm_description;Code Description;S|"""

        listingpage = "codemstrlist.aspx"
        _FormsName = "Code Item Maintenance"
        'columnscount = "10"
        TableName = "codemaster"
        DetailPage = "codemaster.aspx"
        IDPField = ""
        IDField = "cm_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "cm_filter"
        Orderby = ""
        '_pagesize = 40
        APPCode = "" '"SMS"
        AddRights = "" '"SM0001"
        DelRights = "" ' "SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "mstrcategory" 'can change
        pFieldNames = " * "
        pJoinFields = ""
        Orderby = ""

        If Page.IsPostBack = False Then

            codegroup.Value = Request("ga") & ""
            _searchfilter = "cm_fieldname = '" & codegroup.Value & "'"

        Else
            _searchfilter = ""

        End If

        btnback.Visible = True

        Call InitLoad()
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Edit" Then
            Response.Redirect("postpage.aspx?NextPage=" & DetailPage & "&ga=" & e.CommandArgument & "&ba=" & bid.Value)
        End If
        If e.CommandName = "Delete" Then
            Call DeleteRec(e.CommandArgument)
            Call gotoback()
        End If
        'If e.CommandName = "viewCode" Then
        '    Response.Redirect("postpage.aspx?NextPage=codemstritemlist.aspx&ga=" & e.CommandArgument & "&ba=" & e.CommandArgument)
        'End If

    End Sub
    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound

        Dim objEdit As Object = e.Item.FindControl("lnkEdit")
        If Not objEdit Is Nothing Then
            If WebLib.hasrights(NmSpace, APPCode, ModRights) = False Then
                Try
                    objEdit.Visible = False
                Catch ex As Exception
                End Try
            End If
        End If

        Dim objDel As Object = e.Item.FindControl("lnkDelete")
        If Not objDel Is Nothing Then
            If WebLib.hasrights(NmSpace, APPCode, DelRights) = False Then
                Try
                    objDel.Visible = False
                Catch ex As Exception
                End Try
            End If
        End If

        Dim drv As DataRowView
        drv = e.Item.DataItem

        Dim objdata As Literal = e.Item.FindControl("litData")
        If Not objdata Is Nothing Then
            objdata.Text = drv.Row("cm_description").ToString.Trim & ""
        End If


        'objdata = e.Item.FindControl("litimage")
        'If Not objdata Is Nothing Then

        '    If drv.Row("wo_active").ToString & "" = "Yes" Then
        '        objdata.Text = "<img src=""" & WebLib.ClientURL("graphics/misc/greenfigure.png") & """ width=""32"">"

        '    Else
        '        objdata.Text = "<img src=""" & WebLib.ClientURL("graphics/misc/redflag.png") & """ width=""32"">"

        '    End If

        'End If

    End Sub

    Public Sub AddEventAdd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("postpage.aspx?NextPage=" & WebLib.ClientURL("codemaster.aspx") & "&la=" & codegroup.Value & "")
    End Sub
End Class

