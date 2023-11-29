<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="wflowtag.aspx.vb" Inherits="wflowtag_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
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
                <div class="col-md-2 bg-light ">
                    <div style="padding-top: 1em; text-align: left; font-size: 0.8rem;">
                        <div class="card">
                            <div class="card-header">
                                <h6 class="card-subtitle">Options Menu</h6>
                            </div>
                            <div class="card-body">
                                <asp:Button ID="SubmitButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="Save Details" runat="server" OnClick="savepage" />

                                <asp:Button ID="BackButton" CssClass="btn btn-sm btn-info w-100 m-1" Text="btn Back to Listing" runat="server" OnClick="backpage" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
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
                    <div style="padding-top: 1em; font-size:0.8rem;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_FormsName%>
                        </div>
                        <table id="table_listing" class="table table-borderless dt-responsive nowrap" width="100%" style="height: 100%;" cellpadding="2" cellspacing="1" >
                            <thead>
                                <tr>
                                    <th style="text-align: center;" class="cssdetail">No.</th>
                                    <th class="cssdetail">Name</th>
                                    <th class="cssdetail">Workflow</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rep" runat="server">
                                    <ItemTemplate>
                                        <tr id="trRow" class="ui-widget-content" runat="server">
                                            <td align="center" class="cssdetail">
                                                <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                <asp:HiddenField ID="uid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "wfl_id")%>' />
                                            </td>
                                            <td class="cssdetail">
                                                <div>
                                                    <asp:Literal ID="lit_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "wfl_name")%>'></asp:Literal>
                                                </div>
                                            </td>
                                            <td class="cssdetail">
                                                <div ><asp:DropDownList runat="server" style="width:100%;" ID="wfl_wflow"></asp:DropDownList></div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                         <%--  <div class="row mb-1">
                            <div class="col-md-1">No.</div>
                            <div class="col-md-7">Name</div>
                            <div class="col-md-4">Workflow</div>
                        </div>
                        <asp:Repeater ID="rep" runat="server">
                            <ItemTemplate>
                                <div class="row mb-1">
                                    <div class="col-md-1">
                                        <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal><asp:HiddenField ID="uid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "wfl_id")%>' />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Literal ID="lit_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "wfl_name")%>'></asp:Literal>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList runat="server" ID="wfl_wflow"></asp:DropDownList>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>--%>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" runat="server" id="rid" name="rid" />
        <input type="hidden" runat="server" id="bid" name="bid" />

        <!--#include File="../../include/FormFooter1.aspx"-->
    </form>
    <!--#include File="../../include/footerscript.aspx"-->

    <script type="text/javascript">
        $(document).ready(function () {
            $('#table_listing').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
                "bLengthChange": false,
                "bPaginate": false,
                "lengthMenu": [[-1], ["All"]]
            });
        });
    </script>

</body>
</html>
