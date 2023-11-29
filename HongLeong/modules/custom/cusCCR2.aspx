<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="cusccr2.aspx.vb" Inherits="cusccr2_class" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
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
<script src="<%=ResolveClientUrl("~/plugins/blocker/jquery.blockUI.js")%>" type="text/javascript" charset="utf-8"></script>
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
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_FormsName%></b></span></td></tr></table>				
</td></tr>
<tr><td valign="top" width="100%">

<table width="100%" cellpadding="0" cellspacing="2"><tr>
<td valign="top" width="100%">
<div id="tabs">  
<table width="100%" cellspacing="1" cellpadding="1">

<tr><td class="cssdetail" colspan="6" align="center">
<table width="100%"><tr>
<td class="cssdetail" align="left" style="width:25%">
&nbsp;
</td><td align="center" class="csssubheader" style="width:50%">
<%=_FormsName%>
</td>
<td class="cssdetail" align="right"  style="width:25%">
Ref No :&nbsp;<asp:label ID="lblrefno" runat="server"></asp:label>
</td>
</tr></table>


</td></tr>

<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>A) CUSTOMER DESCRIPTION</b></td></tr>
<tr><td class="cssdetail" valign="middle" align="left" width="30%">Distributor Name&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left"  width="70%"><asp:Textbox ID="cus_distributor" runat="server"  style="width:99%" Maxlength="50" class="validate[required]" ValidationGroup="0-" ></asp:Textbox></td>
</tr>
<tr><td class="cssdetail" valign="middle" align="left">Customer Name&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_customer" runat="server"  style="width:99%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:Textbox></td>
</tr>
<tr>
    <td class="cssdetail" valign="middle" align="left">Location&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_location" runat="server"  style="width:99%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:Textbox></td>
 </tr>
<tr><td class="cssdetail" valign="middle" align="left">Person to Contact On Site&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_person" runat="server"  style="width:95%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:Textbox></td>
    <td class="cssdetail" valign="middle" align="left">&nbsp;&nbsp;&nbsp;Tel No&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_telno" runat="server"  style="width:98%" Maxlength="50" ValidationGroup="1-" ></asp:Textbox></td>
 </tr>
<tr><td class="cssdetail" valign="middle" align="left">Date of Complaint&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left" width="25%">
    <uc:datepicker ID="cus_dateofcomplaint" runat="server" AllowNull="false" class="validate[required]" ValidationGroup="1-" width="100%" />    
    </td>
<td class="cssdetail" valign="middle" align="left" width="20%">&nbsp;&nbsp;&nbsp;H/P&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left" width="25%"><asp:Textbox ID="cus_hp" runat="server"  style="width:98%" Maxlength="50" ValidationGroup="1-" ></asp:Textbox></td>

 </tr>
<tr><td class="cssdetail" colspan="4" align="left">&nbsp;</td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>B) COMPLAINT DESCRIPTION</b><asp:Label runat="server" ID="lbllevel1"></asp:Label><asp:PlaceHolder ID="phlevel1" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" valign="middle" align="left">D/O Number&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_dono" runat="server"  style="width:95%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:Textbox></td>
<td class="cssdetail" valign="middle" align="left">&nbsp;&nbsp;&nbsp;Transporter&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_transporter" runat="server"  style="width:98%" Maxlength="50" ValidationGroup="1-" ></asp:Textbox></td>
 </tr>

<tr>
    <td class="cssdetail" valign="middle" align="left">Product&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_product" runat="server"  style="width:95%" Maxlength="50" class="validate[required]" ValidationGroup="1-" ></asp:Textbox></td>
    <td class="cssdetail" valign="middle" align="left">&nbsp;&nbsp;&nbsp;Quantity&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Textbox ID="cus_qty" runat="server"  style="width:98%" Maxlength="50" ValidationGroup="1-" ></asp:Textbox></td>
 </tr>
<tr><td class="cssdetail" valign="top" align="left">Description of Complaint&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left">
    <asp:TextBox ID="cus_description" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="1-" ></asp:TextBox>
    </td>
</tr>    
<tr><td class="cssdetail" valign="top" align="left">Classification&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left">
    <asp:DropDownList ID="cus_classification" runat="server" style="width:100%" ValidationGroup="1-" AutoPostBack="true"></asp:DropDownList>
    </td>
</tr>
<tr><td class="cssdetail" valign="top" align="left">Complaint&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="3" class="cssdetail"  valign="top" align="left">
    <asp:DropDownList ID="cus_complaint" runat="server" style="width:100%" ValidationGroup="1-"  ></asp:DropDownList>
    </td>
</tr>
<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>C) COMMENTS BY SITE INVESTIGATOR (SALES)</b><asp:Label runat="server" ID="lbllevel2"></asp:Label><asp:PlaceHolder ID="phlevel2" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_investigatorremarks" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="2-" ></asp:TextBox>
</td></tr>
<tr><td class="cssdetail" valign="top" align="left">&nbsp;</td>
    <td colspan="1" class="cssdetail"  valign="top" align="left">&nbsp;</td>
    <td class="cssdetail" valign="middle" align="left">Date Of Visit&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left" width="25%">
        <uc:datepicker ID="cus_investigatordate" runat="server" AllowNull="false" class="validate[required]" ValidationGroup="2-" width="100%" />    
    
    </td>
 </tr>

<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>D) MANAGER, SALES </b><asp:Label runat="server" ID="lbllevel3"></asp:Label><asp:PlaceHolder ID="phlevel3" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_salesmanager" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="3-" ></asp:TextBox>
</td></tr>




<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>E) QC / LOGISTIC / PRODUCTION / SALES FINDINGS</b><asp:Label runat="server" ID="lbllevel4"></asp:Label><asp:PlaceHolder ID="phlevel4" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_qcfindings" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="4-" ></asp:TextBox>
</td></tr>
<tr>
<td class="cssdetail" valign="middle" align="left">Valid&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left">
                <asp:RadioButtonList runat="server" ID="cus_valid" RepeatDirection="Horizontal" ValidationGroup="4-">
                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                <asp:ListItem Value="No">No</asp:ListItem>
                </asp:RadioButtonList>
    </td>
    <td class="cssdetail" valign="middle" align="left">&nbsp;</td>
    <td colspan="1" class="cssdetail"  valign="top" align="left">
    
&nbsp;    
    
        </tr>







<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>F) CORRECTIVE / PREVENTIVE ACTION</b><asp:Label runat="server" ID="lbllevel5"></asp:Label><asp:PlaceHolder ID="phlevel5" runat="server" ></asp:PlaceHolder></td></tr>

<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_corrective" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="5-" ></asp:TextBox>
</td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:checkbox runat="server" id="cus_rootcause" ValidationGroup="5-" Enabled="false" /> &nbsp;<font class="cssrequired">*</font> Root Cause Analysis attachment is mandatory for Valid case
</td></tr>

<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>G) PLANT MANAGER</b><asp:Label runat="server" ID="lbllevel6"></asp:Label><asp:PlaceHolder ID="phlevel6" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_plantmgr" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="6-" ></asp:TextBox>
</td></tr>




<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>H) IMMEDIATE ACTION</b><asp:Label runat="server" ID="lbllevel7"></asp:Label><asp:PlaceHolder ID="phlevel7" runat="server" ></asp:PlaceHolder></td></tr>
<tr>
<td class="cssdetail" valign="top" align="left" colspan="2">

   <asp:RadioButtonList runat="server" ID="cus_immediateaction" RepeatDirection="Vertical"  ValidationGroup="7-" AutoPostBack="true">
                <asp:ListItem Value="Compensate">COMPENSATE (Credit note requisition is needed)</asp:ListItem>
                <asp:ListItem Value="Not Compensate">NOT COMPENSATE</asp:ListItem>
                </asp:RadioButtonList>

</td>
    <td class="cssdetail" valign="top" align="left" style="display:none;">Date of Action&nbsp;<font class="cssrequired">*</font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left" style="display:none;">    
           <uc:datepicker ID="cus_immediatedate" runat="server" AllowNull="false" class="validate[required]" ValidationGroup="7-" width="100%" enabled="false" />     
</td>
</tr>
<tr>
<td class="cssdetail" valign="top" align="left" colspan="3">
</td>
<td class="cssdetail"  valign="top" align="right">
    <asp:Button ID="btnCN" Text="Credit Note" runat="server" Visible="false"/> 
</td>
</tr>






<%--<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr>
<tr><td class="cssdetail" colspan="4" align="left"><b>I) CASE ACCEPTED BY CUSTOMER (ATTACH DOC)</b><asp:Label runat="server" ID="lbllevel8"></asp:Label><asp:PlaceHolder ID="phlevel8" runat="server" ></asp:PlaceHolder></td></tr>
<tr>
    <td colspan="4" class="cssdetail"  valign="top" align="left">
                <asp:RadioButtonList runat="server" ID="cus_cusaccept" RepeatDirection="Horizontal"  ValidationGroup="8-">
                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                <asp:ListItem Value="No">No</asp:ListItem>
                </asp:RadioButtonList>
    </td>
 </tr>--%>


<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr><%--J)--%>
<tr><td class="cssdetail" colspan="4" align="left"><b>I) CASE CLOSED BY SENIOR MANAGER, SALES / MANAGER, SALES </b><asp:Label runat="server" ID="lbllevel8"></asp:Label><asp:PlaceHolder ID="phlevel8" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">REMARKS:</td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_gmsalesremarks" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="8-" ></asp:TextBox>
</td></tr>


<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr><%--K)--%>
<tr><td class="cssdetail" colspan="4" align="left"><b>J) CASE VERIFIED BY MD</b><asp:Label runat="server" ID="lbllevel9"></asp:Label><asp:PlaceHolder ID="phlevel9" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">REMARKS:</td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_gmremarks" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="9-" ></asp:TextBox>
</td></tr>

<tr><td class="csssubheader" colspan="4"><hr width="100%" class="cssdivider" /></td></tr><%--L)--%>
<tr><td class="cssdetail" colspan="4" align="left"><b>K) CASE CLOSED BY SALES</b><asp:Label runat="server" ID="lbllevel10"></asp:Label><asp:PlaceHolder ID="phlevel10" runat="server" ></asp:PlaceHolder></td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:checkbox runat="server" id="cus_cusaccept" ValidationGroup="10-" />Case accepted by customer &nbsp;<font class="cssrequired">*</font>
</td></tr>
<tr><td class="cssdetail" colspan="4" align="left">REMARKS:</td></tr>
<tr><td class="cssdetail" colspan="4" align="left">
    <asp:TextBox ID="cus_salesclose" runat="server" TextMode="MultiLine" style="width:100%;height:100px" Maxlength="500" ValidationGroup="10-" ></asp:TextBox>
</td></tr>

    <asp:label ID="lcnno" runat="server"></asp:label>
    <asp:label ID="lcnstatus" runat="server"></asp:label>
<asp:Repeater ID="rep" runat="server">
<ItemTemplate>
<tr><td class="cssdetail" valign="middle" align="left">CN No&nbsp;</td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Literal runat="server" ID="litinvno" Text='<%#DataBinder.Eval(Container.DataItem, "cus_uno")%>'></asp:Literal> </td>
    <td class="cssdetail" valign="middle" align="left">&nbsp;&nbsp;&nbsp;CN Date&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Literal runat="server" ID="litproduct" Text='<%#DataBinder.Eval(Container.DataItem, "cus_createdt")%>'></asp:Literal></td>
</tr>
<tr><td class="cssdetail" valign="middle" align="left">CN Amount&nbsp;</td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Literal runat="server" ID="lituom" Text='<%# WebLib.formatthemoney(DataBinder.Eval(Container.DataItem, "cus_cndnamt"))%>'></asp:Literal></td>
    <td class="cssdetail" valign="middle" align="left">&nbsp;&nbsp;&nbsp;CN Status&nbsp;<font class="cssrequired"></font></td>
    <td colspan="1" class="cssdetail"  valign="top" align="left"><asp:Literal runat="server" ID="Literal1" Text='<%#DataBinder.Eval(Container.DataItem, "wst_status")%>'></asp:Literal></td>
</tr>
<tr>
    <td colspan="3" class="cssdetail"  valign="top"></td>
    <td colspan="1" class="cssdetail"  valign="top"><asp:Literal runat="server" ID="Literal2" Text='<%# If(DataBinder.Eval(Container.DataItem, "wst_status") = "Pending", "Last Action On " & DataBinder.Eval(Container.DataItem, "statusdate"), "On " & DataBinder.Eval(Container.DataItem, "statusdate"))%>'></asp:Literal>
    </td>
</tr>
<tr><td colspan="4">&nbsp;</td></tr>
</ItemTemplate>
</asp:Repeater>

</table>

<br />

</div> 
</td></tr></table>

<br /><br />
<input type="hidden" runat="server" id="ucode" name="ucode">

<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
<input type="hidden" runat="server" id="cnum" name="cnum">
<input type="hidden" runat="server" id="ccode" name="ccode">



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
<asp:Button ID="BackButton" Text="Back to Previous" Runat="server" OnClick="backpagepage"  style="width:100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  />
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
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("input[name*='dobj']").click(function () {
            $.blockUI({css: {border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff'},message: '<h1>Processing....Please wait</h1><h3>Please do not click refresh or back button</h3>' });        
        });
    });
</script>

</form>
</body>
</html>

