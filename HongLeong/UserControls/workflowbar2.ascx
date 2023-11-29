<%@ Control Language="VB" AutoEventWireup="false" CodeFile="workflowbar2.ascx.vb" Inherits="UserControls_workflowbar2" %>


<div>
    <table class="ui-widget-header" width="100%">
        <tr>
            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
            <td width="100%"><span class="ui-widget"><b>Status</b></span></td>
        </tr>
    </table>
</div>
<div class=" container text-center p-1" style="width: 80%">
    <asp:Literal ID="litstatus" runat="server"></asp:Literal><br />
</div>

<div runat="server" id="resultsCard" style="display:none;">
    <table class="ui-widget-header" width="100%">
        <tr>
            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
            <td width="100%"><span class="ui-widget"><b>Results</b></span></td>
        </tr>
    </table>
</div>
<div class=" container text-center p-1" style="width: 80%; display:none;">
    <asp:Literal ID="litresults" runat="server"></asp:Literal><br />
</div>


                            <% If WebLib.isStaff = True Then %>
<div>
    <table class="ui-widget-header" width="100%">
        <tr>
            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
            <td width="100%"><span class="ui-widget"><b>Approval Details</b></span></td>
        </tr>
    </table>
</div>
<div class="card-body text-left " style="padding-bottom: 0em;">
    <font class="form-body-fonts"><asp:Literal ID="litdetails" runat="server"></asp:Literal></font>
    <br />
    <br />
    <font class="form-body-fonts"><asp:Literal ID="litapprovalperson" runat="server"></asp:Literal></font>
</div>

<div>
    <table class="ui-widget-header" width="100%">
        <tr>
            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
            <td width="100%"><span class="ui-widget"><b>Approval Actions</b></span></td>
        </tr>
    </table>
</div>
<div class="card-body">
    <div class="container p-1 text-center">
        <asp:Button CssClass="btn btn-sm btn-info w-100" ID="btnwResend" Text="Resend Email" runat="server" OnClick="resend" Style="width: 90%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
    </div>
    <div class="container p-1 text-center">
        <asp:Button CssClass="btn btn-sm btn-info w-100 " ID="btnTracking" Text="Track Workflow" runat="server" OnClick="viewworkflow" Style="width: 90%;" />
        <br />
    </div>
    <div class="card-content">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</div>

                            <%End if %>
<div>
    <table class="ui-widget-header" width="100%">
        <tr>
            <td width="10px"><span class="ui-icon ui-icon-triangle-1-e"></span></td>
            <td width="100%"><span class="ui-widget"><b>Attachments</b></span></td>
        </tr>
    </table>
</div>
<div class="card-body" style="padding-bottom: 1em;">
    <div class="container p-1">
        <font class="cssdetail"><asp:Literal ID="litattachments" runat="server"></asp:Literal></font>
        <asp:Button CssClass="btn tbn-sm btn-info w-100" ID="btnAttachments" Text="Manage Attachments" runat="server" OnClick="viewattach" Style="width: 100%" />
    </div>
    <div class="container p-1 text-center">
        <asp:Button CssClass="btn btn-info btn-sm w-100" ID="btnwApprove" Text="Approve" runat="server" OnClick="approve" Style="width: 90%" />
    </div>
    <div class="container p-1 text-center">
        <asp:Button CssClass="btn btn-sm btn-info w-100" ID="btnwReject" Text="Reject" runat="server" OnClick="reject" Style="width: 90%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
       
    </div>
    <div class="container p-1 text-center">
        <asp:Button CssClass="btn btn-sm btn-info w-100" ID="btnwCancel" Text="Cancel" runat="server" OnClick="cancel" Style="width: 90%" CausesValidation="false" OnClientClick="jQuery('#frmform').validationEngine('detach');" />
       
    </div>
</div>
<%--<div class="card-header bg-header form-fonts p-1">&nbsp;<span class="fas fa-caret-right">&nbsp;</span> Others</div>		--%>

                            <% If WebLib.isStaff = True Then %>
<div class="card-body" style="padding-bottom: 0em;">
    <div class="card-content text-left">
        <font class="cssdetail "><asp:Literal ID="litAudit" runat="server"></asp:Literal></font>
    </div>
</div>
                            <%End if %>

<asp:HiddenField runat="server" ID="wucode" />
<asp:HiddenField runat="server" ID="cus_wrefno" />
<asp:HiddenField runat="server" ID="wwid" />
<asp:HiddenField runat="server" ID="wlevel" />
<asp:HiddenField runat="server" ID="wlevelA" />
<asp:HiddenField runat="server" ID="wlevelAP" />
<asp:HiddenField runat="server" ID="wlevelName" />

<asp:HiddenField runat="server" ID="aAType" />
<asp:HiddenField runat="server" ID="aCType" />
<asp:HiddenField runat="server" ID="aRType" />
<asp:HiddenField runat="server" ID="wstatus" />
<asp:HiddenField runat="server" ID="wr" />
<asp:HiddenField runat="server" ID="wrm" />

<asp:HiddenField runat="server" ID="wlevelamt" />
<asp:HiddenField runat="server" ID="wlevelamtend" />
<asp:HiddenField runat="server" ID="wlevelamtenabled" />

<asp:HiddenField runat="server" ID="wversion" />
<asp:HiddenField runat="server" ID="wtablename" />


