Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Class UserControls_GraphNP
    Inherits System.Web.UI.UserControl
    Protected _Width As String = "300px"
    Protected _Height As String = "600px"
    Protected _ChartTitle As String = ""
    Protected _ChartSubTitle As String = ""
    Protected _ToolTipValueSuffix As String = ""
    Protected _XAxisTitle As String = ""
    Protected _YAxisTitle As String = ""
    Protected _YAxisTitle1 As String = ""
    Protected _YAxisTitle2 As String = ""
    Protected _ChartType As String = ""
    Protected _YAxisMinValue As String = "0"
    Protected _YAxisMinValue1 As String = "0"
    Protected _YAxisMinValue2 As String = "0"
    Protected _XAxisLabels As String = ""
    Protected _PiePErcent As Boolean = True
    Protected _Data As String = ""
    Protected _ddData As String = ""
    Protected _YAxisData As String = ""

    Public litcode1, graphcontainer1 As Object

#Region "Property"

    Public Property Width() As String
        Get
            Return _Width
        End Get
        Set(ByVal value As String)
            _Width = value
        End Set
    End Property

    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
        End Set
    End Property

    Public Property ChartType() As String
        Get
            Return _ChartType
        End Get
        Set(ByVal value As String)
            _ChartType = value
        End Set
    End Property

    Public Property YAxisData() As String
        Get
            Return _YAxisData
        End Get
        Set(ByVal value As String)
            _YAxisData = value
        End Set
    End Property

    Public Property Data() As String
        Get
            Return _Data
        End Get
        Set(ByVal value As String)
            _Data = value
        End Set
    End Property

    Public Property DrillDownData() As String
        Get
            Return _ddData
        End Get
        Set(ByVal value As String)
            _ddData = value
        End Set
    End Property

    Public Property PieinPercentage() As Boolean
        Get
            Return _PiePErcent
        End Get
        Set(ByVal value As Boolean)
            _PiePErcent = value
        End Set
    End Property

    Public Property ChartTitle() As String
        Get
            'Return "title: {text:'" & _ChartTitle & "'}"
            Return "title: {text:'" & _ChartTitle & "', style: {fontWeight: 'bold'}}"
        End Get
        Set(ByVal value As String)
            _ChartTitle = value
        End Set
    End Property

    Public Property ChartSubTitle() As String
        Get
            Return "subtitle: {text: '" & _ChartSubTitle & "'}"
        End Get
        Set(ByVal value As String)
            _ChartSubTitle = value
        End Set
    End Property

    Public Property XAxisTitle() As String
        Get
            Return _XAxisTitle
        End Get
        Set(ByVal value As String)
            _XAxisTitle = value
        End Set
    End Property

    Public Property XAxisLabels() As String
        Get
            Return _XAxisLabels
        End Get
        Set(ByVal value As String)
            _XAxisLabels = value
        End Set
    End Property

    Public Property YAxisTitle() As String
        Get
            Return _YAxisTitle
        End Get
        Set(ByVal value As String)
            _YAxisTitle = value
        End Set
    End Property

    Public Property YAxisTitle1() As String
        Get
            Return _YAxisTitle1
        End Get
        Set(ByVal value As String)
            _YAxisTitle1 = value
        End Set
    End Property

    Public Property YAxisTitle2() As String
        Get
            Return _YAxisTitle2
        End Get
        Set(ByVal value As String)
            _YAxisTitle2 = value
        End Set
    End Property

    Public Property YAxisMinValue() As String
        Get
            If IsNumeric(_YAxisMinValue) = False Then
                _YAxisMinValue = "0"
            End If
            Return _YAxisMinValue
        End Get
        Set(ByVal value As String)
            _YAxisMinValue = value
        End Set
    End Property

    Public Property YAxisMinValue1() As String
        Get
            If IsNumeric(_YAxisMinValue1) = False Then
                _YAxisMinValue1 = "0"
            End If
            Return _YAxisMinValue1
        End Get
        Set(ByVal value As String)
            _YAxisMinValue1 = value
        End Set
    End Property

    Public Property YAxisMinValue2() As String
        Get
            If IsNumeric(_YAxisMinValue2) = False Then
                _YAxisMinValue2 = "0"
            End If
            Return _YAxisMinValue2
        End Get
        Set(ByVal value As String)
            _YAxisMinValue2 = value
        End Set
    End Property

    Public Property ToolTipValueSuffix() As String
        Get
            Return _ToolTipValueSuffix
        End Get
        Set(ByVal value As String)
            _ToolTipValueSuffix = value
        End Set
    End Property

#End Region

    Private Function Chart() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                ltemp = "chart: {type: 'bar'}"
            Case "pie"
                ltemp = "chart: {plotBackgroundColor: null,plotBorderWidth: null,plotShadow: false, type: 'pie'}"
            Case "line"
                ltemp = "chart: {type: 'line'}"
            Case "spline" 'combination of column & line
                ltemp = "chart: {type: 'spline'}"
            Case "column"
                ltemp = "chart: {type: 'column'}"
            Case "column2"
                ltemp = "chart: {type: 'column'}"
            Case "pie2"
                ltemp = "chart: {type: 'pie'}"
        End Select

        Return ltemp

    End Function

    Private Function ToolTip() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                ltemp = "valueSuffix: '" & ToolTipValueSuffix & "'"
            Case "pie"
                If PieinPercentage = True Then
                    ltemp = "pointFormat: ' <b>{point.percentage:.1f}%</b>'"
                End If
            Case "line"
                ltemp = "valueSuffix: '" & ToolTipValueSuffix & "'"
            Case "spline"
                ltemp = "valueSuffix: '" & ToolTipValueSuffix & "'"
            Case "column" 'Area NPS/ Graph 5
                'ltemp = "formatter: function () { " &
                '         "   return '<b>' + this.x + '</b><br/>' + this.series.name + ': ' + this.y + '<br/>' + " &
                '         "       'Total: ' + this.point.stackTotal; " &
                '        "}"
                '20200928
                'ltemp = "formatter: function () { " &
                '         "   return 'Response in <b>' + this.series.name + '</b><br/>Total : ' + this.point.totalnum + ' <br/>Total % : ' + this.y + '<br/>'; " &
                '        "}"
                '20200929
                ltemp = "formatter: function() { " &
                        "   if (this.series.chart.drilldownLevels !== UNDF && this.series.chart.drilldownLevels.length > 0) {" &
                        "       return 'Response in <b>' + this.series.name + '</b><br/>Total : ' + this.y + ' <br/>'; " &
                        "   } else {" &
                        "       return 'Response in <b>' + this.series.name + '</b><br/>Total : ' + this.y + ' <br/>Total % : ' + this.point.totalptg + '<br/>'; " &
                        "   }" &
                        "}"
            Case "column2"
                'ltemp = "formatter: function() { " &
                '        "   var stackName = this.series.userOptions.stack; " &
                '        "   return '<b>' + stackName + ' ( ' + this.x + ' )</b><br/>' + " &
                '        "    this.series.name + ': ' + this.y + '<br/>' + " &
                '        "    'Total: ' + this.point.stackTotal; " &
                '        "}"
                '20200928
                'ltemp = "formatter: function() { " &
                '        "   var stackName = this.series.userOptions.stack; " &
                '        "   return '<b>' + stackName + ' ( ' + this.x + ' )</b><br/>' + " &
                '        "    'Response in ' + this.series.name + '<br/> Total : ' + this.point.totalnum + ' <br/>Total % : ' + this.y + '<br/>'; " &
                '        "}"
                '20200929
                ltemp = "formatter: function() { " &
                        "   var stackName = this.series.userOptions.stack; " &
                        "   return '<b>' + stackName + ' ( ' + this.x + ' )</b><br/>' + " &
                        "    'Response in ' + this.series.name + '<br/> Total : ' + this.y + ' <br/>Total % : ' + this.point.totalptg + '<br/>'; " &
                        "}"
            Case "pie2"
                ltemp = "headerFormat: '<span style='font-size:11px'>{series.name}</span><br>', pointFormat: '<span style='color:{point.color}'>{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'"
        End Select

        Return "tooltip: {" & ltemp & "}"

    End Function

    Private Function XAxis() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                'ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "'}"
                ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "', style: {fontWeight: 'bold'}}"
            Case "pie"

            Case "line"
                'ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "'}"
                ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "', style: {fontWeight: 'bold'}}"
            Case "spline"
                ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "', style: {fontWeight: 'bold'}}"
            Case "column"
                'ltemp = "type: 'category'"
                '20200928
                ltemp = "type: 'category',title: {text: '" & XAxisTitle & "', style: {fontWeight: 'bold'}}"
            Case "column2"
                'ltemp = "categories: [" & XAxisLabels & "]"
                '20200928
                ltemp = "categories: [" & XAxisLabels & "],title: {text: '" & XAxisTitle & "', style: {fontWeight: 'bold'}}"
        End Select

        Return "xAxis: {" & ltemp & " }"

    End Function

    Private Function YAxis() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                'ltemp = " min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "',align: 'high'},labels: {overflow:  'justify'}"
                ltemp = "{ min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "', style: {fontWeight: 'bold'}},labels: {overflow:  'justify'} }"
            Case "pie"

            Case "line"
                'ltemp = " min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "',align: 'high'},labels: {overflow:  'justify'}"
                ltemp = "{ min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "', style: {fontWeight: 'bold'}},labels: {overflow:  'justify'} }"
            Case "spline"
                ltemp = "[" &
                        "  {title: {text: '" & YAxisTitle & "', style: {fontWeight: 'bold'}}, labels: {overflow:  'justify'} }, " &
                        "  {min: " & YAxisMinValue1 & ", opposite:true, title: {text: '" & YAxisTitle1 & "', style: {fontWeight: 'bold'}}, labels: {overflow:  'justify'} }, " &
                        "  {min: " & YAxisMinValue2 & ", opposite:true, title: {text: '" & YAxisTitle2 & "', style: {fontWeight: 'bold'}}, labels: {overflow:  'justify'} } " &
                        "]"
            Case "column"
                ltemp = "{allowDecimals: false,min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "'}}"
            Case "column2"
                ltemp = "{allowDecimals: false,min: " & YAxisMinValue & ",title: {text: '" & YAxisTitle & "'}}"
        End Select

        Return "yAxis: " & ltemp & ""

    End Function

    Private Function Colors() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "spline"
                If _ChartTitle.Contains("Sales Incentive") Then
                    ltemp = "'#FB39CE'"          ' purple   'column
                    ltemp = ltemp & ",'#7cb5ec'" ' blue     'line
                ElseIf _ChartTitle.Contains("Rolling 12 Months Tiles") Then
                    ltemp = "'#7cb5ec'" ' blue                  'column
                    ltemp = ltemp & ",'#00008B'" ' DarkBlue     'column
                    ltemp = ltemp & ",'#87CEEB'" ' SkyBlue      'column
                    ltemp = ltemp & ",'#f45b5b'" ' red          'line
                ElseIf _ChartTitle.Contains("NPS Monthly Rating") Then
                    ltemp = "'#90EE90'"          ' purple   'column
                    ltemp = ltemp & ",'#00008B','#FB39CE'" ' DarkBlue, purple    'line
                ElseIf _ChartTitle.Contains("Monthly Responsiveness") Then
                    ltemp = "'#90ed7d'"          ' purple   'column
                    ltemp = ltemp & ",'#00008B','#FB39CE'" ' DarkBlue, purple    'line
                End If
            Case "column"
                ltemp = "'#90EE90'"
                ltemp = ltemp & ",'#FFFF66','#F08080'"
                
            Case "line"
                
                ltemp = ltemp & "'#90ed7d'" ' green
                ltemp = ltemp & ",'#e4d354'" ' yellow
                ltemp = ltemp & ",'#f45b5b'" ' red

            Case Else 'bar, pie, line
                ltemp = "'#FB39CE'"          ' purple
                ltemp = ltemp & ",'#90ed7d'" ' green
                ltemp = ltemp & ",'#f7a35c'" ' orange
                ltemp = ltemp & ",'#7cb5ec'" ' blue
                ltemp = ltemp & ",'#434348'" ' black
                ltemp = ltemp & ",'#e4d354'" ' yellow
                ltemp = ltemp & ",'#f45b5b'" ' red
        End Select

        Return "colors: [" & ltemp & "]"

    End Function

    Private Function Zone() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "spline"
                If _ChartTitle.Contains("Monthly") Then
                    ltemp = "{value:6.9, color: '#FF0000'},{value: 7.9, color:'#FFFF00'},{value:10.00, color:'#008000'}"
                End If
        End Select

        Return "plotOptions:{series:{zoneAxis: 'x', zones: [" & ltemp & "]}}"

    End Function

    Private Function Series() As String
        Dim ltemp As String = ""
        Dim tempo
        Dim bSingleSeries As Boolean = False
        Dim axisno As Integer = 0


        If ChartType.ToLower = "pie" Then
            bSingleSeries = True
        ElseIf ChartType.ToLower = "column" Then
            GoTo SkipAll
        ElseIf ChartType.ToLower = "pie2" Then
            GoTo SkipAll
        End If

        If _Data.Trim = "" Then
            Return "'"
            Exit Function
        End If

        tempo = Microsoft.VisualBasic.Split(_Data, ";;")

        For counter = 0 To Microsoft.VisualBasic.UBound(tempo)
            Dim ltempa
            ltempa = Microsoft.VisualBasic.Split(tempo(counter), "||")

            If Microsoft.VisualBasic.UBound(ltempa) < 0 Then
                GoTo NextITem
            End If

            If ltemp.Trim <> "" Then
                ltemp = ltemp & ","
            End If

            Select Case _ChartType.ToLower
                Case "bar", "line"
                    ltemp = ltemp & "{name: '" & ltempa(0) & "',data: [" & ltempa(1) & "]}"
                Case "column2"
                    ltemp = ltemp & "{name: '" & ltempa(0) & "',data: [" & ltempa(1) & "], stack: '" & ltempa(2) & "', color: '" & ltempa(3) & "'}"
                Case "pie"
                    ltemp = ltemp & "{type: 'pie',name: '" & ltempa(0) & "',data: [" & ltempa(1) & "]}"
                Case "spline"
                    ltemp = ltemp & "{type: 'column' , name: '" & ltempa(0) & "',data: [" & ltempa(1) & "], dataLabels: {enabled: true,align: 'center'}}"
                Case Else
                    ltemp = ltemp & ""
            End Select

            axisno += 1

NextITem:

            If bSingleSeries = True And ltemp.Trim <> "" Then
                Exit For
            End If

        Next


        Dim tempoY

        If _YAxisData.Trim = "" Then
            Return "series: [" & ltemp & "]"
            Exit Function
        End If

        tempoY = Microsoft.VisualBasic.Split(_YAxisData, ";;")


        For counter = 0 To Microsoft.VisualBasic.UBound(tempoY)
            Dim ltempb
            ltempb = Microsoft.VisualBasic.Split(tempoY(counter), "||")

            If Microsoft.VisualBasic.UBound(ltempb) < 0 Then
                GoTo NextITemY
            End If

            If ltemp.Trim <> "" Then
                ltemp = ltemp & ","
            End If

            Select Case _ChartType.ToLower
                Case "bar", "line"
                    ltemp = ltemp & "{name: '" & ltempb(0) & "',data: [" & ltempb(1) & "]}"
                Case "column2"
                    ltemp = ltemp & "{name: '" & ltempb(0) & "',data: [" & ltempb(1) & "], stack: '" & ltempb(0) & "'}"
                Case "pie"
                    ltemp = ltemp & "{type: 'pie',name: '" & ltempb(0) & "',data: [" & ltempb(1) & "]}"
                Case "spline"
                    ltemp = ltemp & "{type: 'spline', yAxis:" & axisno & " , name: '" & ltempb(0) & "',data: [" & ltempb(1) & "],"

                    If ltempb(0) = "Responsiveness(%)" Then
                        ltemp = ltemp & "dataLabels: {enabled: true,align: 'center'}"
                    Else
                        ltemp = ltemp & "dataLabels: {enabled: true,align: 'center', y: 28}"
                    End If

                    ltemp = ltemp & "}"
                Case Else
                    ltemp = ltemp & ""
            End Select

            axisno += 1

NextITemY:

            If bSingleSeries = True And ltemp.Trim <> "" Then
                Exit For
            End If

        Next

SkipAll:
        If ChartType.ToLower = "column" Then
            ltemp = Data
        End If
        If ChartType.ToLower = "pie2" Then
            ltemp = Data
        End If

        Return "series: [" & ltemp & "]"
        '        Return "series: [{name:'Target (Tonnes)',data: [107, 331, 635, 203, 21,324,213,455,211,789,321,445]}, {name:   'Actual (Tonnes)',data: [973, 914, 4054, 732, 314, 321,467,764,234,678,88,332]}]"
    End Function

    Private Function Legend() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                ltemp = "layout: 'vertical',align: 'right',verticalAlign: 'top',x: 0,y: 22,floating: true,borderWidth: 1,backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor || '#FFFFFF'),shadow: true"
            Case "pie"

            Case "line"
                ltemp = "layout: 'vertical',align: 'right',verticalAlign: 'top',x: 0,y: 22,floating: true,borderWidth: 1,backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor || '#FFFFFF'),shadow: true"
            Case "spline"
                ltemp = "layout: 'vertical',align: 'center',verticalAlign: 'bottom',borderWidth: 1,backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor || '#FFFFFF'),shadow: true"
            Case "column2"
                ltemp = " labelFormatter: function() { return this.name + ' (' + this.userOptions.stack + ')'; }"
        End Select

        Return " legend: {" & ltemp & "}"

    End Function

    Private Function PlotOptions() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "bar"
                ltemp = " bar: { dataLabels: {enabled: true} "
            Case "pie"
                ltemp = " pie: {allowPointSelect: true,cursor:'pointer',dataLabels: {enabled: true"
                If PieinPercentage = True Then
                    ltemp = ltemp & ""
                Else
                    '  ltemp = ltemp & " ,format: '<b>{point.name}</b>: {point.percentage:.1f} %'"
                End If
                ltemp = ltemp & ", showInLegend: true,style: {color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'}}"
            Case "line"
                ltemp = " line: { dataLabels: {enabled: true} "
            Case "spline"
                ltemp = " series: {dataLabels: {enabled: true, style:{fontSize: 10}, allowOverlap: false, crop: false, overflow: 'none'}  " ' ', AllowOutSidePlotArea: true
            Case "column"
                'ltemp = "column: {stacking: 'percent'}"
                '20200929
                ltemp = "column: {stacking: 'normal'}"
            Case "column2"
                ltemp = "column: {stacking: 'normal'}"
            Case "pie2"
                ltemp = "series: {dataLabels: {enabled: true,format: '{point.name}: {point.y:.1f}%'}}"
        End Select

        If _ChartTitle.Contains("NPS Monthly Rating") And ChartType.ToLower = "spline" Then
            ltemp = ltemp & ", zones:[{value:6.99, className: 'zone-0'}, {value: 7.99, className: 'zone-1'}, {value:10.00, className: 'zone-2'}]"
        End If

        If _ChartType.ToLower = "column" Or _ChartType.ToLower = "column2" Then

            Return "plotOptions: {" & ltemp & "}"
        Else
            Return "plotOptions: {" & ltemp & "}}"

        End If

    End Function

    Private Function Drilldown() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "column"
                ltemp = "activeDataLabelStyle: {color: 'white', textShadow: '0 0 2px black, 0 0 2px black'}, series: [" & _ddData & "]"
            Case "pie2"
                ltemp = "series: [" & _ddData & "]"
        End Select

        Return "drilldown: {" & ltemp & "}"

    End Function

    Private Function Access() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "pie2"
                ltemp = "announceNewData: {enabled: true},point: {valueSuffix: '%'}"

        End Select

        Return "accessibility: {" & ltemp & "}"
    End Function

    Private Function exporting() As String
        Dim ltemp As String = ""

        Select Case _ChartType.ToLower
            Case "column2"
                ltemp = ltemp & "    csv: {"
                ltemp = ltemp & "        columnHeaderFormatter: function(item, key) {"
                ltemp = ltemp & "            if (!item || item instanceof Highcharts.Axis) {"
                ltemp = ltemp & "                return 'Month' "
                ltemp = ltemp & "            } else {"
                ltemp = ltemp & "                return item.name +' ('+ item.userOptions.stack  + ')';"
                ltemp = ltemp & "            }"
                ltemp = ltemp & "        }"
                ltemp = ltemp & "    }"

        End Select

        Return "exporting: {" & ltemp & "}"

    End Function

    Private Function GenerateGraph() As String
        Dim ltemp As String = ""
        ltemp = ltemp & "$(function () {" & Environment.NewLine
        ltemp = ltemp & "var UNDF;" & Environment.NewLine
        ltemp = ltemp & " $('#" & graphcontainer.ClientID & "').highcharts({" & Environment.NewLine

        Select Case _ChartType.ToLower
            Case "bar"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & ToolTip() & "," & PlotOptions() & "," & Legend() & "," & Series() & "," & Colors()
            Case "pie"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & ToolTip() & "," & PlotOptions() & "," & Legend() & "," & Series() & "," & Colors()
            Case "line"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & ToolTip() & "," & PlotOptions() & "," & Legend() & "," & Series() & "," & Colors()
            Case "spline"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & ToolTip() & "," & PlotOptions() & "," & Legend() & "," & Series() & "," & Colors()
            Case "column"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & ToolTip() & "," & PlotOptions() & "," & Series() & "," & Drilldown() & "," & Colors()
            Case "column2"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & Legend() & "," & ToolTip() & "," & PlotOptions() & "," & Series() & "," & exporting()
            Case "pie2"
                ltemp = ltemp & Chart() & "," & ChartTitle & "," & ChartSubTitle & "," & XAxis() & "," & YAxis() & "," & Access() & "," & PlotOptions() & "," & ToolTip() & "," & Series() & "," & Drilldown()
            Case Else
                Return ""
                Exit Function
        End Select

        ltemp = ltemp & "});});"
        Return ltemp

    End Function

    Public Sub ResetGraph()
        litcode.Text = ""
        graphcontainer.InnerHtml = ""
        graphcontainer.InnerText = ""
    End Sub

    Public Sub InitGraph()
        litcode.Text = "<script>" & GenerateGraph() & "</script>"
    End Sub


End Class
