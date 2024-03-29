<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wiz-selectcustomer.aspx.vb" Inherits="wiz_selectcustomer_class" %>

<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--Generated by ViSoftLabs Forms Generator (http:// www.vifeandi.net)-->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <title>Wizard - Select Customer</title>
    <!--#include File="topinitdetail.aspx"-->
    <script>
        $(function () {
            $("input[type=submit], button")
            .button()
            var div1 = $("#divnavi").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div2 = $("#divsearch").accordion({ collapsible: false, heightStyle: "content", active: 0 });
            var div3 = $("#divdata");
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
                <div class="col-md-2 bg-light ">
                    <div style="padding-top: 1em; display: none; font-size: 0.8rem; text-align: left;">
                        <div style="text-align: left">
                            <asp:Button ID="btnadd" CssClass="btn btn-sm btn-info w-100" Text="Add New Record" runat="server" OnClick="AddEvent" Style="width: 160px" /><br />
                            <br />
                            <asp:Button ID="btnback" CssClass="btn btn-sm btn-info w-100" Text="Back to Listing" runat="server" OnClick="backpage" Style="width: 160px" CausesValidation="false" />

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
                            <br />
                            <asp:TextBox ID="search_key1" runat="server" Columns="23" MaxLength="50" Width="100%"></asp:TextBox><br />

                            <asp:PlaceHolder ID="phSearchFields" runat="server"></asp:PlaceHolder>
                            <br />
                            <hr class="cssdivider" width="100%" runat="server" id="hrdate" />
                            <br />
                            <uc:datepicker ID="uc_from" runat="server" AllowNull="false" Width="72px" PlaceHolder="From Date" />
                            <uc:datepicker ID="uc_to" runat="server" AllowNull="false" Width="72px" PlaceHolder="To Date" />
                            <asp:PlaceHolder ID="phSearchDate" runat="server"></asp:PlaceHolder>
                            <br />
                            <asp:Button ID="btnsearch" CssClass="btn btn-sm btn-info w-100" Text="Search" runat="server" OnClick="SearchStr" Style="width: 100%" />
                            <br />
                            <br />
                            <asp:Button ID="btnnext" CssClass="btn btn-sm btn-warning w-100" Text="Skip Selection >>" runat="server" OnClick="nextpage" Style="width: 100%" CausesValidation="false" />
                        </div>
                    </div>
                </div>
                <div class="col-md-10 bg-white">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: left; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                        <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%"  style="height:100%;cellpadding="2" cellspacing="1">
                                                                        <thead>
                                                                            <tr class="ui-widget-header" style="height: 25px">
                                            <th class="cssdetail"><b>No.</b></th>
                                            <th class="cssdetail">Merchant code</th>
                                            <th class="cssdetail">Merchant name</th>

                                        </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            
                                        <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                            <ItemTemplate>
                                                <tr id="trRow" class="ui-widget-content" runat="server">
                                                    <td align="center" class="cssdetail">
                                                        <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                    </td>
                                                    <td class="cssdetail">
                                                        <asp:Literal ID="litsm_code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "sm_code")%>'></asp:Literal></td>
                                                    <td class="cssdetail">
                                                        <b>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "sm_code")%>' CommandName="Select">
<font style="text-decoration:none;color:blue">
<%#DataBinder.Eval(Container.DataItem, "sm_name")%></font>
                                                            </asp:LinkButton>
                                                        </b>

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

        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />
        <input type="hidden" runat="server" id="wnextpage" name="wnextpage" />
        <input type="hidden" runat="server" id="wparam" name="wparam" />
        <input type="hidden" runat="server" id="com" name="com" />
        <input type="hidden" runat="server" id="refno" name="refno" />

        <hr width="100%" />
        <!--#include File="include/FormFooter1.aspx"-->
    </form>
    <!--#include File="include/footerscript.aspx"-->
    <script type="text/javascript">

        $(document).ready(function () {

            $('#table_listing').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false
            });
        });


    </script>
</body>
</html>

