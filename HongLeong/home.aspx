<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="home.aspx.vb" Inherits="home_class" %>

<%--<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/Graph.ascx" TagPrefix="uc" TagName="Graph" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <!--#include File="topinitdetail.aspx"-->

    <script type="">
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
                DASHBOARD
            </div>

            <div class="row">

               <% 
                   Dim oo As New WebStats
               %>

                <div class="col-sm-2">
                    <div style="width: 100%; padding: 10px 10px 10px 10px; border-radius: 10px; border: solid 1px silver; color: #FFFFFF; background-color: #868686;">
                        <b>Change Request</b>
                    </div>
                    <br />
                    <div style="background-color: #D8D8D8; padding: 10px; border-radius: 10px; border: solid 1px #01579b;">
                        <b>Pending Customer CR</b><br />
                        <%= oo.GetPendingCRCStats() %> Records<br />
                        <a href="../modules/custom/crC_list.aspx" style="color: #01579b;">View Records</a>
                    </div>
                    <br />
                    <div style="background-color: #D8D8D8; padding: 10px; border-radius: 10px; border: solid 1px #01579b;">
                        <b>Pending Internal CR</b><br />
                        <%= oo.GetPendingCRIStats() %> Records<br />
                        <a href="../modules/custom/crI_list.aspx" style="color: #01579b;">View Records</a>
                    </div>
                    <br />
                    <div style="background-color: #D8D8D8; padding: 10px; border-radius: 10px; border: solid 1px #01579b;">
                        <b>Pending Support CR</b><br />
                        <%= oo.GetPendingCRSStats() %> Records<br />
                        <a href="../modules/custom/crS_list.aspx" style="color: #01579b;">View Records</a>
                    </div>
                </div>



                <div class="col-sm-2">
                    <div style="width: 100%; padding: 10px 10px 10px 10px; border-radius: 10px; border: solid 1px silver; color: #FFFFFF; background-color: #868686;">
                        <b>Support Ticket</b>
                    </div>
                    <br />
                    <div style="background-color: #D8D8D8; padding: 10px; border-radius: 10px; border: solid 1px #01579b;">
                        <b>Pending Internal Issue</b><br />
                        <%= oo.GetPendingSTIStats() %> Records<br />
                        <a href="../modules/custom/stI_list.aspx" style="color: #01579b;">View Records</a>
                    </div>
                    <br />
                    <div style="background-color: #D8D8D8; padding: 10px; border-radius: 10px; border: solid 1px #01579b;">
                        <b>Pending Support Issue</b><br />
                        <%= oo.GetPendingSTSStats() %> Records<br />
                        <a href="../modules/custom/stS_list.aspx" style="color: #01579b;">View Records</a>
                    </div>
                    <br />
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

