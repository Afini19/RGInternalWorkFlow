<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="lockscreen.aspx.vb" Inherits="lockscreen_class" %>
<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/Calculator.ascx" TagPrefix="uc" TagName="Calculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta charset="utf-8">
<title>Login</title>
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
   .button()
   });
</script>
</head>
<body>
<center>
<form id="frmform" runat="server">

<table width="240">
<tr><td> <img src="images/vifeandisuite.png" /></td></tr>
<tr><td align="left" width="100%">
<table class="ui-widget-header ui-corner-all"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Please enter login ID and password</b></span></td></tr></table>
</td></tr>
<tr><td>
<table width="100%">
<tr><td>Login ID</td><td><asp:TextBox ID="usr_loginid" runat="server"  style="width:150px" Maxlength="20" class="validate[required]" ></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="usr_password" TextMode="Password" runat="server"  style="width:150px" Maxlength="20" class="validate[required]" ></asp:TextBox></td></tr>
</table>
</td></tr>

<tr><td>
<asp:Button ID="SubmitButton" Text="Login with ID/Password" Runat="server" OnClick="loginpage" style="width:100%;Height:40px"  /> <br /><br />
</td></tr>
<tr><td align="left" width="100%">
<br />
</td></tr>
<tr><td align="left" width="100%">
<table class="ui-widget-header ui-corner-all"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Login with Pin : Please enter PIN number</b></span></td></tr></table>
</td></tr>

<tr><td align="center" width="100%">
<uc:calculator ID="uc_login" runat="server" Forpassword="true" />
</td></tr>
<tr><td>
<asp:Button ID="Button1" Text="Login with PIN" Runat="server" OnClick="loginpage2" style="width:100%;Height:40px"  /> <br /><br />
</td></tr>

</table>

<br />
<asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label><br />
<font class="posbalance">SCREEN LOCK MODE</font>
               

<input type="hidden" runat="server" id="bid" name="bid">
	
</form>
</center>
</body>
</html>

