
<style type="text/css">
    .popover-header {
        font-size: 0.9rem;
    }
    .popover {
        font-size: 0.8rem;
    }
    .navbar-nav li:hover > ul.dropdown-menu {
        display: block;
    }
    .dropdown-submenu {
        position: relative;
    }
        .dropdown-submenu > .dropdown-menu {
            top: 0;
            left: 100%; /* 10rem is the min-width of dropdown-menu */
            /*left: -10rem; 
            margin-top: -6px;*/
            margin-left: .1rem;
            margin-right: .1rem;
            font-size: 0.75rem;
        }

    /* rotate caret on hover */
    .dropdown-menu > li > a:after {
        text-decoration: underline;
        transform: rotate(-90deg);
        display: block;
        position: absolute;
        right: 6px;
        top: .8em;
    }
    .navbar .nav > li > a > i {
        display: block;
        text-align: center;
        color: rebeccapurple;
    }
    .navbar .nav > li > a > span {
        color: black;
    }

    @media (max-width: 768px) {
        .navbar .nav > li > a > i {
            display: unset;
        }    
        .dropdown-item {
            max-width: 90vw;
            white-space: normal;
        }
        .dropdown-menu .dropdown-submenu  {
            max-width: 90vw;
        }
        .navbar-collapse {
            padding: 15px;
            background-color: gainsboro;
            max-height: 80vh;
            overflow-y: scroll;        
        }
    }
</style>
<script>
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

    $(function () {
        $('[data-toggle="popover"]').popover()
    });
    
        $(function () {
            $.ajax({
                type: "POST",
                url: "selectcustomer.aspx/GetCustomers",
                //data: '{pFieldNames: "' + pFieldNames + '", TableName: "' + TableName + '", pJoinFields: "' + pJoinFields + '", _searchfilter: "' + _searchfilter + '", Orderby: "' + Orderby + '"}',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var ddlCustomers = $("[id*=select_customer]");
                    // ddlCustomers.empty().append('<option selected="selected" value="">Please Select</option>');
                    $.each(r.d, function () {
                        ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                }
            });
        });
</script>
<div>
    <!--background-color: #2F4F4F; #778899   -->

    <nav class="navbar navbar-expand-lg navbar-light bg-bar bg-white" style="font-weight: 500px; font-size: 0.9rem; background-repeat: repeat-x; left: 0; top: 0; border-bottom: 8px solid; border-bottom-color:gainsboro;">
        <a class="navbar-brand pb-2 m-2" href="<%=WebLib.ClientURL("home.aspx")%>">
            <img src="<%=WebLib.ClientURL("images/rgtech.png")%>" width="220" height="50" class="d-inline-block align-top" alt="Logo" ></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse w-100 col-xs-12" id="navbarNavDropdown">
            <ul class=" nav navbar-nav ml-auto ">

                <% if WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True Then%>
                <li class="nav-item dropdown">
                    <%--<select id="select_customer" name="select_customer" class="form-control" style="width:300px;" runat="server" onchange="ddlCustomers_onchange(this.value);"></select>--%>
                    
                    <select id="select_customer" name="select_customer" class="form-control select2" style="width:300px;" runat="server" onchange="ddlCustomers_onchange(this.value);" data-live-search="true"></select>
                    
                    <%--<select id="select_customer" name="select_customer" class="form-control selectpicker" runat="server" onchange="ddlCustomers_onchange(this.value);" data-live-search="true"></select>--%>
                </li>
                <%end If%>
                
                <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Then%>
                <li class="nav-item"><a class="nav-link" href="<%=WebLib.ClientURL("home.aspx")%>"><i class="fa fa-home"></i><span> Home</span></a></li>
                <li class="nav-item"><a class="nav-link" href="<%=WebLib.ClientURL("main2.aspx")%>"><i class="fa fa-line-chart"></i><span> Dashboard</span></a></li>
                <%end If%>


                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-table"></i><span> My Workspace</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink" style="font-size: 0.75rem;">
                        <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Or (WebLib.isStaff = True And WebLib.hasmodrights("salessdt", "SALES", "ST000") = True) Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Sales Order</a>
                            <ul class="dropdown-menu">                                
                                <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("sales.aspx")%>">Web Order Placement</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("saleslist.aspx")%>">Web Order Tracking</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("salesorderlist.aspx")%>">Sales Order Enquiry</a></li>
                                <%end If%>
                                <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("salessdt", "SALES", "ST000") = True) Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("deliverytracking.aspx")%>">Delivery Tracking</a></li>
                                <%end If%>
                                <%--<li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Submenu 1</a>
                                    <ul class="dropdown-menu">
                                      <li><a class="dropdown-item" href="#">Subsubmenu1</a></li>
                                      <li><a class="dropdown-item" href="#">Subsubmenu1</a></li>
                                    </ul>
                                </li>
                                <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Submenu 2</a>
                                    <ul class="dropdown-menu">
                                      <li><a class="dropdown-item" href="#">Subsubmenu2</a></li>
                                      <li><a class="dropdown-item" href="#">Subsubmenu2</a></li>
                                    </ul>
                                </li>--%>
                            </ul>
                        </li>
                        <%end If%>
						
                        <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Or (WebLib.isStaff = True And WebLib.hasmodrights("salessdt", "SALES", "ST000") = True) Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Ship To / GPS</a>
                            <ul class="dropdown-menu">
                                <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("shiptolist.aspx")%>">Ship To Submission</a></li>
                                <%end If%>
                                <% if WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("shiptodaily.aspx")%>">Ship to Daily View</a></li>
                                <%end If%>
                                <% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("salessdt", "SALES", "ST000") = True) Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("gpstracking.aspx")%>">GPS Tracking - Today's Delivery</a></li>
                                <%end If%>
                                <% if WebLib.isStaff = True And WebLib.hasmodrights("salessdt", "SALES", "ST000") = True Then%>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("gpsreview.aspx")%>">GPS Location Review</a></li>
                                <%end If%>
                            </ul>
                        </li>
                        <%end If%>
						
                        <% if WebLib.isStaff = False And WebLib.hasmodrights("zcustom_ccrc", "WORKFLOW", "PC000") = True Then%>
                            <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/cusccr_listC.aspx")%>">Customer Complaint</a></li>
                        <%end If%>

                        <% if WebLib.isStaff = True Then%>
                        <% if WebLib.hasmodrights("zcustom_ccr", "WORKFLOW", "PQ000") = True Or WebLib.hasmodrights("zcustom_ccrp", "WORKFLOW", "PK000") = True Or
                              WebLib.hasmodrights("zcustom_ccrs", "WORKFLOW", "PS000") = True Or WebLib.hasmodrights("zcustom_samples", "WORKFLOW", "PT000") = True Or
                              WebLib.hasmodrights("zcustom_ccrc", "WORKFLOW", "PC000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Customer Service</a>
                            <ul class="dropdown-menu">
                                <% if WebLib.hasmodrights("zcustom_ccrc", "WORKFLOW", "PC000") = True %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/cusccr_listC.aspx")%>">Customer Complaint</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_ccr", "WORKFLOW", "PQ000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/cusccr_listC.aspx")%>">Customer Complaint - Product Quality</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_ccrp", "WORKFLOW", "PK000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/cusccr_listP.aspx")%>">Customer Complaint - Packaging</a></li>
                                <%end If%>
                                <% if WebLib.hasmodrights("zcustom_ccrs", "WORKFLOW", "PS000") = True %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/cusccr_listS.aspx")%>">Customer Complaint - Service</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_samples", "WORKFLOW", "PT000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/samples_list.aspx")%>">Customer Sample Form</a></li>
                                <%end if%>
                            </ul>
                        </li>
                        <%end if%>

                        <% if WebLib.hasmodrights("zcustom_crC", "WORKFLOW", "AA000") = True Or WebLib.hasmodrights("zcustom_crI", "WORKFLOW", "BB000") = True Or WebLib.hasmodrights("zcustom_crS", "WORKFLOW", "CC000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Change Request</a>
                            <ul class="dropdown-menu">
                                <% if WebLib.hasmodrights("zcustom_crC", "WORKFLOW", "AA000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/crC_list.aspx")%>">Customer CR</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_crI", "WORKFLOW", "BB000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/crI_list.aspx")%>">Internal CR</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_crS", "WORKFLOW", "CC000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/crS_list.aspx")%>">Support CR</a></li>
                                <%end if%>
                            </ul>
                        </li>
                        <%end If%>

                        <% if WebLib.hasmodrights("zcustom_stI", "WORKFLOW", "SI000") = True Or WebLib.hasmodrights("zcustom_stS", "WORKFLOW", "SS000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Support Ticket</a>
                            <ul class="dropdown-menu">
                                <% if WebLib.hasmodrights("zcustom_stI", "WORKFLOW", "SI000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/stI_list.aspx")%>">Internal Issue</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_stS", "WORKFLOW", "SS000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/stS_list.aspx")%>">Support Issue</a></li> 
                                <%end if%>
                            </ul>
                        </li>
                        <%end If%>
						
                        <% if Weblib.hasmodrights("zcustom_tempcl", "WORKFLOW", "TC000") = true Or Weblib.hasmodrights("zcustom_clexceed", "WORKFLOW", "CL000") = true Or _
                              Weblib.hasmodrights("zcustom_unblockacct", "WORKFLOW", "UA000") = true Or Weblib.hasmodrights("zcustom_ceval", "WORKFLOW", "CV000") = true Or _
                              Weblib.hasmodrights("zcustom_rebate", "WORKFLOW", "RM000") = true Or Weblib.hasmodrights("zcustom_inactive", "WORKFLOW", "IN000") = true then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Credit Control</a>
                            <ul class="dropdown-menu col-xs-12">
                                <% if Weblib.hasmodrights("zcustom_tempcl", "WORKFLOW", "TC000") = true %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/tempcl_list.aspx") %>">Application for Temporary Credit Limit</a></li>
                                <%end if%>
                                <% if Weblib.hasmodrights("zcustom_clexceed", "WORKFLOW", "CL000") = true %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/climit_list.aspx")%>">Credit Limit Exceeded Form</a></li>
                                <%end if%>
                                <% if Weblib.hasmodrights("zcustom_unblockacct", "WORKFLOW", "UA000") = true %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/unblockacct_list.aspx")%>">Requisition for Unblock Account</a></li>
                                <%end if%>
                                <% if Weblib.hasmodrights("zcustom_ceval", "WORKFLOW", "CV000") = true %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/ceval_list.aspx")%>">Credit Evaluation Form</a></li>
                                <%end if%>
                                <% if Weblib.hasmodrights("zcustom_rebate", "WORKFLOW", "RM000") = true %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/rebate_list.aspx")%>">Rebate(s) Form</a></li>
                                <%end if%>
                                <% if Weblib.hasmodrights("zcustom_inactive", "WORKFLOW", "IN000") = true %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/inactive_list.aspx")%>">Inactive / Close Account, Return / Non-Renewal of Collateral</a></li>
                                <%end if%>
                            </ul>
                        </li>
                        <%end if%>
						
                        <% if WebLib.hasmodrights("zcustom_cn", "WORKFLOW", "CN000") = True Or WebLib.hasmodrights("zcustom_dn", "WORKFLOW", "DN000") = True Or _
                              WebLib.hasmodrights("zcustom_cn2", "WORKFLOW", "CN000") = True Or WebLib.hasmodrights("zcustom_dn2", "WORKFLOW", "DN000") = True Or _
                              WebLib.hasmodrights("zcustom_cn3", "WORKFLOW", "CN000") = True Or WebLib.hasmodrights("zcustom_dn3", "WORKFLOW", "DN000") = True Then%>                        
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">CN/ DN</a>
                            <ul class="dropdown-menu">
                                <% if Weblib.hasmodrights("zcustom_cn3", "WORKFLOW", "CN000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/cn3_list.aspx")%>">Credit Note Requisition Form</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_dn3", "WORKFLOW", "DN000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/dn3_list.aspx")%>">Debit Note Requisition Form</a></li>
                                <%end If%>
                            </ul>
                        </li>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Archive CN/ DN</a>
                            <ul class="dropdown-menu">
                                <% if WebLib.hasmodrights("zcustom_cn2", "WORKFLOW", "CN000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/cn2_list.aspx")%>">Credit Note Requisition (GFC Level)</a></li>
                                <%end If%>
                                <% if WebLib.hasmodrights("zcustom_cn", "WORKFLOW", "CN000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/cn_list.aspx")%>">Credit Note Requisition (OTHERS)</a></li>
                                <%end If%>
                                <% if WebLib.hasmodrights("zcustom_dn2", "WORKFLOW", "DN000") = True %>
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("modules/custom/dn2_list.aspx")%>">Debit Note Requisition (GFC Level)</a></li>
                                <%end if%>
                                <% if WebLib.hasmodrights("zcustom_dn", "WORKFLOW", "DN000") = True %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/dn_list.aspx")%>">Debit Note Requisition (OTHERS)</a></li>
                                <%end if%>
                            </ul>
                        </li>
                        <%end if%>
						
						<% If WebLib.hasrights("npscore", "GENERAL", "NP0004") = True Or WebLib.hasrights("npscore", "GENERAL", "NP0005") = True %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">NP Score</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("npscoregraph.aspx")%>">Graph</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("npscorereport.aspx")%>">Report</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("npscorelist.aspx")%>">Questionnaire Response Listing</a></li>
                            </ul>
                        </li>
                        <% End If %>
						
						<% if Weblib.hasmodrights("fieldforce", "GENERAL", "FF000") = true Or Weblib.hasmodrights("ptcustomer", "GENERAL", "PT000") = true %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Field Force</a>
                            <ul class="dropdown-menu">
								<% if Weblib.hasmodrights("ptcustomer", "GENERAL", "PT000") = true %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("customerlist.aspx")%>">Potential Customer</a></li>
								<% end If %>
								<% if Weblib.hasmodrights("fieldforce", "GENERAL", "FF000") = true %>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("fieldforcelist.aspx")%>">Appointment Maintenance & Export</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("fieldforcecalendar.aspx")%>">Calendar</a></li>
								<% end If %>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% End if%>
                    </ul>
                </li>


                
                <% if WebLib.hasmodrights("edocinv", "EDOC", "DIN000") = True Or
                WebLib.hasmodrights("edocstate", "EDOC", "DST000") = True Or WebLib.hasmodrights("edoccn", "EDOC", "DCN000") = True Or
                WebLib.hasmodrights("edocdn", "EDOC", "DDN000") = True Or WebLib.hasmodrights("edocdo", "EDOC", "DDO000") = True Or
                WebLib.hasmodrights("edocpaylist", "EDOC", "DPL000") = True Then%>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                          <i class="fa fa-file"></i><span> eDocuments</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-left" aria-labelledby="navbarDropdown2" style="font-size: 0.75rem;">
                        <% if WebLib.hasmodrights("edocinv", "EDOC", "DIN000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("invoiceprint.aspx")%>">Invoice</a></li>
                        <%end If%>
                        <% if WebLib.hasmodrights("edocstate", "EDOC", "DST000") = True Then %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("edocstatelist.aspx?ga=S")%>">Statement</a></li>
                        <%end If%>
                        <% if WebLib.hasmodrights("edoccn", "EDOC", "DCN000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("CNPrint.aspx")%>">Credit Notes</a></li>
                        <%end If%>
                        <% if WebLib.hasmodrights("edocdn", "EDOC", "DDN000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("DNPrint.aspx")%>">Debit Note</a></li>
                        <%end If%>
                        <% if WebLib.hasmodrights("edocdo", "EDOC", "DDO000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("DOPrint.aspx")%>">Delivery Order</a></li>
                        <%end If%>
                        <% if WebLib.hasmodrights("edocpaylist", "EDOC", "DPL000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("edocstatelist.aspx?ga=P")%>">Payment Listing</a></li>
                        <%end If%>
                    </ul>
                </li>
                <%end If%>

                <% if WebLib.isStaff = True Then%>
                <% if WebLib.hasmodrights("salesqouta", "SALES", "SQ000") = True Or WebLib.hasmodrights("salestarget", "SALES", "SG000") = True Or
                      WebLib.hasmodrights("salesactcust", "SALES", "SA000") = True Or WebLib.hasmodrights("salescustlogin", "SALES", "SM000") = True Or
                      WebLib.hasmodrights("salespref", "SALES", "SP000") = True Or WebLib.hasmodrights("salesmaxqty", "SALES", "SX000") = True Or
                      WebLib.hasmodrights("sales", "SALES", "SA000") = True Or (WebLib.hasmodrights("npscore", "GENERAL", "NP000") = True) Or WebLib.hasmodrights("salescustmaintenance", "SALES", "SE000") = True Then%>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown2" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-cog "></i><span> Sales Admin</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown2" style="font-size: 0.75rem;">
                        <% if WebLib.hasmodrights("salesqouta", "SALES", "SQ000") = True Or WebLib.hasmodrights("salestarget", "SALES", "SG000") = True %>                        
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">General</a>
                            <ul class="dropdown-menu">
                                <li>
                                    <% if Weblib.hasmodrights("salesqouta", "SALES", "SQ000") = true %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("salesqoutalist.aspx")%>">Customer Quota</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("salestarget", "SALES", "SG000") = true %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("salestargetlist.aspx")%>">Sales Target</a>
                                    <%end if %>
                                </li>
                            </ul>
                        </li>
                        <%end if %>
						
                        <% if Weblib.hasmodrights("salesactcust", "SALES", "SA000") = True Or WebLib.hasmodrights("salescustlogin", "SALES", "SM000") = True Or WebLib.hasmodrights("salescustmaintenance", "SALES", "SE000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Setup for a Customer</a>
                            <ul class="dropdown-menu">
                                <li>
                                    <% if WebLib.hasmodrights("salesactcust", "SALES", "SA000") = True %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("sysmerchantlist.aspx")%>">Activate Customer</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if WebLib.hasmodrights("salescustmaintenance", "SALES", "SE000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("custlist.aspx")%>">Customer Maintenance</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("salescustlogin", "SALES", "SM000") = true %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("secuserinfolistA.aspx")%>">Create Customer Login</a>
                                    <%end if %>
                                </li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if Weblib.hasmodrights("salespref", "SALES", "SP000") = true or Weblib.hasmodrights("salesmaxqty", "SALES", "SX000") = true then %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">S/O Parameters</a>
                            <ul class="dropdown-menu">
                                <li>
                                    <% if Weblib.hasmodrights("salespref", "SALES", "SP000") = true then%>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("syspref.aspx")%>">Order Preferences</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("salespref", "SALES", "SP000") = true then%>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("sysshipto.aspx")%>">Ship To Preferences</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("salesmaxqty", "SALES", "SX000") = true then%>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("salesmaxlist.aspx")%>">Order Qty Settings</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("salesmaxqty", "SALES", "SX000") = true then%>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("customerclasslist.aspx")%>">End User Type</a>
                                    <%end if %>
                                </li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if WebLib.hasmodrights("sales", "SALES", "SA000") = True Then%>
                        <a class="dropdown-item" href="<%=WebLib.ClientURL("auditcustomer.aspx")%>">Customer Logins Audit</a>
                        <a class="dropdown-item" href="<%=WebLib.ClientURL("auditcustomer2.aspx")%>">Customer Logins by Period</a>
                        <% End If %>
						
						<% if Weblib.hasrights("npscore", "GENERAL", "NP0005") = true %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Setup for NP Score</a>
                             <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("setupnparealist.aspx")%>">Areas</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("setupnpaddblist.aspx")%>">Address Book</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("setupnpscorelist.aspx")%>">Questionnaire</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("setupnptargetlist.aspx")%>">Target Recipient</a></li>
                            </ul>
                        </li>
                        <% End If %>
                    </ul>
                </li>
                <% End If %>
                
                <% if Weblib.hasmodrights("secpro", "GENERAL", "UP100") = True Or WebLib.hasmodrights("secuse", "GENERAL", "SU000") = True Or _
                      Weblib.hasmodrights("mstrcountry", "GENERAL", "CO000") = True Or _
                      Weblib.hasmodrights("territory", "GENERAL", "TE000") = True Or Weblib.hasmodrights("mstrstate", "GENERAL", "ST000") = True Or _
                      Weblib.hasmodrights("mstrcustcomplaint", "GENERAL", "CL000") = True Or Weblib.hasmodrights("mstrmatrixlevel", "GENERAL", "MT000") = True Or _
					  Weblib.hasmodrights("mstrholiday", "GENERAL", "HL000") = True Or Weblib.hasmodrights("mstrcategory", "GENERAL", "CT000") = True Or _
                      Weblib.hasmodrights("webcms", "GENERAL", "ED000") = True Or Weblib.hasmodrights("sysset", "GENERAL", "SS000") = true Or _
					  Weblib.hasmodrights("workflow", "WORKFLOW", "WF000") = true Then%>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown3" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-gear "></i><span> System Admin</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-left" aria-labelledby="navbarDropdown2" style="font-size: 0.75rem;">
                        <% if Weblib.hasmodrights("secpro", "GENERAL", "UP100") = True Or WebLib.hasmodrights("secuse", "GENERAL", "SU000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Security</a>
                            <ul class="dropdown-menu">
                                <li>
                                    <% if Weblib.hasmodrights("secpro", "GENERAL", "UP100") = True %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("secprofilelist.aspx")%>">User Profile</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("secuse", "GENERAL", "SU000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("secuserinfolist.aspx")%>">Login Accounts</a>
                                    <%end if %>
                                </li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if Weblib.hasmodrights("mstrcountry", "GENERAL", "CO000") = True Or _
                              Weblib.hasmodrights("territory", "GENERAL", "TE000") = True Or Weblib.hasmodrights("mstrstate", "GENERAL", "ST000") = True Or _
                              Weblib.hasmodrights("mstrcustcomplaint", "GENERAL", "CL000") = True Or Weblib.hasmodrights("mstrmatrixlevel", "GENERAL", "MT000") = True Or _
						      Weblib.hasmodrights("mstrholiday", "GENERAL", "HL000") = True Or Weblib.hasmodrights("mstrcategory", "GENERAL", "CT000") = True Then%>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Others Masterfiles</a>
                            <ul class="dropdown-menu">
                                <li>
                                    <% if Weblib.hasmodrights("mstrcountry", "GENERAL", "CO000") = true %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("mstrcountrylist.aspx")%>">Country</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("territory", "GENERAL", "TE000") = true %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("mstrterritorylist.aspx")%>">Region</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("mstrstate", "GENERAL", "ST000") = true %>
                                    <a class="dropdown-item" href="<%=weblib.clienturl("mstrstatelist.aspx")%>">State</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("mstrcustcomplaint", "GENERAL", "CL000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("mstrclassificationlist.aspx")%>">Classification</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("mstrmatrixlevel", "GENERAL", "MT000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("mstrmatrixlevellist.aspx")%>">Matrix Level</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("mstrholiday", "GENERAL", "HL000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("mstrholiday.aspx")%>">Holiday</a>
                                    <%end if %>
                                </li>
                                <li>
                                    <% if Weblib.hasmodrights("mstrcategory", "GENERAL", "CT000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("mstrcategorylist.aspx")%>">FieldForce Category</a>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("deptlist.aspx")%>">Department</a>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("codemstrlist.aspx")%>">Codemaster</a>
                                    <%end if %>
                                </li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if Weblib.hasmodrights("webcms", "GENERAL", "ED000") = True %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">CMS</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="<%=weblib.clienturl("editor.aspx?ba=L")%>">Landing Page</a></li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if Weblib.hasmodrights("sysset", "GENERAL", "SS000") = true %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">System Parameters</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("sysset.aspx")%>">Customer Portal Settings</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("sysgps.aspx")%>">GPS Settings</a></li>
                            </ul>
                        </li>
                        <% End If %>
						
                        <% if Weblib.hasmodrights("workflow", "WORKFLOW", "WF000") = true %>
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Workflow</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/workflow/wgrouplist.aspx")%>">Approval Group</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/workflow/wlist.aspx")%>">Approval Workflow</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/workflow/wflowtag.aspx")%>">Forms/Workflow Tagging</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowrou")%>">Routing Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflownot")%>">Notify Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowapp")%>">Approved Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowrej")%>">Rejected Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowcan")%>">Cancelled Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowsub")%>">Submitted Email Format</a></li>
                                <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/general/postpage.aspx?nextpage=setupemail.aspx&ba=wflowclo")%>">Closed Email Format</a></li>
                            </ul>
                        </li>
                        <% End If %>
                    </ul>
                </li>
                <%end If %>
                <%end If %>
				
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown5" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-user-circle-o fa-2x" style="display: unset;"></i>
                        <span><%=WebLib.LoginUserName %></span></a>
                    <div class="dropdown-menu navbar-font" aria-labelledby="navbarDropdown5" style="font-size: 0.75rem;">
                        <a class="dropdown-item" href="<%=WebLib.ClientURL("secuserinfoedit.aspx")%>">Profile</a>
                        <%--<a class="dropdown-item" href="<%=WebLib.ClientURL("login.aspx?ga=S")%>">Log Out</a>--%>
                        <a class="dropdown-item" href="<%=WebLib.ClientURL("loginstaff.aspx?ga=S")%>">Log Out</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</div>

<script type="text/javascript">

    $(document).ready(function () {
        //jQuery code goes here
          $('.select2').select2(); //- works
      // $('.selectpicker').selectpicker();
    });

    function ddlCustomers_onchange(str) {
        $.ajax({
            type: "POST",
            url: "selectcustomer.aspx/SelectCustomer2",
            data: '{pCustCode: "' + str + '"}',
            //data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {
                //var resData = jQuery.parseJSON(response.d);
                    var resData = response.d
                    location.reload(true);
            },

            failure: function (response) {
                alert(response.d);
            }
        });
    }
</script>

