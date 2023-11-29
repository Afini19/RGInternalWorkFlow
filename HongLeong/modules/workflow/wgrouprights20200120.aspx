<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wgrouprights.aspx.vb" Inherits="wgrouprights_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="~/UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->

    <script>
        $(function () {
            $("input[type=submit], button")
            .button()
            $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
        });
    </script>
    <script type="text/javascript">
        function selectAll() {
            $("input[type=checkbox]").each(function () {
                this.checked = true;
            });
        }
        function selectNone() {
            $("input[type=checkbox]").each(function () {
                this.checked = false;
            });
        }
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="../../include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-light" style="font-size: 1rem;">
            <div class="row listpage">
                <div class="col-md-2 bg-light ">
                    <div style="padding-top: 1em; font-size: 0.8rem; text-align: left;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Options Menu</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />
                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <asp:PlaceHolder ID="phModules" runat="server"></asp:PlaceHolder>
                                <br />
                                <br />
                                <b>Messages:</b><br />
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
                                <br />
                                <b>Filter:</b><br />
                                <asp:DropDownList ID="usr_profile" runat="server" Style="width: 100%"></asp:DropDownList><br />
                                <br />
                                <asp:Button ID="btnSearch" CssClass="btn btn-sm btn-info w-100" Text="Search" runat="server" OnClick="searchdata" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_FormsName%>
                        </div>
                        <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%" style="height: 100%; font-size: 0.8rem;" cellpadding="2" cellspacing="1">
                            <thead>
                                <tr>
                                    <th class="cssdetail"><b>No.</b></th>
                                    <th class="cssdetail">User Code</th>
                                    <th class="cssdetail">User Name</th>
                                    <th class="cssdetail">Select</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rep" runat="server">
                                    <ItemTemplate>
                                        <tr id="trRow" class="ui-widget-content" runat="server">
                                            <td align="center" class="cssdetail">
                                                <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "usr_id")%>' />
                                                <asp:HiddenField ID="txtiid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "wur_id")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:Literal ID="litcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "usr_code")%>'></asp:Literal></td>
                                            <td class="cssdetail">
                                                <asp:Literal ID="litname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "usr_name")%>'></asp:Literal></td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkfull" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "usr_id")%>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <a href="javascript:void(0)" onclick="selectAll()">Select All</a> | <a href="javascript:void(0)" onclick="selectNone()">Select None</a>
                        <input type="hidden" runat="server" id="rid" name="rid" />
                        <input type="hidden" runat="server" id="bid" name="bid" />
                        <hr width="100%" />
                    </div>
                </div>
            </div>

        </div>
        
            <!--#include File="../../include/FormFooter1.aspx"-->
    </form>
    <!--#include File="../../include/footerscript.aspx"-->

    <script type="text/javascript">
        $(document).ready(function () {
            $('#table_listing').DataTable({
                responsive: true,
                "info": true,
                "bFilter": false
            });
        });
    </script>
</body>
</html>

