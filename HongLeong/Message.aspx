<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="message.aspx.vb" Inherits="message_class" %>

<%@ Register Src="UserControls/DatePicker.ascx" TagPrefix="uc" TagName="DatePicker" %>
<%@ Register Src="UserControls/Calculator.ascx" TagPrefix="uc" TagName="Calculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title><%=_FormsName%></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="topinitdetail.aspx"-->
    <script>
        $(function () {
            $("input[type=submit], button")
            .button()
        });
    </script>
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader1.aspx"-->
        <center>
            <div class=" container-fluid bg-light" style="font-size: 1rem;">
                <div class="col-md-12 bg-light">
                    <div style="padding-top: 1em;">
                        <div class="ui-widget-header alert p-1 form-fonts w-100  bg-header " role="alert" style="text-align: center; padding-left: 1em!important; margin-bottom: 1em!important">
                            <%=_formsname%>
                        </div>
                        <div><%--<img src="images/logo.png" /><br /><br />--%>
                            <b>OOOPPSSS....</b>
                            <br />
                            <h2>
                                <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label></h2>
                            <br />
                            <asp:Button ID="SubmitButton" Text="Ok. Noted" runat="server" OnClick="gonextpage" /><%-- Style="width: 100%; height: 30px"--%>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </center>
        <input type="hidden" runat="server" id="bid" name="bid" />
        <!--#include File="include/FormFooter1.aspx"-->

    </form>
    <!--#include File="include/footerscript.aspx"-->
</body>
</html>

