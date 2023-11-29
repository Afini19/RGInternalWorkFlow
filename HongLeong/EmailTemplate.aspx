
<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="EmailTemplate.aspx.vb" Inherits="emailtemplace_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<!--#include File="topinitdetail.aspx"-->
<script>
$(function() {
$( "input[type=submit],input[type=button], button" )
.button();    
$( "#tabs" ).tabs();       
jQuery("#frmform").validationEngine('attach', {promptPosition : "topRight", scroll: false, showArrow : true, focusFirstField : false});
var div1 = $( "#divnavi" ).accordion({collapsible: false,heightStyle: "content",active: 0});
var div2 = $( "#divdetails" ).accordion({collapsible: false,heightStyle: "content",active: 0});
var div3 = $( "#tabs" );
div1.show();
div2.show();
div3.show();
$("#tabs" ).tabs( "option", "heightStyle", "fill" );
});
</script>
<!--#include File="topscriptdetail.aspx"-->
</head>
<body>
<form id="frmform" runat="server">
<!--#include File="include/FormHeader1.aspx"-->
<table width="100%">
<tr><td align="left" width="100%">
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td></tr></table>				
</td></tr>
<tr><td valign="top" width="100%">
<table width="100%" cellpadding="0" cellspacing="2"><tr><td width="220px" valign="top">
<div id="divnavi" style="display:none">
<h3>Options Menu</h3>
<div>
<asp:Button ID="SubmitButton" Text="Save Details" Runat="server" OnClick="savepage" style="width:160px" UseSubmitBehavior="false" OnClientClick="if (jQuery('#frmform').validationEngine('validate') == false){return false;}" /> <br /><br />
<asp:Button ID="BackButton" Text="Back to Listing" Runat="server" OnClick="backpage" style="width:160px" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  /> 
<br /><br />
<b>Messages:</b><br />
<asp:Label ID="lblMessage" runat="server"></asp:Label>
<br /><br /><br />
</div>
</div>
<div id="divdetails" style="text-align:left" style="display:none">
<h3>Additional Details</h3>
<div>
<b>Created By:</b><br />
<asp:Literal ID="litcreateby" runat="server"></asp:Literal>
<br /><br />
<b>Created On:</b><br />
<asp:Literal ID="litcreateon" runat="server"></asp:Literal>
<br /><br />
<b>Last Update By: </b><br />
<asp:Literal ID="litupdateby" runat="server"></asp:Literal>
<br /><br />
<b>Last Update On: </b><br />
<asp:Literal ID="litupdateon" runat="server"></asp:Literal>
<br /><br />
</div>
</div>
</td>
<td  valign="top" width="100%">
<div id="tabs" style="display:none">  
<ul>   
<li><a href="#tabs-1">Email Template</a></li>    
</ul>  
<div id="tabs-1">
<table width="100%">
<tr><td class="csssubheader" colspan="2">Please fill in details below</td></tr>
<tr><td class="csssubheader" colspan="2"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" valign="top" align="left" colspan="2">


                    <table  width="100%" align="center">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="cssdetail">
                            <td style="text-align: right" width="200px">
                                <b><span class="RequiredField">*</span> Subject :</b>
                            </td>
                            <td class="cssdetail" align="left">
                                <asp:TextBox ID="email_subject" runat="server" Width="100%" class="validate[required]"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="cssdetail">
                            <td style="text-align: right" valign="top">
                                <b><span class="RequiredField">*</span> Content :</b>
                                <br /><br /><br />
                                <font size="2"><u>Required Fields:</u><br />
                                #Salutation#<br />
                                #FullName#<br />                                
                                #Email#<br />
                                #Company#<br />                                
                                #ConferenceID#<br />
                                #Password#<br />                                
                                #EventVenue#<br />
                                #EventDate#<br />
                                #EventName#<br />
                                #ClientName#<br />
                            </font>
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="email_body" runat="server" Width="100%" Height="450px">
                                
                                
                                
                               </CKEditor:CKEditorControl>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>



</td></tr>

</table></div> 
</div>
</td></tr></table>
<br /><br />
<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
</td></tr></table>
<!--#include File="include/FormFooter1.aspx"-->
</form>
</body>
</html>

