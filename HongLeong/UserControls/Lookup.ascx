    <%@ Control Language="VB" AutoEventWireup="true" Inherits="lookup_class" %>

    <div style="DISPLAY:inline-block;text-align:center" >
    <table width="100%" cellpadding="0" cellspacing="0"><tr>
    <td width="<%=width%>" valign="center">
    <asp:TextBox ID="lookupcode" runat="server"></asp:TextBox></td>
    <td width="25px" valign="center"><input type="button" ID="lnklookup" runat="server" Width="25px" Height="20px" value="..." tabindex="-1" /></td>
    <td valign="center"><asp:Label runat="server" ID="litdisplay"></asp:Label></td>
    </tr></table>
    <asp:Literal ID="Literal1" runat="server" ViewStateMode="Disabled"></asp:Literal>
    <asp:HiddenField runat="server" id="lookupdefault" />
    <asp:HiddenField runat="server" id="lookuppage" />
    <asp:HiddenField runat="server" id="islookup" />
    </div>


