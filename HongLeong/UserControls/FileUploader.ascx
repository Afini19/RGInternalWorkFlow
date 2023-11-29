    <%@ Control Language="VB" AutoEventWireup="true" Inherits="fileuploader_class" %>

    <div style="DISPLAY:inline-block;text-align:left; width:<%=Width%>" >
    <asp:Literal runat="server" id="ltimage" Visible="false"></asp:Literal>   
    <asp:FileUpload ID="flddoc1" runat="server"   /><br /><asp:Button ID="btnupload" Text="Upload File" Runat="server" Class="inputbutton" OnClick="uc_file1_click"  /><asp:Button ID="btndelete" Text="Delete File" Runat="server" Class="inputbutton" OnClick="DeleteDoc" Visible="false"  />&nbsp;<asp:Label ID="lbluploadstatus" runat="server" class="cssrequired"></asp:Label>
    <br /><asp:Label ID="lblfilename" runat="server" class="cssdetail"></asp:Label>
    <asp:Label ID="lblformnamespace" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="lbluniqueid" runat="server" style="display:none"></asp:Label>
    <asp:Label ID="lblappcode" runat="server"  style="display:none"></asp:Label>
    </div>


