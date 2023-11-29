<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="dncn_list.aspx.vb" Inherits="dncn_list_class" %>


<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<!--Generated by ViSoftLabs Forms Generator (http://www.vifeandi.net)-->
<meta charset="utf-8">
<title></title>
<!--#include File="../../topinit.aspx"-->
<script>
   $(function() {
   $( "input[type=submit], button" )
   .button()
   var div1 = $( "#divnavi" ).accordion({collapsible: false,heightStyle: "content",active: 0});
   var div2 = $( "#divsearch" ).accordion({collapsible: false,heightStyle: "content",active: 0});
   var div3 = $( "#divdata" );
   div1.show();
   div2.show();
   div3.show();
   });
</script>
<!--#include File="../../topscript.aspx"-->
</head>
<body>
<form id="frmform" runat="server">
<!--#include File="../../include/FormHeader1.aspx"-->
<table width="100%">
<tr><td align="left" width="100%">
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td></tr></table>
</td></tr>
<tr>
<td valign="top" width="100%">
<table width="100%" cellpadding="0" cellspacing="2">
    <tr><td width="220px" valign="top">
<div id="divnavi" style="display:none" >
<h3>Options Menu</h3>
<div style="text-align:left">
<asp:Button ID="btnadd" Text="Add New Record" Runat="server"  OnClick="addeventadd" style="width:160px"   /><br /><br />


<b>View Document by Status:-</b><br />
<asp:Button ID="btnmy" Text="My Action Inbox" Runat="server" OnClick="shortcutmy" style="width:160px" CausesValidation="false" /><br />
<hr class="cssdivider" style="width:100%" />
<asp:PlaceHolder ID="phFilters" runat="server" ></asp:PlaceHolder>

<hr class="cssdivider" style="width:100%" />
<asp:Button ID="btn1" Text="Pending" Runat="server" OnClick="shortcut1" style="width:160px" CausesValidation="false" /><br />
<asp:Button ID="btn2" Text="Approved" Runat="server" OnClick="shortcut2" style="width:160px" CausesValidation="false"  /> <br />
<asp:Button ID="btn3" Text="Cancelled" Runat="server" OnClick="shortcut3" style="width:160px" CausesValidation="false"  /> <br />
<asp:Button ID="btn5" Text="Rejected" Runat="server" OnClick="shortcut4" style="width:160px" CausesValidation="false" /> <br /><br />


<asp:Button ID="btnback" Text="Back to Listing" Runat="server" OnClick="backpage" style="width:160px" CausesValidation="false" /> 
<br /><br />
<b>Messages:</b><br />
<asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
<br /><br /><br />
</div>
</div>
<div id="divsearch" style="display:none">
<h3>Search Menu</h3>
<div style="text-align:left">
<b>Please enter search key:</b><br />
<asp:TextBox ID="search_key1" runat="server" Columns="23" Maxlength="50"></asp:TextBox><br />
Search Field:<br />
<asp:PlaceHolder ID="phSearchFields" runat="server" ></asp:PlaceHolder>
<br />
<hr class="cssdivider" width="100%" runat="server" id="hrdate" /><br />
<uc:datepicker ID="uc_from" runat="server" AllowNull="false" Width="72px" PlaceHolder="From Date" />
<uc:datepicker ID="uc_to" runat="server" AllowNull="false" Width="72px" PlaceHolder="To Date" />
<asp:PlaceHolder ID="phSearchDate" runat="server" ></asp:PlaceHolder>
<br /><br />
<asp:Button ID="btnsearch" Text="Search" Runat="server"  OnClick="SearchStr" style="width:150px" /> 
</div>
</div>
</td>
<td  valign="top" width="100%" class="cssdetail"> 
            <div id="divdata" class="cssdetail">
            <asp:Literal ID="filterhead" runat="server"></asp:Literal>
            <hr width="100%" class="cssdivider" />
<table width="100%" cellpadding="0" cellspacing="2">
<tr>
    <td  valign="top" width="100%"> 


                    <table  width="100%" cellpadding="5" cellspacing="0">
                        <asp:Repeater ID="rep" runat="server"  OnItemCommand="rep_ItemCommand">
                        <ItemTemplate>
                                <tr id="trRow" class="ui-widget-content" runat="server">
                                <td align="center" class="cssdetail" width="48px" style="border-bottom: solid 1px silver" valign="top">
                                <asp:Literal ID="litimage" runat="server"></asp:Literal>
                                </td>
                                <td class="cssdetail"  style="border-bottom: solid 1px silver">
                                <asp:Literal ID="litData" runat="server"></asp:Literal>
                                </td>
                                </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                        <tr class="ui-widget-header"><td colspan="<%=columnscount%>" align="center" class="cssdetail" style="height:20px"><asp:label id="lblCurrentPage" runat="server"></asp:label></td></tr>
                    </table>
                    
</td></tr></table>


</div>
    <!--#include File="../../PageControl.aspx"-->
</td></tr>

</table>
</td>
</tr>
</table>

<input type="hidden" runat="server" id="wfid" name="wfid">
<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
<!--#include File="../../include/FormFooter1.aspx"-->
<hr width="100%" />
</form>
</body>
</html>

