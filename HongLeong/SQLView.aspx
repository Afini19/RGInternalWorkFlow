<%@ Page Language="VB" Debug=true %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDB" %>

<%@ Import Namespace="System.Data.Odbc" %>

<Script runat="Server">
	Private connectionstring as string =  System.Configuration.ConfigurationSettings.AppSettings("ConnStr")
    
	Sub Page_Load(obj as Object,e as EventArgs)
		if page.ispostback = false then
			call LoadData
		end if


	End Sub
	Public sub loaddata()
	            connectionstring = Weblib.connEpicor

        Dim cn As OdbcConnection
        Dim cmd As OdbcCommand
        Dim ad As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet()

            Dim counter as integer = 0
            Dim dr As DataRow

Dim sql as string

'sql = "Select top 20 * from pub.UD100"
'sql = "Select top 20 * from pub.salester"
'sql = "Select InvoiceNum,PONum,InvoiceDate,InvoiceAmt,OrderNum,Company from pub.InvcHead where ((convert(SQL_VARCHAR,invoicenum) like '%83%' and PONum like '%%') and (( (InvoiceDate >= '10/01/2012' and InvoiceDate <= '10/31/2012')))) and creditmemo<>1 and custnum=22"
'sql = "Select territoryid,territoryid as rtnfield,territorydesc as previewfield,territoryid as field1,territorydesc as field2,'' as field3,'' as field4,'' as field5,'' as param1,'' as param2,'' as param3,'' as param4,'' as param5,'' as param6,'' as param7,'' as param8,'' as param9,'' as param10 from pub.salester where (territoryid like '%%' or territorydesc like '%%') "
' sql = "select top 10 * from pub.part where partnum='1800101001'"
 'sql = "Select a.InvoiceNum as 'Invoice No',a.Character01 as [Reference No],a.invoicedate as [Invoice Date],a.TermsCode as [Terms Code],a.FOB as FOB,a.PONum as [PO Num],a.depositcredit as [Deposit],a.CurrencyCode as [Currency Code],b.Name as [Company Name],c.Orderline as [Order Line No],c.PartNum as [Order Line Part],c.LineDesc as [Order Line Desc],c.PackNum as [DO Num],c.OrderNum as [SO Num],c.SellingOrderQty as [Order Line Qty],c.SalesUM as [Order Line UM],c.UnitPrice as [Order Line UPrice],c.discount as [Order Line Disc],c.extprice as [Order Line Total],d.Name as [Bill to Name],d.Address1 as [Bill to Address 1],d.Address2 as [Bill to Address 2],d.Address3 as [Bill to Address 3],d.City as [Bill to City],d.State [Bill to State],d.Country as [Bill to Country],d.zip as [Bill to Zip],d.PhoneNum as [Bill to Tel No],d.FaxNum as [Bill to Fax No],e.Description as [Terms Name] from pub.InvcHead a inner join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode where a.InvoiceNum = 16059"
'sql = "select top 10 a.packnum,b.* from pub.shiphead a inner join pub.shipto b on a.shiptonum = b.shiptonum and a.company = b.company and a.custnum = b.custnum"
' sql = "Select top 10 a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.UnitPrice as 'Order Line UPrice',c.discount as 'Order Line Disc',c.extprice as 'Order Line Total',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name' from pub.InvcHead a left outer join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode"

'SQL="Select TOP 10 a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.UnitPrice as 'Order Line UPrice',c.discount as 'Order Line Disc',c.extprice as 'Order Line Total',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name',g.Name as 'Ship to Name',g.Address1 as 'Ship to Address 1',g.Address2 as 'Ship to Address 2',g.Address3 as 'Ship to Address 3',g.City as 'Ship to City',g.State 'Ship to State',d.Country as 'Bill to Country',g.zip as 'Ship to Zip',g.PhoneNum as 'Ship to Tel No',g.FaxNum as 'Ship to Fax No',f.orderdate as 'SO Date',f.salesreplist as 'SO Sales Rep' from InvcHead a inner join Company b on a.company = b.company inner join invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join customer d on a.custnum = d.custnum and a.company = d.company left outer join Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode inner join OrderHed f on a.ordernum = f.ordernum and a.company=f.company and a.CustNum = f.CustNum left outer join pub.ShipTo g on f.company = g.company and f.shiptonum = g.shiptonum and f.custnum = g.CustNum "
'sql = "Select * from pub.invcdtl where invoicenum=6037"
sql = "Select * from pub.orderdtl where ordernum=16059"
sql = "Select top 100 * from pub.uomconv"

sql = "Select top 100 * from pub.part where partnum='1800101005'"
sql = "Select top 100 * from pub.invcdtl where invoicenum=6454"
sql = "Select top 100 * from pub.shiphead"
sql ="Select top 10 a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.UnitPrice as 'Order Line UPrice',c.OrdBasedPrice as 'Order Line Nett UPrice',c.discountpercent as 'Order Line Disc', isnull(c.discount,0) as 'Order Line Disc Amt',(isnull(c.extprice,0) - isnull(c.discount,0)) as 'Order Line Total',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name',g.Name as 'Ship to Name',g.Address1 as 'Ship to Address 1',g.Address2 as 'Ship to Address 2',g.Address3 as 'Ship to Address 3',g.City as 'Ship to City',g.State 'Ship to State',d.Country as 'Ship to Country',g.zip as 'Ship to Zip',g.PhoneNum as 'Ship to Tel No',g.FaxNum as 'Ship to Fax No',f.orderdate as 'SO Date',f.salesreplist as 'SO Sales Rep' from pub.InvcHead a inner join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode inner join pub.OrderHed f on a.ordernum = f.ordernum and a.company=f.company and a.CustNum = f.CustNum left outer join pub.ShipTo g on f.company = g.company and f.shiptonum = g.shiptonum and f.custnum = g.CustNum"
sql = "select * from pub.InvcHead where creditmemo = 1 and invoicenum=6037"
'sql = "select * from pub.customer where custnum = 12"
sql = "Select * from pub.invcdtl where invoicenum=6037"
'sql = "Select  a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.UnitPrice as 'Order Line UPrice',c.OrdBasedPrice as 'Order Line Nett UPrice',c.discountpercent as 'Order Line Disc', c.discount as 'Order Line Disc Amt',(c.extprice - c.discount) as 'Order Line Total',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name',g.Name as 'Ship to Name',g.Address1 as 'Ship to Address 1',g.Address2 as 'Ship to Address 2',g.Address3 as 'Ship to Address 3',g.City as 'Ship to City',g.State 'Ship to State',d.Country as 'Ship to Country',g.zip as 'Ship to Zip',g.PhoneNum as 'Ship to Tel No',g.FaxNum as 'Ship to Fax No',f.orderdate as 'SO Date',f.salesreplist as 'SO Sales Rep' from pub.InvcHead a inner join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode inner join pub.OrderHed f on a.ordernum = f.ordernum and a.company=f.company and a.CustNum = f.CustNum left outer join pub.ShipTo g on f.company = g.company and f.shiptonum = g.shiptonum and f.custnum = g.CustNum where a.InvoiceNum = 6037 and creditmemo=1"
'12
sql = "Select top 10 * from pub.InvcHead"
'sql ="Select sum(SellingInventoryShipQty) as Datas from pub.ShipDtl a inner join pub.ShipHead b on a.Company = b.Company and a.PackNum = b.PackNum and b.CustNum =12 and (b.ShipDate>='8/1/2013' and b.ShipDate<='8/31/2013') where a.LineType='PART'"
'sql = "select top 20 * from pub.invcdtl  order by invoicenum desc"
sql = "select top 20 * from pub.invchead  where invoicenum=6842"
'sql = "Select * from pub.salester"
'sql = "Select Top 20 pub.InvcHead.InvoiceNum,pub.InvcHead.PONum,InvoiceDate,InvoiceAmt,pub.InvcHead.OrderNum,pub.InvcHead.Company,pub.Invcdtl.InvoiceRef from pub.InvcHead inner join pub.Invcdtl on pub.Invchead.invoicenum = pub.Invcdtl.Invoicenum and pub.Invchead.company = pub.Invcdtl.company where creditmemo=1 and custnum=41 and invoicesuffix<>'UR' order by invoicedate desc "
'sql = "Select top 100 * from pub.partuom "
'sql = "Select top 100 * from pub.part where partnum='1800101002' "
'sql = "Select top 100 * from pub.part where partnum='1800101001' or partnum='1800101002' or partnum='1800101003' or partnum='1800101004' or partnum='1800101005'"


'sql = "Select top 100 * from pub.uomconv where UOMClassID='WEIGHT'"
'sql = "select top 20 * from pub.invcdtl where partnum='1800101002'"
sql = "Select  * from pub.uomconv"

'sql = "Select top 100 a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',a.Invoiceref as 'Invoice Ref',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.ShipDate as 'Order Line Date',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.IUM as 'Order Line IUM',50 as 'Sales UM Conv',1 as 'IUM Conv','TONNE' as 'Order Line TUM',derived_tbl1.my_count as 'TUM Conv' ,c.UnitPrice as 'Order Line UPrice',c.OrdBasedPrice as 'Order Line Nett UPrice',c.discountpercent as 'Order Line Disc', c.discount as 'Order Line Disc Amt',(c.extprice - c.discount) as 'Order Line Total',c.InvoiceRef as 'Order Line Invoice Ref',c.InvoiceComment as 'Order Line Invoice Comment',d.CustID as 'Customer ID',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name',g.Name as 'Ship to Name',g.Address1 as 'Ship to Address 1',g.Address2 as 'Ship to Address 2',g.Address3 as 'Ship to Address 3',g.City as 'Ship to City',g.State 'Ship to State',d.Country as 'Ship to Country',g.zip as 'Ship to Zip',g.PhoneNum as 'Ship to Tel No',g.FaxNum as 'Ship to Fax No',f.orderdate as 'SO Date',f.salesreplist as 'SO Sales Rep' from pub.InvcHead a,((Select ConvFactor from pub.uomconv where UOMCode='TONNE' and UOMClassID='WEIGHT') AS derived_tbl1 (my_count)) inner join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode inner join pub.OrderHed f on a.ordernum = f.ordernum and a.company=f.company and a.CustNum = f.CustNum left outer join pub.ShipTo g on f.company = g.company and f.shiptonum = g.shiptonum and f.custnum = g.CustNum "
'sql="Select Top 20 pub.InvcHead.InvoiceNum,pub.InvcHead.PONum,pub.InvcHead.InvoiceDate,pub.InvcHead.InvoiceAmt,pub.InvcHead.OrderNum,pub.InvcHead.Company,pub.InvcHead.DocInvoiceBal,pub.Invcdtl.Packnum from pub.InvcHead inner join pub.Invcdtl on pub.InvcHead.InvoiceNum = pub.Invcdtl.Invoicenum and pub.InvcHead.Company = pub.Invcdtl.company where creditmemo<>1 and custnum=9 order by pub.InvcHead.invoicedate desc    "
    
'sql="Select Top 20 * from  pub.InvcHead where shortchar03<>''"
'sql = "Select  * from pub.custcnt"

'sql="Select Top 20 * from  pub.invcdtl where invoicecomment<>''"
'sql="Select Top 20 * from  pub.ShipDtl"
 sql="Select a.InvoiceNum as 'Invoice No',a.Character01 as 'Reference No',a.invoicedate as 'Invoice Date',a.TermsCode as 'Terms Code',a.FOB as FOB,a.PONum as 'PO Num',a.depositcredit as 'Deposit',a.CurrencyCode as 'Currency Code',a.Invoiceref as 'Invoice Ref',b.Name as 'Company Name',c.Orderline as 'Order Line No',c.ShipDate as 'Order Line Date',c.PartNum as 'Order Line Part',c.LineDesc as 'Order Line Desc',c.PackNum as 'DO Num',c.OrderNum as 'SO Num',c.SellingOrderQty as 'Order Line Qty',c.SalesUM as 'Order Line UM',c.IUM as 'Order Line IUM',50 as 'Sales UM Conv',1 as 'IUM Conv','TONNE' as 'Order Line TUM',1000 as 'TUM Conv',c.UnitPrice as 'Order Line UPrice',c.OrdBasedPrice as 'Order Line Nett UPrice',c.discountpercent as 'Order Line Disc', c.discount as 'Order Line Disc Amt',(c.extprice - c.discount) as 'Order Line Total',c.InvoiceRef as 'Order Line Invoice Ref',c.InvoiceComment as 'Order Line Invoice Comment',d.CustID as 'Customer ID',d.Name as 'Bill to Name',d.Address1 as 'Bill to Address 1',d.Address2 as 'Bill to Address 2',d.Address3 as 'Bill to Address 3',d.City as 'Bill to City',d.State 'Bill to State',d.Country as 'Bill to Country',d.zip as 'Bill to Zip',d.PhoneNum as 'Bill to Tel No',d.FaxNum as 'Bill to Fax No',e.Description as 'Terms Name',g.Name as 'Ship to Name',g.Address1 as 'Ship to Address 1',g.Address2 as 'Ship to Address 2',g.Address3 as 'Ship to Address 3',g.City as 'Ship to City',g.State 'Ship to State',d.Country as 'Ship to Country',g.zip as 'Ship to Zip',g.PhoneNum as 'Ship to Tel No',g.FaxNum as 'Ship to Fax No',f.orderdate as 'SO Date',f.salesreplist as 'SO Sales Rep' from pub.InvcHead a inner join pub.Company b on a.company = b.company inner join pub.invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company inner join pub.customer d on a.custnum = d.custnum and a.company = d.company left outer join pub.Terms e on a.Company = e.Company and a.TermsCode = e.TermsCode inner join pub.OrderHed f on a.ordernum = f.ordernum and a.company=f.company and a.CustNum = f.CustNum left outer join pub.ShipTo g on f.company = g.company and f.shiptonum = g.shiptonum and f.custnum = g.CustNum where (a.InvoiceDate >= '01/07/2013' and a.InvoiceDate <= '01/07/2013') and creditmemo<>1 and a.custnum=9"      

'sql = "select * from pub.InvcHead where invoicenum=78057"
sql = "select * from pub.Invcdtl where invoicenum=78057"

 

            cn = New OdbcConnection(connectionString)
            cn.Open()
            cmd = New OdbcCommand(sql, cn)

            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")

                ad.Fill(ds, "Registration")
				DataGrid1.DAtaSource  = ds.Tables("datarecords").DefaultView
				DataGrid1.DataBind()

	end sub
</Script>


<html>
<HEAD>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=iso-8859-1"/>
<TITLE></TITLE>
<link REL="STYLESHEET" HREF="Styles.css" TYPE="text/css">

</HEAD> 
<BODY>

<form runat="server" name=frmForm>
<asp:label runat="server" id="lblmessage" class="tablesubdetailsmall"></asp:label>

		<table width="100%" cellspacing="1" cellpadding="1">
		<tr><td colspan="1" valign="top"><font class="header">SQL View</font></td></tr>
		<tr><td colspan="1" valign="top"><hr width="100%" class="divider"></td></tr>
		</table>	

<table width="100%">
<tr><td class="tablesubdetail" align="left">
Search :&nbsp;
<asp:TextBox ID="search" runat="server" Columns="20" Maxlength="20" Class="inputnormal" onEnter="checkrecord"></asp:TextBox>&nbsp;|&nbsp;<asp:DropDownList id="accmgr" class="inputnormal" runat="server"></asp:DropDownList><font class="required">[Acc. Mgr.]</font>&nbsp;|				 <asp:DropDownList id="customer" class="inputnormal" runat="server"></asp:DropDownList><font class="required">[Customer]</font>&nbsp;|&nbsp;
<font class="required"></font>
</td><td align="right">


</td></tr></table>
<font class="tablesubdetail"><b><asp:label runat="server" id="lblmax" class="tablesubdetail"></asp:label></b></font>

<table width="100%">
<tr><td valign="top">

	<asp:DataGrid id="DataGrid1" runat="server"
	width="100%"
	autogeneratecolumns="true"
	Font-Names ="Tahoma"
	Font-Size = "8pt"
	HeaderStyle-Backcolor="#333333"
	HeaderStyle-ForeColor="white"
	allowSorting = "true"
		cellpadding = "2"
		 HeaderStyle-Height = "30px"
	>	
	</asp:DataGrid>
	
</td>
<td valign="top">
</td></tr>
</table>


</form>
</body>
</html>
