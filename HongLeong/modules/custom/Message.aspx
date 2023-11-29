<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="message.aspx.vb" Inherits="message_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/Calculator.ascx" TagPrefix="uc" TagName="Calculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>Message</title>

<!--#include File="topinitdetail.aspx"-->
<script>
   $(function() {
   $( "input[type=submit], button" )
   .button()
   });
</script>
<!--#include File="topscriptdetail.aspx"-->
</head>
<body>
<form id="frmform" runat="server">
<br />
<center>
<img src="images/logo.png" /><br /><br />
<h1>OOOPPSSS....</h1>

<h2><asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label></h2><br />
<asp:Button ID="SubmitButton" Text="Ok. Noted" Runat="server" OnClick="gonextpage" style="width:200px;Height:30px"  /> <br /><br />
</td></tr>
</table>
</center>


<input type="hidden" runat="server" id="bid" name="bid">
               

	
</form>
</body>
</html>

