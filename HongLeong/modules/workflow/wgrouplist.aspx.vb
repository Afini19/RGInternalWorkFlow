Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class wgroup_list_class
    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "wo_name;Group Name;S|"""

        listingpage = "wgrouplist.aspx"
        _FormsName = "Workflow Approval Group"
        'columnscount = "10"
        TableName = "wgroup"
        DetailPage = "wgroup.aspx"
        IDPField = ""
        IDField = "wo_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "wo_filter"
        Orderby = ""
        '_pagesize = 40
        APPCode = "" '"SMS"
        AddRights = "" '"SM0001"
        DelRights = "" ' "SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "wgroup"
        pFieldNames = " * "
        pJoinFields = ""
        btnback.visible = False
        Call InitLoad()
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Edit" Then
            Response.Redirect("postpage.aspx?NextPage=" & DetailPage & "&ga=" & e.CommandArgument & "&ba=" & bid.value)
        End If
        If e.CommandName = "Del" Then
            Call DeleteRec(e.CommandArgument)
        End If
        If e.CommandName = "Rights" Then
            Response.Redirect("postpage.aspx?NextPage=wgrouprights.aspx&ga=" & e.CommandArgument & "&ba=" & e.CommandArgument)
        End If

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
            objdata.Text = drv.Row("wo_name").ToString.Trim & ""
        End If


        objdata = e.Item.FindControl("litimage")
        If Not objdata Is Nothing Then

            If drv.Row("wo_active").ToString & "" = "Yes" Then
                objdata.Text = "<img src=""" & weblib.clienturl("graphics/misc/greenflag.png") & """ width=""32"">"

            Else
                objdata.Text = "<img src=""" & weblib.clienturl("graphics/misc/redflag.png") & """ width=""32"">"

            End If

        End If

    End Sub
End Class
