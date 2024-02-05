Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class invoiceprint_class
    Inherits listpage
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1

    Dim printserverurl As String = WebLib.PrintEngine
    Dim whereCondition As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = "convert(varchar(30),InvcHead.invoicenum);Invoice No.;S|InvcHead.PONum;P/O Number;S|convert(varchar(30),InvcHead.OrderNum);Sales Order No.;S|convert(varchar(30),InvcDtl.PackNum);D/O Number;S|InvcHead.InvoiceDate;Invoice Date;D|"

        listingpage = ""
        _FormsName = "Invoice Print"
        _connection = "Epicor"
        'columnscount = "10"
        TableName = "InvcHead"
        DetailPage = ""
        IDPField = ""
        IDField = ""
        AppIDField = ""
        MerchantIDField = ""
        FilterField = ""
        Orderby = ""
        '_pagesize = 20
        APPCode = "SALES"
        AddRights = ""
        DelRights = ""
        ModRights = ""
        ViewRights = ""
        FullRights = ""
        NmSpace = "invoice"

        If Page.IsPostBack = False Then
            pFieldNames = "Top 10 InvcHead.InvoiceNum,InvcHead.PONum,InvcHead.InvoiceDate,InvcHead.InvoiceAmt,InvcHead.OrderNum,InvcHead.Company,InvcHead.DocInvoiceBal,Invcdtl.Packnum,OpenInvoice,Posted,InvcHead.LegalNumber"
            Orderby = "order by InvcHead.invoicedate desc"
        Else
            pFieldNames = "InvcHead.InvoiceNum,InvcHead.PONum,InvcHead.InvoiceDate,InvcHead.InvoiceAmt,InvcHead.OrderNum,InvcHead.Company,InvcHead.DocInvoiceBal,Invcdtl.Packnum,OpenInvoice,Posted,InvcHead.LegalNumber"
            Orderby = "order by InvcHead.invoicedate desc"
        End If

        If (WebLib.CustNum & "").trim = "" Then
            Dim obj As New RuntimeCustomer
            Call obj.getInfo(WebLib.MerchantID)
            WebLib.CustNum = obj.CustNum
            obj = Nothing
        End If

        If (WebLib.CustNum & "").trim = "" Then
            WebLib.ShowMessagePage(Response, "You are required to login as a customer instance", "main.aspx")
        End If

        Dim lBranchFilter As String = ""
        If (WebLib.CustBranchID & "").trim <> "" Then
            lBranchFilter = " and isnull(InvcHead.ShortChar02,'')='" & (WebLib.CustBranchID & "").trim & "' "
        End If

        _searchfilter = " creditmemo<>1 and InvoiceType='SHP' and InvcHead.custnum=" & WebLib.CustNum & " " & lBranchFilter & " and InvcHead.Posted=1 and InvcHead.LegalNumber <> '' and InvcHead.Company = '" & WebLib.LoginUserCompanySelected & "' "

        If WebLib.isStaff = True Then
            'If Session("CustUnderLoginUserMatrixLevel").ToString.Contains("L3") Then
            '    If (_searchfilter & "").Trim <> "" Then
            '        _searchfilter = _searchfilter & " and "
            '    End If
            '    Dim territories As String = WebLib.GetValue("mstrterritorylist", " distinct STUFF((SELECT ''',''' + tl_territorycode FROM mstrterritorylist WHERE tl_regioncode in ('" & HttpContext.Current.Session("LoginUserRegion").ToString.Replace(",", "','") & "') FOR xml path('')), 2, 2, '') + '''' ", "tl_merchantid", "''", "", "")

            '    _searchfilter = _searchfilter & " OrderHed.ShortChar05 in (" & territories & ") "
            'End If
            For i As Integer = 3 To WebLib.GetValue("mstrmatrixlevel", "max(ml_code)", "ml_active", "'Yes'", "", "", "").Replace("L", "")
                If WebLib.CustUnderLoginUserMatrixLevel.Contains("L" & i) Then
                    _searchfilter = _searchfilter & " and " & backend.getMatrixValidation("L" & i, "invPrint")
                End If
            Next
        End If

        pJoinFields = " inner join Invcdtl on InvcHead.InvoiceNum = Invcdtl.Invoicenum and InvcHead.Company = Invcdtl.company and InvcHead.Company = '" & WebLib.LoginUserCompanySelected & "' " &
            " inner join OrderHed on OrderHed.company=InvcHead.company And OrderHed.CustNum=InvcHead.CustNum And OrderHed.OrderNum=InvcHead.OrderNum "
        btnback.Visible = False


        whereCondition = IIf(_searchfilter = "", "", Server.UrlEncode(_searchfilter.Replace("InvcHead", "a").Replace("OrderHed", "f")))


        Call InitLoad()

    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep.ItemCommand

    End Sub

    Public Sub printrange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _l_EpicorDateFormat As String = "MM/dd/yyyy"
        Dim lstring As String = ""
        lblprint.Text = ""
        Dim whereCondition As String
        whereCondition = IIf(_searchfilter = "", "", Server.UrlEncode(_searchfilter.Replace("InvcHead", "a").Replace("OrderHed", "f")))

        If uc_fromp.Value.tostring.trim = "" And uc_top.Value.tostring.trim = "" Then
            lblprint.Text = "Please select from and to date"
            Exit Sub
        End If

        Dim struc_top As DateTime
        If uc_top.Value.tostring.trim = "" Then
            struc_top = DateTime.Now
        Else
            struc_top = uc_top.DateValue
        End If

        Dim dt As New DropDownList
        Dim lURL As String

        Call WebLib.setListItemsTableEpicor(dt, "InvoiceNum", "InvoiceNum", TableName, "", _searchfilter & " and InvoiceDate >= '" & Microsoft.VisualBasic.Format(uc_fromp.DateValue, _l_EpicorDateFormat) & "' and InvoiceDate <= '" & Microsoft.VisualBasic.Format(struc_top, _l_EpicorDateFormat) & "'")

        If dt.Items.Count <= 0 Then
            lURL = "$(function() {$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: 'message1.aspx?ga=Not Available',width:'90%',height:'90%'})})"

        Else
            If DateDiff("d", uc_fromp.DateValue, New DateTime(2018, 9, 1, 0, 0, 0)) <= 0 Then
                'SST Time

                lstring = "?df=" & Microsoft.VisualBasic.Format(uc_fromp.DateValue, _l_EpicorDateFormat) & "&dt=" & Microsoft.VisualBasic.Format(struc_top, _l_EpicorDateFormat) & "&cn=" & WebLib.CustNum & "&baid=" & (WebLib.CustBranchID & "").trim
                lURL = "$(function() {$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: '" & printserverurl & "printreport.aspx" & lstring & "&pt=IS&cond=" & whereCondition & "',width:'90%',height:'90%'})})"

            Else
                lstring = "?df=" & Microsoft.VisualBasic.Format(uc_fromp.DateValue, _l_EpicorDateFormat) & "&dt=" & Microsoft.VisualBasic.Format(struc_top, _l_EpicorDateFormat) & "&cn=" & WebLib.CustNum & "&baid=" & (WebLib.CustBranchID & "").trim
                lURL = "$(function() {$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: '" & printserverurl & "printreport.aspx" & lstring & "&pt=I1&cond=" & whereCondition & "',width:'90%',height:'90%'})})"

            End If
        End If

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "myscript", lURL, True)
    End Sub

    Public Sub exportrange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _l_EpicorDateFormat As String = "MM/dd/yyyy"
        Dim lstring As String = ""
        Dim lFieldNames As String = "InvcHead.InvoiceNum as 'Invoice No',InvcHead.InvoiceDate as 'Invoice Date',InvcHead.InvoiceAmt as 'Invoice Amt',InvcHead.DocInvoiceBal as 'Balance Amt',InvcHead.PONum as 'P/O No',InvcHead.OrderNum as 'Sales Order No',Invcdtl.Packnum as 'Delivery Order No',OpenInvoice as 'Open Invoice ?' "

        lblprint.Text = ""

        If uc_fromp.Value.tostring.trim = "" And uc_top.Value.tostring.trim = "" Then
            lblprint.Text = "Please select from and to date"
            Exit Sub
        End If

        Dim struc_top As DateTime
        If uc_top.Value.tostring.trim = "" Then
            struc_top = DateTime.Now
        Else
            struc_top = uc_top.DateValue
        End If

        lstring = " and (InvcHead.InvoiceDate >= '" & Microsoft.VisualBasic.Format(uc_fromp.DateValue, _l_EpicorDateFormat) & "' and InvcHead.InvoiceDate <= '" & Microsoft.VisualBasic.Format(struc_top, _l_EpicorDateFormat) & "') and Posted=1 "
        Dim _l_sql As String = "Select " & lFieldNames & " from " & TableName & " " & pJoinFields & " where " & _searchfilter & "  " & lstring & " " & Orderby

        WebLib.ExportExcelODBC(Response, _l_sql, "Invoice")
    End Sub

    Protected Sub rep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rep.ItemDataBound
        Dim drv As DataRowView
        drv = e.Item.DataItem
        Dim lAmtTotal As String = "0"
        Dim lAmtBal As String = "0"
        Dim mytext As Literal = e.Item.FindControl("litlink")

        If Not mytext Is Nothing Then
            If WebLib.BitToBoolean(drv.Row("Posted") & "") = True And drv.Row("LegalNumber") & "" <> "" Then
                If DateDiff("d", drv.Row("InvoiceDate"), New DateTime(2015, 4, 1, 0, 0, 0)) <= 0 Then
                    If DateDiff("d", drv.Row("InvoiceDate"), New DateTime(2018, 9, 1, 0, 0, 0)) <= 0 Then
                        'SST Time
                        mytext.Text = "<a href=""#"" onClick=""$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: '" & printserverurl & "printreport.aspx?dno=" & drv.Row("InvoiceNum").ToString.Trim & "&dcompany=" & drv.Row("Company").ToString.Trim & "&pt=IS&cond=" & whereCondition & "',width:'90%',height:'90%'})"">Print Invoice</a>"

                    Else
                        'GST Time
                        mytext.Text = "<a href=""#"" onClick=""$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: '" & printserverurl & "printreport.aspx?dno=" & drv.Row("InvoiceNum").ToString.Trim & "&dcompany=" & drv.Row("Company").ToString.Trim & "&pt=I1&cond=" & whereCondition & "',width:'90%',height:'90%'})"">Print Invoice</a>"

                    End If
                Else
                    'Prior GST Time
                    mytext.Text = "<a href=""#"" onClick=""$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href: 'http://humecementconnect.com.my/printengine2/printreport.aspx?dno=" & drv.Row("InvoiceNum").ToString.Trim & "&dcompany=" & drv.Row("Company").ToString.Trim & "&pt=I1',width:'90%',height:'90%'})"">Print Invoice</a>"

                End If

                mytext = e.Item.FindControl("litAmt")
                If Not mytext Is Nothing Then
                    lAmtTotal = mytext.Text
                End If
                mytext = e.Item.FindControl("litAmtBal")
                If Not mytext Is Nothing Then
                    lAmtBal = mytext.Text
                End If
            Else
                mytext.Text = "<font color=""Red"">Processing</font>"
                mytext = e.Item.FindControl("litAmt")
                If Not mytext Is Nothing Then
                    mytext.Text = ""
                End If
                mytext = e.Item.FindControl("litAmtBal")
                If Not mytext Is Nothing Then
                    mytext.Text = ""
                End If
            End If
        End If

        mytext = e.Item.FindControl("litopen")
        If Not mytext Is Nothing Then
            If WebLib.BitToBoolean(drv.Row("openinvoice") & "") = True Then
                mytext.Text = "Open"
            End If
            If WebLib.BitToBoolean(drv.Row("openinvoice") & "") = False Then
                mytext.Text = "Close"
            End If
        End If
        Dim mytexttotal As Literal = Page.FindControl("litAmtTotal")
        If Not mytexttotal Is Nothing Then
            If IsNumeric(mytexttotal.Text) = False Or e.Item.ItemIndex = 0 Then
                mytexttotal.Text = "0"
            End If
            mytexttotal.Text = CDbl(mytexttotal.Text) + CDbl(lAmtTotal)
            mytexttotal.Text = WebLib.formatthemoney(CDbl(mytexttotal.Text))
        End If
        mytexttotal = Page.FindControl("litAmtBalTotal")
        If Not mytexttotal Is Nothing Then
            If IsNumeric(mytexttotal.Text) = False Or e.Item.ItemIndex = 0 Then
                mytexttotal.Text = "0"
            End If
            mytexttotal.Text = CDbl(mytexttotal.Text) + CDbl(lAmtBal)
            mytexttotal.Text = WebLib.formatthemoney(CDbl(mytexttotal.Text))
        End If
    End Sub

End Class
