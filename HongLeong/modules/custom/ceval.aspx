<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="ceval.aspx.vb" Inherits="ceval_class" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="~/UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar2.ascx" TagPrefix="uc" TagName="Workflowbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->
    <script src="<%=ResolveClientUrl("~/plugins/blocker/jquery.blockUI.js")%>" type="text/javascript" charset="utf-8"></script>
    <style type="text/css">
        input[type=submit] {
            margin: 0.1rem;
            background-color: #17a2b8;
            border-color: #17a2b8;
            color: #fff;
            padding: .25rem .5rem;
            font-size: .875rem;
            line-height: 1.5;
            border-radius: .2rem;
            width: 100%;
            display: inline-block;
            font-weight: 400;
            text-align: center;
            vertical-align: middle;
            user-select: none;
            border: 1px solid transparent;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }

            input[type=submit]:disabled {
                margin: 0.1rem;
                cursor: not-allowed;
                opacity: .65;
                box-shadow: none;
                background-color: #5bc0de;
                border-color: #5bc0de;
                color: #fff;
                padding: .25rem .5rem;
                font-size: .875rem;
                line-height: 1.5;
                border-radius: .2rem;
                width: 100%;
                display: inline-block;
                font-weight: 400;
                text-align: center;
                vertical-align: middle;
                user-select: none;
                border: 1px solid transparent;
                transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            }
    </style>
    <script>
        $(function () {
            $("input[type=submit],input[type=button], button")
                .button();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: false, showArrow: true, focusFirstField: false });
        });
    </script>
    <script type="text/javascript">
        function OpenColorBox() {
            $.colorbox({
                opacity: 0.1,
                width: '350px',
                height: '350px',
                iframe: true,
                href: 'www.yahoo.com',
                onLoad: function () {

                    $('#cboxClose').remove();
                },
                onClosed: function () {

                }
            });
        }
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <div class="container-fluid">
            <!--#include File="../../include/FormHeader1.aspx"-->


            <div class=" container bg-light" style="font-size: 1rem;">
                <div class="row listpage">
                    <div class="col-md-8 bg-light " style="font-size: 0.8rem;">
                        <div runat="server" id="mp">

                            <div class="row">
                                <table class="ui-widget-header" width="100%">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                        <td width="100%"><span class="ui-widget"><b><%=_FormsName%></b></span></td>
                                    </tr>
                                </table>
                            </div>

                            <div class="row w-100">
                                <div class="col-md-3"></div>
                                <div class="col-md-6" style="text-align: center;">
                                    <%=_FormsName%>
                                </div>

                                <div class="col-md-3" style="text-align: right;">FORM G (iv) - CE</div>
                            </div>
                            <div class="row w-100">
                                <div class="col-md-12" style="text-align: right;">Ref No :&nbsp;<asp:Label ID="lblrefno" runat="server"></asp:Label></div>
                            </div>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>


                            <div class="row">
                                <div class="col-md-3">&nbsp;<font class="cssrequired"></font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:RadioButtonList runat="server" ID="cus_custype" RepeatDirection="Horizontal" ValidationGroup="1-"></asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">&nbsp;<font class="cssrequired"></font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:RadioButtonList runat="server" ID="cus_cusgroup" RepeatDirection="Horizontal" ValidationGroup="1-"></asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-3">APPLICANT COMPANY&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_company" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <div class="row">
                                        <div class="col-md-12">CREDIT REQUIRED&nbsp;<font class="cssrequired">*</font></div>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-5" style="white-space: nowrap;">Trading Limit (RM)</div>
                                                <div class="col-md-7">
                                                    <div class="validation-content" style="position: relative;">
                                                        <asp:TextBox ID="cus_tradinglimit" runat="server" Style="width: 100%" MaxLength="50" class="validate[required,custom[number]]" ValidationGroup="1-"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-5" style="white-space: nowrap;">Credit Period</div>
                                                <div class="col-md-7">
                                                    <div class="validation-content" style="position: relative;">
                                                        <asp:TextBox ID="cus_tradingcperiod" runat="server" Style="width: 70%" MaxLength="50" class="validate[required,custom[integer]]" ValidationGroup="1-"></asp:TextBox>&nbsp;days
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <div class="row">
                                        <div class="col-md-12"></div>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-5" style="white-space: nowrap;">Project Limit (RM)</div>
                                                <div class="col-md-7">
                                                    <div class="validation-content" style="position: relative;">
                                                        <asp:TextBox ID="cus_projectlimit" runat="server" Style="width: 100%" MaxLength="50" class="validate[required,custom[number]]" ValidationGroup="1-"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-5" style="white-space: nowrap;">Credit Period</div>
                                                <div class="col-md-7">
                                                    <div class="validation-content" style="position: relative;">
                                                        <asp:TextBox ID="cus_projectcperiod" runat="server" Style="width: 70%" MaxLength="50" class="validate[required,custom[integer]]" ValidationGroup="1-"></asp:TextBox>&nbsp;days
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            
                            <% If createdt.Value >= Convert.ToDateTime(ConfigurationManager.AppSettings("CR2023005")) Then %>
                            <div class="row mb-1">
                                <div class="col-md-3">Account Holder&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_accountholder" runat="server" Style="width: 100%" ValidationGroup="1-" class="validate[required]"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <% End if %>


                            <% If backend.viewRights2(wfb_bar.wlevelAget(), 2, rid.value, NmSpace) OR wfb_bar.wlevelAPget().tostring.trim = "2" Then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>

                            <div class="row">
                                <div class="col-md-12"><b>SECURITY OFFERED</b></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_remarks1" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" class="validate[required]" MaxLength="500"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12"><b>PRODUCTS REQUIRED</b></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks2" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" class="validate[required]" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12"><b>PAST SALES PERFORMANCE & EXPECTED FUTURE SALES</b></div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks3" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" class="validate[required]" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>


                            <% End If %>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>


                            <div class="row">
                                <div class="col-md-3">
                                    <a href="#financialanalysis" data-toggle="collapse">FINANCIAL ANALYSIS</a>
                                </div>
                                <div class="col-md-9">
                                    <asp:Button ID="btnRefreshAnalysis" Text="Refresh Analysis Data" runat="server" OnClick="RefreshCreditDetails" Width="50%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                </div>
                                <br />
                                <div class="col-md-12">
                                    <div id="financialanalysis" style="overflow-x: auto;">

                                        <table width="100%" cellpadding="5" cellspacing="1" style="background-color: Gray">
                                            <tr>
                                                <td class="cssdetail" width="40%" align="left" style="background-color: white"></td>
                                                <td class="cssdetail" width="12%" align="center" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_1" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" width="12%" align="center" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_1" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" width="12%" align="center" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_1" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" width="12%" align="center" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_1" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" width="12%" align="center" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_1" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" width="40%" align="left" style="background-color: white">
                                                    <b><u>Summary Balance Sheet Items</u></b><br />
                                                    Total Current Assets
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_2" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_2" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_2" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_2" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_2" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Total Current Liabilities</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_3" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_3" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_3" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_3" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_3" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Net Working Capital / (Liabiities)</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_4" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_4" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_4" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_4" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_4" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Other Assets</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_5" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_5" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_5" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_5" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_5" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Paid Up Capital</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_6" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_6" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_6" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_6" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_6" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Net Worth</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_7" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_7" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_7" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_7" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_7" runat="server"></asp:Literal>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Long-Term Debts</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_8" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_8" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_8" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_8" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_8" runat="server"></asp:Literal>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Trade Creditors</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_9" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_9" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_9" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_9" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_9" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" width="40%" align="left" style="background-color: white">
                                                    <b><u>Summary P & L Items</u></b><br />
                                                    Sales / Turnover
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_10" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_10" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_10" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_10" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_10" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Profit Before Tax</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_11" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_11" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_11" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_11" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_11" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" width="40%" align="left" style="background-color: white">
                                                    <b><u>Key Financial Ratios</u></b><br />
                                                    Current Ratio
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_12" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_12" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_12" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_12" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_12" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Debt/Equity Ratio</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_13" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_13" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_13" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_13" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_13" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">Creditors Ageing</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_14" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_14" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_14" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_14" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_14" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" align="left" style="background-color: white">DSO</td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl1_15" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl2_15" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl3_15" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl4_15" runat="server"></asp:Literal>
                                                </td>
                                                <td class="cssdetail" align="right" style="background-color: white">
                                                    <asp:Literal ID="cus_tbl5_15" runat="server"></asp:Literal>
                                                </td>
                                            </tr>

                                        </table>

                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    <font color="blue"><b>
                                        <asp:Literal runat="server" ID="littimestamp"></asp:Literal></b></font>
                                </div>
                            </div>



                            <%--                            <%If backend.viewRights(wfb_bar.wlevelAget(), 5) Then %>--%>
                            <%If backend.viewRights2(wfb_bar.wlevelAget(), 3, rid.value, NmSpace) or wfb_bar.wlevelAPget().tostring.trim = "3" Then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>

                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <b>COMMENTS</b><asp:PlaceHolder ID="phlevel5" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks4" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <b>TRADE REFERENCE</b>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks5" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <a href="#gcbr" data-toggle="collapse">GROUP CREDIT BUREAU REFERENCE</a>

                                    <div id="gcbr" style="overflow-x: auto;">
                                        <table width="100%">
                                            <tr>
                                                <td width="60%" class="cssdetail" rowspan="2">
                                                    <u>Group Exposure</u><br />
                                                    <asp:RadioButtonList runat="server" ID="cus_groupexposure" RepeatDirection="Horizontal"></asp:RadioButtonList><br />


                                                    <table width="100%" cellpadding="2" cellspacing="1" style="background-color: Gray">
                                                        <tr>
                                                            <td class="cssdetail" width="20%" align="left" style="color: white">Company</td>
                                                            <td class="cssdetail" width="30%" align="center" style="color: white">Trading Limit<br />
                                                                (RM)</td>
                                                            <td class="cssdetail" width="30%" align="center" style="color: white">Project Limit<br />
                                                                (RM)</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">Expiry</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex10" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex11" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex12" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex13" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex20" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex21" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex22" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex23" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex30" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex31" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex32" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex33" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex40" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex41" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex42" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex43" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex50" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex51" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex52" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex53" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex60" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex61" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex62" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex63" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>



                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex70" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex71" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex72" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex73" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <asp:TextBox ID="cus_groupex80" runat="server" Style="width: 95%; text-align: left" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex81" runat="server" Style="width: 85%; text-align: right" MaxLength="20" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_groupex82" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="center">
                                                                <uc:datepicker ID="cus_groupex83" runat="server" AllowNull="false" Width="95%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: silver" align="left">TOTAL</td>
                                                            <td class="cssdetail" style="background-color: silver" align="right">
                                                                <asp:Literal ID="cus_groupextotal1" runat="server"></asp:Literal>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: silver" align="right">
                                                                <asp:Literal ID="cus_groupextotal2" runat="server"></asp:Literal>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: silver" align="right"></td>
                                                        </tr>


                                                    </table>



                                                    <asp:TextBox ID="cus_remarks6" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500"></asp:TextBox>
                                                </td>
                                                <td width="40%">
                                                    <u>Legal/winding-up action against company/firm</u><br />
                                                    <asp:RadioButtonList runat="server" ID="legalwind" RepeatDirection="Horizontal" ValidationGroup="5-"></asp:RadioButtonList><br />
                                                    <asp:TextBox ID="cus_remarks7" runat="server" TextMode="MultiLine" Style="width: 100%; height: 140px" MaxLength="500"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" class="cssdetail">
                                                    <u>Legal/bankruptcy action againt guarantors/directors</u><br />
                                                    <asp:RadioButtonList runat="server" ID="legalbackcruptcy" RepeatDirection="Horizontal" ValidationGroup="5-"></asp:RadioButtonList><br />
                                                    <asp:TextBox ID="cus_remarks8" runat="server" TextMode="MultiLine" Style="width: 100%; height: 80px" MaxLength="500"></asp:TextBox>
                                                </td>
                                            </tr>



                                        </table>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <b>BANK REFERENCE</b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks9" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <b>OTHER RELAVANT INFORMATION TO SUPPORT APPLICATION (including guarantor (s) financial standing)</b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks10" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>


                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>


                            <% End if %>

                            <%-- <% If lvlvalid.Value = "True" And wfb_bar.wlevelAget().tostring.trim <> "" And wfb_bar.wlevelAget().tostring.trim <> "1" And wfb_bar.wlevelAget().tostring.trim <> "5" And Not backend.closed(ucode.Value) then %>--%>
                            <% If lvlvalid.Value = "True" And (wfb_bar.wlevelAPget().tostring.trim = "" Or wfb_bar.wlevelAPget().tostring.trim = "2") And Not backend.closed(ucode.Value) Then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>

                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <b><%= wfb_bar.wlevelNameget().tostring.trim %></b><asp:Label ID="lblrcm" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>


                            <% End if %>

                            <div class="row mb-2">
                                <div class=" col-sm-3">
                                    <asp:PlaceHolder ID="commentSubmit" runat="server"></asp:PlaceHolder>

                                </div>
                            </div>

                            <div id="accordion" class="mb-2">


                                <div class="card">

                                    <div class="card-header p-1" id="headingOne">
                                        <h5 class="mb-0">
                                            <a class="btn btn-link" data-toggle="collapse" data-target="#Comments" aria-expanded="false" aria-controls="Comments" href="#">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="10px"><span class="ui-icon ui-icon-plusthick"></span></td>
                                                        <td width="100%">Previous Comments</td>
                                                    </tr>
                                                </table>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="Comments" class="p-2 table-responsive" aria-labelledby="headingOne" data-parent="#accordion">
                                        <table id="table_comments" class="table table-striped  form-body-fonts">

                                            <thead>
                                                <tr>
                                                    <th scope="col">Reviewer</th>
                                                    <th scope="col">Comment</th>
                                                    <th scope="col">Activity</th>
                                                    <th scope="col">Date</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rep_comment" runat="server">
                                                    <ItemTemplate>
                                                        <tr id="trRow" runat="server">
                                                            <td>
                                                                <span class="fa fa-user"></span>
                                                                <asp:Label ID="rep_uid" runat="server" Text=' <%#Eval("usr_name") %>' />
                                                            </td>
                                                            <td>
                                                                <span class="fa fa-comment-o" style="color: darkblue"></span>
                                                                <asp:Label ID="rep_comment" runat="server" Text=' <%#Eval("comment") %>' />
                                                            </td>
                                                            <td>
                                                                <span class="fa fa-check" style="color: forestgreen"></span>
                                                                <asp:Label ID="rep_wf_level" runat="server" Text=' <%#Eval("wui_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_createddate" runat="server" Text=' <%#Eval("createddate") %>' />
                                                            </td>

                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>
                                            </tbody>



                                        </table>


                                    </div>

                                </div>

                            </div>


                            <%If backend.viewRights2(wfb_bar.wlevelAget(), 3, rid.Value, NmSpace) Or wfb_bar.wlevelAPget().tostring.trim = "3" Then %>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <a href="#clh" data-toggle="collapse">CREDIT LIMIT HISTORY (for existing customer only)</a>

                                    <div id="clh" style="overflow-x: auto;">
                                        <table width="100%">

                                            <tr>
                                                <td colspan="6" class="cssdetail" valign="top" align="left" width="100%">
                                                    <table width="100%" cellpadding="5" cellspacing="1" style="background-color: Gray">
                                                        <tr>
                                                            <td class="cssdetail" width="40%" align="left" style="color: white"></td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">LIMIT<br />
                                                                RM</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">CREDIT PERIOD<br />
                                                                <b>DAYS</b></td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">DATE APPROVED</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="left">Original Credit Limit</td>
                                                            <td class="cssdetail" style="background-color: white">
                                                                <asp:TextBox ID="cus_tblc1_1" runat="server" Style="width: 85%; text-align: right" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_tblc2_1" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[integer]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <uc:datepicker ID="cus_tblc3_1" runat="server" AllowNull="false" Width="91%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="left">First Revision</td>
                                                            <td class="cssdetail" style="background-color: white">
                                                                <asp:TextBox ID="cus_tblc1_2" runat="server" Style="width: 85%; text-align: right" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_tblc2_2" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <uc:datepicker ID="cus_tblc3_2" runat="server" AllowNull="false" Width="91%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="left">Second Revision</td>
                                                            <td class="cssdetail" style="background-color: white">
                                                                <asp:TextBox ID="cus_tblc1_3" runat="server" Style="width: 85%; text-align: right" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_tblc2_3" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <uc:datepicker ID="cus_tblc3_3" runat="server" AllowNull="false" Width="91%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="left">Third Revision</td>
                                                            <td class="cssdetail" style="background-color: white">
                                                                <asp:TextBox ID="cus_tblc1_4" runat="server" Style="width: 85%; text-align: right" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_tblc2_4" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <uc:datepicker ID="cus_tblc3_4" runat="server" AllowNull="false" Width="91%" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: white" align="left">Fourth Revision</td>
                                                            <td class="cssdetail" style="background-color: white">
                                                                <asp:TextBox ID="cus_tblc1_5" runat="server" Style="width: 85%; text-align: right" MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <div class="validation-content" style="position: relative;">
                                                                    <asp:TextBox ID="cus_tblc2_5" runat="server" Style="width: 85%; text-align: right" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: white" align="right">
                                                                <uc:datepicker ID="cus_tblc3_5" runat="server" AllowNull="false" Width="91%" />
                                                            </td>
                                                        </tr>


                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <a href="#pr" data-toggle="collapse">ACTIVITY/PAYMENT RECORD (for existing customer only)</a>

                                    <div id="pr" style="overflow-x: auto;">
                                        <table width="100%">
                                            <tr>
                                                <td colspan="6" class="cssdetail" valign="top" align="left" width="100%">
                                                    <table width="100%" cellpadding="5" cellspacing="1" style="background-color: Gray">
                                                        <tr>
                                                            <td class="cssdetail" width="20%" align="left" style="color: white">MONTH</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">MONTHLY SALES<br />
                                                                RM</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">BALANCE OUTSTANDING<br />
                                                                RM</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">AMOUNT DUE<br />
                                                                RM</td>
                                                            <td class="cssdetail" width="20%" align="center" style="color: white">CREDIT PERIOD UTILISED DAYS</td>
                                                        </tr>
                                                        <asp:Repeater ID="rep" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="cssdetail" style="background-color: white; min-height: 15px; height: 15px">
                                                                        <asp:HiddenField ID="cusi_id" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "cusi_id")%>' />
                                                                        <asp:Literal runat="server" ID="litparam1" Text='<%#DataBinder.Eval(Container.DataItem, "cus_param1")%>'></asp:Literal>
                                                                        <asp:TextBox ID="txtparam1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_param1")%>' Style="width: 85%" MaxLength="20"></asp:TextBox>
                                                                    </td>
                                                                    <td class="cssdetail" style="background-color: white; min-height: 15px; height: 15px" align="right">
                                                                        <asp:Literal runat="server" ID="litparam2"></asp:Literal>
                                                                        <asp:TextBox ID="txtparam2" runat="server" Style="width: 85%" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                    </td>
                                                                    <td class="cssdetail" style="background-color: white; min-height: 15px; height: 15px" align="right">
                                                                        <asp:Literal runat="server" ID="litparam3"></asp:Literal>
                                                                        <asp:TextBox ID="txtparam3" runat="server" Style="width: 85%" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                    </td>
                                                                    <td class="cssdetail" style="background-color: white; min-height: 15px; height: 15px" align="right">
                                                                        <asp:Literal runat="server" ID="litparam4"></asp:Literal>
                                                                        <asp:TextBox ID="txtparam4" runat="server" Style="width: 85%" MaxLength="10" class="validate[custom[number]]"></asp:TextBox>
                                                                    </td>
                                                                    <td class="cssdetail" style="background-color: white; min-height: 15px; height: 15px" align="right">
                                                                        <asp:Literal runat="server" ID="litparam5" Text='<%#DataBinder.Eval(Container.DataItem, "cus_param5")%>'></asp:Literal>
                                                                        <asp:TextBox ID="txtparam5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_param5")%>' Style="width: 85%" MaxLength="30"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                        <tr>
                                                            <td class="cssdetail" style="background-color: silver" align="left">TOTAL</td>
                                                            <td class="cssdetail" style="background-color: silver" align="right">
                                                                <asp:Literal ID="littotal1" runat="server"></asp:Literal>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: silver" align="right">
                                                                <asp:Literal ID="littotal2" runat="server"></asp:Literal>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: silver" align="right">
                                                                <asp:Literal ID="littotal3" runat="server"></asp:Literal>
                                                            </td>
                                                            <td class="cssdetail" style="background-color: silver" align="right"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cssdetail" colspan="6" align="left"><b>PAST PAYMENT RECORD</b></td>
                                            </tr>

                                            <tr>
                                                <td class="cssdetail" colspan="6" align="left">
                                                    <asp:CheckBox ID="cus_payment1" runat="server" Text="Within 30 days" />&nbsp;
                                                    <asp:CheckBox ID="cus_payment2" runat="server" Text="30 to 60 days" />&nbsp;
                                                    <asp:CheckBox ID="cus_payment3" runat="server" Text="60 to 90 days" />&nbsp;
                                                    <asp:CheckBox ID="cus_payment4" runat="server" Text="90 to 120 days" />&nbsp;
                                                    <asp:CheckBox ID="cus_payment5" runat="server" Text="Over 120 days" />

                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>


                            <% End if %>
                            <div id="accordion2" class="mb-2">

                                <hr />
                                <div class="card">

                                    <div class="card-header p-1" id="headingTwo">
                                        <h5 class="mb-0">
                                            <a class=" collapsed btn btn-link" data-toggle="collapse" data-target="#workflowlog" aria-expanded="false" aria-controls="workflowlog" href="#">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="10px"><span class="ui-icon ui-icon-plusthick"></span></td>
                                                        <td width="100%">Workflow Log</td>
                                                    </tr>
                                                </table>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="workflowlog" class="collapse table-responsive p-2" aria-labelledby="headingTwo" data-parent="#accordion2">
                                        <table id="table_audit" class="table table-striped w-100 form-body-fonts">

                                            <thead>
                                                <tr>
                                                    <th scope="col">Activity</th>
                                                    <th scope="col">Action</th>
                                                    <th scope="col">User</th>
                                                    <th scope="col">Date</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rep_audit" runat="server">
                                                    <ItemTemplate>
                                                        <tr id="trRow" runat="server">
                                                            <td>
                                                                <asp:Label ID="rep_activity" runat="server" Text=' <%#Eval("wui_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_uid" runat="server" Text=' <%#Eval("wfa_code") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_comment" runat="server" Text=' <%#Eval("usr_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_wf_level" runat="server" Text=' <%#Eval("wfa_createon") %>' />
                                                            </td>

                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>
                                            </tbody>



                                        </table>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-4 bg-white" style="font-size: 0.8rem;">
                        <table class="ui-widget-header" width="100%">
                            <tr>
                                <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                <td width="100%"><span class="ui-widget"><b>Doc. Actions</b></span></td>
                            </tr>
                        </table>

                        <br />
                        <b>Ref. No:-</b><br />
                        <asp:TextBox ID="cus_refno" runat="server" Style="width: 95%" MaxLength="50"></asp:TextBox><br />
                        <br />

                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Button ID="SubmitButton" Text="Save Record" runat="server" OnClick="savepage" Style="width: 100%" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="BackButton" Text="Back to Previous" runat="server" OnClick="backpagepage" Style="width: 100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <br />
                        <uc:Workflowbar ID="wfb_bar" runat="server" />
                    </div>
                </div>

                <br />
                <br />
                <input type="hidden" runat="server" id="ucode" name="ucode" />
                <input type="hidden" runat="server" id="rid" name="rid" />
                <input type="hidden" runat="server" id="bid" name="bid" />
                <input type="hidden" runat="server" id="cnum" name="cnum" />
                <input type="hidden" runat="server" id="datats" name="datats" />

                <input type="hidden" runat="server" id="ccode" name="ccode" />
                <input type="hidden" runat="server" id="lvlvalid" name="lvlvalid" />
                <input type="hidden" runat="server" id="createdt" name="createdt" />

            </div>

            <!--#include File="../../include/FormFooter1.aspx"-->
        </div>
        <script language="javascript">
            $(document).ready(function () {

                var isIE = false;
                if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                    isIE = true;
                }
                if (isIE == true) {
                    $("input[type=text]:disabled,textarea:disabled").each(function () {
                        $(this).removeAttr("disabled");
                        $(this).attr("unselectable", "on");
                    })
                };
            });
        </script>
        <script language="javascript" type="text/javascript">
            $(document).ready(function () {
                $("input[name*='dobj']").click(function () {
                    //            $.blockUI({css: {border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff'},message: '<h1>Processing....Please wait</h1><h3>Please do not click refresh or back button</h3>' });        
                });
            });
        </script>

    </form>
    <!--#include File="../../include/footerscript.aspx"-->
    <script type="text/javascript">

        $(document).ready(function () {

            $('#table_comments').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
                "lengthChange": false,
                "bPaginate": false,
                "order": [["Date", "asc"]],
                "columnDefs": [{ "targets": "Date", "type": "date-eu" }]
            });


            $('#table_audit').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
                "lengthChange": false,
                "bPaginate": false,
                "order": [["Date", "asc"]],
                "columnDefs": [{ "targets": "Date", "type": "date-eu" }]
            });
        });
    </script>
</body>
</html>

