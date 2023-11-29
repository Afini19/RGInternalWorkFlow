<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wbuilderd.aspx.vb" Inherits="wbuilderd_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
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

            <div class=" container-fluid bg-light" style="font-size: 1rem;">
                <div class="row listpage">
                    <div class="col-md-2 bg-light adddet">

                        <div style="padding-top: 1em; font-size: 0.8rem; text-align: left">

                            <div>
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" /><br />
                                <asp:Button ID="delbutton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Delete" runat="server" OnClick="deleterec" OnClientClick="return confirm('Are you sure want to delete this record?')" />
                                <br />
                                <hr />
                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100" Text="Back to Designer" runat="server" OnClick="gotoback2" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <br />
                                <br />
                                <b>Messages:</b><br />
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                        <div style="text-align: left; font-size: 0.8rem;">

                            <div>
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
                                <br />
                                <br />
                            </div>
                        </div>

                    </div>

                    <div class="col-md-10 bg-white">
                        <div style="padding-top: 1em; font-size: 0.8rem;">
                            <div id="tabs" style="display: none">
                                <ul>
                                    <li><a href="#tabs-1"><%=_formsname %></a></li>
                                </ul>
                                <div id="tabs-1" style="text-align: left; font-size: 0.8rem;">

                                    <div class="row">
                                        <div class="col-md-12">
                                            Please fill in details below
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <hr width="100%" class="cssdivider" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Level Name&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox runat="server" ID="wui_name" MaxLength="100" class="validate[required]" Width="100%" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Sequence No.&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox runat="server" ID="wui_no" class="validate[required,custom[integer]]" Width="20%" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Allow Attachment&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_allowattach" />&nbsp;Level 1 automatically allowed attachment
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-12">
                                            <hr width="100%" class="cssdivider" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Enable Approve Action&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_approve" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Action Name&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="wui_approvename" MaxLength="20" Width="80%" />(Empty = "Approve")
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">On Approve&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:DropDownList ID="wui_approvestep" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3"></div>
                                        <div class="col-md-9">
                                            <hr class="cssdivider" width="100%" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Enable Approval Limit&nbsp;</div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_approveval" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Approval Limit&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox runat="server" ID="wui_approvevalamt" MaxLength="20" class="validate[custom[number]]" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">End Workflow by Limit&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_approvalvalend" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-12">
                                            <hr width="100%" class="cssdivider" />
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">Enable Reject Action&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_reject" />
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">Action Name&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="wui_rejectname" MaxLength="20" />(Empty = "Reject")
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">On Reject&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:DropDownList ID="wui_rejectstep" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-12">
                                            <hr width="100%" class="cssdivider" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Enable Cancel Action&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:CheckBox runat="server" ID="wui_cancel" />
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Action Name&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="wui_cancelname" MaxLength="20" />(Empty = "Cancel")
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">On Cancel&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-9">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:DropDownList ID="wui_cancelstep" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-12">
                                            <hr width="100%" class="cssdivider" />
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-12">Approval Groups</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">Separate Next Action Routing will override original next action routing on Approved Settings >> &nbsp;&nbsp;<asp:CheckBox runat="server" ID="wui_emailsf" Text="Enable" /></div>
                                    </div>

                                    <div class="row mb-1" style="font-size: 0.7rem;">
                                        <div class="col-md-12">

                                            <table width="100%" id="table_listing" class="dt-responsive nowrap" style="height: 80%; background-color: Gainsboro;" cellpadding="2" cellspacing="1">
                                                <thead>
                                                    <tr class="ui-widget-header" style="height: 25px">
                                                        <th class="cssdetail"><b>No.</b></th>
                                                        <th class="cssdetail">Approval Group</th>
                                                        <th class="cssdetail">Action Rights</th>
                                                        <th class="cssdetail">On Approve: Notify</th>
                                                        <th class="cssdetail">On Approve: Email To</th>
                                                        <th class="cssdetail">On Approve: Next Action</th>
                                                        <th class="cssdetail">On Reject: Email To</th>
                                                        <th class="cssdetail">On Cancel: Email To</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rep" runat="server">
                                                        <ItemTemplate>
                                                            <tr id="trRow" class="ui-widget-content" runat="server">
                                                                <td align="center" class="cssdetail">
                                                                    <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                                    <asp:HiddenField ID="txtid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' />
                                                                    <asp:HiddenField ID="txtiid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' />

                                                                </td>
                                                                <td class="cssdetail">
                                                                    <asp:Literal ID="litname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "wo_name")%>'></asp:Literal></td>
                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkfull" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>
                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkonnotify" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>


                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkonapprove" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>
                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkonapproves" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>

                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkonreject" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>
                                                                <td class="cssdetail">
                                                                    <asp:CheckBox ID="chkoncancel" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "wo_id")%>' /></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="btn2" style="display: none;">
                                        <asp:Button ID="Button1" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />
                                        <asp:Button ID="Button3" CssClass="btn btn-sm btn-info w-100 m-1" Text="Delete" runat="server" OnClick="deleterec" OnClientClick="return confirm('Are you sure want to delete this record?')" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button2" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <input type="hidden" runat="server" id="rid" name="rid" />
            <input type="hidden" runat="server" id="bid" name="bid" />
            <input type="hidden" runat="server" id="pg" name="pg" />
            <input type="hidden" runat="server" id="ucode" name="ucode" />
            <!--#include File="../../include/FormFooter1.aspx"-->
        </form>

        <!--#include File="../../include/footerscript.aspx"-->
        <script type="text/javascript">
            $(document).ready(function () {
                $('#table_listing').DataTable({
                    responsive: true,
                    "info": false,
                    "bFilter": false,
                    "bInfo": false,
                    "bPaginate": false
                });
            });
        </script>
</body>
</html>
