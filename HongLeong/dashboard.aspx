
<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="dashboard.aspx.vb" Inherits="dashboard_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/Calculator.ascx" TagPrefix="uc" TagName="Calculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<script src="jquery/js/jquery.js"></script>    
<script src="jquery/js/jquery-ui.js"></script>    
<link rel="stylesheet" href="jquery/css/default/jquery.default.css">
<link rel="stylesheet" href="Styles/cssdefault.css">
<script src="plugins/validator/languages/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="plugins/validator/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<link rel="stylesheet" href="plugins/validator/css/validationEngine.jquery.css" type="text/css"/>

<script src="plugins/graphs/js/highcharts.js"></script>
<script src="plugins/graphs/js/modules/exporting.js"></script>

<script>
$(document).ready(function() {
$( "input[type=submit], button" )
.button();    
});
</script>
	<script type="text/javascript">
$(function () {
        $('#container').highcharts({
            chart: {
                type: 'bar'
            },
            title: {
                text: 'Sales Performance Target VS Actual'
            },
            subtitle: {
                text: '12 months rolling'
            },
            xAxis: {
                categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                title: {
                    text: null
                }
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'tonne(s)',
                    align: 'high'
                },
                labels: {
                    overflow: 'justify'
                }
            },
            tooltip: {
                valueSuffix: ' tonne(s)'
            },
            plotOptions: {
                bar: {
                    dataLabels: {
                        enabled: true
                    }
                }
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'top',
                x: -40,
                y: 100,
                floating: true,
                borderWidth: 1,
                backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor || '#FFFFFF'),
                shadow: true
            },
            credits: {
                enabled: false
            },
            series: [{
                name: 'Target (Tonnes)',
                data: [107, 331, 635, 203, 21,324,213,455,211,789,321,445]
            }, {
                name: 'Actual (Tonnes)',
                data: [973, 914, 4054, 732, 314, 321,467,764,234,678,88,332]
            }]
        });
    });
    

		</script>
</head>
<body>
<center>
<form id="frmform" runat="server">
<!--#include File="include/FormHeader1.aspx"-->
<table width="100%">
<tr><td width="100%">
<br />
<div id="container" style="min-width: 310px; max-width: 800px; height: 600px; margin: 0 auto"></div>

</td></tr>
</table>

<!--#include File="include/FormFooter1.aspx"-->

</form>
</center>
</body>
</html>

