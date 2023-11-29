<div id="divsearch">
<div style="text-align:left">
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Module Options</b></span></td></tr></table>
<br />
<asp:Panel runat="server" id="pnlsearcharea">
<font class="cssdetail"><b>Please enter search key:</b></font><br />
<asp:TextBox ID="search_key1" runat="server" Columns="23" Maxlength="50"></asp:TextBox><br />
Search Field:<br />
<font class="cssdetail">
<asp:PlaceHolder ID="phSearchFields" runat="server" ></asp:PlaceHolder>
</font>
<hr class="cssdivider" width="100%" runat="server" id="hrdate" />
<uc:datepicker ID="uc_from" runat="server" AllowNull="false" Width="72px" PlaceHolder="From Date" />
<uc:datepicker ID="uc_to" runat="server" AllowNull="false" Width="72px" PlaceHolder="To Date" />
<asp:PlaceHolder ID="phSearchDate" runat="server" ></asp:PlaceHolder>
<br />
</asp:Panel> 
<asp:Button ID="btnsearch" Text="Search" Runat="server"  OnClick="SearchStr" style="width:45%" /> 
<asp:Button ID="btnadd" Text="Add New" Runat="server"  OnClick="AddEvent" style="width:48%"   />

<hr width="100%" class="cssdivider" />
</div>
<asp:Button ID="btnback" Text="Back to Listing" Runat="server" OnClick="backpage" style="width:160px" CausesValidation="false" /> 
<asp:Label ID="lblMessage" runat="server"></asp:Label>

</div>
