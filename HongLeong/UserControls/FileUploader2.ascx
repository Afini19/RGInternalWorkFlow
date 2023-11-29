<%@ Control Language="VB" AutoEventWireup="false" CodeFile="fileuploader2.ascx.vb" Inherits="fileuploader2_class" %>

<div class="row form-body-fonts">
    <div class="col-md-3">
        <asp:Label ID="formtitle" runat="server"></asp:Label>
        <div class="col-3" style="padding-top: 1em;">
            <asp:Literal runat="server" ID="ltimage" Visible="false"></asp:Literal>
            <asp:FileUpload ID="flddoc1" runat="server" />
            <asp:Button ID="btnupload" Text="Upload File" runat="server" Class="inputbutton" OnClick="uc_file1_click" />&nbsp;
            <br />
            <asp:Label ID="lblfilename" runat="server" class="cssdetail" Visible="false"></asp:Label>

            <asp:Label ID="lblformnamespace" runat="server" Style="display: none"></asp:Label>
            <asp:Label ID="lbluniqueid" runat="server" Style="display: none"></asp:Label>
            <asp:Label ID="lblappcode" runat="server" Style="display: none"></asp:Label>
            <input type="hidden" runat="server" id="uploadrights" />
        </div>
    </div>
    <div class="col-md-9">
        <table id="table_id" class="table table-borderless table-responsive" style="height: 100%; width: 100%; font-size: 0.8rem;" cellpadding="2" cellspacing="1">
            <%--style="padding-left: 3em; padding-right: 3em; margin-top: 0;"--%>
            <thead>
                <tr>
                    <th>File</th>
                    <th>Date Uploaded</th>
                    <th>Created By</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rep_pr" runat="server">
                    <ItemTemplate>
                        <tr id="trRow" runat="server">
                            <td>
                                <%--<span class="fas fa-file-invoice"></span><a href="<%#Eval("doc_attach1path")%><%#Eval("doc_attach1").ToString.Trim%>" download="<%#Eval("doc_attach1path").ToString.Trim%><%#Eval("doc_attach1").ToString.Trim%>"><%#Eval("doc_subject").ToString.Trim%></a>--%>
                                <%--<span class="fas fa-file-invoice"></span><a href="#" onclick="$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href:'<%# ConfigurationManager.AppSettings("filespathhttpiissub") + DataBinder.Eval(Container.DataItem, "doc_attach1path").ToString.Trim + DataBinder.Eval(Container.DataItem, "doc_attach1").ToString.Trim %>',width:'90%',height:'90%'})"><%#Eval("doc_subject").ToString.Trim%></a>--%>
                                <span class="fas fa-file-invoice"></span><a href="#" onclick="$.colorbox({iframe:true,opacity:0.5,trapFocus:true,href:'<%# DataBinder.Eval(Container.DataItem, "fullpath").ToString.Trim %>',width:'90%',height:'90%'})"><%#Eval("doc_subject").ToString.Trim%></a>
                            </td>
                            <td>
                                <asp:Label ID="rep_createddate" runat="server" Text=' <%#Eval("doc_createdt")%>' />
                            </td>
                            <td>
                                <asp:Label ID="rep_createdby" runat="server" Text=' <%#Eval("doc_createby") %>' />
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "doc_id")%>' CommandName="Del" OnClientClick="return confirm('Are you sure want to delete this record?')">Del.</asp:LinkButton>

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <asp:Label ID="lbluploadstatus" runat="server" class="cssrequired"></asp:Label>
</div>
<asp:Label ID="lblMessage" runat="server" class="validate-entry"></asp:Label>


