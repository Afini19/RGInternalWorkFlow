<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="setupemail.aspx.vb" Inherits="setupemail_aspx_class" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="../../topinitdetail.aspx"-->
    <!--#include File="../../topmobilecss.aspx"-->
    <script>
        $(function () {
            $("input[type=submit], button")
            .button();
            $("#tabs").tabs();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: false, showArrow: true, focusFirstField: false });
            var div1 = $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div2 = $("#divdetails").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div3 = $("#tabs");
            div1.show();
            div2.show();
            div3.show();
        });
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="../../include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-light">
            <div class="row listpage">
                <div class="col-md-2 bg-light adddet">
                    <div style="padding-top: 1em; text-align: left; font-size: 0.8rem;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Options Menu</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="Button1" CssClass="btn btn-sm btn-info w-100" Text="Save Details" runat="server" OnClick="savepage" />
                                <br />
                                <asp:Button ID="BackButton" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <hr />
                                <b>Messages:</b>
                                <asp:Label ID="Label1" runat="server" class="cssrequired"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div style="text-align: left; font-size: 0.8rem;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Additional Details</h6>
                            </div>
                            <div class="card-body">
                                <b>Created By:</b><br />
                                <asp:Literal ID="litcreateby" runat="server"></asp:Literal>
                                <br />
                                <br />
                                <b>Created On:</b><br />
                                <asp:Literal ID="litcreateon" runat="server"></asp:Literal>
                                <br />
                                <br />
                                <b>Last Update By: </b>
                                <br />
                                <asp:Literal ID="litupdateby" runat="server"></asp:Literal>
                                <br />
                                <br />
                                <b>Last Update On: </b>
                                <br />
                                <asp:Literal ID="litupdateon" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_FormsName%>
                        </div>
                        <table width="100%" align="center" style="height: 100%">
                            <tr class="cssdetail">
                                <td>
                                    <b><span class="RequiredField">*</span> Email Subject :</b>
                                </td>
                            </tr>
                            <tr class="cssdetail">
                                <td class="cssdetail" align="left">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr class="cssdetail">
                                <td>
                                    <b><span class="RequiredField">*</span> Email Content :</b>
                                    <br />
                                    <font size="2"><u>Custom Fields:</u><br />
                                        <asp:Literal ID="litcustom" runat="server"></asp:Literal>
                                    </font>
                                </td>
                            </tr>
                            <tr class="cssdetail">
                                <td>
                                    <CKEditor:CKEditorControl ID="emailContent" runat="server" Width="100%" Height="100%">                      
                                    </CKEditor:CKEditorControl>
                                </td>
                            </tr>
                        </table>

                        <br />
                        <%--<asp:Button CssClass="btn btn-sm btn-info" ID="SubmitButton" Text="Save Email Template" runat="server" Class="inputbutton" OnClick="savepage" />--%>
                        <asp:Button CssClass="btn btn-sm btn-info" ID="ResetButton" Text="Reset to Default" runat="server" Class="inputbutton" OnClick="resetpage" />
                        <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>

                        <br />
                        <br />
                        <br />
                        <div class="btn2" style="display: none;">
                            <asp:Button ID="Button2" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                            <!--<asp:Button ID="Button3" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />-->

                        </div>
                        <input type="hidden" runat="server" id="rid" name="rid" />
                        <input type="hidden" runat="server" id="bid" name="bid" />
                    </div>
                </div>
                <!--#include File="../../include/FormFooter1.aspx"-->
            </div>
        </div>
    </form>
    <!--#include File="../../include/footerscript.aspx"-->
</body>
</html>
