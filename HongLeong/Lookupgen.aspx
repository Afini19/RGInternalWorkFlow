<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="lookupgen.aspx.vb" Inherits="lookupgen_class" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<!--Generated by ViSoftLabs Forms Generator (http://www.vifeandi.net)-->
<meta charset="utf-8">
<title>Lookup</title>
<script>
   $(function() {
   $( "input[type=button], button" )
   .button()
   var divld = $( "#divlookupdata" );
   divld.show();
   });
</script>
</head>
<body>
<form id="frmlookup" runat="server">
<table width="100%">
<tr><td align="left" width="100%">
<table class="ui-widget-header ui-corner-all"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b><%=_formsname%></b></span></td></tr></table>
</td></tr>
<tr><td valign="top" width="100%">
<table width="100%" cellpadding="0" cellspacing="2"><tr>
<td  valign="top" width="100%" > 
<div id="divnavi" style="display:none">
<h3>Options Menu</h3>
<div style="text-align:left">
<b>Messages:</b><br />
<%--<asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>--%>
</div>
</div>
<div id="divlookupdata" style="display:none">
<b><asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label></b>
<table  width="100%"  style="height:80%; background-color:Gainsboro;" cellpadding="2" cellspacing="1">
<tr class="ui-widget-header" style="height:25px">
<td  class="cssdetail" width="20px"><b>No.</b></td>
<td class="cssdetail"><asp:Literal ID="lithead1" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail"><asp:Literal ID="lithead2" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail"><asp:Literal ID="lithead3" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail"><asp:Literal ID="lithead4" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail"><asp:Literal ID="lithead5" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail"><asp:Literal ID="lithead6" runat="server" Text=''></asp:Literal></td>
<td class="cssdetail" width="35px"></td>
</tr>
<asp:Repeater ID="rep" runat="server"  OnItemCommand="rep_ItemCommand" >
<ItemTemplate>
<tr id="trRow" class="ui-widget-content" runat="server">
<td align="center" class="cssdetail"  width="20px">
<asp:Literal ID="litNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Literal>
</td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field1")%>'></asp:Literal></td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field2")%>'></asp:Literal></td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field3")%>'></asp:Literal></td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field4")%>'></asp:Literal></td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field5")%>'></asp:Literal></td>
<td class="cssdetail" align="left"><asp:Literal ID="litfield6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "field6")%>'></asp:Literal></td>
<td align="center" class="cssdetail" width="35px">
<%--<input type="button" value="Select" onclick="javascript:document.getElementById('<%=returnobj1.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "rtnfield").replace("'","\'")%>';document.getElementById('<%=previewobj.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "previewfield").replace("'","\'")%>';document.getElementById('<%=selectflag.ClientID%>').value ='Y';document.getElementById('<%=param1.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param1").replace("'","\'")%>';document.getElementById('<%=param2.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param2").replace("'","\'")%>';document.getElementById('<%=param3.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param3").replace("'","\'")%>';document.getElementById('<%=param4.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param4").replace("'","\'")%>';document.getElementById('<%=param5.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param5").replace("'","\'")%>';document.getElementById('<%=param6.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param6").replace("'","\'")%>';document.getElementById('<%=param7.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param7").replace("'","\'")%>';document.getElementById('<%=param8.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param8").replace("'","\'")%>';document.getElementById('<%=param9.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param9").replace("'","\'")%>';document.getElementById('<%=param10.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param10").replace("'","\'")%>';$.colorbox.close();" />--%>
<input type="button" value="Select" onclick="javascript:document.getElementById('<%=returnobj1.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "rtnfield").replace("'","\'")%>';document.getElementById('<%=previewobj.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "previewfield").replace("'","\'")%>';document.getElementById('<%=selectflag.ClientID%>').value ='Y';document.getElementById('<%=param1.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param1").replace("'","\'")%>';document.getElementById('<%=param2.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param2").replace("'","\'")%>';document.getElementById('<%=param3.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param3").replace("'","\'")%>';document.getElementById('<%=param4.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param4").replace("'","\'")%>';document.getElementById('<%=param5.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param5").replace("'","\'")%>';document.getElementById('<%=param6.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param6").replace("'","\'")%>';document.getElementById('<%=param7.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param7").replace("'","\'")%>';document.getElementById('<%=param8.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param8").replace("'","\'")%>';document.getElementById('<%=param9.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param9").replace("'","\'")%>';document.getElementById('<%=param10.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param10").replace("'","\'")%>';document.getElementById('<%=param11.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param11").replace("'", "\'")%>';document.getElementById('<%=param12.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param12").replace("'", "\'")%>';document.getElementById('<%=param13.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param13").replace("'", "\'")%>';document.getElementById('<%=param14.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param14").replace("'", "\'")%>';document.getElementById('<%=param15.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param15").replace("'", "\'")%>';document.getElementById('<%=param16.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param16").replace("'", "\'")%>';document.getElementById('<%=param17.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param17").replace("'", "\'")%>';document.getElementById('<%=param18.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param18").replace("'", "\'")%>';document.getElementById('<%=param19.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param19").replace("'", "\'")%>';document.getElementById('<%=param20.ClientID%>').value ='<%#DataBinder.Eval(Container.DataItem, "param20").replace("'", "\'")%>';$.colorbox.close();" />
</td>
</tr>
</ItemTemplate>
</asp:Repeater>
<tr class="ui-widget-content">
<td colspan="<%=columnscount%>" align="center" class="cssdetail">
<asp:Literal ID="litspacing" runat="server"></asp:Literal>
</td>
</tr>
<tr class="ui-widget-header"><td colspan="<%=columnscount%>" align="center" class="cssdetail" style="height:20px"><asp:label id="lblCurrentPage" runat="server"></asp:label>
</td></tr>
</table>
</div>
</td></tr></table>
</td>
</tr>
</table>
<input type="hidden" runat="server" id="returnobj1" name="returnobj1" value="">
<input type="hidden" runat="server" id="returnobj2" name="returnobj2" value="">
<input type="hidden" runat="server" id="returnobj3" name="returnobj3" value="">
<input type="hidden" runat="server" id="returnobj4" name="returnobj4" value="">
<input type="hidden" runat="server" id="returnobj5" name="returnobj5" value="">
<input type="hidden" runat="server" id="returnobj6" name="returnobj6" value="">
<input type="hidden" runat="server" id="returnobj7" name="returnobj7" value="">
<input type="hidden" runat="server" id="returnobj8" name="returnobj8" value="">
<input type="hidden" runat="server" id="returnobj9" name="returnobj9" value="">
<input type="hidden" runat="server" id="returnobj10" name="returnobj10" value="">
<input type="hidden" runat="server" id="returnobj11" name="returnobj11" value="">
<input type="hidden" runat="server" id="returnobj12" name="returnobj12" value="">
<input type="hidden" runat="server" id="returnobj13" name="returnobj13" value="">
<input type="hidden" runat="server" id="returnobj14" name="returnobj14" value="">
<input type="hidden" runat="server" id="returnobj15" name="returnobj15" value="">
<input type="hidden" runat="server" id="returnobj16" name="returnobj16" value="">
<input type="hidden" runat="server" id="returnobj17" name="returnobj17" value="">
<input type="hidden" runat="server" id="returnobj18" name="returnobj18" value="">
<input type="hidden" runat="server" id="returnobj19" name="returnobj19" value="">
<input type="hidden" runat="server" id="returnobj20" name="returnobj20" value="">
<input type="hidden" runat="server" id="param1" name="param1" value="">
<input type="hidden" runat="server" id="param2" name="param2" value="">
<input type="hidden" runat="server" id="param3" name="param3" value="">
<input type="hidden" runat="server" id="param4" name="param4" value="">
<input type="hidden" runat="server" id="param5" name="param5" value="">
<input type="hidden" runat="server" id="param6" name="param6" value="">
<input type="hidden" runat="server" id="param7" name="param7" value="">
<input type="hidden" runat="server" id="param8" name="param8" value="">
<input type="hidden" runat="server" id="param9" name="param9" value="">
<input type="hidden" runat="server" id="param10" name="param10" value="">
<input type="hidden" runat="server" id="param11" name="param11" value="">
<input type="hidden" runat="server" id="param12" name="param12" value="">
<input type="hidden" runat="server" id="param13" name="param13" value="">
<input type="hidden" runat="server" id="param14" name="param14" value="">
<input type="hidden" runat="server" id="param15" name="param15" value="">
<input type="hidden" runat="server" id="param16" name="param16" value="">
<input type="hidden" runat="server" id="param17" name="param17" value="">
<input type="hidden" runat="server" id="param18" name="param18" value="">
<input type="hidden" runat="server" id="param19" name="param19" value="">
<input type="hidden" runat="server" id="param20" name="param20" value="">

<input type="hidden" runat="server" id="previewobj" name="previewobj" value="">
<input type="hidden" runat="server" id="selectflag" name="selectflag" value="">
<asp:TextBox runat="server" id="searchkey">&nbsp;</asp:TextBox>
<input type="hidden" runat="server" id="rid" name="rid">
<input type="hidden" runat="server" id="bid" name="bid">
<hr width="100%" />
</form>
</body>
</html>

