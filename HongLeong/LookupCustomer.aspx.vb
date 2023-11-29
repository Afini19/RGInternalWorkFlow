Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class LookupCustomer_class
    Inherits lookuppage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "cust_code;Customer Code;S|cust_name;Customer name;S|cust_companyreg;Company Reg No;S|cust_address1;Address 1;S|cust_catid;Customer category;N|"
        listingpage = "customerlist.aspx"
        _FormsName = "Lookup : Customer"
        columnscount = "5"
        TableName = "customer"
        DetailPage = "customer.aspx"
        IDPField = ""
        IDField = "cust_id"
        APPIDField = ""
        MerchantIDField = "cust_merchantid"
        FilterField = "cust_filter"
        Orderby = ""
        _pagesize = 20
        APPCODE = "GENERAL"
        AddRights = "CU0001"
        DelRights = "CU0003"
        ModRights = "CU0002"
        ViewRights = "CU0004"
        FullRights = ""
        NMSpace = "customer"
        pFieldNames = "cust_id,cust_code,cust_name,cc_name as cust_catid,cust_createby,cust_createdt,cust_updateby,cust_updatedt"
        pJoinFields = " inner join customercat on cust_catid = cc_id"

        searchkey.visible = False
        If Page.IsPostBack = False Then
            searchkey.text = Request("skey") & ""
        End If
        Call doSearch()
        Call initLoad()
    End Sub
    Private Sub doSearch()
        If searchkey.text.trim <> "" Then
            _searchfilter = " (cust_code like '%" & Searchkey.text & "%' or cust_name like '%" & Searchkey.text & "%') "
        Else
            _searchfilter = ""
        End If
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
    End Sub

End Class

