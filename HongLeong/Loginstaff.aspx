<%@ Page Language="VB" AutoEventWireup="false" EnableViewState="True" CodeFile="login.aspx.vb" Inherits="login_class" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!--#include File="topinitdetail.aspx"-->
    <script>
        $(document).ready(function () {
            $("input[type=submit], button")
            .button();
        });
    </script>
    <style type="text/css">
        ::placeholder {
            font-size: 13px;
        }
    </style>
    <!--#include File="topscriptdetail.aspx"-->
</head>
<body>
    <form id="frmform" runat="server">
        <!--#include File="include/FormHeader.aspx"-->
        <div class=" container-fluid bg-white" style="font-size: 1rem;">
            <div class="row listpage h-100 justify-content-center align-items-center m-3">
                <div class="col-md-5"></div>
                <div class="col-md-2 bg-white">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row ui-widget-header ui-corner-all">
                                <span class="ui-icon ui-icon-triangle-1-e"></span><span class="ui-widget"><b>Staff Login</b></span>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row d-flex justify-content-center align-items-center mt-3">
                                        <div class="form-group ">
                                            <div class="input-group">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fa fa-user"></i></span></div>
                                                <asp:TextBox ID="usr_loginid" runat="server" CssClass="form-control" placeholder="Login ID" MaxLength="20" class="validate[required]"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row d-flex justify-content-center align-items-center">
                                        <div class="form-group ">
                                            <div class="input-group">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fa fa-lock"></i></span></div>
                                                <asp:TextBox ID="usr_password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" MaxLength="20" class="validate[required]"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row d-flex justify-content-center align-items-center">
                                        <div class="form-group ">
                                            <div class="input-group">
                                                <asp:LinkButton ID="lnkPassword" runat="server" OnClick="recoverpasswordS" class="cssdetail">Forgot Password</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="SubmitButton" CssClass="btn btn-info btn-sm w-100" Text="Login with ID/Password" runat="server" OnClick="loginpage" Style="width: 100%; height: 40px" /><br />
                            <br />
                        </div>
                        <div class="col-md-12">
                            Customer Login, please click <a href="login.aspx">here</a><br />
                            <br />
                        </div>
                    </div>
                </div>
                <div class="col-md-5"></div>
                <table width="240px" align="center">
                    <asp:Panel runat="server" ID="pnltohide" Visible="false">
                        <tr>
                            <td align="left" width="100%">
                                <table class="ui-widget-header ui-corner-all">
                                    <tr>
                                        <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
                                        <td width="100%"><span class="ui-widget"><b>Customer Login</b></span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td class="cssdetail">Login ID</td>
                                        <td>
                                            <asp:TextBox ID="usr_loginid2" runat="server" Style="width: 150px" MaxLength="20" class="validate[required]"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="cssdetail">Password</td>
                                        <td>
                                            <asp:TextBox ID="usr_password2" TextMode="Password" runat="server" Style="width: 150px" MaxLength="20" class="validate[required]"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="cssdetail">&nbsp;</td>
                                        <td>
                                            <asp:LinkButton ID="lnkPassword2" runat="server" OnClick="recoverpasswordS" class="cssdetail">Forgot Password</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" CssClass="btn btn-info btn-sm w-100" Text="Login with ID/Password" runat="server" OnClick="loginpage2" Style="width: 100%; height: 40px" />
                                <br />
                                <br />

                                <font class="cssdetail">
                                    <asp:Literal ID="lithtml" runat="server"></asp:Literal>
                                </font>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" class="cssrequired"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--#include File="include/FormFooter1.aspx"-->
    </form>
    <!--#include File="include/footerscript.aspx"-->
</body>
</html>
