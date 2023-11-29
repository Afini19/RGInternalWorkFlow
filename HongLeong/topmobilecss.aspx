    <style type="text/css">
        @media (max-width: 768px) {
            .adddet {
                display: none !important;
            }

            .btn2 {
                display: block !important;
            }
            .salesrightpanel {
                display: none !important;
            }
            .col-text-wrap{
                white-space:normal;
            }
            .col-width{
                // width:20%;
            }
        }
    </style>

<script type="text/javascript">
    $(window).resize(function () {

        if ($(this).width() >= 768) {
            $('#search').addClass("show");
	    $('#opt').addClass("show");
	    $('#pt').addClass("show");
	    $('#exp').addClass("show");
        };
        //if ($(this).width() < 768) {
        //    $('#opt').removeClass("show")
        //};
        // if ($(this).width() < 768) {
        //     $('#pt').removeClass("show")
        // };
        //if ($(this).width() < 768) {
         //   $('#exp').removeClass("show")
        //};
    });

    $(document).ready(function () {
        $(window).trigger('resize');
    });
</script>
