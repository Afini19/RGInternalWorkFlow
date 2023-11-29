<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="home.aspx.vb" Inherits="home_class" %>

<%--<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/Graph.ascx" TagPrefix="uc" TagName="Graph" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="topinitdetail.aspx"-->

    <script>
        $(document).ready(function () {
            $("input[type=submit], button")
            .button();
            $("#tabs").tabs();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: true, showArrow: true, focusFirstField: false });
            var a = $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var b = $("#divdetails").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            a.show();
            b.show();
        });

    </script>

    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>

    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-white" style="font-size: 1rem; min-height: 100vh">
            <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                MESSAGE CENTER
            </div>
            <div class="row">


                <div class="col-md-6 bg-white ">
                    <div class="row">
                        <div class="col-md-12">
                            <table width="100%">
                                <tr>
                                    <td width="64" valign="top">
                                        <asp:Literal runat="server" ID="litbulb"></asp:Literal></td>
                                    <td valign="top">
                                        <table class="ui-widget-header" width="100%">
                                            <tr>
                                                <td width="10px"><span class="ui-icon ui-icon-search"></span></td>
                                                <td width="100%"><span class="ui-widget"><b>Credit Limit Alert</b></span></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:Literal runat="server" ID="litcredit"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
                <div class="col-md-6 bg-white">
                    <div class="row">
                        <div class="col-md-12">
                            <table width="100%">
                                <tr>
                                    <td width="64" valign="top">
                                        <img src="graphics/misc/email64.png" /></td>
                                    <td valign="top">
                                        <table class="ui-widget-header" width="100%">
                                            <tr>
                                                <td width="10px"><span class="ui-icon ui-icon-search"></span></td>
                                                <td width="100%"><span class="ui-widget"><b>Messages</b></span></td>
                                            </tr>
                                        </table>
                                        <br />
                                        You got no new messages
                        
                                    </td>
                                </tr>
                            </table>

                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <table width="100%">
                                        <tr>
                                            <td width="64" valign="top">
                                                <img src="graphics/misc/messages64.png" /></td>
                                            <td valign="top">
                                                <table class="ui-widget-header" width="100%">
                                                    <tr>
                                                        <td width="10px"><span class="ui-icon ui-icon-search"></span></td>
                                                        <td width="100%"><span class="ui-widget"><b>Announcement</b></span></td>
                                                    </tr>
                                                </table>
                                                <br />

                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:Label ID="lblmessage" runat="server"></asp:Label>
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

