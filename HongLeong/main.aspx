<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="supportdash.aspx.vb" Inherits="supportdash_class" %>

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
                <%--  <table class="ui-widget-header" width="100%">
                        <tr>
                            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                            <td width="100%"><span class="ui-widget"><b>MY DASHBOARD</b></span></td>
                        </tr>
                        <tr><td colspan="2">
                    </td></tr>
                    </table>--%>
                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                <br />

            </div>
            <div class="row listpage">

                <div class="col-md-3 bg-white ">

                    <div class="cssdetail" style="display: none">
                        <table width="100%" cellpadding="0" cellspacing="1">
                            <tr>
                                <td align="left" width="100%">
                                    <table class="ui-widget-header">
                                        <tr>
                                            <td width="10px"><span class="ui-icon ui-icon-search"></span></td>
                                            <td width="100%"><span class="ui-widget"><b>Filters</b></span></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <br />
                        D/O Date From :-<br />
                        <uc:datepicker ID="tic_datefrom" width="70px" runat="server" cssClass="validate[required]" AllowNull="false" />
                        &nbsp;To&nbsp;
                    <uc:datepicker ID="tic_dateto" width="70px" runat="server" cssClass="validate[required]" AllowNull="false" />
                    </div>
                    <table width="100%" cellpadding="0" cellspacing="1">
                        <tr>
                            <td align="left" width="100%">
                                <table class="ui-widget-header">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-tag"></span></td>
                                        <td width="100%"><span class="ui-widget"><b>Dashboard Options</b></span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="cssdetail">
                        <table width="100%">
                            <tr>
                                <td width="32" valign="top">
                                    <img runat="server" src="~/graphics/graphs/table.png" width="32" /></td>
                                <td>
                                    <asp:LinkButton ID="lnktable" runat="server" OnClick="view1">12 Months Rolling Sales by TONNE</asp:LinkButton><br />
                                    Information is based on orders delivered measured in TONNE (Total Bags + Bulk)</td>
                            </tr>
                            <tr>
                                <td width="32" valign="top">
                                    <img id="Img1" runat="server" src="~/graphics/graphs/table.png" width="32" /></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="viewbags">12 Months Rolling Sales by BAGS</asp:LinkButton><br />
                                    Information is based on orders delivered measured in Bags (Total Bags Only)</td>
                            </tr>
                            <tr>
                                <td width="32" valign="top">
                                    <img id="Img2" runat="server" src="~/graphics/graphs/table.png" width="32" /></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="viewtonne">12 Months Rolling Sales by BULK</asp:LinkButton><br />
                                    Information is based on orders delivered measured in TONNE (Total Bulk Only)</td>
                            </tr>
                            <tr>
                                <td width="32" valign="top">
                                    <img runat="server" src="~/graphics/graphs/bar.png" width="32" /></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="view2">Sales by Sales Person</asp:LinkButton><br />
                                    Information is available only if sales person is selected during the order placement<br />
                                    <font color="red">Note:<br />
                                        To use this graph, customer is required to <b>maintain Sales Person Code at Menu Sales Admin-> Sales Person</b>, and <b>tag the sales person to the web order placement</b></font></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="col-md-9 bg-white">

                    <div id="divdetails" style="text-align: left; display: none" class="cssdetail">

                        <div style="text-align: left">
                            <b>Note :-</b><br />
                            Data excluding diversion, stock return or other adjustment, please refer to our Sales representative for further clarification<br />
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

