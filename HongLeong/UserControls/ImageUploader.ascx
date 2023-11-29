    <%@ Control Language="VB" AutoEventWireup="true" Inherits="imageuploader_class" %>

    <div style="DISPLAY:inline-block;text-align:center; width:<%=Width%>" >
    <asp:Literal runat="server" id="ltimage" Visible="false"></asp:Literal>   
    <asp:FileUpload ID="flddoc1" runat="server"   />&nbsp;
    <asp:Button ID="btnupload" Text="Upload File" Runat="server" Class="inputbutton" OnClick="uc_file1_click"  />&nbsp;<asp:Label ID="lbluploadstatus" runat="server" class="cssrequired"></asp:Label>
    <asp:Button ID="btndelete" Text="Delete File" Runat="server" Class="inputbutton" OnClick="DeleteDoc" Visible="false"  />
    <br /><asp:Label ID="lblfilename" runat="server" class="cssdetail"></asp:Label>
    <asp:Label ID="lblformnamespace" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="lblappcode" runat="server"  style="display:none"></asp:Label>
    </div>


