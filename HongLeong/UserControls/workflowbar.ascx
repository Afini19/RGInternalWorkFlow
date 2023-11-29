
    <div runat="server" id="bardiv" style="position:relative;" >

<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Status</b></span></td></tr></table>				
<asp:Literal ID="litstatus" runat="server"></asp:Literal><br />
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Approval Details</b></span></td></tr></table>				
<br />
<font class="cssdetail"><asp:Literal ID="litdetails" runat="server"></asp:Literal></font><br /><br />
<font class="cssdetail"><asp:Literal ID="litapprovalperson" runat="server"></asp:Literal></font>

<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Approval Actions</b></span></td></tr></table>				
<br />
<table width="100%">
<tr><td>
<asp:Button ID="btnwApprove" Text="Approve" Runat="server" OnClick="approve"  style="width:100%" />
</td></tr>
<tr><td>
<asp:Button ID="btnwReject" Text="Reject" Runat="server" OnClick="reject"  style="width:100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  />
</td></tr>
<tr><td>
<asp:Button ID="btnwCancel" Text="Cancel" Runat="server" OnClick="cancel"  style="width:100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  />
</td></tr>

<tr><td>
<asp:Button ID="btnwResend" Text="Resend Action Email" Runat="server" OnClick="resend"  style="width:100%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');"  />
</td></tr>

</table>

<asp:Label ID="lblMessage" runat="server"></asp:Label>
<br />
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Attachments</b></span></td></tr></table>				
<br />
<font class="cssdetail"><asp:Literal ID="litattachments" runat="server"></asp:Literal></font>
<asp:Button ID="btnAttachments" Text="Manage Attachments" Runat="server" OnClick="viewattach"  style="width:100%" /> <br />
<br />
<table class="ui-widget-header" width="100%"><tr><td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td><td width="100%"><span class="ui-widget"><b>Others</b></span></td></tr></table>				
<br />
<asp:Button ID="btnTracking" Text="Track Workflow" Runat="server" OnClick="viewworkflow"  style="width:100%" /> <br />
<font class="cssdetail"><asp:Literal ID="litAudit" runat="server"></asp:Literal></font>

<asp:HiddenField runat="server" id="wucode" />
<asp:HiddenField runat="server" id="cus_wrefno" />
<asp:HiddenField runat="server" id="wwid" />
<asp:HiddenField runat="server" id="wlevel" />
<asp:HiddenField runat="server" id="wlevelA" />

<asp:HiddenField runat="server" id="aAType" />
<asp:HiddenField runat="server" id="aCType" />
<asp:HiddenField runat="server" id="aRType" />
<asp:HiddenField runat="server" id="wstatus" />
<asp:HiddenField runat="server" id="wr" />
<asp:HiddenField runat="server" id="wrm" />

<asp:HiddenField runat="server" id="wlevelamt" />
<asp:HiddenField runat="server" id="wlevelamtend" />
<asp:HiddenField runat="server" id="wlevelamtenabled" />

<asp:HiddenField runat="server" id="wversion" />

</div>


