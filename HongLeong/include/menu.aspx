
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
    
        //$(function () {
        //    $.ajax({
        //        type: "POST",
        //        url: "selectcustomer.aspx/GetCustomers",
        //        //data: '{pFieldNames: "' + pFieldNames + '", TableName: "' + TableName + '", pJoinFields: "' + pJoinFields + '", _searchfilter: "' + _searchfilter + '", Orderby: "' + Orderby + '"}',
        //        data: '{}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (r) {
        //            var ddlCustomers = $("[id*=select_customer]");
        //            // ddlCustomers.empty().append('<option selected="selected" value="">Please Select</option>');
        //            $.each(r.d, function () {
        //                ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
        //            });
        //        }
        //    });
        //});
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
                
                <%--<% if WebLib.isStaff = False Or (WebLib.isStaff = True And WebLib.hasmodrights("sales", "SALES", "SA000") = True) Then%>--%>
                    <li class="nav-item"><a class="nav-link" href="<%=WebLib.ClientURL("home.aspx")%>"><i class="fa fa-home"></i><span> Home</span></a></li>
                <%--<li class="nav-item"><a class="nav-link" href="<%=WebLib.ClientURL("main2.aspx")%>"><i class="fa fa-line-chart"></i><span> Dashboard</span></a></li>--%>
                <%--%end If%>--%>


                <% if WebLib.hasmodrights("zcustom_crC", "WORKFLOW", "AA000") = True Or WebLib.hasmodrights("zcustom_crI", "WORKFLOW", "BB000") = True Or WebLib.hasmodrights("zcustom_crS", "WORKFLOW", "CC000") = True Then%>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLinkCR" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-table"></i><span>Change Request</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink" style="font-size: 0.75rem;">
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
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLinkST" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-ticket"></i><span>Support Ticket</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink" style="font-size: 0.75rem;">
                        <% if WebLib.hasmodrights("zcustom_stI", "WORKFLOW", "SI000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/stI_list.aspx")%>">Internal Issue</a></li>
                        <%end if%>
                        <% if WebLib.hasmodrights("zcustom_stS", "WORKFLOW", "SS000") = True %>
                        <li><a class="dropdown-item" href="<%=WebLib.ClientURL("modules/custom/stS_list.aspx")%>">Support Issue</a></li> 
                        <%end if%>
                    </ul>
                </li>
                <%end If%>


                <% if WebLib.isStaff = True Then%>
                <% if WebLib.hasmodrights("salesqouta", "SALES", "SQ000") = True Or WebLib.hasmodrights("salestarget", "SALES", "SG000") = True Or
                    WebLib.hasmodrights("salesactcust", "SALES", "SA000") = True Or WebLib.hasmodrights("salescustlogin", "SALES", "SM000") = True Or
                    WebLib.hasmodrights("salespref", "SALES", "SP000") = True Or WebLib.hasmodrights("salesmaxqty", "SALES", "SX000") = True Or
                    WebLib.hasmodrights("sales", "SALES", "SA000") = True Or (WebLib.hasmodrights("npscore", "GENERAL", "NP000") = True) Or WebLib.hasmodrights("salescustmaintenance", "SALES", "SE000") = True Then%>

                <li class="nav-item"><a class="nav-link" href="<%=WebLib.ClientURL("custlist.aspx")%>"><i class="fa fa-group"></i><span> Customer Maintenance</span></a></li>
                
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
                        <i class="fa fa-gear "></i><span> System Settings</span>
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
                        <li class="dropdown-submenu"><a class="dropdown-item dropdown-toggle" href="#">Masterfiles</a>
                            <ul class="dropdown-menu">
                               
                                <li>
                                    <% if Weblib.hasmodrights("mstrcategory", "GENERAL", "CT000") = True %>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("deptlist.aspx")%>">Department</a>
                                    <a class="dropdown-item" href="<%=WebLib.ClientURL("codemstrlist.aspx")%>">Codemaster</a>
                                    <%end if %>
                                </li>
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
                        <%--<a class="dropdown-item" href="<%=WebLib.ClientURL("secuserinfoedit.aspx")%>">Profile</a>--%>
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

