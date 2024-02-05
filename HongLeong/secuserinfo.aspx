<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="secuserinfo.aspx.vb" Inherits="secuse_class" MaintainScrollPositionOnPostback="true" %>

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
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: true, showArrow: true, focusFirstField: false });
            $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            $("#divdetails").accordion({ collapsible: false, heightStyle: "content", active: 0 });
        });
    </script>
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-light" style="font-size: 1rem;">
            <div class="row listpage">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="col-md-2 bg-light adddet">
                    <div style="padding-top: 1em; font-size: 0.8rem; text-align: left">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Options Menu</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" ValidationGroup="validate" />
                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <br />
                                <b>Messages:</b><br />
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
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
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: left; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                        <div id="tabs" style="font-size: 0.8rem;" class="bg-white borderless">
                            <ul>
                                <li><a href="#tabs-1" style="font-size: 0.8rem; width: 100%;">User Info </a></li>
                                <%--Security Center - --%>
                                <li style="display: none;"><a href="#tabs-2" style="font-size: 0.8rem;">Branch Accessibility </a></li>
                            </ul>
                            <div id="tabs-1">
                                Please fill in details below
                                <hr width="100%" class="cssdivider" />
                                <div class="row listpage">
                                    <div class="col-md-8 bg-white" style="font-size: 0.8rem; padding-top: 1em;">

                                        <div class="row mb-1">
                                            <div class="col-md-3">User Code&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_code" runat="server" Style="width: 80%" MaxLength="20" class="validate[required]"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">User Name&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_name" runat="server" Style="width: 80%" MaxLength="50" class="validate[required]"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">User Profile&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:DropDownList ID="usr_profile" runat="server" class="validate[required,custom[integer]]" Width="80%"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Department</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:DropDownList ID="usr_department" runat="server" class="validate[custom[integer]]" Width="80%"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1" runat="server" visible="false">
                                            <div class="col-md-3">Branch&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <%--<asp:DropDownList ID="usr_branch" runat="server" class="validate[required,custom[integer]]" Width="80%"></asp:DropDownList>--%>
                                                    <asp:CheckBoxList runat="server" ID="usr_branch" RepeatDirection="Horizontal" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">SMP</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:DropDownList ID="usr_smp" runat="server" Width="80%"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Email&nbsp;<font class="cssrequired"></font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_email" runat="server" Style="width: 80%" MaxLength="50" class="validate[custom[email]]"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <hr width="100%" class="cssdivider" />
                                        <div class="row mb-1">
                                            <div class="col-md-3">Login Id&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_loginid" runat="server" Style="width: 80%" MaxLength="20" class="validate[required]"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Password&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_password" TextMode="Password" runat="server" Style="width: 80%" MaxLength="20"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="usr_password" ValidationGroup="validate" Display="Dynamic"
                                                        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                                                        ErrorMessage="Password must contain: Minimum 8 characters, at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">First Screen</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:DropDownList ID="usr_firstscreen" runat="server" class="validate[required]" Width="80%"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <hr width="100%" class="cssdivider" />
                                        <div class="row mb-1">
                                            <div class="col-md-3">Expiry date&nbsp;<font class="cssrequired">*</font></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <uc:datepicker ID="usr_expiry" runat="server" AllowNull="false" cssclass="validate[required]" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Disable user</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:CheckBox runat="server" Text="Disable user" ID="usr_disable" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Whereabout Track</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:CheckBox runat="server" Text="Enable" ID="usr_whereabout" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">Active Directory</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:CheckBox runat="server" Text="Enable" ID="usr_isad" AutoPostBack="true" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-1">
                                            <div class="col-md-3">AD Login Name</div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_adlogin" runat="server" Style="width: 80%" MaxLength="20"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <hr width="100%" class="cssdivider" />
                                        <asp:UpdatePanel ID="OtherCustomerPnl" runat="server">
                                            <ContentTemplate>
                                                <div class="row mb-1">
                                                    <div class="col-md-3">Matrix Level</div>
                                                    <div class="col-md-9">
                                                        <div class="validation-content" style="position: relative;">
                                                            <asp:CheckBoxList runat="server" ID="usr_matrixlevel" AutoPostBack="true" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mb-1" id="trusr_region" runat="server" visible="false">
                                                    <div class="col-md-3"></div>
                                                    <div class="col-md-2"><b>&#187;</b> Region <b>&#187;</b></div>
                                                    <div class="col-md-7">
                                                        <div class="validation-content" style="position: relative;">
                                                            <asp:CheckBoxList runat="server" ID="usr_region" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mb-1" id="trusr_state" runat="server" visible="false">
                                                    <div class="col-md-3"></div>
                                                    <div class="col-md-2"><b>&#187;</b> State <b>&#187;</b></div>
                                                    <div class="col-md-7">
                                                        <div class="validation-content" style="position: relative;">
                                                            <asp:CheckBoxList runat="server" ID="usr_state" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="row mb-1">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-9">
                                                <div class="validation-content" style="position: relative;">
                                                    <asp:TextBox ID="usr_pin" runat="server" Style="width: 150px" MaxLength="20" class="validate[custom[integer]]"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="tabs-2">
                                <table class="table table-borderless" width="100%" style="margin-top: 15px" cellpadding="0" cellspacing="2">
                                    <thead>
                                        <tr class="ui-widget-header" style="height: 25px">
                                            <td class="cssdetail" width="5%"><b>No.</b></td>
                                            <td class="cssdetail" width="10%">Branch Code</td>
                                            <td class="cssdetail" width="20%">Branch Name</td>
                                            <td class="cssdetail">Allow Access</td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rep" runat="server">
                                            <ItemTemplate>
                                                <tr id="trRow" class="ui-widget-content" runat="server">
                                                    <td align="center" class="cssdetail">
                                                        <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                        <asp:HiddenField ID="br_code" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "br_code")%>' />
                                                        <asp:HiddenField ID="br_id" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "br_id")%>' />
                                                    </td>
                                                    <td class="cssdetail">
                                                        <asp:Literal ID="litbr_code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "br_code")%>'></asp:Literal></td>
                                                    <td class="cssdetail">
                                                        <asp:Literal ID="litbr_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "br_name")%>'></asp:Literal></td>
                                                    <td class="cssdetail">
                                                        <asp:CheckBox ID="chkfull" runat="server" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="btn2" style="display: none;">
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                            <asp:Button ID="Button2" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />

                        </div>
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

