    <%@ Control Language="VB" AutoEventWireup="true" CodeFile="mapobject.ascx.vb" Inherits="mapsobject_class" %>

    <div class="cssdetail" runat="server" id="receiptpreview" style="position:relative;DISPLAY:inline-block;" >

                <asp:Literal runat="server" id="mapsimg"></asp:Literal>

                <input type="hidden" runat="server" id="rid" name="rid">
                <input type="hidden" runat="server" id="txtobjectid" name="txtobjectid">
                <input type="hidden" runat="server" id="txtmode" name="txtmode">
                <asp:LinkButton ID="btnmapselect" runat="server" OnClick="mapselect" Text="LinkButton" style=" visibility:hidden" />
                <asp:Label ID="lblmessage" runat="server" CssClass="cssrequired"></asp:Label>
    </div>


