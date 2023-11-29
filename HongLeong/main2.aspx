<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="main2.aspx.vb" Inherits="main2" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/Graph.ascx" TagPrefix="uc" TagName="Graph" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="topinitdetail.aspx"-->
    <script src="<%=ResolveClientUrl("~/plugins/highcharts/js/highcharts.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/plugins/highcharts/js/modules/exporting.js")%>"></script>

    <script>
        $(document).ready(function () {
            $("input[type=submit], button")
            .button();
            //$( "#tabs" ).tabs();       
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: true, showArrow: true, focusFirstField: false });
            var a = $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var b = $("#divdetails");  //.accordion({collapsible: false,heightStyle: "content",active: 0});
            a.show();
            b.show();
        });
    </script>
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-white" style="font-size: 1rem;">
            <div class="row listpage">
                <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                    MY DASHBOARD
                </div>
            </div>
            <div class="row listpage">
                <div class="col-md-12 bg-white">
                    <div class="row mb-1">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="dashboardview" runat="server" style="text-align:center;" AutoPostBack="true" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <div class="row mb-1" style="display:none;">
                        D/O Date From :-<br />
                        <uc:datepicker ID="tic_datefrom" width="70px" runat="server" cssClass="validate[required]" AllowNull="false" />
                        &nbsp;To&nbsp;
                    <uc:datepicker ID="tic_dateto" width="70px" runat="server" cssClass="validate[required]" AllowNull="false" /></div>
                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                    <br />
                    <div id="divdetails" style="text-align: left; display: none" class="cssdetail">
                        <div style="text-align: left">
                            <b>Note :-</b><br />
                            Data excluding stock return or other adjustment, please refer to our Sales representative for further clarification<br />
                            <br />
                            <asp:Panel runat="server" ID="pnldetail">
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlgraph">
                                <uc:Graph ID="graph1" width="100%" runat="server" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" runat="server" id="cmode" name="cmode" />
        <input type="hidden" runat="server" id="uid" name="uid" />
        <input type="hidden" runat="server" id="uidname" name="uidname" />
        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />
        <!--#include File="include/FormFooter1.aspx"-->
    </form>
    <!--#include File="include/footerscript.aspx"-->
</body>
</html>

