Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class secpro_list_class
    Inherits listpage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "pf_name;Profile Name;S|"
        listingpage = "secprofilelist.aspx"
        _FormsName = "Security Center : User Profile"
        'columnscount = "7"
        TableName = "secuserprofile"
        DetailPage = "secprofile.aspx"
        IDPField = ""
        IDField = "pf_id"
        APPIDField = "pf_appid"
        MerchantIDField = ""
        FilterField = "pf_filter"
        Orderby = ""

        APPCode = "GENERAL"
        AddRights = "UP1001"
        DelRights = "UP1003"
        ModRights = "UP1002"
        ViewRights = "UP1004"
        FullRights = ""
        NMSpace = "secpro"
        '_pagesize = 20
        btnback.visible = False
		
        pFieldNames = " * "
		
        Call initLoad()
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
        Dim objRights As Object = e.Item.FindControl("lnkRights")
        If Not objRights Is Nothing Then
            If WebLib.hasrights(NmSpace, APPCode, ModRights) = False Then
                Try
                    objRights.Visible = False
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
    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Edit" Then
            Response.Redirect("postpage.aspx?NextPage=" & DetailPage & "&ga=" & e.CommandArgument & "&ba=" & bid.Value)
        End If
        If e.CommandName = "Del" Then
            Call DeleteRec(e.CommandArgument)
        End If
        If e.CommandName = "Rights" Then
            Response.Redirect("postpage.aspx?NextPage=secprofilerights.aspx&ga=" & e.CommandArgument & "&ba=" & bid.Value)
        End If
    End Sub

End Class

