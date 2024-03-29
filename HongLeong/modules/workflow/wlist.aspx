<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wlist.aspx.vb" Inherits="wlist_list_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--Generated by ViSoftLabs Forms Generator (http:// www.vifeandi.net)-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title><%=_FormsName%></title>
    <!--#include File="../../topinitdetail.aspx"-->
    <!--#include File="../../topmobilecss.aspx"-->
    <script>
        $(function () {
            $("input[type=submit], button")
            .button()
            var div1 = $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div2 = $("#divsearch").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div3 = $("#divdata");
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
                <div class="col-md-2 bg-light ">
                    <div style="padding-top: 1em; font-size: 0.8rem; text-align: left;">
                        <div class="card" style="text-align: left;">
                            <div class="card-header">
                                <h6>
                                    <a data-toggle="collapse" href="#opt" aria-expanded="false" aria-controls="opt">
                                        <i class="fa fa-ellipsis-v"></i> Options Menu
                                    </a>
                                </h6>
                            </div>
                            <div id="opt" class="collapse">
                                <div class="card-body">
                                    <asp:Button ID="btnadd" CssClass="btn btn-sm btn-info w-100" Text="Add New Record" runat="server" OnClick="AddEvent" /><br />

                                    <asp:Button ID="btnback" Text="Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" />
                                    <br />
                                    <b>Messages:</b><br />
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    <br />
                                </div>
                            </div>

                        </div>
                    </div>
                    <br class="adddet" />
                    <div>
                        <div class="card" style="text-align: left; font-size: 0.8rem;">
                            <div class="card-header">
                                <h6>
                                    <a data-toggle="collapse" href="#search" aria-expanded="false" aria-controls="search">
                                        <i class="fa fa-search-plus"></i> Search Menu
                                    </a>
                                </h6>
                            </div>
                            <div id="search" class="collapse">
                                <div class="card-body">
                                    <b>Please enter search key:</b><br />
                                    <asp:TextBox placeholder="Search" ID="search_key1" runat="server" Columns="23" MaxLength="50" CssClass="form-control"></asp:TextBox><br />
                                    Search Field:<br />
                                    <asp:PlaceHolder ID="phSearchFields" runat="server"></asp:PlaceHolder>
                                    <asp:Button ID="btnSearch" CssClass="btn btn-sm btn-info w-100" Text="Search" runat="server" OnClick="SearchStr" />
                                    <hr class="cssdivider" width="100%" runat="server" id="hrdate" />
                                    <br />
                                    <uc:datepicker ID="uc_from" runat="server" AllowNull="false" PlaceHolder="From Date" />
                                    <uc:datepicker ID="uc_to" runat="server" AllowNull="false" PlaceHolder="To Date" />
                                    <asp:PlaceHolder ID="phSearchDate" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: left; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_FormsName%>
                        </div>
                        <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%" style="height: 100%; font-size: 0.8rem;" cellpadding="2" cellspacing="1">
                            <thead>
                                <tr>
                                    <th class="cssdetail" data-priority="1">No.</th>
                                    <th class="cssdetail">Workflow</th>
                                    <th class="cssdetail" data-priority="2"></th>
                                    <th class="cssdetail">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                    <ItemTemplate>
                                        <tr id="trRow" class="ui-widget-content" runat="server">
                                            <td align="center" class="cssdetail">
                                                <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                            </td>
                                            <td class="cssdetail" width="48px" valign="top">
                                                <div>
                                                    <asp:Literal ID="litimage" runat="server"></asp:Literal><%--&nbsp;<asp:Literal ID="litData" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="litimage2" runat="server"></asp:Literal>--%>
                                                </div>
                                            </td>
                                            <td class="cssdetail">
                                                <div style="vertical-align:text-top;">
                                                    <asp:Literal ID="litData" runat="server" ></asp:Literal><asp:Literal ID="litimage2" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                            <td class="cssdetail">

                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "wf_id")%>' CommandName="Edit">Edit</asp:LinkButton>
                                                <asp:Literal ID="litSepDel" runat="server">|</asp:Literal>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "wf_id")%>' CommandName="Del" OnClientClick="return confirm('Are you sure want to delete this record?')">Del.</asp:LinkButton>
                                                <asp:Literal ID="Literal1" runat="server">|</asp:Literal>
                                                <asp:LinkButton ID="lnkBuild" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "wf_id")%>' CommandName="Def">Build Workflow</asp:LinkButton>
                                                <asp:Literal ID="Literal2" runat="server">|</asp:Literal>
                                                <asp:LinkButton ID="lnkCopy" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "wf_id")%>' CommandName="New">Duplicate Workflow</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--<tr class="ui-widget-header">
                                    <td colspan="<%=columnscount%>" align="center" class="cssdetail" style="height: 20px">
                                    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label></td>
                                </tr>--%>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />
        <hr width="100%" />
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




