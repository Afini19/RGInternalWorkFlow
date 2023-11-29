Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class supportdash_class
    Inherits stdpage
    Public _l_resource1 As String
    Public _l_resource2 As String
    'Generated by VI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listingpage = ""
        _FormsName = "Dashboard"
        TableName = ""
        IDPField = ""
        IDField = ""
        APPIDField = ""
        MerchantIDField = ""
        FilterField = ""
        Call initLoad()
        lblmessage.text = ""
        If Page.IsPostBack = False Then
            uid.value = ""
            uidname.value = ""
            pnldetail.visible = False
            pnlgraph.visible = True
            tic_datefrom.value = Weblib.formatthedate(datetime.today)
            tic_dateto.value = Weblib.formatthedate(dateadd("d", 30, datetime.today))

            '           Call loadSales()
            '
            If request("ga") = "2" Then
                Call loadbySalesPerson()
            Else
                Dim ltype as string = request("da") & ""
                ltype = ltype.trim
'                response.write ("ID" & ltype)

                Call loadSales(ltype)

            End If



        End If
    End Sub
    Private Function ValidateForm()
        Return True
    End Function
    Private Function returnmonth(ByVal pMonth As String) As String
        Select Case CLng(pMonth)

            Case 1
                Return "Jan"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Apr"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "Jul"
            Case 8
                Return "Aug"
            Case 9
                Return "Sept"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dec"

        End Select

    End Function
    Private Sub loadSales(optional byval pType as string = "")

        pnldetail.visible = False
        pnlgraph.visible = True


        '        If Weblib.isstaff = True Then


        '        Else

        If (WebLib.CustNum & "").trim = "" Then
            lblmessage.text = WebLib.getAlertMessageStyle("You are required to select a customer instance")
            Exit Sub
        End If

        '       End If


        Dim cn As New OdbcConnection(WebLib.ConnEpicor)
        Dim cmd As New OdbcCommand()
        Dim ad As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0
        Dim lTitleAdd As String = ""
        Dim dr As DataRow
        Dim ltemplabel As String = ""
        Dim lseries1 As String = ""
        Dim lseries2 As String = ""
        Dim lseries3 As String = ""
        Dim ltempdata As String

        Dim ad2 As New OleDb.OleDbDataAdapter()
        Dim ds2 As New DataSet()
        Dim dr2 As DataRow

        If ValidateForm() = False Then
            Exit Sub
        End If

        Dim lSubTitle As String = "Value in Tonne(s)"


        Dim ltempSQL As String = ""

        Try

            Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)

            Dim fromdate As Date
            Dim todate As Date
            Dim lfrommonth
            Dim lCustNum As String = " and a.custnum=" & WebLib.CustNum & " "


            If (WebLib.CustNum & "").trim = "" And WebLib.isStaff = True Then
                lCustNum = ""
            End If
            For counter = 0 To 12
                fromdate = thisMonth.AddMonths((12 - counter) * -1)
                todate = thisMonth.AddMonths((12 - (counter + 1)) * -1).AddDays(-1)
                counter2 = 0

                ltempSQL = ""


                If ltemplabel.Trim <> "" Then
                    ltemplabel = ltemplabel & ","
                End If
                ltemplabel = ltemplabel & "'" & returnmonth(fromdate.Month) & " " & fromdate.Year & "'"


                Select Case pType

                    Case "1"
                        cmd.CommandText = "Select sum((SellingShipQty)) as Datas from InvcHead a inner join invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company and c.IUM='KG' and c.salesum='Bags' inner join customer d on a.custnum = d.custnum and a.company = d.company inner join Erp.uomconv k on c.SalesUM=k.UOMCode and k.uomclassid='WEIGHT' where  (a.InvoiceDate >= '" & WebLib.formatthedate(fromdate, True) & "' and a.InvoiceDate <= '" & WebLib.formatthedate(todate, True) & "') " & lCustNum & " and a.Creditmemo = 0"
                        lSubTitle = "Value in Bag(s)"
                        lTitleAdd = "(Bags)"
                    Case "2"
                        cmd.CommandText = "Select sum((SellingShipQty * ConvFactor)/1000) as Datas from InvcHead a inner join invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company and c.IUM='KG' and c.salesum<>'Bags' inner join customer d on a.custnum = d.custnum and a.company = d.company inner join Erp.uomconv k on c.SalesUM=k.UOMCode and k.uomclassid='WEIGHT' where  (a.InvoiceDate >= '" & WebLib.formatthedate(fromdate, True) & "' and a.InvoiceDate <= '" & WebLib.formatthedate(todate, True) & "') " & lCustNum & " and a.Creditmemo = 0"
                        lSubTitle = "Value in Tonne"
                        lTitleAdd = "(Bulk)"

                    Case Else
                        lSubTitle = "Value in Tonne"

                        cmd.CommandText = "Select sum((SellingShipQty * ConvFactor)/1000) as Datas from InvcHead a inner join invcdtl c on a.invoicenum = c.invoicenum and a.company = c.company and c.IUM='KG' inner join customer d on a.custnum = d.custnum and a.company = d.company inner join Erp.uomconv k on c.SalesUM=k.UOMCode and k.uomclassid='WEIGHT' where  (a.InvoiceDate >= '" & WebLib.formatthedate(fromdate, True) & "' and a.InvoiceDate <= '" & WebLib.formatthedate(todate, True) & "') " & lCustNum & " and a.Creditmemo = 0"

                End Select

                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    counter2 = counter2 + 1
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If

                    If (dr("Datas") & "").trim = "" Then
                        lseries1 = lseries1 & "0"

                    Else
                        lseries1 = lseries1 & dr("Datas")

                    End If
                    Exit For
                Next


                If counter2 = 0 Then
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If
                    lseries1 = lseries1 & "0"
                End If

                ds.Clear()
                ad.Dispose()

            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()


            Select Case pType

                Case "1"
                    lseries1 = "Sales in Bag(s)||" & lseries1
                    graph1.YAxisTitle = "Bag(s)"
                    graph1.ToolTipValueSuffix = "Bag(s)"

                Case Else
                    lseries1 = "Sales in Tonne(s)||" & lseries1
                    graph1.YAxisTitle = "Tonne(s)"
                    graph1.ToolTipValueSuffix = "Tonne(s)"

            End Select


            If pType.Trim = "" Then
                lseries2 = GetSalesTargetSeries()
            End If

            If lseries2.Trim = "" Then
                ltempdata = lseries1

            Else
                ltempdata = lseries1 & ";;" & lseries2 ''& ";;" & lseries3

            End If
            '           lseries3 = "Cancelled Ticket||" & lseries3




            '            lblmessage.text = lseries2

            graph1.Width = "100%"
            '            graph1.Height = "100%"
            graph1.ChartType = "line"
            graph1.ChartTitle = "Rolling 12 months Sales " & lTitleAdd
            graph1.ChartSubTitle = lSubTitle
            graph1.XAxisTitle = "Month"

            graph1.YAxisMinValue = "0"

            graph1.XAxisLabels = ltemplabel
            graph1.Data = ltempdata

            graph1.Initgraph()
        Catch ex As Exception
            lblmessage.text = WebLib.getAlertMessageStyle(ex.message)

        End Try

    End Sub
    Private Function GetSalesTargetSeries() As String
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0

        Dim dr As DataRow
        Dim ltemplabel As String = ""
        Dim lseries1 As String = ""
        Dim ltempdata As String

        Dim ad2 As New OleDb.OleDbDataAdapter()
        Dim ds2 As New DataSet()
        Dim dr2 As DataRow


        Dim ltempSQL As String = ""

        Try



            Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)

            Dim fromdate As Date
            Dim todate As Date
            Dim lfrommonth
            For counter = 0 To 12
                fromdate = thisMonth.AddMonths((12 - counter) * -1)
                todate = thisMonth.AddMonths((12 - (counter + 1)) * -1).AddDays(-1)
                counter2 = 0

                'cmd.CommandText = "Select isnull(sat_" & Microsoft.VisualBasic.Format(fromdate.Month, "00") & ",0) as Datas from SalesTarget where sat_custcode='" & Weblib.Merchantid & "' and sat_year = " & fromdate.Year
                cmd.CommandText = "Select isnull(sum((sat_" & Microsoft.VisualBasic.Format(fromdate.Month, "00") & " * uom_rptconvt)/uom_rptconvd),0) as Datas from SalesTarget inner join productuom on sat_uom = uom_code where sat_custcode='" & Weblib.Merchantid & "' and sat_year = " & fromdate.Year

                cmd.Connection = cn
                ad.SelectCommand = cmd
                ad.Fill(ds, "datarecords")
                For Each dr In ds.Tables("datarecords").Rows
                    counter2 = counter2 + 1
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If

                    If (dr("Datas") & "").trim = "" Then
                        lseries1 = lseries1 & "0"

                    Else
                        lseries1 = lseries1 & dr("Datas")

                    End If
                    Exit For
                Next


                If counter2 = 0 Then
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If
                    lseries1 = lseries1 & "0"
                End If

                ds.Clear()
                ad.Dispose()

            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()



            lseries1 = "Sales Target in Tonne(s)||" & lseries1
            Return lseries1
        Catch ex As Exception
            lblmessage.text = Weblib.getAlertMessageStyle(ex.message)
            Return ""
        End Try

    End Function

    Private Sub loadbySalesPerson()

        pnldetail.visible = False
        pnlgraph.visible = True


        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0


        If (weblib.CustNum & "").trim = "" Then
            lblmessage.text = Weblib.getAlertMessageStyle("You are required to select a customer instance")
            Exit Sub
        End If


        Dim dr As DataRow
        Dim ltemplabel As String = ""
        Dim lseries1 As String = ""
        Dim lseries2 As String = ""
        Dim lseries3 As String = ""
        Dim ltempdata As String

        Dim ad2 As New OleDb.OleDbDataAdapter()
        Dim ds2 As New DataSet()
        Dim dr2 As DataRow

        If ValidateForm() = False Then
            Exit Sub
        End If


        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        Dim fromdate As Date
        Dim todate As Date
        fromdate = thisMonth.AddMonths((12 - counter) * -1)
        todate = (thisMonth.AddMonths(1)).AddDays(-1)


        Dim lSubTitle As String = "From " & weblib.formatthedate(fromdate) & " to " & weblib.formatthedate(todate) & " by online order date"
        Dim ltempSQL As String = " and (datediff(d,sa_orderdt,'" & weblib.formatthedate(fromdate) & "') <=0 and datediff(d,sa_orderdt,'" & weblib.formatthedate(todate) & "') >=0)"

        Try

            cmd.CommandText = "Select sp_name as Labels,sp_id as id from salesperson where sp_merchantid='" & Weblib.merchantid & "' and sp_filter='" & Weblib.FilterCode & "'"
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows

                counter = counter + 1

                If ltemplabel.Trim <> "" Then
                    ltemplabel = ltemplabel & ","
                End If
                ltemplabel = ltemplabel & "'" & dr("Labels") & "'"

                cmd.CommandText = "Select isnull(sum(sd_qty),0) as Datas from salesdetails inner join sales on sd_uid = sa_uid and isnull(sa_custsmp,0)=" & dr("id") & " and isnull(sa_approved,'')='Y' " & ltempSQL & " and sa_custcode='" & Weblib.MerchantID & "' and sa_filter='" & Weblib.FilterCode & "'"

                ad2.SelectCommand = cmd
                ad2.Fill(ds2, "datarecords")
                counter2 = 0
                For Each dr2 In ds2.Tables("datarecords").Rows
                    counter2 = counter2 + 1
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If
                    lseries1 = lseries1 & dr2("Datas")
                    Exit For
                Next
                ds2.Clear()
                ad2.Dispose()

                If counter2 = 0 Then
                    If lseries1.Trim <> "" Then
                        lseries1 = lseries1 & ","
                    End If
                    lseries1 = lseries1 & "0"
                End If



            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            lseries1 = "Sales in Tonne(s)||" & lseries1
            ltempdata = lseries1

            graph1.Width = "100%"
            '            graph1.Height = "300"
            graph1.ChartType = "bar"
            graph1.ChartTitle = "Sales by Sales Person"
            graph1.ChartSubTitle = lSubTitle
            graph1.XAxisTitle = "Sales Person"
            graph1.YAxisTitle = "Value in tonne(s)"
            graph1.YAxisMinValue = "0"
            graph1.ToolTipValueSuffix = "tonne(s)"

            graph1.XAxisLabels = ltemplabel
            graph1.Data = ltempdata

            graph1.Initgraph()
        Catch ex As Exception
            lblmessage.text = Weblib.getAlertMessageStyle(ex.message)
        End Try

    End Sub

    Public Sub view1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        server.transfer("postpage.aspx?NextPage=main.aspx&ga=1")

        '       Call loadSales()
    End Sub
    Public Sub view2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        server.transfer("postpage.aspx?NextPage=main.aspx&ga=2")

        '        Call loadbySalesPerson()

    End Sub

    Public Sub viewbags(ByVal sender As System.Object, ByVal e As System.EventArgs)
        server.transfer("postpage.aspx?NextPage=main.aspx&ga=1&da=1")
        '       Call loadSales()
    End Sub
    Public Sub viewtonne(ByVal sender As System.Object, ByVal e As System.EventArgs)
        server.transfer("postpage.aspx?NextPage=main.aspx&ga=1&da=2")
'        server.transfer("postpage.aspx?NextPage=main.aspx&ga=1")

    End Sub

End Class
