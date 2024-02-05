<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="secprofile.aspx.vb" Inherits="secpro_class" %>

<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--#include File="topinitdetail.aspx"-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="topmobilecss.aspx"-->
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
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-light" style="font-size: 1rem;">
            <div class="row listpage">
                <div class="col-md-2 bg-light adddet ">
                    <div style="padding-top: 1em; font-size: 0.8rem; text-align: left;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Options Menu</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <br />
                                <b>Messages:</b><br />
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
                            </div>
                        </div>

                    </div>
                    <br />
                    <div style="font-size: 0.8rem; text-align: left;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Additional Details</h6>
                            </div>
                            <div class="card-body">
                                <b>Created By:</b><br />
                                <asp:Literal ID="litcreateby" runat="server"></asp:Literal>
                                <br />
                                <b>Created On:</b><br />
                                <asp:Literal ID="litcreateon" runat="server"></asp:Literal>
                                <br />
                                <b>Last Update By: </b>
                                <br />
                                <asp:Literal ID="litupdateby" runat="server"></asp:Literal>
                                <br />
                                <b>Last Update On: </b>
                                <br />
                                <asp:Literal ID="litupdateon" runat="server"></asp:Literal>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                        Please fill in details below<br />
                        <hr width="100%" class="cssdivider" />
                        <table class="table table-borderless" width="100%" style="margin-top: -15px" cellpadding="0" cellspacing="2">
                            <tr>
                                <td class="cssdetail" valign="top" align="left" width="20%">Profile Name&nbsp;<font class="cssrequired">*</font></td>
                                <td colspan="1" class="cssdetail" valign="top" align="left">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="pf_name" runat="server" Style="width: 80%" MaxLength="50" class="validate[required]"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <div class="btn2" style="display: none;">
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                            <asp:Button ID="Button2" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />

                        </div>

                        <%--  <asp:LinkButton runat="server" ID="btnsave2" OnClick="savepage" CssClass="btn btn-sm btn-info w-100 m-1 btn2"  > <i class='fa fa-save'></i> Save</asp:LinkButton>
                        
                        <asp:LinkButton runat="server" ID="btnback2" OnClick="backpage" CssClass="btn btn-sm btn-info w-100 m-1 btn2" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  > <i class='fa fa-angle-left'></i> Back to Listing</asp:LinkButton>--%>
                        <input type="hidden" runat="server" id="rid" name="rid" />
                        <input type="hidden" runat="server" id="bid" name="bid" />
                    </div>
                </div>
            </div>
        </div>
        <!--#include File="include/FormFooter1.aspx"-->
    </form>
    <!--#include File="include/footerscript.aspx"-->
</body>
</html>

