<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="cusccr.aspx.vb" Inherits="cusccr_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar2.ascx" TagPrefix="uc" TagName="Workflowbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <!--#include File="../../topinitdetail.aspx"-->
    <script src="<%=ResolveClientUrl("~/plugins/blocker/jquery.blockUI.js")%>" type="text/javascript" charset="utf-8"></script>
    <style type="text/css">
        input[type=submit] {
            margin: 0.1rem;
            background-color: #17a2b8;
            border-color: #17a2b8;
            color: #fff;
            padding: .25rem .5rem;
            font-size: .875rem;
            line-height: 1.5;
            border-radius: .2rem;
            width: 100%;
            display: inline-block;
            font-weight: 400;
            text-align: center;
            vertical-align: middle;
            user-select: none;
            border: 1px solid transparent;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }
            input[type=submit]:disabled {
                margin: 0.1rem;
                cursor: not-allowed;
                opacity: .65;
                box-shadow: none;
                background-color: #5bc0de;
                border-color: #5bc0de;
                color: #fff;
                padding: .25rem .5rem;
                font-size: .875rem;
                line-height: 1.5;
                border-radius: .2rem;
                width: 100%;
                display: inline-block;
                font-weight: 400;
                text-align: center;
                vertical-align: middle;
                user-select: none;
                border: 1px solid transparent;
                transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            }
    </style>
    <script>
        $(function () {
            $("input[type=submit],input[type=button], button")
            .button();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: false, showArrow: true, focusFirstField: false });
        });
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <div class="container-fluid">
            <!--#include File="../../include/FormHeader1.aspx"-->

            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div class=" container bg-light" style="font-size: 1rem;">
                <div class="row listpage">
                    <div class="col-md-8 bg-light " style="font-size: 0.8rem;">
                        <div runat="server" id="mp">
                            <div class="row">
                                <table class="ui-widget-header" width="100%">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                        <td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="row w-100">
                                <div class="col-md-12" style="text-align: center;"><%=_FormsName%></div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" style="text-align: right;">Ref No :&nbsp;<asp:Label ID="lblrefno" runat="server"></asp:Label></div>
                            </div>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12 m-2" style="text-align: left"><b>CUSTOMER DESCRIPTION</b></div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">Distributor Name&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_distributor" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class=" validate[required]" ValidationGroup="0-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">Customer Name&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_customer" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">Location&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class=" validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_location" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class=" validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-6">Person to Contact On Site&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-6">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox ID="cus_person" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">Tel No&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="cus_telno" runat="server" Style="width: 100%" MaxLength="50" ValidationGroup="1-"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-6">Date of Complaint&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-6">
                                            <div class=" validation-content" style="position: relative;">
                                                <uc:datepicker ID="cus_dateofcomplaint" runat="server" AllowNull="false" class="validate[required]" ValidationGroup="1-" width="100%" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">H/P&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="cus_hp" runat="server" Style="width: 100%" MaxLength="50" ValidationGroup="1-"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 m-2" style="text-align: left">
                                    <b>COMPLAINT DESCRIPTION</b><asp:PlaceHolder ID="phlevel1" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-6">D/O Number&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-6">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox ID="cus_dono" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class=" validate[required]" ValidationGroup="1-"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">Transporter&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="cus_transporter" runat="server" Style="width: 100%" MaxLength="50" ValidationGroup="1-"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-6">Product&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-6">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:TextBox ID="cus_product" runat="server" Style="width: 100%; font-size: 0.8rem;" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">Quantity&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="cus_qty" runat="server" Style="width: 100%" MaxLength="50" ValidationGroup="1-"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">Description of Complaint&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_description" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <% If createdt.Value >= New DateTime(2020, 3, 8, 0, 0, 0) Then %>
                            <div class="row mb-1">
                                <div class="col-md-4">Classification&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_classification" runat="server" Style="width: 100%" ValidationGroup="1-" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">Complaint&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_complaint" runat="server" Style="width: 100%" ValidationGroup="1-"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server" ID="cnpanel" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-9"></div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnCN" CssClass="btn btn-info btn-sm" Text="Credit Note" runat="server" Visible="false" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <% End if %>


                            <%-- <% If lvlvalid.Value = "True" And wfb_bar.wlevelAget().tostring.trim <> "" And wfb_bar.wlevelAget().tostring.trim <> "1" And wfb_bar.wlevelAget().tostring.trim <> "7" And Not backend.closed(ucode.Value) then %>--%>
                            <% If lvlvalid.Value = "True" And wfb_bar.wlevelAPget().tostring.trim <> "1" And wfb_bar.wlevelAPget().tostring.trim <> "5" And Not backend.closed(ucode.Value) then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <b><%= wfb_bar.wlevelNameget().tostring.trim %></b><asp:PlaceHolder ID="phlevel3" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" class="validate[required]" Style="width: 100%; height: 100px" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>
                            <% End if %>


                            <%If lvlvalid.Value = "True" And backend.viewRights2(wfb_bar.wlevelAget(), 2, rid.value, NmSpace) and wfb_bar.wlevelAPget().tostring.trim = "2" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row mb-2">
                                        <div class="col-md-10" style="text-align: right;">Date Of Visit&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-2 mb-2">
                                            <div class="validation-content" style="position: relative;">
                                                <uc:datepicker ID="cus_investigatordate" runat="server" AllowNull="false" class="validate[required]" width="100%" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <%If lvlvalid.Value = "True" And backend.viewRights2(wfb_bar.wlevelAget(), 3, rid.Value, NmSpace) And wfb_bar.wlevelAPget().tostring.trim = "3" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-1">Valid&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-11">
                                            <asp:RadioButtonList runat="server" ID="cus_valid" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <%If lvlvalid.Value = "True" And backend.viewRights2(wfb_bar.wlevelAget(), 4, rid.Value, NmSpace) And wfb_bar.wlevelAPget().tostring.trim = "4" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-12">
                                            <asp:CheckBox runat="server" ID="cus_rootcause" Enabled="false" />
                                            &nbsp;<font class="cssrequired">*</font> Root Cause Analysis attachment is mandatory for Valid case
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <%If lvlvalid.Value = "True" And backend.viewRights2(wfb_bar.wlevelAget(), 5, rid.Value, NmSpace) And wfb_bar.wlevelAPget().tostring.trim = "5" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <hr width="100%" class="cssdivider" />
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <b>IMMEDIATE ACTION</b><asp:Label runat="server" ID="lbllevel7"></asp:Label><asp:PlaceHolder ID="phlevel7" runat="server"></asp:PlaceHolder>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList runat="server" ID="cus_immediateaction" RepeatDirection="Vertical" AutoPostBack="true">
                                                        <asp:ListItem Value="Compensate">COMPENSATE (Credit note requisition is needed)</asp:ListItem>
                                                        <asp:ListItem Value="Not Compensate">NOT COMPENSATE</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-6" style="display: none;">
                                                    Date of Action&nbsp;<font class="cssrequired">*</font>
                                                </div>
                                                <div class="col-md-6" style="display: none;">
                                                    <div class="validation-content" style="position: relative;">
                                                        <uc:datepicker ID="cus_immediatedate" runat="server" AllowNull="false" class="validate[required]" width="100%" enabled="false" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <%If lvlvalid.Value = "True" And backend.viewRights2(wfb_bar.wlevelAget(), 6, rid.Value, NmSpace) And wfb_bar.wlevelAPget().tostring.trim = "6" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <%--<div class="col-md-6">
                                            <b>CASE CLOSED BY SALES</b><asp:Label runat="server" ID="lbllevel10"></asp:Label><asp:PlaceHolder ID="phlevel10" runat="server"></asp:PlaceHolder>
                                        </div>--%>
                                        <div class="col-md-6">
                                            <asp:CheckBox runat="server" ID="cus_cusaccept" />Case accepted by customer &nbsp;<font class="cssrequired">*</font>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <div class="row mb-2" style="display: none;">
                                <div class="col-md-12">
                                    <asp:Label ID="lcnno" runat="server"></asp:Label>
                                    <asp:Label ID="lcnstatus" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-3">CN No&nbsp;</div>
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="litinvno" Text='<%#DataBinder.Eval(Container.DataItem, "cus_uno")%>'></asp:Literal>
                                        </div>
                                        <div class="col-md-3">CN Date&nbsp;<font class="cssrequired"></font></div>
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="litproduct" Text='<%#DataBinder.Eval(Container.DataItem, "cus_createdt")%>'></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">CN Amount&nbsp;</div>
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="lituom" Text='<%# WebLib.formatthemoney(DataBinder.Eval(Container.DataItem, "cus_cndnamt"))%>'></asp:Literal>
                                        </div>
                                        <div class="col-md-3">CN Status&nbsp;</div>
                                        <div class="col-md-3">
                                            <asp:Literal runat="server" ID="Literal3" Text='<%# If(DataBinder.Eval(Container.DataItem, "wst_status") = "Pending", DataBinder.Eval(Container.DataItem, "wst_status") & "Last Action On " & DataBinder.Eval(Container.DataItem, "statusdate"), DataBinder.Eval(Container.DataItem, "wst_status") & " On " & DataBinder.Eval(Container.DataItem, "statusdate"))%>'></asp:Literal>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <div class="row mb-2">
                                <div class=" col-sm-3">
                                    <asp:PlaceHolder ID="commentSubmit" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            
                            <div id="accordion" class="mb-2">
                                <div class="card">
                                    <div class="card-header p-1" id="headingOne">
                                        <h5 class="mb-0">
                                            <a class="btn btn-link" data-toggle="collapse" data-target="#Comments" aria-expanded="false" aria-controls="Comments" href="#">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="10px"><span class="ui-icon ui-icon-plusthick"></span></td>
                                                        <td width="100%">Previous Comments</td>
                                                    </tr>
                                                </table>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="Comments" class="p-2 table-responsive" aria-labelledby="headingOne" data-parent="#accordion">
                                        <table id="table_comments" class="table table-striped  form-body-fonts">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Reviewer</th>
                                                    <th scope="col">Comment</th>
                                                    <th scope="col">Activity</th>
                                                    <th scope="col">Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rep_comment" runat="server">
                                                    <ItemTemplate>
                                                        <tr id="trRow" runat="server">
                                                            <td>
                                                                <span class="fa fa-user"></span>
                                                                <asp:Label ID="rep_uid" runat="server" Text=' <%#Eval("usr_name") %>' />
                                                            </td>
                                                            <td>
                                                                <span class="fa fa-comment-o" style="color:darkblue"></span>
                                                                <asp:Label ID="rep_comment" runat="server" Text=' <%#Eval("comment") %>' />
                                                            </td>
                                                            <td>
                                                                <span class="fa fa-check" style="color:forestgreen"></span>
                                                                <asp:Label ID="rep_wf_level" runat="server" Text=' <%#Eval("wui_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_createddate" runat="server" Text=' <%#Eval("createddate") %>' />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div id="accordion2" class="mb-2">
                                <div class="card">
                                    <div class="card-header p-1" id="headingTwo">
                                        <h5 class="mb-0">
                                            <a class=" collapsed btn btn-link" data-toggle="collapse" data-target="#workflowlog" aria-expanded="false" aria-controls="workflowlog" href="#">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="10px"><span class="ui-icon ui-icon-plusthick"></span></td>
                                                        <td width="100%">Workflow Log</td>
                                                    </tr>
                                                </table>
                                            </a>
                                        </h5>
                                    </div>
                                    <div id="workflowlog" class="collapse table-responsive p-2" aria-labelledby="headingTwo" data-parent="#accordion2">
                                        <table id="table_audit" class="table table-striped w-100 form-body-fonts">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Activity</th>
                                                    <th scope="col">Action</th>
                                                    <th scope="col">User</th>
                                                    <th scope="col">Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rep_audit" runat="server">
                                                    <ItemTemplate>
                                                        <tr id="trRow" runat="server">
                                                            <td>
                                                                <asp:Label ID="rep_activity" runat="server" Text=' <%#Eval("wui_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_uid" runat="server" Text=' <%#Eval("wfa_code") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_comment" runat="server" Text=' <%#Eval("usr_name") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="rep_wf_level" runat="server" Text=' <%#Eval("wfa_createon") %>' />
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
                    </div>
                    <div class="col-md-4 bg-white" style="font-size: 0.8rem;">
                        <table class="ui-widget-header" width="100%">
                            <tr>
                                <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                <td width="100%"><span class="ui-widget"><b>Doc. Actions</b></span></td>
                            </tr>
                        </table>
                        <br />
                        <b>Ref. No:-</b><br />
                        <asp:TextBox ID="cus_refno" runat="server" Style="width: 95%" MaxLength="50"></asp:TextBox><br />
                        <br />
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Button ID="SubmitButton" Text="Save Record" runat="server" OnClick="savepage" Style="width: 100%" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="BackButton" Text="Back to Previous" runat="server" OnClick="backpagepage" Style="width: 100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <br />
                        <uc:Workflowbar ID="wfb_bar" runat="server" />
                    </div>
                </div>
                <br />
                <br />
                <input type="hidden" runat="server" id="ucode" name="ucode" />
                <input type="hidden" runat="server" id="rid" name="rid" />
                <input type="hidden" runat="server" id="bid" name="bid" />
                <input type="hidden" runat="server" id="cnum" name="cnum" />
                <input type="hidden" runat="server" id="ccode" name="ccode" />
                <input type="hidden" runat="server" id="lvlvalid" name="lvlvalid" />
                <input type="hidden" runat="server" id="createdt" name="createdt" />
            </div>
            <!--#include File="../../include/FormFooter1.aspx"-->
    </form>
    <!--#include File="../../include/footerscript.aspx"-->

    <script type="text/javascript">
        $(document).ready(function () {
            $('#table_comments').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
                "lengthChange": false,
                "bPaginate": false,
                "order": [["Date", "asc"]],
                "columnDefs": [{ "targets": "Date", "type": "date-eu" }]
            });

            $('#table_audit').DataTable({
                responsive: true,
                "info": false,
                "bFilter": false,
                "lengthChange": false,
                "bPaginate": false,
                "order": [["Date", "asc"]],
                "columnDefs": [{ "targets": "Date", "type": "date-eu" }]
            });
        });
    </script>
</body>
</html>

