<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingPageControl.ascx.cs" Inherits="UserControls_ListingPageControl" %>
<asp:PlaceHolder ID="plcNoRecord" runat="server" Visible="false">
    <table class="gridWrap" width="100%">
        <tr>
            <td colspan="6" style="height: 50px" align="center" valign="middle">
                No records found.
            </td>
        </tr>
    </table>
</asp:PlaceHolder>
<table class="gridPagerWrap" width="100%">
    <tr class="Grid_Header">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <td>
                Total
                <asp:Literal ID="litTotalRecords" runat="server"></asp:Literal>
                records found.
            </td>
            <td>
                Listing records
                <asp:Literal ID="litRecordsRange" runat="server"></asp:Literal>.
            </td>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
            <td>
                <table align="center">
                    <tr valign="middle">
                        <td>
                            <asp:LinkButton ID="lnkXls1" OnClick="lnkXls_Click" runat="server"><img src="Images/ico_excel.png" border="0" /></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkXls2" OnClick="lnkXls_Click" runat="server">Excel.</asp:LinkButton>
                        </td>
                                               <%-- <td><asp:LinkButton ID="lnkPrt1" OnClick="lnkPrint_Click" runat="server"><img src="Images/ico_print.png" border="0" /></asp:LinkButton></td>
                        <td><asp:LinkButton ID="lnkPrt2" OnClick="lnkPrint_Click" runat="server">Print.</asp:LinkButton></td>--%>
                    </tr>
                </table>
            </td>
        </asp:PlaceHolder>
        <td>
            <asp:LinkButton ID="lnkFirst" runat="server" OnClick="lnkFirst_Click">&#60;&#60; First</asp:LinkButton>
            &#149;
            <asp:LinkButton ID="lnkPrev" runat="server" OnClick="lnkPrev_Click">&#60; Prev</asp:LinkButton>
            &#149;
            <asp:DropDownList ID="drpPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpPage_SelectedIndexChanged">
            </asp:DropDownList>
            of
            <asp:Literal ID="litTotalPages" runat="server"></asp:Literal>
            &#149;
            <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">Next &#62;</asp:LinkButton>
            &#149;
            <asp:LinkButton ID="lnkLast" runat="server" OnClick="lnkLast_Click">Last &#62;&#62;</asp:LinkButton>
        </td>
    </tr>
</table>
