<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="secprofilerights.aspx.vb" Inherits="secprorights_list_class" %>

<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--Generated by ViSoftLabs Forms Generator (http://www.vifeandi.net)-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title><%=_formsname%></title>
    <!--#include File="topinitdetail.aspx"-->
    <!--#include File="topmobilecss.aspx"-->
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
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->

        <div class=" container-fluid bg-light" style="font-size: 1rem;">
            <div class="row listpage">
                <div class="col-md-2 bg-light ">
                    <div style="padding-top: 1em; font-size: 0.8rem; text-align: left;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Modules</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1 adddet" Text="Save Details" runat="server" OnClick="savepage" />

                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100 m-1 adddet" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                <br />
                                <asp:PlaceHolder ID="phModules" runat="server"></asp:PlaceHolder>
                                <br class="adddet" />
                                <b class="adddet">Messages:</b><br />
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired adddet"></asp:Label>
                                <br class="adddet" />
                                <b>Filter:</b><br />
                                <asp:DropDownList ID="sys_app" runat="server" Style="width: 100%"></asp:DropDownList><br />
                                <br />
                                <asp:Button ID="btnSearch" Text="Search" CssClass="btn btn-sm btn-info w-100" runat="server" OnClick="searchdata" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: left; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                        <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%" style="height: 100%;font-size:0.8rem;" cellpadding="2" cellspacing="1">
                            <thead>
                                <tr>
                                    <th class="cssdetail"><b>No.</b></th>
                                    <th class="cssdetail" width="200px">Description</th>
                                    <th class="cssdetail">Add</th>
                                    <th class="cssdetail">Edit</th>
                                    <th class="cssdetail">Delete</th>
                                    <th class="cssdetail">View</th>
                                    <th class="cssdetail">Full Rights</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rep" runat="server">
                                    <ItemTemplate>
                                        <tr id="trRow" class="ui-widget-content" runat="server">
                                            <td align="center" class="cssdetail">
                                                <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                <asp:HiddenField ID="txtappid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ssf_appid")%>' />
                                                <asp:HiddenField ID="txtcode" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ssf_code")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:Literal ID="litssf_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ssf_name")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkadd" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "ssf_add")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkmod" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "ssf_edit")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkdel" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "ssf_del")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkview" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "ssf_view")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <asp:CheckBox ID="chkfull" runat="server" ToolTip='<%#DataBinder.Eval(Container.DataItem, "ssf_gotrights")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div style="text-align: left;">
                            <a href="javascript:void(0)" onclick="selectAll()">Select All</a> | <a href="javascript:void(0)" onclick="selectNone()">Select None</a>
                        </div>
                        <br />
                        <br />
                        <div class="btn2" style="display: none;">
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                            <asp:Button ID="Button2" CssClass="btn btn-sm btn-info w-100 m-1" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />
        <hr width="100%" />
        <!--#include File="include/FormFooter1.aspx"-->
    </form>
    <!--#include File="include/footerscript.aspx"-->

    <script type="text/javascript">
        $(document).ready(function () {
            $('#table_listing').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
		"lengthMenu": [[-1], ["All"]]
            });
        });
    </script>
</body>
</html>
