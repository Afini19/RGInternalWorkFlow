<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="cussamples.aspx.vb" Inherits="cussamples_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar.ascx" TagPrefix="uc" TagName="Workflowbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->

    <script>
        $(function () {
            $("input[type=submit],input[type=button], button")
            .button();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: false, showArrow: true, focusFirstField: false });
        });
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <center>
            <div class="container">
                <!--#include File="../../include/FormHeader1.aspx"-->
                <div id="div1" class="verticalseparator">
                    &nbsp;
                </div>
                <div runat="server" id="middlepanel100p">

                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" width="100%">
                                <table class="ui-widget-header" width="100%">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                        <td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="100%">

                                <table width="100%" cellpadding="0" cellspacing="2">
                                    <tr>
                                        <td valign="top" width="100%">
                                            <div id="tabs">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="csssubheader" colspan="2" align="center"><%=_FormsName%></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="csssubheader" colspan="2">
                                                            <hr width="100%" class="cssdivider" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Company&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_company" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Name of PIC&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_name" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Contact No&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_contactno" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Email&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_email" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Address to Send to&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_address" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Type of Samples<br />
                                                            (OPC / GGBS / etc)&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_typeofsample" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Amount&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_amount" runat="server" Style="width: 50%" MaxLength="50" class="validate[required,custom[number]]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Type of Test<br />
                                                            (Strength, Chemical, etc)&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_typeoftest" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Expected Duration of Testing Before Confirm&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_duration" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left">Remarks&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left">
                                                            <asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500" ValidationGroup="0-"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="cssdetail" valign="top" align="left" width="30%">Sales Exec&nbsp;<font class="cssrequired">*</font></td>
                                                        <td colspan="1" class="cssdetail" valign="top" align="left" width="70%">
                                                            <asp:TextBox ID="cus_salesexec" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="0-"></asp:TextBox></td>
                                                    </tr>

                                                </table>

                                                <br />

                                            </div>
                                        </td>
                                    </tr>
                                </table>

                                <br />
                                <br />
                                <input type="hidden" runat="server" id="ucode" name="ucode">

                                <input type="hidden" runat="server" id="rid" name="rid">
                                <input type="hidden" runat="server" id="bid" name="bid">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divsep1" class="verticalseparator">
                    &nbsp;
                </div>
                <div id="rightpanelsmall">
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

                <!--#include File="../../include/FormFooter1.aspx"-->
            </div>
        </center>
    </form>
</body>
</html>

