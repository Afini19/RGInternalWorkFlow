
<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="edocstate.aspx.vb" Inherits="edocstate_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<script src="jquery/js/jquery.js"></script>    
<script src="jquery/js/jquery-ui.js"></script>    
<link rel="stylesheet" href="jquery/css/default/jquery.default.css">
<link rel="stylesheet" href="Styles/cssdefault.css">
<script src="plugins/validator/languages/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="plugins/validator/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<link rel="stylesheet" href="plugins/validator/css/validationEngine.jquery.css" type="text/css"/>
<script>
$(function() {
$( "input[type=submit], button" )
.button();    
$( "#tabs" ).tabs();       
jQuery("#frmform").validationEngine('attach', {promptPosition : "topRight", scroll: true, showArrow : true, focusFirstField : false});
$( "#divnavi" ).accordion({collapsible: false,heightStyle: "content",active: 0});
$( "#divdetails" ).accordion({collapsible: false,heightStyle: "content",active: 0});
});
</script>
</head>
<body>
<center>
<form id="frmform" runat="server">
<!--#include File="include/FormHeader1.aspx"-->
<table width="100%">
<tr><td align="left" width="100%">
<table class="ui-widget-header"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td></tr></table>				
</td></tr>
<tr><td valign="top" width="100%">
<table width="100%" cellpadding="0" cellspacing="2"><tr><td width="220px" valign="top">
<div id="divnavi">
<h3>Options Menu</h3>
<div>
<asp:Button ID="SubmitButton" Text="Save Details" Runat="server" OnClick="savepage" style="width:160px"  /> <br />
<asp:Button ID="BackButton" Text="Back to Listing" Runat="server" OnClick="backpage" style="width:160px" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  /> 
<br /><br />
<b>Messages:</b><br />
<asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
<br /><br /><br />
</div>
</div>
<div id="divdetails" style="text-align:left">
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
<div id="tabs">  
<ul>   
<li><a href="#tabs-1">eDocument : Statement</a></li>    
</ul>  
<div id="tabs-1">
<table width="100%">
<tr><td class="csssubheader" colspan="2">Please fill in details below</td></tr>
<tr><td class="csssubheader" colspan="2"><hr width="100%" class="cssdivider" /></td></tr>

<tr><td class="cssdetail" valign="top" align="left" width="200">Year&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="edoc_year" runat="server"  style="width:100px" Maxlength="4" class="validate[required]" ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Month&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="edoc_month" runat="server"  style="width:100px" Maxlength="2" class="validate[required]" ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Branch</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="edoc_branch" runat="server"  style="width:50px" Maxlength="50"  ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Document Type&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:DropDownList ID="edoc_type" runat="server" class="validate[required]" ></asp:dropdownlist></td></tr>

</table></div> 
</div>
</td></tr></table>
<br /><br />
<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
</td></tr></table>
<!--#include File="include/FormFooter1.aspx"-->
</form>
</center>
</body>
</html>

