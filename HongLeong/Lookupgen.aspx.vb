Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class lookupgen_class
    Inherits lookuppage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Public lAdditionalParam As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        _searchkeystr = ""
        listingpage = ""
        DetailPage = ""
        IDPField = ""
        AppIDField = ""
        _pagesize = 10
        APPCode = "GENERAL"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = ""

        _returnfield = ""
        _returnfield2 = ""
        _returnfield3 = ""
        _returnfield4 = ""
        _returnfield5 = ""
        _returnfield6 = ""
        _returnfield7 = ""
        _returnfield8 = ""
        _returnfield9 = ""

        _previewfield = ""
        'lAdditionalParam = ",'' as param1,'' as param2,'' as param3,'' as param4,'' as param5,'' as param6,'' as param7,'' as param8,'' as param9,'' as param10"
        lAdditionalParam = ",'' as param1,'' as param2,'' as param3,'' as param4,'' as param5,'' as param6,'' as param7,'' as param8,'' as param9,'' as param10,'' as param11,'' as param12,'' as param13,'' as param14,'' as param15,'' as param16,'' as param17,'' as param18,'' as param19,'' as param20"

        Dim groupby As String = ""
        Dim lcat As String = ""
        lcat = Request("lcat") & ""


        '        response.write("Test")


        searchkey.Visible = False
        If Page.IsPostBack = False Then
            searchkey.Text = Request("skey") & ""
        End If

        Select Case lcat.ToLower

            Case "user"
                _connection = "OfficeOne"

                lithead1.Text = "User ID"
                lithead2.Text = "User Name"
                lithead3.Text = "Login ID"
                lithead4.Text = "Email"

                _FormsName = "Lookup : User"
                columnscount = "7"
                IDField = "usr_id"
                TableName = "secuserinfo"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "user"
                _returnfield = "usr_loginid"
                _previewfield = "usr_name"

                pFieldNames = "usr_id," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,usr_code as field1,usr_name as field2,usr_loginid as field3,usr_email as field4,'' as field5" & lAdditionalParam
                pJoinFields = ""

                _searchfilter = " isnull(usr_disable,0) = 0 and rtrim(isnull(usr_merchantid,'')) = '' "



            Case "customer"

                _connection = "Epicor"

                _FormsName = "Lookup : Customer"
                columnscount = "7"
                IDField = "custid"
                TableName = "customer"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                lithead1.Text = "Customer ID"
                lithead2.Text = "Customer Name"
                lithead3.Text = "Address 1"
                lithead4.Text = "SMP"

                NmSpace = "customer"
                _returnfield = "custid"
                _previewfield = "name"

                pFieldNames = "custnum," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,custid as field1,name as field2,Address1 as field3,'' as field4,'' as field5,'' as field6 " & lAdditionalParam
                pJoinFields = ""

                _searchfilter = " (custid like '%" & searchkey.Text & "%' or name like '%" & searchkey.Text & "%') "
                Orderby = " order by name asc "

            Case "territory"

                _connection = "Epicor"

                lithead1.Text = "Territory Code"
                lithead2.Text = "Territory Name"

                _FormsName = "Lookup : Territory"
                columnscount = "7"
                IDField = "territoryid"
                TableName = "salester"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "territory"
                _returnfield = "territoryid"
                _previewfield = "territorydesc"

                pFieldNames = "territoryid," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,territoryid as field1,territorydesc as field2,'' as field3,'' as field4,'' as field5" & lAdditionalParam
                pJoinFields = ""

                _searchfilter = " (territoryid like '%" & searchkey.Text & "%' or territorydesc like '%" & searchkey.Text & "%') "

                '            Case "territory"

                ' _Connection = "OfficeOne"

                '  lithead1.text = "Territory Code"
                '   lithead2.text = "Territory Name"

                '    _FormsName = "Lookup : Territory"
                '     columnscount = "7"
                '      IDField = "te_id"
                '       TableName = "mstrterritory"
                '        MerchantIDField = "te_merchantid"
                '         FilterField = "te_filter"
                '          Orderby = ""
                '           NMSpace = "territory"
                '            _returnfield = "te_code"
                '             _previewfield = "te_name"

                '              pFieldNames = "te_id," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,te_code as field1,te_name as field2,te_name as field3,'' as field4,'' as field5" & lAdditionalParam
                '               pJoinFields = ""

                '                _searchfilter = " (te_code like '%" & Searchkey.text & "%' or te_name like '%" & Searchkey.text & "%') "


            Case "region"

                _connection = "OfficeOne"

                lithead1.Text = "Region Code"
                lithead2.Text = "Region Name"

                _FormsName = "Lookup : Region"
                columnscount = "7"
                IDField = "te_id"
                TableName = "mstrterritory"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "territory"
                _returnfield = "te_code"
                _previewfield = "te_name"

                pFieldNames = "te_id," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,te_code as field1,te_name as field2,'' as field3,'' as field4,'' as field5" & lAdditionalParam
                pJoinFields = ""

                _searchfilter = " (te_code like '%" & searchkey.Text & "%' or te_name like '%" & searchkey.Text & "%') "


            Case "destinationcode"
                _connection = "Epicor"
                lithead1.Text = "Destination Code"
                lithead2.Text = "Description"
                lithead3.Text = ""
                lithead4.Text = ""

                _FormsName = "Lookup : Destination Code"
                columnscount = "7"
                IDField = "key1"
                TableName = "Ice.UD100"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "destination"
                _returnfield = "key1"
                _previewfield = "character01"

                pFieldNames = "key1," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,key1 as field1,character01 as field2,'' as field3,'' as field4,'' as field5,'' as field6" & lAdditionalParam
                pJoinFields = ""

                If (Request("param1") & "").Trim <> "" Then
                    _searchfilter = " (key1 like '%" & searchkey.Text & "%' or character01 like '%" & searchkey.Text & "%') and key3='" & (Request("param1") & "").Trim & "'"

                Else
                    _searchfilter = " (key1 like '%" & searchkey.Text & "%' or character01 like '%" & searchkey.Text & "%') "

                End If


            Case "shipto"

                _connection = "Epicor"
                lithead1.Text = "Ship To Num"
                lithead2.Text = "Ship To Name"
                lithead3.Text = "Address 1"
                lithead4.Text = "Address 2"
                lithead5.Text = "City"
                lithead6.Text = "End User Type"

                _FormsName = "Lookup : Ship to Address"
                columnscount = "7"
                IDField = "ShipTo.shiptonum"
                TableName = "ShipTo"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "custshipto"
                _returnfield = "ShipTo.shiptonum"
                _previewfield = "ShipTo.Name"

                'Change on 20150311 for End User Type
                '                lAdditionalParam = ",Name as param1,Address1 as param2,Address2 as param3, Address3 as param4,City as param5,State as param6,Zip as param7,Country as param8,'' as param9,'' as param10"
                'lAdditionalParam = ",Name as param1,Address1 as param2,Address2 as param3, Address3 as param4,City as param5, isnull((select distinct state_code from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.mstrstate where state_name=state), '') as param6,Zip as param7,Country as param8,isnull(ShortChar01,'') as param9,isnull(ShortChar01,'') as param10"

                'lAdditionalParam = ",ShipTo.Name as param1,ShipTo.Address1 as param2,ShipTo.Address2 as param3, ShipTo.Address3 as param4,ShipTo.City as param5, " &
                '                    "isnull((select distinct state_code from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.mstrstate where state_name=ShipTo.state), '') as param6," &
                '                    "ShipTo.Zip as param7,ShipTo.Country as param8,isnull(ShipTo.ShortChar01,'') as param9,isnull(ShipTo.ShortChar01,'') as param10," &
                '                    "isnull(ShipTo.ShortChar08,'') as param11,isnull(ShipTo.Character01,'') as param12," &
                '                    "'' as param13," &
                '                    "isnull((case CAST(OrderHed.ShpConNum AS NVARCHAR(10)) when 0 then Customer.BTName else CustCnt.Name end),'') as param14," &
                '                    "isnull((case CAST(OrderHed.ShpConNum AS NVARCHAR(10)) when 0 then Customer.BTPhoneNum else CustCnt.PhoneNum end),'') as param15," &
                '                    "isnull(CAST(OrderHed.ShpConNum AS NVARCHAR(10)),'') as param16," &
                '                    "" &
                '                    "ShipTo.Prefix_c as param17, '' as param18, '' as param19, '' as param20 "

                lAdditionalParam = ",ShipTo.Name as param1,ShipTo.Address1 as param2,ShipTo.Address2 as param3, ShipTo.Address3 as param4,ShipTo.City as param5, " &
                                    "isnull((select distinct state_code from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.mstrstate where state_name=ShipTo.state), '') as param6," &
                                    "ShipTo.Zip as param7,ShipTo.Country as param8,isnull(ShipTo.ShortChar01,'') as param9,isnull(ShipTo.ShortChar01,'') as param10," &
                                    "isnull(ShipTo.ShortChar08,'') as param11,isnull(ShipTo.Character01,'') as param12," &
                                    "'' as param13," &
                                    "isnull((case CAST(ShipTo.SHipToNum AS NVARCHAR(10)) when '' then Customer.BTName else CustCnt.Name end),'') as param14," &
                                    "isnull((case CAST(ShipTo.SHipToNum AS NVARCHAR(10)) when '' then Customer.BTPhoneNum else CustCnt.PhoneNum end),'') as param15," &
                                    "isnull(CAST(CustCnt.ConNum  AS NVARCHAR(10)),0) as param16," &
                                    "" &
                                    "ShipTo.Prefix_c as param17, '' as param18, '' as param19, '' as param20 "

                pFieldNames = "ShipTo.shiptonum," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,ShipTo.shiptonum as field1,ShipTo.Name as field2,ShipTo.Address1 as field3,ShipTo.Address2 as field4,ShipTo.City as field5," &
                                "(select distinct cc_name from " & ConfigurationManager.AppSettings("ConnStrDB") & "dbo.customerclass where cc_code=isnull(ShipTo.ShortChar01,'')) as field6" & lAdditionalParam

                pJoinFields = " left join Customer Customer on ShipTo.company = Customer.company and ShipTo.CustNum = Customer.custnum " &
                              " left join CustCnt CustCnt on ShipTo.company = CustCnt.company and ShipTo.CustNum = CustCnt.CustNum and ShipTo.ShipToNum = CustCnt.ShipToNum "

                _searchfilter = " (ShipTo.shiptonum ='" & searchkey.Text & "' or ShipTo.[Name] like '%" & searchkey.Text & "%' or ShipTo.Zip like '%" & searchkey.Text & "%') " &
                                " And isnull(ShipTo.Checkbox01,0)<>1 And ShipTo.CustNum=" & WebLib.CustNum & " and ShipTo.Prefix_c <> '' "

                'If Session("CustUnderLoginUserMatrixLevel").ToString.Contains("L3") Then
                '    _searchfilter = _searchfilter & " and ShipTo.TerritoryID in (" & backend.getTerritoryIDfromLoginUser() & ") "
                'End If
                If WebLib.isStaff = True Then
                    For i As Integer = 3 To WebLib.GetValue("mstrmatrixlevel", "max(ml_code)", "ml_active", "'Yes'", "", "", "").Replace("L", "")
                        If WebLib.CustUnderLoginUserMatrixLevel.Contains("L" & i) Then
                            _searchfilter = _searchfilter & " and " & backend.getMatrixValidation("L" & i, "lookupgen")
                        End If
                    Next
                End If

                groupby = "group by ShipTo.shiptonum,ShipTo.Name,ShipTo.Address1,ShipTo.Address2,ShipTo.Address3,ShipTo.City,ShipTo.state,ShipTo.Zip,ShipTo.Country " &
                                ",ShipTo.ShortChar01,ShipTo.ShortChar08, ShipTo.Character01" &
                                ",CustCnt.Name,Customer.BTName,CustCnt.PhoneNum,Customer.BTPhoneNum,ShipTo.Prefix_c, CustCnt.ConNum  "

                _searchfilter = _searchfilter & groupby


            Case "product"

                _connection = "Epicor"

                lithead1.Text = "Part Num"
                lithead2.Text = "Description"
                lithead3.Text = "UOM"
                lithead4.Text = "List Price"

                _FormsName = "Lookup : Product"
                columnscount = "7"
                IDField = "part.partnum"
                TableName = "part"
                MerchantIDField = ""
                FilterField = ""
                Orderby = ""
                NmSpace = "product"
                _returnfield = "part.partnum"
                _returnfield2 = "SalesUM"
                _previewfield = "partdescription"

                Dim ltempa As String
                If _returnfield2.Trim <> "" Then : ltempa = ltempa & "," & _returnfield2 & " as rtnfield2" : End If

                lAdditionalParam = ",partdescription as param1,SalesUM as param2,cast(PriceLstParts.BasePrice as nvarchar) as param3,'' as param4,'' as param5,'' as param6,'' as param7,'' as param8,'' as param9,'' as param10,'' as param11,'' as param12,'' as param13,'' as param14,'' as param15,'' as param16,'' as param17,'' as param18,'' as param19,'' as param20"

                pFieldNames = "part.partnum as pt_id," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,part.partnum as field1,partdescription as field2,SalesUM as field3,cast(PriceLstParts.BasePrice as nvarchar) as field4,'' as field5,'' as field6" & ltempa & lAdditionalParam

                'pJoinFields = "inner join Erp.PriceLstParts PriceLstParts on part.partnum = PriceLstParts.partnum inner join Erp.PriceLst PriceLst on PriceLstParts.ListCode = PriceLst.ListCode "
                pJoinFields = " left join Erp.PriceLstParts PriceLstParts on part.partnum = PriceLstParts.partnum left join Erp.PriceLst PriceLst on PriceLstParts.ListCode = PriceLst.ListCode and PriceLst.Company = PriceLstParts.Company left join Erp.PriceLst_UD PriceLst2 on PriceLst.SysRowID = PriceLst2.ForeignSysRowID "

                Dim lproductfilter As String = ""
                If (WebLib.FilterPartClass & "").Trim <> "" Then
                    lproductfilter = " and Classid in (" & WebLib.FilterPartClass & ")"
                End If
                Dim lstatefilter As String = ""
                If Request("param1") IsNot Nothing Then ' for web order
                    If (Request("param1") & "") = "" Then
                        lblMessage.Text = "Shipping State is Mandatory"
                        Exit Sub
                    End If
                    _searchfilter = " (part.partnum like '%" & searchkey.Text & "%' or partdescription like '%" & searchkey.Text & "%') and PriceLst2.Character01='" & (Request("param1") & "").Trim & "'" &
                                        "and '" & WebLib.formatthedate(DateTime.Today(), True) & "' between PriceLst.StartDate and ISNULL(PriceLst.EndDate,'" & WebLib.formatthedate(DateTime.Today(), True) & "') " & lproductfilter

                Else ' for sales order qty max
                    lithead4.Text = ""
                    lAdditionalParam = ",partdescription as param1,SalesUM as param2,'' as param3,'' as param4,'' as param5,'' as param6,'' as param7,'' as param8,'' as param9,'' as param10,'' as param11,'' as param12,'' as param13,'' as param14,'' as param15,'' as param16,'' as param17,'' as param18,'' as param19,'' as param20"
                    pFieldNames = "part.partnum as pt_id," & _returnfield & " as rtnfield," & _previewfield & " as previewfield,part.partnum as field1,partdescription as field2,SalesUM as field3,'' as field4,'' as field5,'' as field6" & ltempa & lAdditionalParam
                    pJoinFields = ""
                    _searchfilter = " (part.partnum like '%" & searchkey.Text & "%' or partdescription like '%" & searchkey.Text & "%') " & lproductfilter

                End If
        End Select

        Dim lsql As String = "select " & pFieldNames & lAdditionalParam & " from " & TableName & pJoinFields & " where " & _searchfilter & Orderby

        Call InitLoad()

        '        If weblib.isadmin = True Then
        'response.write(weblib.errortrap)
        'End If
    End Sub
    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand
    End Sub

End Class
