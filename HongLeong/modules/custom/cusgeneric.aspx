
<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="cusgeneric.aspx.vb" Inherits="cusgeneric_class" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="~/UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
<%@ Register Src="~/UserControls/Lookup.ascx" TagPrefix="uc" TagName="Lookup" %>
<%@ Register Src="~/UserControls/Workflowbar.ascx" TagPrefix="uc" TagName="Workflowbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=9" />
<meta content="True" name="HandheldFriendly">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
<meta name="viewport" content="width=device-width" />
<title></title>
<!--#include File="../../topinitdetail.aspx"-->

<script>
$(function() {
$( "input[type=submit],input[type=button], button" )
.button();    
jQuery("#frmform").validationEngine('attach', {promptPosition : "topRight", scroll: false, showArrow : true, focusFirstField : false});
});
</script>
<!--#include File="../../topscriptdetail.aspx"-->
</head>
<body>
<form id="frmform" runat="server">
<center>
<div class="container">    
<!--#include File="../../include/FormHeader1.aspx"-->
<div id="div1" class="verticalseparator">
&nbsp;
</div>

<div runat="server" id="middlepanel100p">

<table width="100%" cellpadding="0" cellspacing="0">
<tr><td align="left" width="100%">
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td></tr></table>				
</td></tr>
<tr><td valign="top" width="100%">

<table width="100%" cellpadding="0" cellspacing="2"><tr>
<td valign="top" width="100%">
<div id="tabs">  
<table width="100%">
<tr><td class="csssubheader" colspan="2" align="center"><%=_FormsName%></td></tr>
<tr><td class="csssubheader" colspan="2"><hr width="100%" class="cssdivider" /></td></tr>

<tr><td class="cssdetail" colspan="2" align="left"><b>Please Enter Subject / Description</b><asp:Label runat="server" ID="lbllevel1"></asp:Label></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="20%">Subject&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"  width="80%"><asp:Textbox ID="cus_subject" runat="server"  style="width:100%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left">Description&nbsp;<font class="cssrequired">*</font></td>
<td colspan="1" class="cssdetail"  valign="top" align="left">
<asp:TextBox ID="cus_remarks" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="1-" ></asp:TextBox>
</td></tr>
</table>



<br />

</div> 
</td></tr></table>

<br /><br />
<input type="hidden" runat="server" id="ucode" name="ucode">

<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
</td></tr></table>
</div>
<div id="divsep1" class="verticalseparator">
&nbsp;
</div>
<div id="rightpanelsmall">
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Doc. Actions</b></span></td></tr></table>				

<br />
<b>Ref. No:-</b><br />
<asp:Textbox ID="cus_refno" runat="server"  style="width:95%" Maxlength="50"></asp:TextBox><br /><br />

<table width="100%">
<tr><td>
<asp:Button ID="SubmitButton" Text="Save Record" Runat="server" OnClick="savepage"  style="width:100%" /> <br />
</td></tr>
<tr><td>
<asp:Button ID="BackButton1" Text="Back to Previous" Runat="server" OnClick="backpagepage"  style="width:100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  />
</td></tr>
</table>
<br />
<asp:Label ID="lblMessage" runat="server"></asp:Label>
<br />
<uc:Workflowbar ID="wfb_bar" runat="server" />
</div>

<!--#include File="../../include/FormFooter1.aspx"-->
</div>
</center>
</form>
</body>
</html>

