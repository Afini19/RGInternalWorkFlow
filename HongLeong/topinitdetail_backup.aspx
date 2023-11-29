<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
<link rel="stylesheet" href="~/jquery/css/Cupertino/jquery.default.css">
<link rel="stylesheet" type="text/css" href="<%=WebLib.ClientURL("Styles/jquery-ui.theme.css")%>" />

<link rel="stylesheet" href="~/Styles/cssdefault.css">

<link href="~/plugins/menu3/css/skins/white.css" rel="stylesheet" type="text/css" />

<link rel="stylesheet" href="~/plugins/validator/css/validationEngine.jquery.css" type="text/css" />
<link rel="stylesheet" href="~/plugins/timepicker/jquery.ui.timepicker.css?v=0.3.3" type="text/css" />

<link rel="stylesheet" href="~/plugins/colorbox/colorbox.css" />

<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/responsive/2.0.2/css/responsive.dataTables.css" />
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />

<link rel="stylesheet" href="~/plugins/font-awesome/css/font-awesome.min.css">
<style type="text/css">
    .container-fluid {
        /*min-height: 90vh;*/
        position: relative;
        height: auto !important;
        min-height: 100% !important;
        /*min-height: 81.5vh !important;*/
        /*padding-top: 6em;*/
        overflow:auto;
    }

    .card-header {
        /* Extra small devices (portrait phones, less than 576px)*/
        @media (max-width: 575.98px) {
            .partOptionMenu{display:none}
        }
        /*Small devices (landscape phones, 576px and up)*/
        @media (min-width: 576px) and (max-width: 767.98px) {
            .partOptionMenu{display:none}            
        }
        /*Medium devices (tablets, 768px and up)*/
        @media (min-width: 768px) and (max-width: 991.98px) {
            .partOptionMenu{display:block}            
        }
        /*Large devices (desktops, 992px and up)*/
        @media (min-width: 992px) and (max-width: 1199.98px) {
            .partOptionMenu{display:block}            
        }
        /*Extra large devices (large desktops, 1200px and up)*/
        @media (min-width: 1200px) {
            .partOptionMenu{display:block}            
        }
    }
</style>

<script src="<%=ResolveClientUrl("~/jquery/js/jquery.js")%>"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="<%=ResolveClientUrl("~/jquery/js/jquery-ui.js")%>"></script>
<script src="<%=ResolveClientUrl("~/plugins/validator/languages/jquery.validationEngine-en.js")%>" type="text/javascript" charset="utf-8"></script>
<script src="<%=ResolveClientUrl("~/plugins/validator/jquery.validationEngine.js")%>" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript" src="<%=ResolveClientUrl("~/plugins/timepicker/jquery.ui.timepicker.js?v=0.3.3")%>"></script>
<script type='text/javascript' src='<%=ResolveClientUrl("~/plugins/menu3/js/jquery.hoverIntent.minified.js")%>'></script>
<script type='text/javascript' src='<%=ResolveClientUrl("~/plugins/menu3/js/jquery.dcmegamenu.1.2.js")%>'></script>
