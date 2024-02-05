<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="stI.aspx.vb" Inherits="stI_class" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="~/UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar2.ascx" TagPrefix="uc" TagName="Workflowbar" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta content="True" name="HandheldFriendly"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0"/>
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
    <script type="">
        $(function () {
            $("input[type=submit],input[type=button], button")
            .button();
            jQuery("#frmform").validationEngine('attach', { promptPosition: "topRight", scroll: false, showArrow: true, focusFirstField: false });
        });
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
        <div class="container-fluid">
            <!--#include File="../../include/FormHeader1.aspx"-->

            <asp:ScriptManager runat="server" EnablePartialRendering="true" EnablePageMethods="true"></asp:ScriptManager>
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
                                <div class="col-md-12" style="text-align: right;">Task No :&nbsp;<asp:Label ID="lbltaskno" runat="server"></asp:Label></div>
                            </div>
                            <div class="row">
                                <hr width="100%" class="cssdivider" />
                            </div>


                            <div class="row mb-1" hidden="hidden">
                                <div class="col-md-4" >Title&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_title" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-" Enabled="false" Visible="false">Support Ticket</asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4" >Title&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_ticketTitle" runat="server" TextMode="MultiLine" Style="width: 100%; height: 50px" MaxLength="300" class="validate[required]" ValidationGroup="1-"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Type of Issue&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_issuetype" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-" Enabled="false">Internal Issue</asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Date&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-4">
                                    <div class=" validation-content" style="position: relative;">
                                        <uc:datepicker ID="cus_date" runat="server" Style="width: 100%" class="validate[required]" ValidationGroup="1-" Enabled="false"/>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Support Ticket Number&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_stno" runat="server" Style="width: 100%" MaxLength="50" class="validate[required]" ValidationGroup="1-" Enabled="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Department&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
<%--                                        <asp:DropDownList ID="cus_department" runat="server" CssClass="validate[required]" Width="100%" ValidationGroup="1-" AutoPostBack="true" OnSelectedIndexChanged="cus_department_SelectedIndexChanged"></asp:DropDownList>--%>
                                        <asp:DropDownList ID="cus_department" runat="server" CssClass="validate[required]" Width="100%" ValidationGroup="1-" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">1st level Category&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <%--<asp:DropDownList ID="cus_category" runat="server" Style="width: 100%" ValidationGroup="1-" CssClass="validate[required]" AutoPostBack="true" OnSelectedIndexChanged="cus_category_SelectedIndexChanged"></asp:DropDownList>--%>
                                        <asp:DropDownList ID="cus_category" runat="server" Style="width: 100%" ValidationGroup="1-" CssClass="validate[required]" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">2nd level Module&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_module" runat="server" Style="width: 100%" ValidationGroup="1-" class="validate[required]"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Customer&nbsp;</div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_customer" runat="server" Style="width: 100%" ValidationGroup="1-" class="validate"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Priority&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:DropDownList ID="cus_priority" runat="server" Style="width: 100%" ValidationGroup="1-" class="validate[required]"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Development man-days&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_devmandays" runat="server" Style="width: 70%" MaxLength="50" class="validate[required,custom[number]]" ValidationGroup="1-" ></asp:TextBox>&nbsp;man-days
                                    </div>
                                </div>

                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Internal testing man-days&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:TextBox ID="cus_testingmandays" runat="server" Style="width: 70%" MaxLength="50" class="validate[required,custom[number]]"  ValidationGroup="1-"></asp:TextBox>&nbsp;man-days
                                    </div>
                                </div>

                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">Technical Requirement&nbsp;</div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
<%--                                        <asp:TextBox ID="cus_description" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500" class="validate[required]" ValidationGroup="1-"></asp:TextBox>  --%>
                                        <CKEditor:CKEditorControl ID="cus_technicalReq" runat="server" Width="100%" Height="300px" ValidationGroup="1-"></CKEditor:CKEditorControl>
                                    </div>
                                </div>
                            </div>
                            

                            <div class="row mb-1">
                                <div class="col-md-4">Tags&nbsp;<font class="cssrequired">*</font></div>
                                <div class="col-md-8">
                                    <div class="validation-content" style="position: relative;">
                                        <asp:CheckBoxList runat="server" ID="cus_tags" RepeatDirection="Horizontal" ValidationGroup="1-"/>
                                    </div>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">&nbsp;</div>
                                <div class="col-md-8">
                                    <asp:PlaceHolder ID="phlevel1" runat="server"></asp:PlaceHolder>
                                </div>

                            </div>

                            
<%--                            <% If lvlvalid.Value = "True" And wfb_bar.wlevelAget().tostring.trim <> "" And wfb_bar.wlevelAget().tostring.trim <> "1" And Not backend.closed(uid.Value) then %>--%>
                            <%--<% If lvlvalid.Value = "True" And wfb_bar.wlevelAPget().tostring.trim = "" And Not backend.closed(uid.Value) Then %>--%>
                            <% If lvlvalid.Value = "True" And Not backend.closed(uid.Value) Then %>
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
                                    <asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" Style="width: 100%; height: 100px" MaxLength="500" class="validate"></asp:TextBox>
                                </div>
                            </div>

                            <% End if %>  

                            <%If lvlvalid.Value = "True" And wfb_bar.wlevelAPget().tostring.trim = "5" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Development dues date&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-7">
                                            <div class="validation-content" style="position: relative;">
                                                <uc:datepicker ID="cus_devduedate" runat="server" AllowNull="false" class="validate[required]" Width="100%" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Developer name&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-7">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:DropDownList ID="cus_devname" runat="server" Style="width: 100%" class="validate[required]"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


                            <%If lvlvalid.Value = "True" And wfb_bar.wlevelAPget().tostring.trim = "7" Then %>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row mb-1">
                                        <div class="col-md-3">Tester name&nbsp;<font class="cssrequired">*</font></div>
                                        <div class="col-md-7">
                                            <div class="validation-content" style="position: relative;">
                                                <asp:DropDownList ID="cus_testername" runat="server" Style="width: 100%" class="validate[required]"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel runat="server">
                                 <ContentTemplate>
                                     <div class="row mb-1">
                                         <div class="col-md-3">Testing Status&nbsp;<font class="cssrequired">*</font></div>
                                         <div class="col-md-7">
                                             <div class="validation-content" style="position: relative;"> 
                                                 <asp:DropDownList ID="cus_testingstatus" runat="server" Style="width: 100%" class="validate[required]" AutoPostBack="true"></asp:DropDownList>
                                             </div>
                                         </div>

                                     </div>
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                            <%End if %>


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
                        
                        <%If wfb_bar.wlevelAPget().tostring.trim = "" Or wfb_bar.wlevelAPget().tostring.trim = "1" And WebLib.LoginUser = "OPS" Then %>
                        <br />
                        <div class="row mb-1">
                            <div class="col-md-12">
                                <b>* Ticket Draft only valid for 30 days</b>
                            </div>
                        </div>
                        <%End if %>

                       
                        <b style="visibility:hidden">Ref. No:-</b><br />
                        <asp:TextBox ID="cus_refno" runat="server" Style="width: 95%" MaxLength="50" Visible="false"></asp:TextBox><br />
                        

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
                        <br />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <br />
                        <uc:Workflowbar ID="wfb_bar" runat="server" />
                    </div>
                </div>

                <br />
                <br />
                <input type="hidden" runat="server" id="uid" name="uid" />
                <input type="hidden" runat="server" id="rid" name="rid" />
                <input type="hidden" runat="server" id="bid" name="bid" />
                <input type="hidden" runat="server" id="cnum" name="cnum" />
                <input type="hidden" runat="server" id="ccode" name="ccode" />
                <input type="hidden" runat="server" id="lvlvalid" name="lvlvalid" />
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

        $(document).on('change', '#cus_department', function (event) {
            event.preventDefault();


            var selectedValue = $(this).val();

            $.ajax({
                type: "POST",
                url: "crC.aspx/LoadCategories",
                data: JSON.stringify({ departmentId: selectedValue }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    var categories = response.d;

                    $("#cus_category").empty();

                    $.each(categories, function (index, category) {
                        $("#cus_category").append($('<option>', {
                            value: category.Value,
                            text: category.Text
                        }));
                    });
                }
            });
        });

        $(document).on('change', '#cus_category', function (event) {
            event.preventDefault();


            var selectedValue = $(this).val();

            $.ajax({
                type: "POST",
                url: "crC.aspx/LoadModules",
                data: JSON.stringify({ categoryId: selectedValue }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    var module1 = response.d;

                    $("#cus_module").empty();

                    $.each(module1, function (index, module2) {
                        $("#cus_module").append($('<option>', {
                            value: module2.Value,
                            text: module2.Text
                        }));
                    });
                }
            });
        });

    </script>
</body>
</html>

