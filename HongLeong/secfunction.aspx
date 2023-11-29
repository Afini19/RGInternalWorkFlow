
<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="secfunction.aspx.vb" Inherits="secfun_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/ImageUploader.ascx" TagPrefix="uc" TagName="ImageUploader" %>
<%@ Register Src="UserControls/FileUploader.ascx" TagPrefix="uc" TagName="FileUploader" %>
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
});
</script>
<!--#include File="topscriptdetail.aspx"-->
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
<div id="divnavi" style="display:none">
<h3>Options Menu</h3>
<div>
<asp:Button ID="SubmitButton" Text="Save Details" Runat="server" OnClick="savepage" style="width:160px"  /> <br /><br />
<asp:Button ID="BackButton" Text="Back to Listing" Runat="server" OnClick="backpage" style="width:160px" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  /> 
<br /><br />
<b>Messages:</b><br />
<asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
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
<li><a href="#tabs-1">Security Center - Function Code</a></li>    
</ul>  
<div id="tabs-1">
<table width="100%">
<tr><td class="csssubheader" colspan="2">Please fill in details below</td></tr>
<tr><td class="csssubheader" colspan="2"><hr width="100%" class="cssdivider" /></td></tr>

<tr><td class="cssdetail" valign="top" align="left" width="200">Application ID&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:DropDownList ID="ssf_appid" runat="server" class="validate[required]" ></asp:dropdownlist></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Function code&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_code" runat="server"  style="width:100px" Maxlength="20" class="validate[required]" ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Function name&nbsp;<font class="cssrequired">*</font></td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_name" runat="server"  style="width:300px" Maxlength="50" class="validate[required]" ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Add</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_add" runat="server"  style="width:150px" Maxlength="20"  ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Edit</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_edit" runat="server"  style="width:150px" Maxlength="20"  ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Delete</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_del" runat="server"  style="width:150px" Maxlength="20"  ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">View</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_view" runat="server"  style="width:150px" Maxlength="20"  ></asp:TextBox></td></tr>
<tr><td class="cssdetail" valign="top" align="left" width="200">Full</td><td colspan="1" class="cssdetail"  valign="top" align="left"><asp:TextBox ID="ssf_gotrights" runat="server"  style="width:150px" Maxlength="20"  ></asp:TextBox></td></tr>

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

