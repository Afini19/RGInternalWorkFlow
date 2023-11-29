<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="cn3.aspx.vb" Inherits="cn3_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="~/UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar2.ascx" TagPrefix="uc" TagName="Workflowbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
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
    <script type="text/javascript">
        function OpenColorBox() {
            $.colorbox({
                opacity: 0.1,
                width: '350px',
                height: '350px',
                iframe: true,
                href: 'www.yahoo.com',
                onLoad: function () {
                    $('#cboxClose').remove();
                },
                onClosed: function () {
                }
            });
        }
    </script>
    <!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <div class="container-fluid ">
            <!--#include File="../../include/FormHeader1.aspx"-->

            <div class=" container bg-light" style="font-size: 1rem;">
                <div class="row listpage">
                    <div class="col-md-8 bg-light " style="font-size: 0.8rem;">
                        <div runat="server" id="mp">
                            <div class="row">
                                <table class="ui-widget-header" width="100%">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                        <td width="100%"><span class="ui-widget"><b><%=_FormsName%></b></span></td>
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
                                <div class="col-md-12" style="text-align: right;">CCR No :&nbsp;<asp:Label ID="lblccrno" runat="server"></asp:Label></div>
                            </div>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-3">&nbsp;<font class="cssrequired"></font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:RadioButtonList runat="server" ID="cus_custype" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">Customer Name&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_company" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">CN Type&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="cus_cndntype" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">Reason Due To&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="cus_cndnreason" runat="server" TextMode="MultiLine" Style="width: 100%; height: 60px" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">CN Amount&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="cus_cndnamt" runat="server" Style="width: 100%" MaxLength="50" class="validate[required,custom[number]]" ValidationGroup="1-"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-5">Invoice Month</div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="cus_cndnmth" runat="server" class="validate[required]" ValidationGroup="1-"></asp:DropDownList>
                                            <asp:DropDownList ID="cus_cndnyear" runat="server" class="validate[required]" ValidationGroup="1-"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            
                            <% If createdt.Value >= Convert.ToDateTime(ConfigurationManager.AppSettings("CR2023005")) Then %>
                            <div class="row mb-1">
                                <div class="col-md-3">Account Holder&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-9">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_accountholder" runat="server" Style="width: 100%" ValidationGroup="1-" class="validate[required]"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <% End if %>


                            <% If wfb_bar.wlevelAPget().tostring.trim = "2" Then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <b>Validation by Credit Control:</b><asp:PlaceHolder ID="phlevel3" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-12">
                                    <table width="100%" cellpadding="1" cellspacing="1" style="background-color: gray">
                                        <tr>
                                            <td class="cssdetail" align="center" style="background-color: White; border: solid 0.5px black;" width="33%">
                                                <asp:CheckBox runat="server" ID="cus_justification" TextAlign="Left" Text="Justification " /></td>
                                            <td class="cssdetail" align="center" style="background-color: White; border: solid 0.5px black;" width="33%">
                                                <asp:CheckBox runat="server" ID="cus_workings" TextAlign="Left" Text="Workings " /></td>
                                            <td class="cssdetail" align="center" style="background-color: White; border: solid 0.5px black;" width="33%">
                                                <asp:CheckBox runat="server" ID="cus_documents" TextAlign="Left" Text="Documents " /></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%End if %>


                            <% If lvlvalid.Value = "True" And wfb_bar.wlevelAPget().tostring.trim = "" And Not backend.closed(ucode.Value) then %>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <b><%= wfb_bar.wlevelNameget().tostring.trim %></b><asp:PlaceHolder ID="lblrcm" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500" class="validate[required]"></asp:TextBox>
                                </div>
                            </div>
                            <% End if %>


                            <div class="row">
                                <div class="col-md-12"><b>Workings:</b></div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-12" style="overflow-x: auto;">
                                    <table width="100%" cellpadding="5" cellspacing="1" style="background-color: Gray">
                                        <tr>
                                            <td class="cssdetail" width="4%" align="center" style="color: white">No.</td>
                                            <td class="cssdetail" width="20%" align="left" style="color: white">Invoice No / Month</td>
                                            <td class="cssdetail" width="25%" align="left" style="color: white">Product Desciption</td>
                                            <td class="cssdetail" width="11%" align="center" style="color: white">Rate<br />
                                                (RM)</td>
                                            <td class="cssdetail" width="10%" align="center" style="color: white">Qty</td>
                                            <td class="cssdetail" width="9%" align="left" style="color: white">UOM</td>
                                            <td class="cssdetail" width="14%" align="center" style="color: white">Amount<br />
                                                (RM)</td>
                                        </tr>
                                        <asp:Repeater ID="rep" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="center">
                                                        <asp:HiddenField ID="cusi_id" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "cusi_id")%>' />
                                                        <asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black">
                                                        <asp:Literal runat="server" ID="litinvno" Text='<%#DataBinder.Eval(Container.DataItem, "cus_invno")%>'></asp:Literal>
                                                        <asp:TextBox ID="txtinvno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cus_invno")%>' Style="width: 85%" MaxLength="20" ValidationGroup="1-"></asp:TextBox>
                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black">
                                                        <asp:Literal runat="server" ID="litproduct" Text='<%#DataBinder.Eval(Container.DataItem, "cus_itemdesc")%>'></asp:Literal>
                                                        <asp:DropDownList ID="txtproduct" runat="server" Style="width: 100%" ValidationGroup="1-"></asp:DropDownList>
                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                        <asp:Literal runat="server" ID="litrebate"></asp:Literal>
                                                        <asp:TextBox ID="txtrebate" runat="server" Style="width: 85%" MaxLength="10" ValidationGroup="1-" class="validate[custom[number]]"></asp:TextBox>
                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                        <asp:Literal runat="server" ID="litqty" Text='<%#DataBinder.Eval(Container.DataItem, "cus_qty")%>'></asp:Literal>
                                                        <asp:TextBox ID="txtqty" runat="server" Style="width: 85%" MaxLength="10" ValidationGroup="1-" class="validate[custom[number]]"></asp:TextBox>
                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black">
                                                        <asp:Literal runat="server" ID="lituom" Text='<%#DataBinder.Eval(Container.DataItem, "cus_uom")%>'></asp:Literal>
                                                        <asp:DropDownList ID="txtuom" runat="server" Style="width: 100%" ValidationGroup="1-"></asp:DropDownList>

                                                    </td>
                                                    <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                        <asp:Literal runat="server" ID="litamt"></asp:Literal></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr runat="server" id="rwsubtotal">
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="center">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black"><b>Subtotal</b></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black"></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                <asp:Literal runat="server" ID="litsubtotal"></asp:Literal></td>
                                        </tr>
                                        <tr runat="server" id="rwgst">
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="center">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black"><b>Add : GST
                                                <asp:Literal runat="server" ID="litgstrate"></asp:Literal>%</b></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black"></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                <asp:Literal runat="server" ID="litgst"></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="center">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black"><b>Total :</b></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                <asp:Literal runat="server" ID="littotalqty"></asp:Literal></td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black">&nbsp;</td>
                                            <td class="cssdetail" style="background-color: white; border: solid 0.5px black" align="right">
                                                <asp:Literal runat="server" ID="littotal"></asp:Literal></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12"><b>Documents:</b></div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-12" style="overflow-x: auto;">
                                    <table width="100%" cellpadding="1" cellspacing="1" style="background-color: gray">
                                        <tr>
                                            <td class="cssdetail" width="20%" style="background-color: White; border: solid 0.5px black" rowspan="2">Please ensure relevant supporting documents are complete</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">Rebate Master</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">PO</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">Invoice</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">DO</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">RMA Report</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">Diversion Report</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">Incentive Details</td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">Others</td>
                                        </tr>
                                        <tr>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc1" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc2" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc3" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc4" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc5" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc6" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc7" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                            <td class="cssdetail" width="10%" align="center" style="background-color: White; border: solid 0.5px black">
                                                <asp:CheckBox runat="server" ID="cus_doc8" TextAlign="Left" Text="" ValidationGroup="1-2-3-" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-sm-3">
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
                                <hr />
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
                        <b>Support Ticket No:-</b><br />
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
                <input type="hidden" runat="server" id="isgst" name="isgst" />
                <input type="hidden" runat="server" id="lvlvalid" name="lvlvalid" />

                <input type="hidden" runat="server" id="ccr" name="ccr">
                <input type="hidden" runat="server" id="disabled" name="disabled">
                <input type="hidden" runat="server" id="createdt" name="createdt" />
            </div>


            <!--#include File="../../include/FormFooter1.aspx"-->
        </div>
        <script language="javascript">
            $(document).ready(function () {
                var isIE = false;
                if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                    isIE = true;
                }
                if (isIE == true) {
                    $("input[type=text]:disabled,textarea:disabled").each(function () {
                        $(this).removeAttr("disabled");
                        $(this).attr("unselectable", "on");
                    })
                };
            });
        </script>
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

