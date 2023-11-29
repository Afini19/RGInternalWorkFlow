<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="dn3_list.aspx.vb" Inherits="dn3_list_class" %>


<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--Generated by ViSoftLabs Forms Generator (http://www.vifeandi.net)-->
    <meta charset="utf-8">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
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
                        <div class="card">
                            <div class="card-header">
                                <h6>
                                    <a data-toggle="collapse" href="#opt" aria-expanded="false" aria-controls="opt">
                                        <i class="fa fa-ellipsis-v"></i> Options Menu
                                    </a>
                                </h6>
                            </div>
                            <div id="opt" class="collapse">
                                <div class="card-body">
                                    <asp:Button ID="btnadd" CssClass="btn btn-info btn-sm w-100" Text="Add New Record" runat="server" OnClick="addeventadd" Style="width: 160px" />

                                    <b>View Document by Status:-</b><br />
                                    <asp:Button ID="btnmy" CssClass="btn btn-info btn-sm w-100" Text="My Action Inbox" runat="server" OnClick="shortcutmy" Style="width: 160px" CausesValidation="false" /><br />
                                    <hr class="cssdivider" style="width: 100%" />
                                    <asp:PlaceHolder ID="phFilters" runat="server"></asp:PlaceHolder>

                                    <hr class="cssdivider" style="width: 100%" />
                                    <asp:Button ID="btn1" CssClass="btn btn-info btn-sm w-100 m-1" Text="Pending" runat="server" OnClick="shortcut1" Style="width: 160px" CausesValidation="false" />
                                    <asp:Button ID="btn2" CssClass="btn btn-info btn-sm w-100 m-1" Text="Approved" runat="server" OnClick="shortcut2" Style="width: 160px" CausesValidation="false" />

                                    <asp:Button ID="btn3" CssClass="btn btn-info btn-sm w-100 m-1" Text="Cancelled" runat="server" OnClick="shortcut3" Style="width: 160px" CausesValidation="false" />

                                    <asp:Button ID="btn5" CssClass="btn btn-info btn-sm w-100 m-1" Text="Rejected" runat="server" OnClick="shortcut4" Style="width: 160px" CausesValidation="false" />


                                    <asp:Button ID="btnback" CssClass="btn btn-info btn-sm w-100" Text="Back to Listing" runat="server" OnClick="backpage" Style="width: 160px" CausesValidation="false" />
                                    <br />
                                    <b>Messages:</b><br />
                                    <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>
                    <br class="adddet" />
                    <div style="text-align: left; font-size: 0.8rem;">
                        <div class="card">
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

                                    <asp:TextBox ID="search_key1" runat="server" Columns="23" MaxLength="50" Width="100%"></asp:TextBox><br />
                                    Search Field:<br />
                                    <asp:PlaceHolder ID="phSearchFields" runat="server"></asp:PlaceHolder>

                                    <hr class="cssdivider" width="100%" runat="server" id="hrdate" />

                                    <uc:datepicker ID="uc_from" runat="server" AllowNull="false" Width="72px" PlaceHolder="From Date" />
                                    <uc:datepicker ID="uc_to" runat="server" AllowNull="false" Width="72px" PlaceHolder="To Date" />
                                    <br />
                                    <asp:PlaceHolder ID="phSearchDate" runat="server"></asp:PlaceHolder>

                                    <asp:Button ID="btnSearch" CssClass="btn btn-sm btn-info w-100" Text="Search" runat="server" OnClick="SearchStr" Style="width: 150px" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <asp:Literal ID="filterhead" runat="server"></asp:Literal>
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: left; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                    </div>
                    <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%" style="height: 100%; font-size: 0.8rem;" cellpadding="2" cellspacing="1">
                        <thead>
                            <tr>
                                <th class="cssdetail" data-priority="1">&nbsp;</th>
                                <th class="cssdetail"><b>Customer</b></th>
                                <th class="cssdetail">Doc Type</th>
                                <th class="cssdetail" data-priority="2">Doc Ref</th>
                                <th class="cssdetail">Type</th>
                                <th class="cssdetail">Amount</th>
                                <th class="cssdetail">Created By</th>
                                <th class="cssdetail" data-priority="3">Status</th>
                                <th class="cssdetail">Last Action On</th>
                                <th class="cssdetail"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                <ItemTemplate>
                                    <tr id="trRow" class="ui-widget-content" runat="server">
                                        <td align="center" class="cssdetail" width="48px" style="border-bottom: solid 1px silver" valign="top">
                                            <asp:Literal ID="litimage" runat="server"></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="litcust" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_company")%>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# "<b>" + DataBinder.Eval(Container.DataItem, "wst_subject") + " </b>" %>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_uno") + If(DataBinder.Eval(Container.DataItem, "wst_refno").ToString() = "", "", "<br/>( Ticket No. " + DataBinder.Eval(Container.DataItem, "wst_refno") + " )")%>'></asp:Literal>
                                        </td>           
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_cndntype")%>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal7" runat="server" Text='<%# WebLib.formatthemoney(DataBinder.Eval(Container.DataItem, "cus_cndnamtcount"))%>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "usr_name") + " " + DataBinder.Eval(Container.DataItem, "wst_createon")%>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal5" runat="server" Text=' <%# "<b>" + If(Eval("wst_status").ToString() = "Pending", "Pending <b>" + DataBinder.Eval(Container.DataItem, "ApprovalLevelName") + "</b>", DataBinder.Eval(Container.DataItem, "wst_status")) + " </b>" %>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <asp:Literal ID="Literal4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "wst_lastupdateon")%>'></asp:Literal>
                                        </td>
                                        <td class="cssdetail" style="border-bottom: solid 1px silver">
                                            <a href='<%# WebLib.ClientURL(Redirector.Redirect(DataBinder.Eval(Container.DataItem, "wst_module"), DataBinder.Eval(Container.DataItem, "wst_ucode"))) %>'>View Document</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <input type="hidden" runat="server" id="wfid" name="wfid" />
        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />
        <!--#include File="../../include/FormFooter1.aspx"-->
        <hr width="100%" />
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

