Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class wiz_selectcustomer_class
    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "sm_code;Merchant code;S|sm_name;Merchant name;S|"
        listingpage = ""
        _FormsName = "Wizard Entry - Please select a customer"
        TableName = "Customer"
        DetailPage = "sysMerchant.aspx"
        IDPField = ""
        IDField = "sm_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = ""
        Orderby = " order by sm_name "
        APPCode = "GENERAL"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = ""
        NmSpace = "selectcustomer"
        pFieldNames = "sm_id,sm_code,sm_name,sm_expiry,sm_active,sm_createby,sm_createdt,sm_updateby,sm_updatedt"
        pJoinFields = " inner join " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "sysMerchant  on sysMerchant.sm_code = Customer.CustID and Customer.Company = '" & WebLib.LoginUserCompanySelected & "' "
        btnback.Visible = False
        btnadd.Visible = False
        _connection = "Epicor"
        _searchfilter = " sm_id is not null "

        If IsPostBack = False Then
            com.Value = Request("wp7") & ""
            wnextpage.Value = Request("wp1") & ""
            refno.Value = Request("wp5") & ""
            wparam.Value = VifeandiURL.GetParameters()
        End If

        Dim query As String = ""

        If WebLib.isStaff = True Then

            If WebLib.LoginUserMatrixLevel = "" Or WebLib.LoginUserMatrixLevel.ToString.Contains("L1") Then
            Else
                For Each item As String In WebLib.LoginUserMatrixLevel.ToString.Split(",")
                    If (query & "").Trim <> "" Then
                        query = query & " union "
                    End If

                    query = query & "select sm_code,sm_name, '" & item & "' as custundermatrixlevel " &
                        "FROM " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo." & "sysMerchant " &
                        "inner join Customer on sysMerchant.sm_code = Customer.CustID and Customer.Company = '" & WebLib.LoginUserCompanySelected & "' " &
                        "where sm_id is not null and " & backend.getMatrixValidation(item, "selCust")
                Next

                pFieldNames = " * from ( select ROW_NUMBER() OVER(Partition by sm_code ORDER BY sm_code) AS ROW_NUMBER, * "
                TableName = " ( " & query & " ) x  group by sm_code,sm_name,custundermatrixlevel) y "
                _searchfilter = " row_number = '1' "
                Orderby = " order by sm_name "
                pJoinFields = ""
            End If
        End If

        Call InitLoad()

        If (com.Value & "") = "Y" Then
            btnnext.Enabled = False
        Else
            btnnext.Enabled = True
        End If
    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
        If e.CommandName = "Select" Then
            Call SelectCustomer((e.CommandArgument))
        End If
    End Sub

    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound
    End Sub

    Public Sub nextpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (wnextpage.Value & "").Trim = "" Then
            WebLib.ShowMessagePage(Response, "Infinite Wizard Loop. Not allowed to proceed.", "")
            Exit Sub
        End If

        Dim lparam As String = wparam.Value

        Try
            lparam = VifeandiURL.setparam(1, lparam, wnextpage.Value)
            lparam = VifeandiURL.setparam(2, lparam, "")
            lparam = VifeandiURL.setparam(3, lparam, "")

            'Param5 use for Any reference. Adi pass param 5 in redirector. No need to pass here
            lparam = VifeandiURL.setparam(5, lparam, refno.Value)
            lparam = VifeandiURL.setparam(7, lparam, com.Value)
            lparam = VifeandiURL.setparamclearall(lparam)
            lparam = VifeandiURL.Encode(lparam)
        Catch ex As Exception
            WebLib.ShowMessagePage(Response, ex.Message, "home.aspx")
        Finally
            Server.Transfer("wiz-postpage.aspx" & lparam & "&nextpage=" & wnextpage.Value)
        End Try
    End Sub

    Private Sub SelectCustomer(ByVal pCustCode As String)
        If (wnextpage.Value & "").Trim = "" Then
            WebLib.ShowMessagePage(Response, "Infinite Wizard Loop. Not allowed to proceed.", "")
            Exit Sub
        End If

        Dim lparam As String = wparam.Value

        Try
            Dim obj As New RuntimeCustomer
            Call obj.getInfo(pCustCode)

            lparam = VifeandiURL.setparam(1, lparam, wnextpage.Value)
            lparam = VifeandiURL.setparam(2, lparam, pCustCode)
            lparam = VifeandiURL.setparam(3, lparam, obj.CustNum)
            lparam = VifeandiURL.setparam(7, lparam, com.Value)
            lparam = VifeandiURL.setparam(5, lparam, refno.Value)
            lparam = VifeandiURL.setparamclearall(lparam)
            lparam = VifeandiURL.Encode(lparam)

            obj = Nothing

        Catch ex As Exception
            WebLib.ShowMessagePage(Response, ex.Message, "home.aspx")
        Finally
            Server.Transfer("wiz-postpage.aspx" & lparam & "&nextpage=" & wnextpage.Value)
        End Try
    End Sub

End Class
