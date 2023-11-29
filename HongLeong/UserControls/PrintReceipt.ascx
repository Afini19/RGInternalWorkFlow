    <%@ Control Language="VB" AutoEventWireup="true" CodeFile="printreceipt.ascx.vb" Inherits="printreceipt_class" %>

    <div class="cssdetail" runat="server" id="receiptpreview" style="DISPLAY:inline-block;text-align:left;width:250px;" >

                <table width="250px">
                <tr><td>
                <asp:Literal runat="server" id="ltBranchName"></asp:Literal>
                </td></tr>
                <tr>
                <td>
                <asp:Literal runat="server" id="ltbillno"></asp:Literal>
                <asp:Literal runat="server" id="ltcasher"></asp:Literal>
                <asp:Literal runat="server" id="ltdate"></asp:Literal>
                </td>
                </tr>
                <tr>
                <td>
                <table width="250px" cellpadding="0">
                <tr><td colspan="3"><hr width="100%" /></td></tr>
                <tr><td width="30">QTY</td><td width="150">ITEM</td><td align="right" width="70">AMOUNT</td></tr>
                <tr><td colspan="3"><hr width="100%" /></td></tr>
                <asp:Literal runat="server" id="ltitems"></asp:Literal>
                <tr><td colspan="3"><hr width="100%" /></td></tr>
                <tr><td colspan="2" align="left">NETT TOTAL</td><td align="right"><asp:Literal runat="server" id="ltnett"></asp:Literal></td></tr>
                <asp:Literal runat="server" id="ltpayments"></asp:Literal>
                <tr><td colspan="3"><hr width="100%" /></td></tr>
                <tr><td colspan="3"><br /><br />Thank you. Please come again</td></tr>

                </table>
                </td>
                </tr>

                </table><br />
                <asp:Label ID="lblmessage" runat="server" CssClass="cssrequired"></asp:Label>
    </div>


